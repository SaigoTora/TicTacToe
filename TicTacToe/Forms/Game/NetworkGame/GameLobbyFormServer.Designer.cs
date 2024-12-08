using TicTacToe.Models.Utilities.FormUtilities;

namespace TicTacToe.Forms.Game.NetworkGame
{
	partial class GameLobbyServerForm
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
			this.pictureBoxCoin = new System.Windows.Forms.PictureBox();
			this.labelCoins = new System.Windows.Forms.Label();
			this.label7on7 = new System.Windows.Forms.Label();
			this.label5on5 = new System.Windows.Forms.Label();
			this.label3on3 = new System.Windows.Forms.Label();
			this.labelFieldSize = new System.Windows.Forms.Label();
			this.numericUpDownNumberOfRounds = new System.Windows.Forms.NumericUpDown();
			this.labelNumberOfRounds = new System.Windows.Forms.Label();
			this.pictureBoxCoinBet = new System.Windows.Forms.PictureBox();
			this.labelCoinsBet = new System.Windows.Forms.Label();
			this.buttonGameAssistsEnabled = new FontAwesome.Sharp.IconButton();
			this.buttonTimerEnabled = new FontAwesome.Sharp.IconButton();
			this.buttonStart = new Guna.UI2.WinForms.Guna2GradientButton();
			this.flpPlayers = new System.Windows.Forms.FlowLayoutPanel();
			this.labelValueCoinsBet = new System.Windows.Forms.Label();
			this.textBoxMessage = new Guna.UI2.WinForms.Guna2TextBox();
			this.panelChat = new Guna.UI2.WinForms.Guna2Panel();
			this.richTextBoxChat = new TicTacToe.Models.Utilities.FormUtilities.NoCaretRichTextBox();
			this.buttonSendMessage = new Guna.UI2.WinForms.Guna2GradientButton();
			this.pictureBoxLineAboveChat = new Guna.UI2.WinForms.Guna2PictureBox();
			this.comboBoxGameMode = new Guna.UI2.WinForms.Guna2ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfRounds)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoinBet)).BeginInit();
			this.panelChat.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxLineAboveChat)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxCoin
			// 
			this.pictureBoxCoin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxCoin.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxCoin.Image = global::TicTacToe.Properties.Resources.coin;
			this.pictureBoxCoin.Location = new System.Drawing.Point(1146, 12);
			this.pictureBoxCoin.Name = "pictureBoxCoin";
			this.pictureBoxCoin.Size = new System.Drawing.Size(42, 42);
			this.pictureBoxCoin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxCoin.TabIndex = 13;
			this.pictureBoxCoin.TabStop = false;
			// 
			// labelCoins
			// 
			this.labelCoins.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCoins.BackColor = System.Drawing.Color.Transparent;
			this.labelCoins.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCoins.ForeColor = System.Drawing.Color.Khaki;
			this.labelCoins.Location = new System.Drawing.Point(1012, 20);
			this.labelCoins.Name = "labelCoins";
			this.labelCoins.Size = new System.Drawing.Size(130, 27);
			this.labelCoins.TabIndex = 12;
			this.labelCoins.Text = "999 999";
			this.labelCoins.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7on7
			// 
			this.label7on7.AutoSize = true;
			this.label7on7.BackColor = System.Drawing.Color.Transparent;
			this.label7on7.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label7on7.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label7on7.ForeColor = System.Drawing.Color.LightGray;
			this.label7on7.Location = new System.Drawing.Point(375, 20);
			this.label7on7.Name = "label7on7";
			this.label7on7.Size = new System.Drawing.Size(73, 35);
			this.label7on7.TabIndex = 3;
			this.label7on7.Text = "7 x 7";
			this.label7on7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.label7on7.Click += new System.EventHandler(this.LabelFieldSize_Click);
			// 
			// label5on5
			// 
			this.label5on5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label5on5.AutoSize = true;
			this.label5on5.BackColor = System.Drawing.Color.Transparent;
			this.label5on5.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label5on5.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5on5.ForeColor = System.Drawing.Color.LightGray;
			this.label5on5.Location = new System.Drawing.Point(275, 20);
			this.label5on5.Name = "label5on5";
			this.label5on5.Size = new System.Drawing.Size(73, 35);
			this.label5on5.TabIndex = 2;
			this.label5on5.Text = "5 x 5";
			this.label5on5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.label5on5.Click += new System.EventHandler(this.LabelFieldSize_Click);
			// 
			// label3on3
			// 
			this.label3on3.AutoSize = true;
			this.label3on3.BackColor = System.Drawing.Color.Transparent;
			this.label3on3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label3on3.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3on3.ForeColor = System.Drawing.Color.LightGray;
			this.label3on3.Location = new System.Drawing.Point(175, 20);
			this.label3on3.Name = "label3on3";
			this.label3on3.Size = new System.Drawing.Size(73, 35);
			this.label3on3.TabIndex = 1;
			this.label3on3.Text = "3 x 3";
			this.label3on3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.label3on3.Click += new System.EventHandler(this.LabelFieldSize_Click);
			// 
			// labelFieldSize
			// 
			this.labelFieldSize.AutoSize = true;
			this.labelFieldSize.BackColor = System.Drawing.Color.Transparent;
			this.labelFieldSize.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelFieldSize.ForeColor = System.Drawing.Color.White;
			this.labelFieldSize.Location = new System.Drawing.Point(12, 20);
			this.labelFieldSize.Name = "labelFieldSize";
			this.labelFieldSize.Size = new System.Drawing.Size(140, 35);
			this.labelFieldSize.TabIndex = 0;
			this.labelFieldSize.Text = "Field size:";
			this.labelFieldSize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// numericUpDownNumberOfRounds
			// 
			this.numericUpDownNumberOfRounds.BackColor = System.Drawing.Color.Black;
			this.numericUpDownNumberOfRounds.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDownNumberOfRounds.ForeColor = System.Drawing.Color.White;
			this.numericUpDownNumberOfRounds.Location = new System.Drawing.Point(259, 78);
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
			this.numericUpDownNumberOfRounds.Size = new System.Drawing.Size(75, 38);
			this.numericUpDownNumberOfRounds.TabIndex = 6;
			this.numericUpDownNumberOfRounds.TabStop = false;
			this.numericUpDownNumberOfRounds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownNumberOfRounds.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.numericUpDownNumberOfRounds.ValueChanged += new System.EventHandler(this.NumericUpDownNumberOfRounds_ValueChanged);
			// 
			// labelNumberOfRounds
			// 
			this.labelNumberOfRounds.AutoSize = true;
			this.labelNumberOfRounds.BackColor = System.Drawing.Color.Transparent;
			this.labelNumberOfRounds.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelNumberOfRounds.ForeColor = System.Drawing.Color.White;
			this.labelNumberOfRounds.Location = new System.Drawing.Point(12, 80);
			this.labelNumberOfRounds.Name = "labelNumberOfRounds";
			this.labelNumberOfRounds.Size = new System.Drawing.Size(241, 35);
			this.labelNumberOfRounds.TabIndex = 5;
			this.labelNumberOfRounds.Text = "Number of rounds:";
			// 
			// pictureBoxCoinBet
			// 
			this.pictureBoxCoinBet.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxCoinBet.Image = global::TicTacToe.Properties.Resources.coin;
			this.pictureBoxCoinBet.Location = new System.Drawing.Point(262, 135);
			this.pictureBoxCoinBet.Name = "pictureBoxCoinBet";
			this.pictureBoxCoinBet.Size = new System.Drawing.Size(45, 45);
			this.pictureBoxCoinBet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxCoinBet.TabIndex = 9;
			this.pictureBoxCoinBet.TabStop = false;
			// 
			// labelCoinsBet
			// 
			this.labelCoinsBet.AutoSize = true;
			this.labelCoinsBet.BackColor = System.Drawing.Color.Transparent;
			this.labelCoinsBet.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCoinsBet.ForeColor = System.Drawing.Color.Khaki;
			this.labelCoinsBet.Location = new System.Drawing.Point(12, 140);
			this.labelCoinsBet.Name = "labelCoinsBet";
			this.labelCoinsBet.Size = new System.Drawing.Size(138, 35);
			this.labelCoinsBet.TabIndex = 7;
			this.labelCoinsBet.Text = "Coins bet:";
			// 
			// buttonGameAssistsEnabled
			// 
			this.buttonGameAssistsEnabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(30)))));
			this.buttonGameAssistsEnabled.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonGameAssistsEnabled.FlatAppearance.BorderSize = 0;
			this.buttonGameAssistsEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonGameAssistsEnabled.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonGameAssistsEnabled.ForeColor = System.Drawing.Color.White;
			this.buttonGameAssistsEnabled.IconChar = FontAwesome.Sharp.IconChar.Circle;
			this.buttonGameAssistsEnabled.IconColor = System.Drawing.Color.White;
			this.buttonGameAssistsEnabled.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.buttonGameAssistsEnabled.IconSize = 30;
			this.buttonGameAssistsEnabled.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonGameAssistsEnabled.Location = new System.Drawing.Point(12, 260);
			this.buttonGameAssistsEnabled.Margin = new System.Windows.Forms.Padding(0);
			this.buttonGameAssistsEnabled.Name = "buttonGameAssistsEnabled";
			this.buttonGameAssistsEnabled.Size = new System.Drawing.Size(220, 40);
			this.buttonGameAssistsEnabled.TabIndex = 11;
			this.buttonGameAssistsEnabled.TabStop = false;
			this.buttonGameAssistsEnabled.Text = " Game Assists";
			this.buttonGameAssistsEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonGameAssistsEnabled.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonGameAssistsEnabled.UseVisualStyleBackColor = false;
			this.buttonGameAssistsEnabled.Click += new System.EventHandler(this.ButtonGameAssistsEnabled_Click);
			this.buttonGameAssistsEnabled.MouseEnter += new System.EventHandler(this.EnabledButton_MouseEnter);
			this.buttonGameAssistsEnabled.MouseLeave += new System.EventHandler(this.EnabledButton_MouseLeave);
			// 
			// buttonTimerEnabled
			// 
			this.buttonTimerEnabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(35)))), ((int)(((byte)(30)))));
			this.buttonTimerEnabled.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonTimerEnabled.FlatAppearance.BorderSize = 0;
			this.buttonTimerEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonTimerEnabled.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonTimerEnabled.ForeColor = System.Drawing.Color.White;
			this.buttonTimerEnabled.IconChar = FontAwesome.Sharp.IconChar.Circle;
			this.buttonTimerEnabled.IconColor = System.Drawing.Color.White;
			this.buttonTimerEnabled.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.buttonTimerEnabled.IconSize = 30;
			this.buttonTimerEnabled.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonTimerEnabled.Location = new System.Drawing.Point(12, 210);
			this.buttonTimerEnabled.Margin = new System.Windows.Forms.Padding(0);
			this.buttonTimerEnabled.Name = "buttonTimerEnabled";
			this.buttonTimerEnabled.Size = new System.Drawing.Size(140, 40);
			this.buttonTimerEnabled.TabIndex = 10;
			this.buttonTimerEnabled.TabStop = false;
			this.buttonTimerEnabled.Text = " Timer";
			this.buttonTimerEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonTimerEnabled.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonTimerEnabled.UseVisualStyleBackColor = false;
			this.buttonTimerEnabled.Click += new System.EventHandler(this.ButtonTimerEnabled_Click);
			this.buttonTimerEnabled.MouseEnter += new System.EventHandler(this.EnabledButton_MouseEnter);
			this.buttonTimerEnabled.MouseLeave += new System.EventHandler(this.EnabledButton_MouseLeave);
			// 
			// buttonStart
			// 
			this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonStart.Animated = true;
			this.buttonStart.BackColor = System.Drawing.Color.Transparent;
			this.buttonStart.BorderRadius = 20;
			this.buttonStart.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.buttonStart.BorderThickness = 1;
			this.buttonStart.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonStart.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.buttonStart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.buttonStart.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonStart.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonStart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.buttonStart.Enabled = false;
			this.buttonStart.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(239)))), ((int)(((byte)(125)))));
			this.buttonStart.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(153)))), ((int)(((byte)(142)))));
			this.buttonStart.Font = new System.Drawing.Font("Cooper Black", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonStart.ForeColor = System.Drawing.Color.White;
			this.buttonStart.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonStart.Location = new System.Drawing.Point(968, 715);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(220, 50);
			this.buttonStart.TabIndex = 17;
			this.buttonStart.TabStop = false;
			this.buttonStart.Text = "Start";
			this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
			// 
			// flpPlayers
			// 
			this.flpPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.flpPlayers.AutoScroll = true;
			this.flpPlayers.BackColor = System.Drawing.Color.Transparent;
			this.flpPlayers.Location = new System.Drawing.Point(677, 375);
			this.flpPlayers.Name = "flpPlayers";
			this.flpPlayers.Size = new System.Drawing.Size(267, 390);
			this.flpPlayers.TabIndex = 16;
			this.flpPlayers.Tag = "needToMoveParentDown";
			// 
			// labelValueCoinsBet
			// 
			this.labelValueCoinsBet.BackColor = System.Drawing.Color.Transparent;
			this.labelValueCoinsBet.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelValueCoinsBet.ForeColor = System.Drawing.Color.Khaki;
			this.labelValueCoinsBet.Location = new System.Drawing.Point(156, 139);
			this.labelValueCoinsBet.Name = "labelValueCoinsBet";
			this.labelValueCoinsBet.Size = new System.Drawing.Size(100, 38);
			this.labelValueCoinsBet.TabIndex = 8;
			this.labelValueCoinsBet.Text = "9 999";
			this.labelValueCoinsBet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBoxMessage
			// 
			this.textBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.textBoxMessage.AutoScroll = true;
			this.textBoxMessage.BorderColor = System.Drawing.Color.DarkGray;
			this.textBoxMessage.BorderRadius = 5;
			this.textBoxMessage.BorderThickness = 2;
			this.textBoxMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBoxMessage.DefaultText = "";
			this.textBoxMessage.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.textBoxMessage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.textBoxMessage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxMessage.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.textBoxMessage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.textBoxMessage.FocusedState.BorderColor = System.Drawing.Color.Gold;
			this.textBoxMessage.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxMessage.ForeColor = System.Drawing.Color.White;
			this.textBoxMessage.HoverState.BorderColor = System.Drawing.Color.LightGray;
			this.textBoxMessage.Location = new System.Drawing.Point(4, 338);
			this.textBoxMessage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.textBoxMessage.MaxLength = 300;
			this.textBoxMessage.Name = "textBoxMessage";
			this.textBoxMessage.PasswordChar = '\0';
			this.textBoxMessage.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.textBoxMessage.PlaceholderText = "Send message";
			this.textBoxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxMessage.SelectedText = "";
			this.textBoxMessage.Size = new System.Drawing.Size(535, 50);
			this.textBoxMessage.TabIndex = 1;
			this.textBoxMessage.TextChanged += new System.EventHandler(this.TextBoxMessage_TextChanged);
			this.textBoxMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxMessage_KeyDown);
			// 
			// panelChat
			// 
			this.panelChat.BackColor = System.Drawing.Color.Transparent;
			this.panelChat.Controls.Add(this.richTextBoxChat);
			this.panelChat.Controls.Add(this.buttonSendMessage);
			this.panelChat.Controls.Add(this.textBoxMessage);
			this.panelChat.Location = new System.Drawing.Point(6, 375);
			this.panelChat.Name = "panelChat";
			this.panelChat.Size = new System.Drawing.Size(670, 390);
			this.panelChat.TabIndex = 15;
			this.panelChat.Tag = "needToMoveParentDown";
			// 
			// richTextBoxChat
			// 
			this.richTextBoxChat.BackColor = System.Drawing.Color.Black;
			this.richTextBoxChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxChat.Dock = System.Windows.Forms.DockStyle.Top;
			this.richTextBoxChat.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxChat.ForeColor = System.Drawing.Color.White;
			this.richTextBoxChat.Location = new System.Drawing.Point(0, 0);
			this.richTextBoxChat.Name = "richTextBoxChat";
			this.richTextBoxChat.ReadOnly = true;
			this.richTextBoxChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.richTextBoxChat.Size = new System.Drawing.Size(670, 300);
			this.richTextBoxChat.TabIndex = 0;
			this.richTextBoxChat.Text = "";
			// 
			// buttonSendMessage
			// 
			this.buttonSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSendMessage.BackColor = System.Drawing.Color.Transparent;
			this.buttonSendMessage.BorderRadius = 4;
			this.buttonSendMessage.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.buttonSendMessage.BorderThickness = 1;
			this.buttonSendMessage.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonSendMessage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.buttonSendMessage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.buttonSendMessage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonSendMessage.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonSendMessage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.buttonSendMessage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(126)))));
			this.buttonSendMessage.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(83)))), ((int)(((byte)(138)))));
			this.buttonSendMessage.Font = new System.Drawing.Font("Cooper Black", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonSendMessage.ForeColor = System.Drawing.Color.White;
			this.buttonSendMessage.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonSendMessage.Location = new System.Drawing.Point(543, 338);
			this.buttonSendMessage.Name = "buttonSendMessage";
			this.buttonSendMessage.Size = new System.Drawing.Size(125, 50);
			this.buttonSendMessage.TabIndex = 2;
			this.buttonSendMessage.TabStop = false;
			this.buttonSendMessage.Text = "Chat";
			this.buttonSendMessage.Click += new System.EventHandler(this.ButtonSendMessage_Click);
			// 
			// pictureBoxLineAboveChat
			// 
			this.pictureBoxLineAboveChat.AutoRoundedCorners = true;
			this.pictureBoxLineAboveChat.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxLineAboveChat.BorderRadius = 1;
			this.pictureBoxLineAboveChat.CustomizableEdges.BottomLeft = false;
			this.pictureBoxLineAboveChat.CustomizableEdges.TopLeft = false;
			this.pictureBoxLineAboveChat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
			this.pictureBoxLineAboveChat.ImageRotate = 0F;
			this.pictureBoxLineAboveChat.Location = new System.Drawing.Point(0, 360);
			this.pictureBoxLineAboveChat.Name = "pictureBoxLineAboveChat";
			this.pictureBoxLineAboveChat.Size = new System.Drawing.Size(500, 4);
			this.pictureBoxLineAboveChat.TabIndex = 14;
			this.pictureBoxLineAboveChat.TabStop = false;
			// 
			// comboBoxGameMode
			// 
			this.comboBoxGameMode.BackColor = System.Drawing.Color.Transparent;
			this.comboBoxGameMode.BorderColor = System.Drawing.Color.Gray;
			this.comboBoxGameMode.BorderRadius = 7;
			this.comboBoxGameMode.BorderThickness = 2;
			this.comboBoxGameMode.Cursor = System.Windows.Forms.Cursors.Hand;
			this.comboBoxGameMode.CustomizableEdges.BottomLeft = false;
			this.comboBoxGameMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.comboBoxGameMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxGameMode.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
			this.comboBoxGameMode.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(75)))), ((int)(((byte)(45)))));
			this.comboBoxGameMode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(75)))), ((int)(((byte)(45)))));
			this.comboBoxGameMode.FocusedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
			this.comboBoxGameMode.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxGameMode.ForeColor = System.Drawing.Color.LightGray;
			this.comboBoxGameMode.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
			this.comboBoxGameMode.HoverState.ForeColor = System.Drawing.Color.White;
			this.comboBoxGameMode.ItemHeight = 38;
			this.comboBoxGameMode.Items.AddRange(new object[] {
            "Classic",
            "Tetris",
            "Reverse Tetris",
            "Swap"});
			this.comboBoxGameMode.ItemsAppearance.ForeColor = System.Drawing.Color.White;
			this.comboBoxGameMode.ItemsAppearance.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(75)))), ((int)(((byte)(45)))));
			this.comboBoxGameMode.Location = new System.Drawing.Point(500, 20);
			this.comboBoxGameMode.MaxDropDownItems = 3;
			this.comboBoxGameMode.Name = "comboBoxGameMode";
			this.comboBoxGameMode.Size = new System.Drawing.Size(255, 44);
			this.comboBoxGameMode.StartIndex = 0;
			this.comboBoxGameMode.TabIndex = 4;
			this.comboBoxGameMode.TabStop = false;
			this.comboBoxGameMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.comboBoxGameMode.SelectedIndexChanged += new System.EventHandler(this.ComboBoxGameMode_SelectedIndexChanged);
			// 
			// GameLobbyServerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.ClientSize = new System.Drawing.Size(1200, 800);
			this.Controls.Add(this.comboBoxGameMode);
			this.Controls.Add(this.pictureBoxLineAboveChat);
			this.Controls.Add(this.panelChat);
			this.Controls.Add(this.labelValueCoinsBet);
			this.Controls.Add(this.flpPlayers);
			this.Controls.Add(this.buttonStart);
			this.Controls.Add(this.buttonGameAssistsEnabled);
			this.Controls.Add(this.buttonTimerEnabled);
			this.Controls.Add(this.pictureBoxCoinBet);
			this.Controls.Add(this.labelCoinsBet);
			this.Controls.Add(this.numericUpDownNumberOfRounds);
			this.Controls.Add(this.labelNumberOfRounds);
			this.Controls.Add(this.labelFieldSize);
			this.Controls.Add(this.label7on7);
			this.Controls.Add(this.label5on5);
			this.Controls.Add(this.label3on3);
			this.Controls.Add(this.pictureBoxCoin);
			this.Controls.Add(this.labelCoins);
			this.KeyPreview = true;
			this.Name = "GameLobbyServerForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "GameLobbyForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameLobbyServerForm_FormClosed);
			this.Load += new System.EventHandler(this.GameLobbyServerForm_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameLobbyServerForm_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfRounds)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoinBet)).EndInit();
			this.panelChat.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxLineAboveChat)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxCoin;
		private System.Windows.Forms.Label labelCoins;
		private System.Windows.Forms.Label label7on7;
		private System.Windows.Forms.Label label5on5;
		private System.Windows.Forms.Label label3on3;
		private System.Windows.Forms.Label labelFieldSize;
		private System.Windows.Forms.NumericUpDown numericUpDownNumberOfRounds;
		private System.Windows.Forms.Label labelNumberOfRounds;
		private System.Windows.Forms.PictureBox pictureBoxCoinBet;
		private System.Windows.Forms.Label labelCoinsBet;
		private FontAwesome.Sharp.IconButton buttonGameAssistsEnabled;
		private FontAwesome.Sharp.IconButton buttonTimerEnabled;
		private Guna.UI2.WinForms.Guna2GradientButton buttonStart;
		private System.Windows.Forms.FlowLayoutPanel flpPlayers;
		private System.Windows.Forms.Label labelValueCoinsBet;
		private Guna.UI2.WinForms.Guna2TextBox textBoxMessage;
		private Guna.UI2.WinForms.Guna2Panel panelChat;
		private Guna.UI2.WinForms.Guna2GradientButton buttonSendMessage;
		private NoCaretRichTextBox richTextBoxChat;
		private Guna.UI2.WinForms.Guna2PictureBox pictureBoxLineAboveChat;
		private Guna.UI2.WinForms.Guna2ComboBox comboBoxGameMode;
	}
}