namespace TicTacToe.Forms.Game.Settings
{
	partial class NetworkGameSettingsForm
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
			this.numericUpDownCoinsBet = new System.Windows.Forms.NumericUpDown();
			this.labelCoinsBet = new System.Windows.Forms.Label();
			this.buttonPlay = new Guna.UI2.WinForms.Guna2GradientButton();
			this.buttonGameAssistsEnabled = new FontAwesome.Sharp.IconButton();
			this.buttonTimerEnabled = new FontAwesome.Sharp.IconButton();
			this.label7on7 = new System.Windows.Forms.Label();
			this.label5on5 = new System.Windows.Forms.Label();
			this.label3on3 = new System.Windows.Forms.Label();
			this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
			this.labelOpponentTitle = new System.Windows.Forms.Label();
			this.pictureBoxCoin = new System.Windows.Forms.PictureBox();
			this.labelDescription = new System.Windows.Forms.Label();
			this.labelDescriptionLength = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCoinsBet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoin)).BeginInit();
			this.SuspendLayout();
			// 
			// numericUpDownCoinsBet
			// 
			this.numericUpDownCoinsBet.BackColor = System.Drawing.Color.Black;
			this.numericUpDownCoinsBet.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDownCoinsBet.ForeColor = System.Drawing.Color.Khaki;
			this.numericUpDownCoinsBet.Location = new System.Drawing.Point(186, 179);
			this.numericUpDownCoinsBet.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.numericUpDownCoinsBet.Name = "numericUpDownCoinsBet";
			this.numericUpDownCoinsBet.Size = new System.Drawing.Size(100, 38);
			this.numericUpDownCoinsBet.TabIndex = 5;
			this.numericUpDownCoinsBet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownCoinsBet.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.numericUpDownCoinsBet.ValueChanged += new System.EventHandler(this.NumericUpDownCoinsBet_ValueChanged);
			// 
			// labelCoinsBet
			// 
			this.labelCoinsBet.AutoSize = true;
			this.labelCoinsBet.BackColor = System.Drawing.Color.Transparent;
			this.labelCoinsBet.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCoinsBet.ForeColor = System.Drawing.Color.Khaki;
			this.labelCoinsBet.Location = new System.Drawing.Point(42, 180);
			this.labelCoinsBet.Name = "labelCoinsBet";
			this.labelCoinsBet.Size = new System.Drawing.Size(138, 35);
			this.labelCoinsBet.TabIndex = 4;
			this.labelCoinsBet.Text = "Coins bet:";
			// 
			// buttonPlay
			// 
			this.buttonPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
			this.buttonPlay.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(239)))), ((int)(((byte)(125)))));
			this.buttonPlay.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(153)))), ((int)(((byte)(142)))));
			this.buttonPlay.Font = new System.Drawing.Font("Cooper Black", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonPlay.ForeColor = System.Drawing.Color.White;
			this.buttonPlay.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonPlay.Location = new System.Drawing.Point(619, 604);
			this.buttonPlay.Name = "buttonPlay";
			this.buttonPlay.Size = new System.Drawing.Size(260, 50);
			this.buttonPlay.TabIndex = 12;
			this.buttonPlay.TabStop = false;
			this.buttonPlay.Text = "Create";
			this.buttonPlay.Click += new System.EventHandler(this.ButtonCreate_Click);
			// 
			// buttonGameAssistsEnabled
			// 
			this.buttonGameAssistsEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
			this.buttonGameAssistsEnabled.Location = new System.Drawing.Point(232, 556);
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
			this.buttonGameAssistsEnabled.MouseEnter += new System.EventHandler(this.EnableButton_MouseEnter);
			this.buttonGameAssistsEnabled.MouseLeave += new System.EventHandler(this.EnableButton_MouseLeave);
			// 
			// buttonTimerEnabled
			// 
			this.buttonTimerEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
			this.buttonTimerEnabled.Location = new System.Drawing.Point(42, 556);
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
			this.buttonTimerEnabled.MouseEnter += new System.EventHandler(this.EnableButton_MouseEnter);
			this.buttonTimerEnabled.MouseLeave += new System.EventHandler(this.EnableButton_MouseLeave);
			// 
			// label7on7
			// 
			this.label7on7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label7on7.AutoSize = true;
			this.label7on7.BackColor = System.Drawing.Color.Transparent;
			this.label7on7.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label7on7.Font = new System.Drawing.Font("Trebuchet MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label7on7.ForeColor = System.Drawing.Color.White;
			this.label7on7.Location = new System.Drawing.Point(692, 20);
			this.label7on7.Name = "label7on7";
			this.label7on7.Size = new System.Drawing.Size(87, 40);
			this.label7on7.TabIndex = 2;
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
			this.label5on5.Font = new System.Drawing.Font("Trebuchet MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5on5.ForeColor = System.Drawing.Color.White;
			this.label5on5.Location = new System.Drawing.Point(402, 20);
			this.label5on5.Name = "label5on5";
			this.label5on5.Size = new System.Drawing.Size(87, 40);
			this.label5on5.TabIndex = 1;
			this.label5on5.Text = "5 x 5";
			this.label5on5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.label5on5.Click += new System.EventHandler(this.LabelFieldSize_Click);
			// 
			// label3on3
			// 
			this.label3on3.AutoSize = true;
			this.label3on3.BackColor = System.Drawing.Color.Transparent;
			this.label3on3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label3on3.Font = new System.Drawing.Font("Trebuchet MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3on3.ForeColor = System.Drawing.Color.White;
			this.label3on3.Location = new System.Drawing.Point(112, 20);
			this.label3on3.Name = "label3on3";
			this.label3on3.Size = new System.Drawing.Size(87, 40);
			this.label3on3.TabIndex = 0;
			this.label3on3.Text = "3 x 3";
			this.label3on3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.label3on3.Click += new System.EventHandler(this.LabelFieldSize_Click);
			// 
			// richTextBoxDescription
			// 
			this.richTextBoxDescription.BackColor = System.Drawing.Color.Black;
			this.richTextBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.richTextBoxDescription.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxDescription.ForeColor = System.Drawing.Color.Gainsboro;
			this.richTextBoxDescription.Location = new System.Drawing.Point(42, 300);
			this.richTextBoxDescription.MaxLength = 110;
			this.richTextBoxDescription.Name = "richTextBoxDescription";
			this.richTextBoxDescription.Size = new System.Drawing.Size(560, 180);
			this.richTextBoxDescription.TabIndex = 8;
			this.richTextBoxDescription.Text = "Description.";
			this.richTextBoxDescription.TextChanged += new System.EventHandler(this.RichTextBoxDescription_TextChanged);
			this.richTextBoxDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RichTextBoxDescription_KeyDown);
			this.richTextBoxDescription.Leave += new System.EventHandler(this.RichTextBoxDescription_Leave);
			// 
			// labelOpponentTitle
			// 
			this.labelOpponentTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelOpponentTitle.AutoSize = true;
			this.labelOpponentTitle.BackColor = System.Drawing.Color.Transparent;
			this.labelOpponentTitle.Font = new System.Drawing.Font("Unispace", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelOpponentTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.labelOpponentTitle.Location = new System.Drawing.Point(290, 100);
			this.labelOpponentTitle.Name = "labelOpponentTitle";
			this.labelOpponentTitle.Size = new System.Drawing.Size(312, 42);
			this.labelOpponentTitle.TabIndex = 3;
			this.labelOpponentTitle.Text = "Local Settings";
			this.labelOpponentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pictureBoxCoin
			// 
			this.pictureBoxCoin.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxCoin.Image = global::TicTacToe.Properties.Resources.coin;
			this.pictureBoxCoin.Location = new System.Drawing.Point(292, 175);
			this.pictureBoxCoin.Name = "pictureBoxCoin";
			this.pictureBoxCoin.Size = new System.Drawing.Size(45, 45);
			this.pictureBoxCoin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxCoin.TabIndex = 6;
			this.pictureBoxCoin.TabStop = false;
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.labelDescription.BackColor = System.Drawing.Color.Transparent;
			this.labelDescription.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDescription.ForeColor = System.Drawing.Color.White;
			this.labelDescription.Location = new System.Drawing.Point(42, 260);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(163, 35);
			this.labelDescription.TabIndex = 7;
			this.labelDescription.Text = "Description:";
			// 
			// labelDescriptionLength
			// 
			this.labelDescriptionLength.BackColor = System.Drawing.Color.Transparent;
			this.labelDescriptionLength.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDescriptionLength.ForeColor = System.Drawing.Color.LightGray;
			this.labelDescriptionLength.Location = new System.Drawing.Point(412, 483);
			this.labelDescriptionLength.Name = "labelDescriptionLength";
			this.labelDescriptionLength.Size = new System.Drawing.Size(190, 35);
			this.labelDescriptionLength.TabIndex = 9;
			this.labelDescriptionLength.Text = "99999 / 99999";
			this.labelDescriptionLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// NetworkGameSettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.ClientSize = new System.Drawing.Size(891, 670);
			this.Controls.Add(this.labelDescriptionLength);
			this.Controls.Add(this.labelDescription);
			this.Controls.Add(this.pictureBoxCoin);
			this.Controls.Add(this.richTextBoxDescription);
			this.Controls.Add(this.numericUpDownCoinsBet);
			this.Controls.Add(this.labelCoinsBet);
			this.Controls.Add(this.labelOpponentTitle);
			this.Controls.Add(this.buttonPlay);
			this.Controls.Add(this.buttonGameAssistsEnabled);
			this.Controls.Add(this.buttonTimerEnabled);
			this.Controls.Add(this.label7on7);
			this.Controls.Add(this.label5on5);
			this.Controls.Add(this.label3on3);
			this.Name = "NetworkGameSettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "NetworkGameSettingsForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NetworkGameSettingsForm_FormClosed);
			this.Load += new System.EventHandler(this.NetworkGameSettingsForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCoinsBet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoin)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown numericUpDownCoinsBet;
		private System.Windows.Forms.Label labelCoinsBet;
		private Guna.UI2.WinForms.Guna2GradientButton buttonPlay;
		private FontAwesome.Sharp.IconButton buttonGameAssistsEnabled;
		private FontAwesome.Sharp.IconButton buttonTimerEnabled;
		private System.Windows.Forms.Label label7on7;
		private System.Windows.Forms.Label label5on5;
		private System.Windows.Forms.Label label3on3;
		private System.Windows.Forms.RichTextBox richTextBoxDescription;
		private System.Windows.Forms.Label labelOpponentTitle;
		private System.Windows.Forms.PictureBox pictureBoxCoin;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.Label labelDescriptionLength;
	}
}