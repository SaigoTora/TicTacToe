using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using TicTacToe.Models.PlayerInfo;
using TicTacToe.Models.PlayerItemCreator;

namespace TicTacToe.Forms.ItemManagement
{
	internal partial class ItemManagementForm : BaseForm
	{
		private readonly (Color Default, Color Hover) _buttonPreferenceNavigation = (Color.Transparent, Color.FromArgb(125, 35, 35, 35));

		protected readonly Player player;

		protected ImageCreator menuBackCreator;
		protected AvatarCreator avatarCreator;
		protected ColorCreator gameBackCreator;
		protected ImageCreator gameAssistantsCreator;

		protected List<(Label label, FlowLayoutPanel flp)> preferences;
		private int _preferenceIndex = 0;

		private ItemManagementForm()
		{ InitializeComponent(); }
		internal ItemManagementForm(Player player)
		{
			InitializeComponent();

			this.player = player;
		}

		#region Change preference navigation
		protected void SubscribeToNavigationButtonEvents(IconButton buttonLeft, IconButton buttonRight)
		{
			buttonLeft.Click += ButtonPreferencesLeft_Click;
			buttonLeft.MouseEnter += ButtonPreferenceNavigation_MouseEnter;
			buttonLeft.MouseLeave += ButtonPreferenceNavigation_MouseLeave;

			buttonRight.Click += ButtonPreferencesRight_Click;
			buttonRight.MouseEnter += ButtonPreferenceNavigation_MouseEnter;
			buttonRight.MouseLeave += ButtonPreferenceNavigation_MouseLeave;
		}
		protected void UnsubscribeFromNavigationButtonEvents(IconButton buttonLeft, IconButton buttonRight)
		{
			buttonLeft.Click -= ButtonPreferencesLeft_Click;
			buttonLeft.MouseEnter -= ButtonPreferenceNavigation_MouseEnter;
			buttonLeft.MouseLeave -= ButtonPreferenceNavigation_MouseLeave;

			buttonRight.Click -= ButtonPreferencesRight_Click;
			buttonRight.MouseEnter -= ButtonPreferenceNavigation_MouseEnter;
			buttonRight.MouseLeave -= ButtonPreferenceNavigation_MouseLeave;
		}

		private void ButtonPreferencesLeft_Click(object sender, EventArgs e)
		{
			ActiveControl = null;

			_preferenceIndex--;

			if (_preferenceIndex < 0)
				_preferenceIndex = preferences.Count - 1;

			SetPreferenceVisibility(_preferenceIndex);
		}
		private void ButtonPreferencesRight_Click(object sender, EventArgs e)
		{
			ActiveControl = null;

			_preferenceIndex++;

			if (_preferenceIndex >= preferences.Count)
				_preferenceIndex = 0;

			SetPreferenceVisibility(_preferenceIndex);
		}
		private void SetPreferenceVisibility(int index)
		{
			for (int i = 0; i < preferences.Count; i++)
			{
				preferences[i].label.Visible = (i == index);
				preferences[i].flp.Visible = (i == index);
			}
		}

		private void ButtonPreferenceNavigation_MouseEnter(object sender, EventArgs e)
		{
			if (sender is IconButton button)
				button.BackColor = _buttonPreferenceNavigation.Hover;
		}
		private void ButtonPreferenceNavigation_MouseLeave(object sender, EventArgs e)
		{
			if (sender is IconButton button)
				button.BackColor = _buttonPreferenceNavigation.Default;
		}
		#endregion

		protected void ItemManagementForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Visible = false;
			menuBackCreator?.Dispose();
			avatarCreator?.Dispose();
			gameBackCreator?.Dispose();
			gameAssistantsCreator?.Dispose();
		}
	}
}