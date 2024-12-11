using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using TicTacToe.Models.GameClientServer.Lobby;
using TicTacToe.Models.PlayerItem;

namespace TicTacToe.Models.Utilities.FormUtilities
{
	internal class NetworkPlayerCreator
	{
		private const string ICON_PLAYER_STATUS_TAG = "IconPlayerStatus";

		private readonly Size _panelSize;
		private readonly Color? _panelBackColor = Color.FromArgb(50, 50, 50);
		private readonly EventHandler _kickButtonClickHandler;

		private readonly List<(Guna2Panel, IconButton)> _createdItems = new List<(Guna2Panel, IconButton)>(2);

		internal NetworkPlayerCreator(Size panelSize, EventHandler kickButtonClickHandler, Color? panelBackColor = null)
			: this(panelSize, panelBackColor)
			=> _kickButtonClickHandler = kickButtonClickHandler;
		internal NetworkPlayerCreator(Size panelSize, Color? panelBackColor = null)
		{
			_panelSize = panelSize;
			if (panelBackColor.HasValue)
				_panelBackColor = panelBackColor.Value;
		}

		internal Guna2Panel CreatePlayerPanel(NetworkPlayer player, bool needToCreateKickButton)
		{
			Guna2Panel panel = new Guna2Panel()
			{
				BackColor = _panelBackColor.Value,
				Size = _panelSize,
			};

			panel.BackColor = _panelBackColor.Value;

			PictureBox pictureBoxAvatar = CreatePlayerAvatarPictureBox(player.VisualSettings.Avatar);
			Label labelName = CreatePlayerNameLabel(player.Name);
			IconPictureBox iconPictureBoxReady = CreatePlayerCheckReady(player.IsReady, _panelSize);

			panel.Controls.Add(pictureBoxAvatar);
			panel.Controls.Add(labelName);
			panel.Controls.Add(iconPictureBoxReady);

			IconButton kickButton = null;
			if (needToCreateKickButton && _kickButtonClickHandler != null)
			{
				kickButton = CreateKickButton(panel);
				kickButton.Click += _kickButtonClickHandler;
				panel.Controls.Add(kickButton);
			}
			_createdItems.Add((panel, kickButton));

			return panel;
		}
		internal void ChangePlayerPanel(Guna2Panel panel, NetworkPlayer player)
		{
			foreach (Control control in panel.Controls)
				if (control is IconPictureBox icon)
					if (icon != null && icon.Tag != null
						&& icon.Tag.ToString() == ICON_PLAYER_STATUS_TAG)
						ChangePlayerCheckReady(icon, player.IsReady);
		}

		private PictureBox CreatePlayerAvatarPictureBox(Avatar avatar)
		{
			PictureBox pictureBox = new PictureBox()
			{
				Image = avatar.Image,
				BackColor = Color.Transparent,
				Location = new Point(3, 3),
				Size = new Size(70, 70),
				SizeMode = PictureBoxSizeMode.Zoom,
			};

			return pictureBox;
		}
		private Label CreatePlayerNameLabel(string name)
		{
			Label label = new Label()
			{
				Text = name,
				BackColor = Color.Transparent,
				FlatStyle = FlatStyle.Flat,
				Font = new Font("Trebuchet MS", 10F, FontStyle.Bold),
				ForeColor = Color.White,
				Location = new Point(74, 3),
				AutoSize = false,
				Size = new Size(167, 36),
				TextAlign = ContentAlignment.MiddleLeft,
			};

			return label;
		}
		private IconPictureBox CreatePlayerCheckReady(bool ready, Size parentPanelSize)
		{
			IconPictureBox iconReady = new IconPictureBox()
			{
				BackColor = Color.Transparent,
				IconFont = IconFont.Auto,
				IconSize = 33,
				Size = new Size(33, 33),
				Tag = ICON_PLAYER_STATUS_TAG
			};
			iconReady.Location = new Point(parentPanelSize.Width - iconReady.Size.Width,
				parentPanelSize.Height - iconReady.Size.Height);
			ChangePlayerCheckReady(iconReady, ready);

			return iconReady;
		}
		private IconButton CreateKickButton(Guna2Panel parentPanel)
		{
			IconButton button = new IconButton()
			{
				BackColor = Color.FromArgb(0, parentPanel.BackColor),
				IconFont = IconFont.Auto,
				IconSize = 30,
				Size = new Size(33, 33),
				IconChar = IconChar.UserSlash,
				IconColor = Color.FromArgb(127, 24, 13),
				Cursor = Cursors.Hand,
				FlatStyle = FlatStyle.Flat,
				TabStop = false
			};
			button.Location = new Point(parentPanel.Width - (2 * button.Size.Width) - 3,
				parentPanel.Height - button.Size.Height);
			button.FlatAppearance.BorderSize = 0;

			return button;
		}
		private void ChangePlayerCheckReady(IconPictureBox icon, bool ready)
		{
			if (ready)
			{
				icon.IconChar = IconChar.CircleCheck;
				icon.IconColor = Color.Lime;
			}
			else
			{
				icon.IconChar = IconChar.Circle;
				icon.IconColor = Color.Gold;
			}
		}

		internal void Dispose(Guna2Panel panel)
		{
			var item = _createdItems.FirstOrDefault((i) => i.Item1 == panel);
			item.Item1?.Dispose();
			if (item.Item2 != null)
				item.Item2.Click -= _kickButtonClickHandler;
			_createdItems.Remove(item);
		}
		internal void Dispose()
		{
			foreach (var item in _createdItems)
			{
				item.Item1?.Dispose();
				if (item.Item2 != null)
					item.Item2.Click -= _kickButtonClickHandler;
			}
			_createdItems?.Clear();
		}
	}
}