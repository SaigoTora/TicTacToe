namespace TicTacToe.Forms
{
	partial class ShopForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabControl = new Guna.UI2.WinForms.Guna2TabControl();
			this.tabPagePreferences = new System.Windows.Forms.TabPage();
			this.panelPreferenceNavigation = new Guna.UI2.WinForms.Guna2Panel();
			this.buttonPreferencesLeft = new FontAwesome.Sharp.IconButton();
			this.buttonPreferencesRight = new FontAwesome.Sharp.IconButton();
			this.labelBackgroundMenu = new System.Windows.Forms.Label();
			this.labelAvatar = new System.Windows.Forms.Label();
			this.labelBackgroundGame = new System.Windows.Forms.Label();
			this.flpBackgroundMenu = new System.Windows.Forms.FlowLayoutPanel();
			this.flpAvatar = new System.Windows.Forms.FlowLayoutPanel();
			this.flpBackgroundGame = new System.Windows.Forms.FlowLayoutPanel();
			this.pictureBoxCoin = new System.Windows.Forms.PictureBox();
			this.labelCoins = new System.Windows.Forms.Label();
			this.tabControl.SuspendLayout();
			this.tabPagePreferences.SuspendLayout();
			this.panelPreferenceNavigation.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoin)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPagePreferences);
			this.tabControl.ItemSize = new System.Drawing.Size(400, 50);
			this.tabControl.Location = new System.Drawing.Point(0, 300);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(1200, 520);
			this.tabControl.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
			this.tabControl.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
			this.tabControl.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
			this.tabControl.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
			this.tabControl.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
			this.tabControl.TabButtonIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
			this.tabControl.TabButtonIdleState.FillColor = System.Drawing.Color.Black;
			this.tabControl.TabButtonIdleState.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabControl.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
			this.tabControl.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
			this.tabControl.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
			this.tabControl.TabButtonSelectedState.FillColor = System.Drawing.Color.Black;
			this.tabControl.TabButtonSelectedState.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabControl.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
			this.tabControl.TabButtonSelectedState.InnerColor = System.Drawing.Color.SteelBlue;
			this.tabControl.TabButtonSize = new System.Drawing.Size(400, 50);
			this.tabControl.TabIndex = 4;
			this.tabControl.TabMenuBackColor = System.Drawing.Color.Black;
			this.tabControl.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
			// 
			// tabPagePreferences
			// 
			this.tabPagePreferences.AutoScroll = true;
			this.tabPagePreferences.BackColor = System.Drawing.Color.Black;
			this.tabPagePreferences.Controls.Add(this.panelPreferenceNavigation);
			this.tabPagePreferences.Controls.Add(this.flpBackgroundMenu);
			this.tabPagePreferences.Controls.Add(this.flpAvatar);
			this.tabPagePreferences.Controls.Add(this.flpBackgroundGame);
			this.tabPagePreferences.Cursor = System.Windows.Forms.Cursors.Default;
			this.tabPagePreferences.Location = new System.Drawing.Point(4, 54);
			this.tabPagePreferences.Name = "tabPagePreferences";
			this.tabPagePreferences.Padding = new System.Windows.Forms.Padding(3);
			this.tabPagePreferences.Size = new System.Drawing.Size(1192, 462);
			this.tabPagePreferences.TabIndex = 0;
			this.tabPagePreferences.Text = "Design Elements";
			// 
			// panelPreferenceNavigation
			// 
			this.panelPreferenceNavigation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelPreferenceNavigation.BackColor = System.Drawing.Color.Transparent;
			this.panelPreferenceNavigation.Controls.Add(this.buttonPreferencesLeft);
			this.panelPreferenceNavigation.Controls.Add(this.buttonPreferencesRight);
			this.panelPreferenceNavigation.Controls.Add(this.labelBackgroundMenu);
			this.panelPreferenceNavigation.Controls.Add(this.labelAvatar);
			this.panelPreferenceNavigation.Controls.Add(this.labelBackgroundGame);
			this.panelPreferenceNavigation.Location = new System.Drawing.Point(361, 12);
			this.panelPreferenceNavigation.Name = "panelPreferenceNavigation";
			this.panelPreferenceNavigation.Size = new System.Drawing.Size(470, 50);
			this.panelPreferenceNavigation.TabIndex = 0;
			// 
			// buttonPreferencesLeft
			// 
			this.buttonPreferencesLeft.BackColor = System.Drawing.Color.Transparent;
			this.buttonPreferencesLeft.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonPreferencesLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.buttonPreferencesLeft.FlatAppearance.BorderSize = 0;
			this.buttonPreferencesLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonPreferencesLeft.IconChar = FontAwesome.Sharp.IconChar.CircleArrowLeft;
			this.buttonPreferencesLeft.IconColor = System.Drawing.Color.White;
			this.buttonPreferencesLeft.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.buttonPreferencesLeft.Location = new System.Drawing.Point(0, 0);
			this.buttonPreferencesLeft.Name = "buttonPreferencesLeft";
			this.buttonPreferencesLeft.Size = new System.Drawing.Size(50, 50);
			this.buttonPreferencesLeft.TabIndex = 0;
			this.buttonPreferencesLeft.TabStop = false;
			this.buttonPreferencesLeft.UseVisualStyleBackColor = false;
			// 
			// buttonPreferencesRight
			// 
			this.buttonPreferencesRight.BackColor = System.Drawing.Color.Transparent;
			this.buttonPreferencesRight.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonPreferencesRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.buttonPreferencesRight.FlatAppearance.BorderSize = 0;
			this.buttonPreferencesRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonPreferencesRight.IconChar = FontAwesome.Sharp.IconChar.CircleArrowRight;
			this.buttonPreferencesRight.IconColor = System.Drawing.Color.White;
			this.buttonPreferencesRight.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.buttonPreferencesRight.Location = new System.Drawing.Point(420, 0);
			this.buttonPreferencesRight.Name = "buttonPreferencesRight";
			this.buttonPreferencesRight.Size = new System.Drawing.Size(50, 50);
			this.buttonPreferencesRight.TabIndex = 4;
			this.buttonPreferencesRight.TabStop = false;
			this.buttonPreferencesRight.UseVisualStyleBackColor = false;
			// 
			// labelBackgroundMenu
			// 
			this.labelBackgroundMenu.BackColor = System.Drawing.Color.Transparent;
			this.labelBackgroundMenu.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelBackgroundMenu.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelBackgroundMenu.ForeColor = System.Drawing.Color.White;
			this.labelBackgroundMenu.Location = new System.Drawing.Point(0, 0);
			this.labelBackgroundMenu.Name = "labelBackgroundMenu";
			this.labelBackgroundMenu.Size = new System.Drawing.Size(470, 50);
			this.labelBackgroundMenu.TabIndex = 1;
			this.labelBackgroundMenu.Text = "Menu Background";
			this.labelBackgroundMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelAvatar
			// 
			this.labelAvatar.BackColor = System.Drawing.Color.Transparent;
			this.labelAvatar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelAvatar.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelAvatar.ForeColor = System.Drawing.Color.White;
			this.labelAvatar.Location = new System.Drawing.Point(0, 0);
			this.labelAvatar.Name = "labelAvatar";
			this.labelAvatar.Size = new System.Drawing.Size(470, 50);
			this.labelAvatar.TabIndex = 2;
			this.labelAvatar.Text = "Avatar";
			this.labelAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labelAvatar.Visible = false;
			// 
			// labelBackgroundGame
			// 
			this.labelBackgroundGame.BackColor = System.Drawing.Color.Transparent;
			this.labelBackgroundGame.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelBackgroundGame.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelBackgroundGame.ForeColor = System.Drawing.Color.White;
			this.labelBackgroundGame.Location = new System.Drawing.Point(0, 0);
			this.labelBackgroundGame.Name = "labelBackgroundGame";
			this.labelBackgroundGame.Size = new System.Drawing.Size(470, 50);
			this.labelBackgroundGame.TabIndex = 3;
			this.labelBackgroundGame.Text = "Game Background";
			this.labelBackgroundGame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labelBackgroundGame.Visible = false;
			// 
			// flpBackgroundMenu
			// 
			this.flpBackgroundMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flpBackgroundMenu.AutoScroll = true;
			this.flpBackgroundMenu.BackColor = System.Drawing.Color.Transparent;
			this.flpBackgroundMenu.Location = new System.Drawing.Point(249, 80);
			this.flpBackgroundMenu.Name = "flpBackgroundMenu";
			this.flpBackgroundMenu.Padding = new System.Windows.Forms.Padding(40, 10, 0, 0);
			this.flpBackgroundMenu.Size = new System.Drawing.Size(700, 340);
			this.flpBackgroundMenu.TabIndex = 1;
			// 
			// flpAvatar
			// 
			this.flpAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flpAvatar.AutoScroll = true;
			this.flpAvatar.BackColor = System.Drawing.Color.Transparent;
			this.flpAvatar.Location = new System.Drawing.Point(249, 80);
			this.flpAvatar.Name = "flpAvatar";
			this.flpAvatar.Padding = new System.Windows.Forms.Padding(40, 10, 0, 0);
			this.flpAvatar.Size = new System.Drawing.Size(700, 340);
			this.flpAvatar.TabIndex = 2;
			this.flpAvatar.Visible = false;
			// 
			// flpBackgroundGame
			// 
			this.flpBackgroundGame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flpBackgroundGame.AutoScroll = true;
			this.flpBackgroundGame.BackColor = System.Drawing.Color.Transparent;
			this.flpBackgroundGame.Location = new System.Drawing.Point(249, 80);
			this.flpBackgroundGame.Name = "flpBackgroundGame";
			this.flpBackgroundGame.Padding = new System.Windows.Forms.Padding(40, 10, 0, 0);
			this.flpBackgroundGame.Size = new System.Drawing.Size(700, 340);
			this.flpBackgroundGame.TabIndex = 3;
			this.flpBackgroundGame.Visible = false;
			// 
			// pictureBoxCoin
			// 
			this.pictureBoxCoin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxCoin.Image = global::TicTacToe.Properties.Resources.coin;
			this.pictureBoxCoin.Location = new System.Drawing.Point(1155, 0);
			this.pictureBoxCoin.Name = "pictureBoxCoin";
			this.pictureBoxCoin.Size = new System.Drawing.Size(42, 42);
			this.pictureBoxCoin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxCoin.TabIndex = 6;
			this.pictureBoxCoin.TabStop = false;
			// 
			// labelCoins
			// 
			this.labelCoins.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCoins.BackColor = System.Drawing.Color.Transparent;
			this.labelCoins.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCoins.ForeColor = System.Drawing.Color.Khaki;
			this.labelCoins.Location = new System.Drawing.Point(1021, 8);
			this.labelCoins.Name = "labelCoins";
			this.labelCoins.Size = new System.Drawing.Size(130, 27);
			this.labelCoins.TabIndex = 5;
			this.labelCoins.Text = "999 999";
			this.labelCoins.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ShopForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1200, 820);
			this.Controls.Add(this.pictureBoxCoin);
			this.Controls.Add(this.labelCoins);
			this.Controls.Add(this.tabControl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(1076, 786);
			this.Name = "ShopForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Shop";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Shop_FormClosed);
			this.Load += new System.EventHandler(this.ShopForm_Load);
			this.tabControl.ResumeLayout(false);
			this.tabPagePreferences.ResumeLayout(false);
			this.panelPreferenceNavigation.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoin)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private Guna.UI2.WinForms.Guna2TabControl tabControl;
		private System.Windows.Forms.TabPage tabPagePreferences;
		private Guna.UI2.WinForms.Guna2Panel panelPreferenceNavigation;
		private FontAwesome.Sharp.IconButton buttonPreferencesLeft;
		private FontAwesome.Sharp.IconButton buttonPreferencesRight;
		private System.Windows.Forms.Label labelBackgroundMenu;
		private System.Windows.Forms.Label labelAvatar;
		private System.Windows.Forms.Label labelBackgroundGame;
		private System.Windows.Forms.FlowLayoutPanel flpBackgroundMenu;
		private System.Windows.Forms.FlowLayoutPanel flpAvatar;
		private System.Windows.Forms.FlowLayoutPanel flpBackgroundGame;
		private System.Windows.Forms.PictureBox pictureBoxCoin;
		private System.Windows.Forms.Label labelCoins;
	}
}