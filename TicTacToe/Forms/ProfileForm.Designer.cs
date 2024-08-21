namespace TicTacToe.Forms
{
	partial class ProfileForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileForm));
			this.labelBackgroundMenu = new System.Windows.Forms.Label();
			this.labelAvatar = new System.Windows.Forms.Label();
			this.labelBackgroundGame = new System.Windows.Forms.Label();
			this.flpBackgroundMenu = new System.Windows.Forms.FlowLayoutPanel();
			this.flpAvatar = new System.Windows.Forms.FlowLayoutPanel();
			this.flpBackgroundGame = new System.Windows.Forms.FlowLayoutPanel();
			this.guna2BorderlessForm = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
			this.buttonRename = new FontAwesome.Sharp.IconButton();
			this.textBoxPlayerName = new System.Windows.Forms.TextBox();
			this.pictureBoxPlayerAvatar = new System.Windows.Forms.PictureBox();
			this.tabControl = new Guna.UI2.WinForms.Guna2TabControl();
			this.tabPagePreferences = new System.Windows.Forms.TabPage();
			this.buttonPreferencesRight = new FontAwesome.Sharp.IconButton();
			this.buttonPreferencesLeft = new FontAwesome.Sharp.IconButton();
			this.panelMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayerAvatar)).BeginInit();
			this.tabControl.SuspendLayout();
			this.tabPagePreferences.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelBackgroundMenu
			// 
			this.labelBackgroundMenu.BackColor = System.Drawing.Color.Transparent;
			this.labelBackgroundMenu.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelBackgroundMenu.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelBackgroundMenu.ForeColor = System.Drawing.Color.White;
			this.labelBackgroundMenu.Location = new System.Drawing.Point(3, 3);
			this.labelBackgroundMenu.Name = "labelBackgroundMenu";
			this.labelBackgroundMenu.Size = new System.Drawing.Size(1106, 50);
			this.labelBackgroundMenu.TabIndex = 1;
			this.labelBackgroundMenu.Text = "Menu background";
			this.labelBackgroundMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelAvatar
			// 
			this.labelAvatar.BackColor = System.Drawing.Color.Transparent;
			this.labelAvatar.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelAvatar.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelAvatar.ForeColor = System.Drawing.Color.White;
			this.labelAvatar.Location = new System.Drawing.Point(3, 53);
			this.labelAvatar.Name = "labelAvatar";
			this.labelAvatar.Size = new System.Drawing.Size(1106, 50);
			this.labelAvatar.TabIndex = 2;
			this.labelAvatar.Text = "Avatar";
			this.labelAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labelAvatar.Visible = false;
			// 
			// labelBackgroundGame
			// 
			this.labelBackgroundGame.BackColor = System.Drawing.Color.Transparent;
			this.labelBackgroundGame.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelBackgroundGame.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelBackgroundGame.ForeColor = System.Drawing.Color.White;
			this.labelBackgroundGame.Location = new System.Drawing.Point(3, 103);
			this.labelBackgroundGame.Name = "labelBackgroundGame";
			this.labelBackgroundGame.Size = new System.Drawing.Size(1106, 50);
			this.labelBackgroundGame.TabIndex = 3;
			this.labelBackgroundGame.Text = "Game background";
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
			this.flpBackgroundMenu.Location = new System.Drawing.Point(216, 80);
			this.flpBackgroundMenu.Name = "flpBackgroundMenu";
			this.flpBackgroundMenu.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
			this.flpBackgroundMenu.Size = new System.Drawing.Size(680, 270);
			this.flpBackgroundMenu.TabIndex = 7;
			// 
			// flpAvatar
			// 
			this.flpAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flpAvatar.AutoScroll = true;
			this.flpAvatar.BackColor = System.Drawing.Color.Transparent;
			this.flpAvatar.Location = new System.Drawing.Point(216, 80);
			this.flpAvatar.Name = "flpAvatar";
			this.flpAvatar.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
			this.flpAvatar.Size = new System.Drawing.Size(680, 270);
			this.flpAvatar.TabIndex = 6;
			this.flpAvatar.Visible = false;
			// 
			// flpBackgroundGame
			// 
			this.flpBackgroundGame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flpBackgroundGame.AutoScroll = true;
			this.flpBackgroundGame.BackColor = System.Drawing.Color.Transparent;
			this.flpBackgroundGame.Location = new System.Drawing.Point(216, 80);
			this.flpBackgroundGame.Name = "flpBackgroundGame";
			this.flpBackgroundGame.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
			this.flpBackgroundGame.Size = new System.Drawing.Size(680, 270);
			this.flpBackgroundGame.TabIndex = 5;
			this.flpBackgroundGame.Visible = false;
			// 
			// guna2BorderlessForm
			// 
			this.guna2BorderlessForm.BorderRadius = 30;
			this.guna2BorderlessForm.ContainerControl = this;
			this.guna2BorderlessForm.DockIndicatorTransparencyValue = 0.6D;
			this.guna2BorderlessForm.DragForm = false;
			this.guna2BorderlessForm.ResizeForm = false;
			this.guna2BorderlessForm.TransparentWhileDrag = true;
			// 
			// panelMain
			// 
			this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelMain.BackColor = System.Drawing.Color.Transparent;
			this.panelMain.Controls.Add(this.buttonRename);
			this.panelMain.Controls.Add(this.textBoxPlayerName);
			this.panelMain.Controls.Add(this.pictureBoxPlayerAvatar);
			this.panelMain.Controls.Add(this.tabControl);
			this.panelMain.Location = new System.Drawing.Point(5, 0);
			this.panelMain.Margin = new System.Windows.Forms.Padding(5, 0, 5, 5);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(1120, 745);
			this.panelMain.TabIndex = 0;
			// 
			// buttonRename
			// 
			this.buttonRename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonRename.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonRename.FlatAppearance.BorderSize = 0;
			this.buttonRename.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRename.IconChar = FontAwesome.Sharp.IconChar.Pencil;
			this.buttonRename.IconColor = System.Drawing.Color.White;
			this.buttonRename.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.buttonRename.IconSize = 38;
			this.buttonRename.Location = new System.Drawing.Point(567, 9);
			this.buttonRename.Name = "buttonRename";
			this.buttonRename.Size = new System.Drawing.Size(41, 41);
			this.buttonRename.TabIndex = 2;
			this.buttonRename.TabStop = false;
			this.buttonRename.UseVisualStyleBackColor = false;
			this.buttonRename.Click += new System.EventHandler(this.ButtonChangeName_Click);
			// 
			// textBoxPlayerName
			// 
			this.textBoxPlayerName.BackColor = System.Drawing.Color.Black;
			this.textBoxPlayerName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxPlayerName.Font = new System.Drawing.Font("Trebuchet MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxPlayerName.ForeColor = System.Drawing.Color.White;
			this.textBoxPlayerName.Location = new System.Drawing.Point(211, 12);
			this.textBoxPlayerName.Name = "textBoxPlayerName";
			this.textBoxPlayerName.ReadOnly = true;
			this.textBoxPlayerName.Size = new System.Drawing.Size(350, 34);
			this.textBoxPlayerName.TabIndex = 1;
			this.textBoxPlayerName.Text = "AAAAAAAAAAAAAAAAAAAA";
			this.textBoxPlayerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxPlayerName_KeyDown);
			this.textBoxPlayerName.Leave += new System.EventHandler(this.TextBoxPlayerName_Leave);
			// 
			// pictureBoxPlayerAvatar
			// 
			this.pictureBoxPlayerAvatar.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxPlayerAvatar.Image = global::TicTacToe.Properties.Resources.legendaryAvatar1;
			this.pictureBoxPlayerAvatar.Location = new System.Drawing.Point(5, 5);
			this.pictureBoxPlayerAvatar.Name = "pictureBoxPlayerAvatar";
			this.pictureBoxPlayerAvatar.Size = new System.Drawing.Size(200, 200);
			this.pictureBoxPlayerAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxPlayerAvatar.TabIndex = 0;
			this.pictureBoxPlayerAvatar.TabStop = false;
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPagePreferences);
			this.tabControl.ItemSize = new System.Drawing.Size(400, 50);
			this.tabControl.Location = new System.Drawing.Point(0, 295);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(1120, 450);
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
			this.tabControl.TabIndex = 3;
			this.tabControl.TabMenuBackColor = System.Drawing.Color.Black;
			this.tabControl.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
			// 
			// tabPagePreferences
			// 
			this.tabPagePreferences.AutoScroll = true;
			this.tabPagePreferences.BackColor = System.Drawing.Color.Black;
			this.tabPagePreferences.Controls.Add(this.buttonPreferencesRight);
			this.tabPagePreferences.Controls.Add(this.buttonPreferencesLeft);
			this.tabPagePreferences.Controls.Add(this.labelBackgroundGame);
			this.tabPagePreferences.Controls.Add(this.labelAvatar);
			this.tabPagePreferences.Controls.Add(this.labelBackgroundMenu);
			this.tabPagePreferences.Controls.Add(this.flpBackgroundMenu);
			this.tabPagePreferences.Controls.Add(this.flpAvatar);
			this.tabPagePreferences.Controls.Add(this.flpBackgroundGame);
			this.tabPagePreferences.Cursor = System.Windows.Forms.Cursors.Default;
			this.tabPagePreferences.Location = new System.Drawing.Point(4, 54);
			this.tabPagePreferences.Name = "tabPagePreferences";
			this.tabPagePreferences.Padding = new System.Windows.Forms.Padding(3);
			this.tabPagePreferences.Size = new System.Drawing.Size(1112, 392);
			this.tabPagePreferences.TabIndex = 0;
			this.tabPagePreferences.Text = "Preferences";
			// 
			// buttonPreferencesRight
			// 
			this.buttonPreferencesRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonPreferencesRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonPreferencesRight.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonPreferencesRight.FlatAppearance.BorderSize = 0;
			this.buttonPreferencesRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonPreferencesRight.IconChar = FontAwesome.Sharp.IconChar.CircleArrowRight;
			this.buttonPreferencesRight.IconColor = System.Drawing.Color.White;
			this.buttonPreferencesRight.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.buttonPreferencesRight.IconSize = 45;
			this.buttonPreferencesRight.Location = new System.Drawing.Point(685, -25);
			this.buttonPreferencesRight.Name = "buttonPreferencesRight";
			this.buttonPreferencesRight.Size = new System.Drawing.Size(41, 41);
			this.buttonPreferencesRight.TabIndex = 4;
			this.buttonPreferencesRight.TabStop = false;
			this.buttonPreferencesRight.UseVisualStyleBackColor = false;
			this.buttonPreferencesRight.Click += new System.EventHandler(this.ButtonPreferencesRight_Click);
			// 
			// buttonPreferencesLeft
			// 
			this.buttonPreferencesLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.buttonPreferencesLeft.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonPreferencesLeft.FlatAppearance.BorderSize = 0;
			this.buttonPreferencesLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonPreferencesLeft.IconChar = FontAwesome.Sharp.IconChar.CircleArrowLeft;
			this.buttonPreferencesLeft.IconColor = System.Drawing.Color.White;
			this.buttonPreferencesLeft.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.buttonPreferencesLeft.IconSize = 45;
			this.buttonPreferencesLeft.Location = new System.Drawing.Point(380, -25);
			this.buttonPreferencesLeft.Name = "buttonPreferencesLeft";
			this.buttonPreferencesLeft.Size = new System.Drawing.Size(41, 41);
			this.buttonPreferencesLeft.TabIndex = 0;
			this.buttonPreferencesLeft.TabStop = false;
			this.buttonPreferencesLeft.UseVisualStyleBackColor = false;
			this.buttonPreferencesLeft.Click += new System.EventHandler(this.ButtonPreferencesLeft_Click);
			// 
			// ProfileForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.ClientSize = new System.Drawing.Size(1130, 750);
			this.Controls.Add(this.panelMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(1024, 700);
			this.Name = "ProfileForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Profile";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Shop_FormClosed);
			this.Load += new System.EventHandler(this.ProfileForm_Load);
			this.panelMain.ResumeLayout(false);
			this.panelMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayerAvatar)).EndInit();
			this.tabControl.ResumeLayout(false);
			this.tabPagePreferences.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Label labelBackgroundMenu;
		private System.Windows.Forms.Label labelAvatar;
		private System.Windows.Forms.Label labelBackgroundGame;
		private System.Windows.Forms.FlowLayoutPanel flpBackgroundMenu;
		private System.Windows.Forms.FlowLayoutPanel flpAvatar;
		private System.Windows.Forms.FlowLayoutPanel flpBackgroundGame;
		private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm;
		private Guna.UI2.WinForms.Guna2Panel panelMain;
		private Guna.UI2.WinForms.Guna2TabControl tabControl;
		private System.Windows.Forms.TabPage tabPagePreferences;
		private System.Windows.Forms.PictureBox pictureBoxPlayerAvatar;
		private System.Windows.Forms.TextBox textBoxPlayerName;
		private FontAwesome.Sharp.IconButton buttonRename;
		private FontAwesome.Sharp.IconButton buttonPreferencesLeft;
		private FontAwesome.Sharp.IconButton buttonPreferencesRight;
	}
}