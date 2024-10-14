using FluentValidation.Results;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using TicTacToe.Forms.Game.Games3on3;
using TicTacToe.Forms.Game.Games5on5;
using TicTacToe.Forms.Game.Games7on7;
using TicTacToe.Forms.Game.NetworkGame;
using TicTacToe.Models.GameInfo;
using TicTacToe.Models.GameInfo.Settings;
using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.PlayerItem;
using TicTacToe.Models.PlayerItemCreator;
using TicTacToe.Models.Utilities.FormUtilities;
using TicTacToeLibrary;

namespace TicTacToe.Forms.Game
{
	internal partial class GameSettingsForm : BaseForm
	{
		internal enum GameType : byte
		{
			SinglePCGame,
			NetworkGame
		}

		private const int SELECTED_AVATAR_INDENT = 10;
		private const string SELECTED_AVATAR_TEXT = "Selected";
		private const string SELECTED_AVATAR_TAG = "ItemSelected";

		private static readonly (Color Default, Color Selected) _foreColorEnableButtons = (Color.Transparent, Color.Khaki);
		private static readonly (Color Default, Color Selected) _ColorFieldSize = (Color.Transparent, Color.Green);
		private static readonly (Color Default, Color DuringRenaming) _buttonChangeNameColor = (Color.White, Color.Yellow);

		private readonly MainForm _mainForm;
		private readonly StartNetworkGameForm _previousForm;
		private readonly Player _player;
		private readonly RoundManager _roundManager;
		private readonly GameType _gameType;

		private AvatarCreator _avatarCreator;
		private readonly List<PictureBox> _avatarPictureBoxes = new List<PictureBox>();
		private Image opponentAvatarImage;

		private readonly ButtonEventHandlers _buttonEventHandlers = new ButtonEventHandlers();
		private readonly LabelEventHandlers _labelEventHandlers = new LabelEventHandlers();

		private readonly Player _tempPlayer;
		private FieldSize _fieldSize;
		private bool _isTimerEnabled;
		private bool _isGameAssistsEnabled;

		internal GameSettingsForm(MainForm mainForm, Player player, RoundManager roundManager,
			GameType gameType, StartNetworkGameForm previousForm = null)
		{
			customTitleBar = new CustomTitleBar(this, "Game settings", minimizeBox: false, maximizeBox: false);
			InitializeComponent();
			_mainForm = mainForm;
			_previousForm = previousForm;
			_player = player;
			_roundManager = roundManager;
			_gameType = gameType;
			_tempPlayer = new Player(textBoxOpponentName.Text);

			SetFormElements(gameType);
			InitializeCreator();
			_buttonEventHandlers.SubscribeToHover(buttonPlay);
			_labelEventHandlers.SubscribeToHoverUnderline(label3on3, label5on5, label7on7);
		}
		private void GameSettingsForm_Load(object sender, EventArgs e)
		{
			TwoPlayersGameSettings settings = default;
			if (_gameType == GameType.SinglePCGame)
				settings = _player.SinglePCGameSettings;
			else if (_gameType == GameType.NetworkGame)
				settings = _player.NetworkGameSettings;
			string opponentName = settings.OpponentName;
			if (opponentName != null)
				textBoxOpponentName.Text = opponentName;
			textBoxOpponentName.MaxLength = PlayerValidator.MAX_NAME_LENGTH;
			textBoxOpponentName.BackColor = BackColor;
			CreateAvatars();

			Label labelFieldSize = GetLabelByFieldSize(settings.FieldSize);
			LabelFieldSize_Click(labelFieldSize, e);
			if (buttonTimerEnabled.Visible && settings.IsTimerEnabled)
				ButtonTimerEnabled_Click(this, EventArgs.Empty);
			if (buttonGameAssistsEnabled.Visible && settings.IsGameAssistsEnabled)
				ButtonGameAssistsEnabled_Click(this, EventArgs.Empty);
		}
		private void SetFormElements(GameType gameType)
		{
			const int NETWORK_GAME_FORM_HEIGHT_REDUCTION = 450;
			const int NETWORK_GAME_ENABLE_BUTTONS_OFFSET_X = 198;

			switch (gameType)
			{
				case GameType.SinglePCGame:
					buttonGameAssistsEnabled.Visible = false;
					break;
				case GameType.NetworkGame:
					{
						labelOpponentTitle.Visible = false;
						textBoxOpponentName.Visible = false;
						buttonChangeOpponentName.Visible = false;
						flpAvatar.Visible = false;
						buttonPlay.Text = "Create";
						Size = new Size(Width, Height - NETWORK_GAME_FORM_HEIGHT_REDUCTION);
						buttonTimerEnabled.Location = new Point(buttonTimerEnabled.Location.X +
							NETWORK_GAME_ENABLE_BUTTONS_OFFSET_X, buttonTimerEnabled.Location.Y);
						buttonGameAssistsEnabled.Location = new Point(buttonGameAssistsEnabled.Location.X +
							NETWORK_GAME_ENABLE_BUTTONS_OFFSET_X, buttonGameAssistsEnabled.Location.Y);
						break;
					}
				default:
					throw new InvalidOperationException
						($"Unknown game type: {gameType}");
			}
		}

		private void ButtonPlay_Click(object sender, EventArgs e)
		{
			switch (_gameType)
			{
				case GameType.SinglePCGame:
					ShowSinglePCGameForm();
					break;
				case GameType.NetworkGame:
					ShowNetworkGameForm();
					break;
				default:
					throw new InvalidOperationException
						($"Unknown game type: {_gameType}");
			}
			if (_previousForm != null)
			{
				_previousForm.NeedToOpenMainForm = false;
				_previousForm.Close();
			}
			Close();
		}
		private void ShowSinglePCGameForm()
		{
			BaseGameForm gameForm;
			switch (_fieldSize)
			{
				case FieldSize.Size3on3:
					gameForm = new Game3on3SinglePCForm(_mainForm, _player, _roundManager,
						CellType.Cross, _isTimerEnabled, opponentAvatarImage, textBoxOpponentName.Text);
					break;
				case FieldSize.Size5on5:
					gameForm = new Game5on5SinglePCForm(_mainForm, _player, _roundManager,
						CellType.Cross, _isTimerEnabled, opponentAvatarImage, textBoxOpponentName.Text);
					break;
				case FieldSize.Size7on7:
					gameForm = new Game7on7SinglePCForm(_mainForm, _player, _roundManager,
						CellType.Cross, _isTimerEnabled, opponentAvatarImage, textBoxOpponentName.Text);
					break;
				default:
					throw new InvalidOperationException
						($"Unknown field size: {_fieldSize}");
			}

			if (!gameForm.IsDisposed)// If a player have enough coints to play
			{
				_mainForm.Hide();
				gameForm.Show();
			}
		}
		private void ShowNetworkGameForm()
		{
			GameLobbyForm gameLobbyForm = new GameLobbyForm(_mainForm, _player);

			_mainForm.Hide();
			gameLobbyForm.Show();
		}

		#region Field Size
		private Label GetLabelByFieldSize(FieldSize fieldSize)
		{
			switch (fieldSize)
			{
				case FieldSize.Size3on3:
					return label3on3;
				case FieldSize.Size5on5:
					return label5on5;
				case FieldSize.Size7on7:
					return label7on7;
				default:
					throw new InvalidOperationException
						($"Unknown field size: {fieldSize}");
			}
		}
		private void LabelFieldSize_Click(object sender, EventArgs e)
		{
			if (!(sender is Label label))
				return;

			label.BackColor = _ColorFieldSize.Selected;
			label.Enabled = false;
			if (label == label3on3)
			{
				SetDefaultFieldSizeLabels(label5on5, label7on7);
				_fieldSize = FieldSize.Size3on3;
			}
			else if (label == label5on5)
			{
				SetDefaultFieldSizeLabels(label3on3, label7on7);
				_fieldSize = FieldSize.Size5on5;
			}
			else
			{
				SetDefaultFieldSizeLabels(label3on3, label5on5);
				_fieldSize = FieldSize.Size7on7;
			}

			if (_gameType == GameType.SinglePCGame)
				_player.SinglePCGameSettings.FieldSize = _fieldSize;
			else if (_gameType == GameType.NetworkGame)
				_player.NetworkGameSettings.FieldSize = _fieldSize;
		}
		private void SetDefaultFieldSizeLabels(params Label[] labels)
		{
			foreach (Label label in labels)
			{
				label.BackColor = _ColorFieldSize.Default;
				label.Enabled = true;
			}
		}
		#endregion

		#region Enable Buttons
		private void ButtonTimerEnabled_Click(object sender, EventArgs e)
		{
			ActiveControl = null;
			if (!_isTimerEnabled)
				SetActiveEnableButtonStyle(buttonTimerEnabled);
			else
				SetDefaultEnableButtonStyle(buttonTimerEnabled);

			_isTimerEnabled = !_isTimerEnabled;
			if (_gameType == GameType.SinglePCGame)
				_player.SinglePCGameSettings.IsTimerEnabled = _isTimerEnabled;
			else if (_gameType == GameType.NetworkGame)
				_player.NetworkGameSettings.IsTimerEnabled = _isTimerEnabled;
		}
		private void ButtonGameAssistsEnabled_Click(object sender, EventArgs e)
		{
			ActiveControl = null;
			if (!_isGameAssistsEnabled)
				SetActiveEnableButtonStyle(buttonGameAssistsEnabled);
			else
				SetDefaultEnableButtonStyle(buttonGameAssistsEnabled);

			_isGameAssistsEnabled = !_isGameAssistsEnabled;
			if (_gameType == GameType.SinglePCGame)
				_player.SinglePCGameSettings.IsGameAssistsEnabled = _isGameAssistsEnabled;
			else if (_gameType == GameType.NetworkGame)
				_player.NetworkGameSettings.IsGameAssistsEnabled = _isGameAssistsEnabled;
		}
		private void SetActiveEnableButtonStyle(IconButton button)
		{
			button.IconChar = IconChar.CircleCheck;
			button.IconColor = Color.Lime;
			button.ForeColor = Color.White;
		}
		private void SetDefaultEnableButtonStyle(IconButton button)
		{
			button.IconChar = IconChar.Circle;
			button.IconColor = Color.White;
			button.ForeColor = Color.White;
		}

		private void EnableButton_MouseEnter(object sender, EventArgs e)
		{
			if (!(sender is IconButton iconButton))
				return;

			if (_isTimerEnabled && iconButton == buttonTimerEnabled
				|| _isGameAssistsEnabled && iconButton == buttonGameAssistsEnabled)
				return;
			iconButton.ForeColor = _foreColorEnableButtons.Selected;
		}
		private void EnableButton_MouseLeave(object sender, EventArgs e)
		{
			if (!(sender is IconButton iconButton))
				return;

			iconButton.ForeColor = _foreColorEnableButtons.Default;
		}
		#endregion

		#region Change Second Player Name
		private void ButtonChangeOpponentName_Click(object sender, EventArgs e)
		{
			if (textBoxOpponentName.ReadOnly)
			{
				buttonChangeOpponentName.IconColor = _buttonChangeNameColor.DuringRenaming;
				textBoxOpponentName.ReadOnly = false;
				textBoxOpponentName.Focus();
				textBoxOpponentName.SelectAll();
			}
			else if (_tempPlayer.Name == textBoxOpponentName.Text)
			{
				buttonChangeOpponentName.IconColor = _buttonChangeNameColor.Default;
				textBoxOpponentName.ReadOnly = true;
				ActiveControl = null;
			}
		}

		private bool IsPlayerDataValid()
		{
			PlayerValidator validator = new PlayerValidator();

			Player newPlayer = new Player(textBoxOpponentName.Text);
			ValidationResult result = validator.Validate(newPlayer);
			if (!result.IsValid)
			{
				CustomMessageBox.Show(result.Errors[0].ErrorMessage, "Invalid input", CustomMessageBoxButtons.OK, CustomMessageBoxIcon.Error);
				return false;
			}
			else
				return true;
		}
		private void TryToChangeName()
		{
			if (textBoxOpponentName.ReadOnly)
				return;

			if (IsPlayerDataValid())
			{
				textBoxOpponentName.ReadOnly = true;
				ActiveControl = null;
				buttonChangeOpponentName.IconColor = _buttonChangeNameColor.Default;
				if (_tempPlayer.Name != textBoxOpponentName.Text)
				{
					_player.SinglePCGameSettings.OpponentName = textBoxOpponentName.Text;
					CustomMessageBox.Show("The second player's nickname has been successfully changed.", "Success",
						CustomMessageBoxButtons.OK, CustomMessageBoxIcon.OK);
				}
			}
			else
				textBoxOpponentName.Focus();
		}

		private void TextBoxOpponentName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				TryToChangeName();
		}
		private void TextBoxOpponentName_Leave(object sender, EventArgs e)
			=> TryToChangeName();
		#endregion

		#region Change Second Player Avatar
		private void InitializeCreator()
		{
			const int ITEM_SIZE = 100;

			_avatarCreator = new AvatarCreator(_player, flpAvatar, ITEM_SIZE);
			ManageItemCreatorEvents(true);
		}
		private void ManageItemCreatorEvents(bool subscribe)
		{
			if (subscribe)
				_avatarCreator.Click += SelectAvatar;
			else
				_avatarCreator.Click -= SelectAvatar;
		}

		private void CreateAvatars()
		{
			Avatar opponentAvatar = _player.SinglePCGameSettings.OpponentAvatar;

			foreach (Item item in _player.ItemsInventory.GetItems())
				if (item is Avatar avatar && item.Name != _player.VisualSettings.Avatar.Name)
				{
					PictureBox pictureBox = _avatarCreator.CreateItemToSelect(avatar);

					if (_avatarPictureBoxes.Count == 0)
						if (opponentAvatar == null
							|| _player.VisualSettings.Avatar.Name == opponentAvatar.Name)
							SelectAvatar(this, new ItemEventArgs(avatar, pictureBox));
					if (opponentAvatar != null && opponentAvatar.Name != null
						&& item.Name == opponentAvatar.Name)
						SelectAvatar(this, new ItemEventArgs(avatar, pictureBox));

					_avatarPictureBoxes.Add(pictureBox);
				}
		}
		private void SelectAvatar(object sender, ItemEventArgs e)
		{
			if (!(e.ClickableControl is PictureBox selectedPicture))
				return;

			DeselectPreviousItem(_avatarPictureBoxes);
			DefaultSelect(selectedPicture);
			opponentAvatarImage = selectedPicture.Image;
			_player.SinglePCGameSettings.OpponentAvatar =
				(Avatar)ItemManager.GetFullItem(e.Item);
		}
		private void DeselectPreviousItem(List<PictureBox> list)
		{
			foreach (PictureBox picture in list)
				if (picture.Tag != null && picture.Tag.ToString() == SELECTED_AVATAR_TAG)
				{
					DefaultDeselect(picture);
					break;
				}
		}
		private void DefaultSelect(PictureBox pictureBox)
		{
			pictureBox.Tag = SELECTED_AVATAR_TAG;
			pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y - SELECTED_AVATAR_INDENT);
			pictureBox.Enabled = false;
			CreateSelectionLabel(pictureBox.Parent);
		}
		private void DefaultDeselect(PictureBox pictureBox)
		{
			pictureBox.Tag = string.Empty;
			pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y + SELECTED_AVATAR_INDENT);
			pictureBox.Enabled = true;
			DeleteSelectionLabel(pictureBox.Parent);
		}
		private void CreateSelectionLabel(Control parent)
		{
			Color foreColor = Color.Yellow;

			new Label
			{
				Parent = parent,
				Text = SELECTED_AVATAR_TEXT,
				ForeColor = foreColor,
				Dock = DockStyle.Bottom,
				TextAlign = ContentAlignment.MiddleCenter,
				Font = new Font("Trebuchet MS", 10F, FontStyle.Bold),
				Size = new Size(0, SELECTED_AVATAR_INDENT * 2)
			};
		}
		private void DeleteSelectionLabel(Control parent)
		{
			var labelToRemove = parent.Controls.OfType<Label>().FirstOrDefault(lbl => lbl.Text == SELECTED_AVATAR_TEXT);
			labelToRemove?.Dispose();
		}
		#endregion

		private void GameSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			_buttonEventHandlers.UnsubscribeAll();
			_labelEventHandlers.UnsubscribeAll();
			ManageItemCreatorEvents(false);

			_avatarCreator?.Dispose();
		}
	}
}