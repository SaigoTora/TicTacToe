namespace TicTacToe.Forms
{
	partial class MainForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.labelAuthor = new System.Windows.Forms.Label();
			this.labelDifficult = new System.Windows.Forms.Label();
			this.labelNumberOfRounds = new System.Windows.Forms.Label();
			this.labelCoins = new System.Windows.Forms.Label();
			this.panelLeft = new Guna.UI2.WinForms.Guna2Panel();
			this.panelMenu = new Guna.UI2.WinForms.Guna2Panel();
			this.buttonPlay = new Guna.UI2.WinForms.Guna2GradientButton();
			this.buttonExit = new Guna.UI2.WinForms.Guna2GradientButton();
			this.buttonShop = new Guna.UI2.WinForms.Guna2GradientButton();
			this.buttonProfile = new Guna.UI2.WinForms.Guna2GradientButton();
			this.panelProfile = new Guna.UI2.WinForms.Guna2Panel();
			this.labelPlayerName = new System.Windows.Forms.Label();
			this.pictureBoxAvatar = new System.Windows.Forms.PictureBox();
			this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
			this.pictureBoxCoin = new System.Windows.Forms.PictureBox();
			this.panelSettingsMain = new Guna.UI2.WinForms.Guna2Panel();
			this.panelSettingsRight = new Guna.UI2.WinForms.Guna2Panel();
			this.buttonShowSettings = new FontAwesome.Sharp.IconButton();
			this.panelSettings = new Guna.UI2.WinForms.Guna2Panel();
			this.buttonImpossible = new FontAwesome.Sharp.IconButton();
			this.buttonHard = new FontAwesome.Sharp.IconButton();
			this.buttonMedium = new FontAwesome.Sharp.IconButton();
			this.buttonEasy = new FontAwesome.Sharp.IconButton();
			this.numericUpDownNumberOfRounds = new System.Windows.Forms.NumericUpDown();
			this.guna2BorderlessForm = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.panelLeft.SuspendLayout();
			this.panelMenu.SuspendLayout();
			this.panelProfile.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
			this.panelMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoin)).BeginInit();
			this.panelSettingsMain.SuspendLayout();
			this.panelSettingsRight.SuspendLayout();
			this.panelSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfRounds)).BeginInit();
			this.SuspendLayout();
			// 
			// labelAuthor
			// 
			this.labelAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.labelAuthor.AutoSize = true;
			this.labelAuthor.BackColor = System.Drawing.Color.Transparent;
			this.labelAuthor.Font = new System.Drawing.Font("Lobster", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelAuthor.ForeColor = System.Drawing.Color.Silver;
			this.labelAuthor.Location = new System.Drawing.Point(961, 713);
			this.labelAuthor.Name = "labelAuthor";
			this.labelAuthor.Size = new System.Drawing.Size(152, 28);
			this.labelAuthor.TabIndex = 5;
			this.labelAuthor.Text = "Author: SaigoTora";
			// 
			// labelDifficult
			// 
			this.labelDifficult.AutoSize = true;
			this.labelDifficult.BackColor = System.Drawing.Color.Transparent;
			this.labelDifficult.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDifficult.ForeColor = System.Drawing.Color.White;
			this.labelDifficult.Location = new System.Drawing.Point(12, -15);
			this.labelDifficult.Name = "labelDifficult";
			this.labelDifficult.Size = new System.Drawing.Size(195, 29);
			this.labelDifficult.TabIndex = 0;
			this.labelDifficult.Text = "Select difficulty:";
			// 
			// labelNumberOfRounds
			// 
			this.labelNumberOfRounds.AutoSize = true;
			this.labelNumberOfRounds.BackColor = System.Drawing.Color.Transparent;
			this.labelNumberOfRounds.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelNumberOfRounds.ForeColor = System.Drawing.Color.White;
			this.labelNumberOfRounds.Location = new System.Drawing.Point(12, 200);
			this.labelNumberOfRounds.Name = "labelNumberOfRounds";
			this.labelNumberOfRounds.Size = new System.Drawing.Size(212, 29);
			this.labelNumberOfRounds.TabIndex = 4;
			this.labelNumberOfRounds.Text = "Number of rounds:";
			// 
			// labelCoins
			// 
			this.labelCoins.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCoins.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.labelCoins.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCoins.ForeColor = System.Drawing.Color.Khaki;
			this.labelCoins.Location = new System.Drawing.Point(955, 8);
			this.labelCoins.Name = "labelCoins";
			this.labelCoins.Size = new System.Drawing.Size(116, 27);
			this.labelCoins.TabIndex = 3;
			this.labelCoins.Text = "999 999";
			this.labelCoins.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panelLeft
			// 
			this.panelLeft.Controls.Add(this.panelMenu);
			this.panelLeft.Controls.Add(this.panelProfile);
			this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelLeft.Location = new System.Drawing.Point(0, 0);
			this.panelLeft.Name = "panelLeft";
			this.panelLeft.Size = new System.Drawing.Size(320, 745);
			this.panelLeft.TabIndex = 1;
			// 
			// panelMenu
			// 
			this.panelMenu.Controls.Add(this.buttonPlay);
			this.panelMenu.Controls.Add(this.buttonExit);
			this.panelMenu.Controls.Add(this.buttonShop);
			this.panelMenu.Controls.Add(this.buttonProfile);
			this.panelMenu.CustomBorderColor = System.Drawing.Color.Black;
			this.panelMenu.CustomBorderThickness = new System.Windows.Forms.Padding(0, 2, 3, 0);
			this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMenu.Location = new System.Drawing.Point(0, 220);
			this.panelMenu.Name = "panelMenu";
			this.panelMenu.Size = new System.Drawing.Size(320, 525);
			this.panelMenu.TabIndex = 1;
			// 
			// buttonPlay
			// 
			this.buttonPlay.Animated = true;
			this.buttonPlay.BackColor = System.Drawing.Color.Transparent;
			this.buttonPlay.BorderRadius = 20;
			this.buttonPlay.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.buttonPlay.BorderThickness = 1;
			this.buttonPlay.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonPlay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.buttonPlay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.buttonPlay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonPlay.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonPlay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.buttonPlay.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(167)))), ((int)(((byte)(106)))));
			this.buttonPlay.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(129)))), ((int)(((byte)(69)))));
			this.buttonPlay.Font = new System.Drawing.Font("Cooper Black", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonPlay.ForeColor = System.Drawing.Color.White;
			this.buttonPlay.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonPlay.Location = new System.Drawing.Point(15, 25);
			this.buttonPlay.Name = "buttonPlay";
			this.buttonPlay.Size = new System.Drawing.Size(280, 50);
			this.buttonPlay.TabIndex = 0;
			this.buttonPlay.TabStop = false;
			this.buttonPlay.Text = "Play";
			this.buttonPlay.Click += new System.EventHandler(this.ButtonPlay_Click);
			// 
			// buttonExit
			// 
			this.buttonExit.Animated = true;
			this.buttonExit.BackColor = System.Drawing.Color.Transparent;
			this.buttonExit.BorderRadius = 20;
			this.buttonExit.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.buttonExit.BorderThickness = 1;
			this.buttonExit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.buttonExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.buttonExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonExit.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.buttonExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(24)))), ((int)(((byte)(13)))));
			this.buttonExit.FillColor2 = System.Drawing.Color.Maroon;
			this.buttonExit.Font = new System.Drawing.Font("Cooper Black", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonExit.ForeColor = System.Drawing.Color.White;
			this.buttonExit.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonExit.Location = new System.Drawing.Point(15, 325);
			this.buttonExit.Name = "buttonExit";
			this.buttonExit.Size = new System.Drawing.Size(280, 50);
			this.buttonExit.TabIndex = 3;
			this.buttonExit.TabStop = false;
			this.buttonExit.Text = "Exit";
			this.buttonExit.Click += new System.EventHandler(this.ButtonExit_Click);
			// 
			// buttonShop
			// 
			this.buttonShop.Animated = true;
			this.buttonShop.BackColor = System.Drawing.Color.Transparent;
			this.buttonShop.BorderRadius = 20;
			this.buttonShop.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.buttonShop.BorderThickness = 1;
			this.buttonShop.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonShop.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.buttonShop.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.buttonShop.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonShop.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonShop.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.buttonShop.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(168)))), ((int)(((byte)(23)))));
			this.buttonShop.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(176)))), ((int)(((byte)(46)))));
			this.buttonShop.Font = new System.Drawing.Font("Cooper Black", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonShop.ForeColor = System.Drawing.Color.White;
			this.buttonShop.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonShop.Location = new System.Drawing.Point(15, 175);
			this.buttonShop.Name = "buttonShop";
			this.buttonShop.Size = new System.Drawing.Size(280, 50);
			this.buttonShop.TabIndex = 2;
			this.buttonShop.TabStop = false;
			this.buttonShop.Text = "Shop";
			this.buttonShop.Click += new System.EventHandler(this.ButtonShop_Click);
			// 
			// buttonProfile
			// 
			this.buttonProfile.Animated = true;
			this.buttonProfile.BackColor = System.Drawing.Color.Transparent;
			this.buttonProfile.BorderRadius = 20;
			this.buttonProfile.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.buttonProfile.BorderThickness = 1;
			this.buttonProfile.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonProfile.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.buttonProfile.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.buttonProfile.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonProfile.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonProfile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.buttonProfile.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(126)))));
			this.buttonProfile.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(83)))), ((int)(((byte)(138)))));
			this.buttonProfile.Font = new System.Drawing.Font("Cooper Black", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonProfile.ForeColor = System.Drawing.Color.White;
			this.buttonProfile.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonProfile.Location = new System.Drawing.Point(15, 100);
			this.buttonProfile.Name = "buttonProfile";
			this.buttonProfile.Size = new System.Drawing.Size(280, 50);
			this.buttonProfile.TabIndex = 1;
			this.buttonProfile.TabStop = false;
			this.buttonProfile.Text = "Profile";
			this.buttonProfile.Click += new System.EventHandler(this.ButtonProfile_Click);
			// 
			// panelProfile
			// 
			this.panelProfile.Controls.Add(this.labelPlayerName);
			this.panelProfile.Controls.Add(this.pictureBoxAvatar);
			this.panelProfile.CustomBorderColor = System.Drawing.Color.Black;
			this.panelProfile.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panelProfile.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelProfile.Location = new System.Drawing.Point(0, 0);
			this.panelProfile.Name = "panelProfile";
			this.panelProfile.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panelProfile.Size = new System.Drawing.Size(320, 220);
			this.panelProfile.TabIndex = 0;
			// 
			// labelPlayerName
			// 
			this.labelPlayerName.BackColor = System.Drawing.Color.Transparent;
			this.labelPlayerName.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.labelPlayerName.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.labelPlayerName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.labelPlayerName.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelPlayerName.ForeColor = System.Drawing.Color.Black;
			this.labelPlayerName.Location = new System.Drawing.Point(0, 193);
			this.labelPlayerName.Name = "labelPlayerName";
			this.labelPlayerName.Size = new System.Drawing.Size(317, 27);
			this.labelPlayerName.TabIndex = 1;
			this.labelPlayerName.Text = "Player name";
			this.labelPlayerName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.labelPlayerName.MouseEnter += new System.EventHandler(this.LabelName_MouseEnter);
			this.labelPlayerName.MouseLeave += new System.EventHandler(this.LabelName_MouseLeave);
			// 
			// pictureBoxAvatar
			// 
			this.pictureBoxAvatar.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBoxAvatar.Image = global::TicTacToe.Properties.Resources.manAvatar1;
			this.pictureBoxAvatar.Location = new System.Drawing.Point(95, 10);
			this.pictureBoxAvatar.Name = "pictureBoxAvatar";
			this.pictureBoxAvatar.Size = new System.Drawing.Size(130, 130);
			this.pictureBoxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxAvatar.TabIndex = 0;
			this.pictureBoxAvatar.TabStop = false;
			this.pictureBoxAvatar.Click += new System.EventHandler(this.ButtonProfile_Click);
			// 
			// panelMain
			// 
			this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelMain.BackColor = System.Drawing.Color.Transparent;
			this.panelMain.Controls.Add(this.pictureBoxCoin);
			this.panelMain.Controls.Add(this.panelSettingsMain);
			this.panelMain.Controls.Add(this.panelLeft);
			this.panelMain.Controls.Add(this.labelCoins);
			this.panelMain.Controls.Add(this.labelAuthor);
			this.panelMain.Location = new System.Drawing.Point(5, 0);
			this.panelMain.Margin = new System.Windows.Forms.Padding(5, 0, 5, 5);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(1120, 745);
			this.panelMain.TabIndex = 0;
			// 
			// pictureBoxCoin
			// 
			this.pictureBoxCoin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxCoin.Image = global::TicTacToe.Properties.Resources.coin;
			this.pictureBoxCoin.Location = new System.Drawing.Point(1075, 0);
			this.pictureBoxCoin.Name = "pictureBoxCoin";
			this.pictureBoxCoin.Size = new System.Drawing.Size(42, 42);
			this.pictureBoxCoin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxCoin.TabIndex = 4;
			this.pictureBoxCoin.TabStop = false;
			// 
			// panelSettingsMain
			// 
			this.panelSettingsMain.BackColor = System.Drawing.Color.Transparent;
			this.panelSettingsMain.Controls.Add(this.panelSettingsRight);
			this.panelSettingsMain.Controls.Add(this.panelSettings);
			this.panelSettingsMain.Location = new System.Drawing.Point(320, 220);
			this.panelSettingsMain.Name = "panelSettingsMain";
			this.panelSettingsMain.Size = new System.Drawing.Size(340, 380);
			this.panelSettingsMain.TabIndex = 2;
			// 
			// panelSettingsRight
			// 
			this.panelSettingsRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.panelSettingsRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.panelSettingsRight.Controls.Add(this.buttonShowSettings);
			this.panelSettingsRight.CustomBorderColor = System.Drawing.Color.Black;
			this.panelSettingsRight.CustomBorderThickness = new System.Windows.Forms.Padding(0, 2, 2, 2);
			this.panelSettingsRight.ForeColor = System.Drawing.Color.Transparent;
			this.panelSettingsRight.Location = new System.Drawing.Point(298, 25);
			this.panelSettingsRight.Name = "panelSettingsRight";
			this.panelSettingsRight.Size = new System.Drawing.Size(41, 41);
			this.panelSettingsRight.TabIndex = 1;
			// 
			// buttonShowSettings
			// 
			this.buttonShowSettings.BackColor = System.Drawing.Color.Transparent;
			this.buttonShowSettings.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonShowSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonShowSettings.FlatAppearance.BorderSize = 0;
			this.buttonShowSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonShowSettings.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
			this.buttonShowSettings.IconChar = FontAwesome.Sharp.IconChar.CircleChevronUp;
			this.buttonShowSettings.IconColor = System.Drawing.Color.Black;
			this.buttonShowSettings.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.buttonShowSettings.IconSize = 38;
			this.buttonShowSettings.Location = new System.Drawing.Point(0, 0);
			this.buttonShowSettings.Name = "buttonShowSettings";
			this.buttonShowSettings.Rotation = 90D;
			this.buttonShowSettings.Size = new System.Drawing.Size(41, 41);
			this.buttonShowSettings.TabIndex = 0;
			this.buttonShowSettings.TabStop = false;
			this.buttonShowSettings.UseVisualStyleBackColor = false;
			this.buttonShowSettings.Click += new System.EventHandler(this.ButtonShowSettings_Click);
			// 
			// panelSettings
			// 
			this.panelSettings.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.panelSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.panelSettings.Controls.Add(this.buttonImpossible);
			this.panelSettings.Controls.Add(this.buttonHard);
			this.panelSettings.Controls.Add(this.buttonMedium);
			this.panelSettings.Controls.Add(this.buttonEasy);
			this.panelSettings.Controls.Add(this.numericUpDownNumberOfRounds);
			this.panelSettings.Controls.Add(this.labelDifficult);
			this.panelSettings.Controls.Add(this.labelNumberOfRounds);
			this.panelSettings.CustomBorderColor = System.Drawing.Color.Black;
			this.panelSettings.CustomBorderThickness = new System.Windows.Forms.Padding(0, 2, 2, 2);
			this.panelSettings.ForeColor = System.Drawing.Color.Transparent;
			this.panelSettings.Location = new System.Drawing.Point(0, 0);
			this.panelSettings.Name = "panelSettings";
			this.panelSettings.Size = new System.Drawing.Size(300, 380);
			this.panelSettings.TabIndex = 0;
			// 
			// buttonImpossible
			// 
			this.buttonImpossible.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(30)))));
			this.buttonImpossible.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonImpossible.FlatAppearance.BorderSize = 0;
			this.buttonImpossible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonImpossible.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonImpossible.ForeColor = System.Drawing.Color.Black;
			this.buttonImpossible.IconChar = FontAwesome.Sharp.IconChar.Circle;
			this.buttonImpossible.IconColor = System.Drawing.Color.Black;
			this.buttonImpossible.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.buttonImpossible.IconSize = 30;
			this.buttonImpossible.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonImpossible.Location = new System.Drawing.Point(20, 145);
			this.buttonImpossible.Margin = new System.Windows.Forms.Padding(0);
			this.buttonImpossible.Name = "buttonImpossible";
			this.buttonImpossible.Size = new System.Drawing.Size(160, 40);
			this.buttonImpossible.TabIndex = 3;
			this.buttonImpossible.TabStop = false;
			this.buttonImpossible.Text = " Impossible";
			this.buttonImpossible.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonImpossible.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonImpossible.UseVisualStyleBackColor = false;
			this.buttonImpossible.Click += new System.EventHandler(this.ButtonDifficulty_Click);
			this.buttonImpossible.MouseEnter += new System.EventHandler(this.ButtonDifficulty_MouseEnter);
			this.buttonImpossible.MouseLeave += new System.EventHandler(this.ButtonDifficulty_MouseLeave);
			// 
			// buttonHard
			// 
			this.buttonHard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(30)))));
			this.buttonHard.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonHard.FlatAppearance.BorderSize = 0;
			this.buttonHard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonHard.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonHard.ForeColor = System.Drawing.Color.Black;
			this.buttonHard.IconChar = FontAwesome.Sharp.IconChar.Circle;
			this.buttonHard.IconColor = System.Drawing.Color.Black;
			this.buttonHard.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.buttonHard.IconSize = 30;
			this.buttonHard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonHard.Location = new System.Drawing.Point(20, 105);
			this.buttonHard.Margin = new System.Windows.Forms.Padding(0);
			this.buttonHard.Name = "buttonHard";
			this.buttonHard.Size = new System.Drawing.Size(160, 40);
			this.buttonHard.TabIndex = 2;
			this.buttonHard.TabStop = false;
			this.buttonHard.Text = " Hard";
			this.buttonHard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonHard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonHard.UseVisualStyleBackColor = false;
			this.buttonHard.Click += new System.EventHandler(this.ButtonDifficulty_Click);
			this.buttonHard.MouseEnter += new System.EventHandler(this.ButtonDifficulty_MouseEnter);
			this.buttonHard.MouseLeave += new System.EventHandler(this.ButtonDifficulty_MouseLeave);
			// 
			// buttonMedium
			// 
			this.buttonMedium.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(30)))));
			this.buttonMedium.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonMedium.FlatAppearance.BorderSize = 0;
			this.buttonMedium.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonMedium.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonMedium.ForeColor = System.Drawing.Color.Black;
			this.buttonMedium.IconChar = FontAwesome.Sharp.IconChar.Circle;
			this.buttonMedium.IconColor = System.Drawing.Color.Black;
			this.buttonMedium.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.buttonMedium.IconSize = 30;
			this.buttonMedium.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonMedium.Location = new System.Drawing.Point(20, 65);
			this.buttonMedium.Margin = new System.Windows.Forms.Padding(0);
			this.buttonMedium.Name = "buttonMedium";
			this.buttonMedium.Size = new System.Drawing.Size(160, 40);
			this.buttonMedium.TabIndex = 6;
			this.buttonMedium.TabStop = false;
			this.buttonMedium.Text = " Medium";
			this.buttonMedium.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonMedium.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonMedium.UseVisualStyleBackColor = false;
			this.buttonMedium.Click += new System.EventHandler(this.ButtonDifficulty_Click);
			this.buttonMedium.MouseEnter += new System.EventHandler(this.ButtonDifficulty_MouseEnter);
			this.buttonMedium.MouseLeave += new System.EventHandler(this.ButtonDifficulty_MouseLeave);
			// 
			// buttonEasy
			// 
			this.buttonEasy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(30)))));
			this.buttonEasy.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonEasy.FlatAppearance.BorderSize = 0;
			this.buttonEasy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonEasy.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonEasy.ForeColor = System.Drawing.Color.Black;
			this.buttonEasy.IconChar = FontAwesome.Sharp.IconChar.Circle;
			this.buttonEasy.IconColor = System.Drawing.Color.Black;
			this.buttonEasy.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.buttonEasy.IconSize = 30;
			this.buttonEasy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonEasy.Location = new System.Drawing.Point(20, 25);
			this.buttonEasy.Margin = new System.Windows.Forms.Padding(0);
			this.buttonEasy.Name = "buttonEasy";
			this.buttonEasy.Size = new System.Drawing.Size(160, 40);
			this.buttonEasy.TabIndex = 1;
			this.buttonEasy.TabStop = false;
			this.buttonEasy.Text = " Easy";
			this.buttonEasy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonEasy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonEasy.UseVisualStyleBackColor = false;
			this.buttonEasy.Click += new System.EventHandler(this.ButtonDifficulty_Click);
			this.buttonEasy.MouseEnter += new System.EventHandler(this.ButtonDifficulty_MouseEnter);
			this.buttonEasy.MouseLeave += new System.EventHandler(this.ButtonDifficulty_MouseLeave);
			// 
			// numericUpDownNumberOfRounds
			// 
			this.numericUpDownNumberOfRounds.BackColor = System.Drawing.Color.White;
			this.numericUpDownNumberOfRounds.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDownNumberOfRounds.Location = new System.Drawing.Point(230, 200);
			this.numericUpDownNumberOfRounds.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
			this.numericUpDownNumberOfRounds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownNumberOfRounds.Name = "numericUpDownNumberOfRounds";
			this.numericUpDownNumberOfRounds.Size = new System.Drawing.Size(55, 29);
			this.numericUpDownNumberOfRounds.TabIndex = 5;
			this.numericUpDownNumberOfRounds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownNumberOfRounds.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// guna2BorderlessForm
			// 
			this.guna2BorderlessForm.BorderRadius = 30;
			this.guna2BorderlessForm.ContainerControl = this;
			this.guna2BorderlessForm.DockIndicatorTransparencyValue = 0.6D;
			this.guna2BorderlessForm.DragForm = false;
			this.guna2BorderlessForm.TransparentWhileDrag = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DarkGray;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1130, 750);
			this.Controls.Add(this.panelMain);
			this.ForeColor = System.Drawing.Color.Transparent;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(1440, 900);
			this.MinimumSize = new System.Drawing.Size(1024, 700);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Tic Tac Toe";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.VisibleChanged += new System.EventHandler(this.Menu_VisibleChanged);
			this.panelLeft.ResumeLayout(false);
			this.panelMenu.ResumeLayout(false);
			this.panelProfile.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).EndInit();
			this.panelMain.ResumeLayout(false);
			this.panelMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoin)).EndInit();
			this.panelSettingsMain.ResumeLayout(false);
			this.panelSettingsRight.ResumeLayout(false);
			this.panelSettings.ResumeLayout(false);
			this.panelSettings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfRounds)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private Guna.UI2.WinForms.Guna2Panel panelMain;
		private Guna.UI2.WinForms.Guna2Panel panelSettingsMain;
		private Guna.UI2.WinForms.Guna2Panel panelLeft;
		private Guna.UI2.WinForms.Guna2Panel panelMenu;
		private Guna.UI2.WinForms.Guna2GradientButton buttonPlay;
		private Guna.UI2.WinForms.Guna2GradientButton buttonExit;
		private Guna.UI2.WinForms.Guna2GradientButton buttonShop;
		private Guna.UI2.WinForms.Guna2GradientButton buttonProfile;
		private Guna.UI2.WinForms.Guna2Panel panelProfile;
		private System.Windows.Forms.Label labelPlayerName;
		public System.Windows.Forms.PictureBox pictureBoxAvatar;
		private System.Windows.Forms.Label labelCoins;
		private System.Windows.Forms.Label labelNumberOfRounds;
		private System.Windows.Forms.Label labelDifficult;
		private System.Windows.Forms.Label labelAuthor;
		private Guna.UI2.WinForms.Guna2Panel panelSettings;
		private FontAwesome.Sharp.IconButton buttonEasy;
		private FontAwesome.Sharp.IconButton buttonShowSettings;
		private Guna.UI2.WinForms.Guna2Panel panelSettingsRight;
		private FontAwesome.Sharp.IconButton buttonMedium;
		private FontAwesome.Sharp.IconButton buttonImpossible;
		private FontAwesome.Sharp.IconButton buttonHard;
		private System.Windows.Forms.NumericUpDown numericUpDownNumberOfRounds;
		private System.Windows.Forms.PictureBox pictureBoxCoin;
		private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm;
	}
}