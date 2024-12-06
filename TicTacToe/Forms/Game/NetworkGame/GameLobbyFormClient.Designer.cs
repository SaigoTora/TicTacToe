namespace TicTacToe.Forms.Game.NetworkGame
{
	partial class GameLobbyClientForm
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
			this.labelFieldSize = new System.Windows.Forms.Label();
			this.labelNumberOfRounds = new System.Windows.Forms.Label();
			this.pictureBoxCoinBet = new System.Windows.Forms.PictureBox();
			this.labelCoinsBet = new System.Windows.Forms.Label();
			this.buttonGameAssistsEnabled = new FontAwesome.Sharp.IconButton();
			this.buttonTimerEnabled = new FontAwesome.Sharp.IconButton();
			this.buttonReady = new Guna.UI2.WinForms.Guna2GradientButton();
			this.flpPlayers = new System.Windows.Forms.FlowLayoutPanel();
			this.labelValueCoinsBet = new System.Windows.Forms.Label();
			this.panelChat = new Guna.UI2.WinForms.Guna2Panel();
			this.richTextBoxChat = new TicTacToe.Models.Utilities.FormUtilities.NoCaretRichTextBox();
			this.buttonSendMessage = new Guna.UI2.WinForms.Guna2GradientButton();
			this.textBoxMessage = new Guna.UI2.WinForms.Guna2TextBox();
			this.pictureBoxLineAboveChat = new Guna.UI2.WinForms.Guna2PictureBox();
			this.labelGameMode = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoin)).BeginInit();
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
			this.pictureBoxCoin.TabIndex = 9;
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
			this.labelCoins.TabIndex = 8;
			this.labelCoins.Text = "999 999";
			this.labelCoins.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
			// labelNumberOfRounds
			// 
			this.labelNumberOfRounds.AutoSize = true;
			this.labelNumberOfRounds.BackColor = System.Drawing.Color.Transparent;
			this.labelNumberOfRounds.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelNumberOfRounds.ForeColor = System.Drawing.Color.White;
			this.labelNumberOfRounds.Location = new System.Drawing.Point(12, 80);
			this.labelNumberOfRounds.Name = "labelNumberOfRounds";
			this.labelNumberOfRounds.Size = new System.Drawing.Size(241, 35);
			this.labelNumberOfRounds.TabIndex = 2;
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
			this.pictureBoxCoinBet.TabIndex = 5;
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
			this.labelCoinsBet.TabIndex = 3;
			this.labelCoinsBet.Text = "Coins bet:";
			// 
			// buttonGameAssistsEnabled
			// 
			this.buttonGameAssistsEnabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.buttonGameAssistsEnabled.Cursor = System.Windows.Forms.Cursors.Default;
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
			this.buttonGameAssistsEnabled.TabIndex = 7;
			this.buttonGameAssistsEnabled.TabStop = false;
			this.buttonGameAssistsEnabled.Text = " Game Assists";
			this.buttonGameAssistsEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonGameAssistsEnabled.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonGameAssistsEnabled.UseVisualStyleBackColor = false;
			// 
			// buttonTimerEnabled
			// 
			this.buttonTimerEnabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.buttonTimerEnabled.Cursor = System.Windows.Forms.Cursors.Default;
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
			this.buttonTimerEnabled.TabIndex = 6;
			this.buttonTimerEnabled.TabStop = false;
			this.buttonTimerEnabled.Text = " Timer";
			this.buttonTimerEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonTimerEnabled.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonTimerEnabled.UseVisualStyleBackColor = false;
			// 
			// buttonReady
			// 
			this.buttonReady.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonReady.Animated = true;
			this.buttonReady.BackColor = System.Drawing.Color.Transparent;
			this.buttonReady.BorderRadius = 20;
			this.buttonReady.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.buttonReady.BorderThickness = 1;
			this.buttonReady.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonReady.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.buttonReady.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.buttonReady.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonReady.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonReady.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.buttonReady.FillColor = System.Drawing.Color.SandyBrown;
			this.buttonReady.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(124)))), ((int)(((byte)(38)))));
			this.buttonReady.Font = new System.Drawing.Font("Cooper Black", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonReady.ForeColor = System.Drawing.Color.White;
			this.buttonReady.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonReady.Location = new System.Drawing.Point(968, 738);
			this.buttonReady.Name = "buttonReady";
			this.buttonReady.Size = new System.Drawing.Size(220, 50);
			this.buttonReady.TabIndex = 13;
			this.buttonReady.TabStop = false;
			this.buttonReady.Text = "Ready";
			this.buttonReady.Click += new System.EventHandler(this.ButtonReady_Click);
			// 
			// flpPlayers
			// 
			this.flpPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.flpPlayers.AutoScroll = true;
			this.flpPlayers.BackColor = System.Drawing.Color.Transparent;
			this.flpPlayers.Location = new System.Drawing.Point(677, 375);
			this.flpPlayers.Name = "flpPlayers";
			this.flpPlayers.Size = new System.Drawing.Size(267, 390);
			this.flpPlayers.TabIndex = 12;
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
			this.labelValueCoinsBet.TabIndex = 4;
			this.labelValueCoinsBet.Text = "9 999";
			this.labelValueCoinsBet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
			this.panelChat.TabIndex = 11;
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
			this.pictureBoxLineAboveChat.TabIndex = 10;
			this.pictureBoxLineAboveChat.TabStop = false;
			// 
			// labelGameMode
			// 
			this.labelGameMode.AutoSize = true;
			this.labelGameMode.BackColor = System.Drawing.Color.Transparent;
			this.labelGameMode.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelGameMode.ForeColor = System.Drawing.Color.White;
			this.labelGameMode.Location = new System.Drawing.Point(500, 20);
			this.labelGameMode.Name = "labelGameMode";
			this.labelGameMode.Size = new System.Drawing.Size(168, 35);
			this.labelGameMode.TabIndex = 1;
			this.labelGameMode.Text = "Game mode:";
			this.labelGameMode.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// GameLobbyClientForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.ClientSize = new System.Drawing.Size(1200, 800);
			this.Controls.Add(this.labelGameMode);
			this.Controls.Add(this.pictureBoxLineAboveChat);
			this.Controls.Add(this.panelChat);
			this.Controls.Add(this.labelValueCoinsBet);
			this.Controls.Add(this.flpPlayers);
			this.Controls.Add(this.buttonGameAssistsEnabled);
			this.Controls.Add(this.buttonTimerEnabled);
			this.Controls.Add(this.pictureBoxCoinBet);
			this.Controls.Add(this.labelCoinsBet);
			this.Controls.Add(this.labelNumberOfRounds);
			this.Controls.Add(this.labelFieldSize);
			this.Controls.Add(this.pictureBoxCoin);
			this.Controls.Add(this.labelCoins);
			this.Controls.Add(this.buttonReady);
			this.Name = "GameLobbyClientForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "GameLobbyForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameLobbyClientForm_FormClosed);
			this.Load += new System.EventHandler(this.GameLobbyClientForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoinBet)).EndInit();
			this.panelChat.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxLineAboveChat)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxCoin;
		private System.Windows.Forms.Label labelCoins;
		private System.Windows.Forms.Label labelFieldSize;
		private System.Windows.Forms.Label labelNumberOfRounds;
		private System.Windows.Forms.PictureBox pictureBoxCoinBet;
		private System.Windows.Forms.Label labelCoinsBet;
		private FontAwesome.Sharp.IconButton buttonGameAssistsEnabled;
		private FontAwesome.Sharp.IconButton buttonTimerEnabled;
		private Guna.UI2.WinForms.Guna2GradientButton buttonReady;
		private System.Windows.Forms.FlowLayoutPanel flpPlayers;
		private System.Windows.Forms.Label labelValueCoinsBet;
		private Guna.UI2.WinForms.Guna2Panel panelChat;
		private Models.Utilities.FormUtilities.NoCaretRichTextBox richTextBoxChat;
		private Guna.UI2.WinForms.Guna2GradientButton buttonSendMessage;
		private Guna.UI2.WinForms.Guna2TextBox textBoxMessage;
		private Guna.UI2.WinForms.Guna2PictureBox pictureBoxLineAboveChat;
		private System.Windows.Forms.Label labelGameMode;
	}
}