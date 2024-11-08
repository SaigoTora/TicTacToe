using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

using TicTacToe.Models.GameClientServer;
using TicTacToe.Models.PlayerItem;

namespace TicTacToe.Models.Utilities.FormUtilities
{
	internal static class NetworkPlayerCreator
	{
		private const string ICON_PLAYER_STATUS_TAG = "IconPlayerStatus";
		private static readonly Color _panelBackColor = Color.FromArgb(50, 50, 50);

		internal static Guna2Panel CreatePlayerPanel(NetworkPlayer player, Size panelSize,
			Color? panelBackColor = null)
		{
			Guna2Panel panel = new Guna2Panel()
			{
				BackColor = _panelBackColor,
				Size = panelSize,
			};

			if (panelBackColor.HasValue)
				panel.BackColor = panelBackColor.Value;
			else
				panel.BackColor = _panelBackColor;

			PictureBox pictureBoxAvatar = CreatePlayerAvatarPictureBox(player.VisualSettings.Avatar);
			Label labelName = CreatePlayerNameLabel(player.Name);
			IconPictureBox iconPictureBoxReady = CreatePlayerCheckReady(player.IsReady);

			panel.Controls.Add(pictureBoxAvatar);
			panel.Controls.Add(labelName);
			panel.Controls.Add(iconPictureBoxReady);

			return panel;
		}
		internal static void ChangePlayerPanel(Guna2Panel panel, NetworkPlayer player)
		{
			foreach (Control control in panel.Controls)
				if (control is IconPictureBox icon)
					if (icon != null && icon.Tag != null
						&& icon.Tag.ToString() == ICON_PLAYER_STATUS_TAG)
						ChangePlayerCheckReady(icon, player.IsReady);
		}

		private static PictureBox CreatePlayerAvatarPictureBox(Avatar avatar)
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
		private static Label CreatePlayerNameLabel(string name)
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
		private static IconPictureBox CreatePlayerCheckReady(bool ready)
		{
			IconPictureBox iconPictureBox = new IconPictureBox()
			{
				Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
				BackColor = Color.Transparent,
				IconFont = IconFont.Auto,
				IconSize = 30,
				Location = new Point(213, 45),
				Size = new Size(30, 30),
				Tag = ICON_PLAYER_STATUS_TAG
			};
			ChangePlayerCheckReady(iconPictureBox, ready);

			return iconPictureBox;
		}
		private static void ChangePlayerCheckReady(IconPictureBox icon, bool ready)
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
	}
}