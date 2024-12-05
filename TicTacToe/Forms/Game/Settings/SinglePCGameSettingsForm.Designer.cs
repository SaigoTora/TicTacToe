namespace TicTacToe.Forms.Game.Settings
{
	partial class SinglePCGameSettingsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SinglePCGameSettingsForm));
			this.label3on3 = new System.Windows.Forms.Label();
			this.label5on5 = new System.Windows.Forms.Label();
			this.label7on7 = new System.Windows.Forms.Label();
			this.buttonTimerEnabled = new FontAwesome.Sharp.IconButton();
			this.buttonPlay = new Guna.UI2.WinForms.Guna2GradientButton();
			this.flpAvatar = new System.Windows.Forms.FlowLayoutPanel();
			this.buttonChangeOpponentName = new FontAwesome.Sharp.IconButton();
			this.textBoxOpponentName = new System.Windows.Forms.TextBox();
			this.numericUpDownNumberOfRounds = new System.Windows.Forms.NumericUpDown();
			this.labelNumberOfRounds = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfRounds)).BeginInit();
			this.SuspendLayout();
			// 
			// label3on3
			// 
			this.label3on3.AutoSize = true;
			this.label3on3.BackColor = System.Drawing.Color.Transparent;
			this.label3on3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label3on3.Font = new System.Drawing.Font("Trebuchet MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3on3.ForeColor = System.Drawing.Color.LightGray;
			this.label3on3.Location = new System.Drawing.Point(112, 20);
			this.label3on3.Name = "label3on3";
			this.label3on3.Size = new System.Drawing.Size(87, 40);
			this.label3on3.TabIndex = 0;
			this.label3on3.Text = "3 x 3";
			this.label3on3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.label3on3.Click += new System.EventHandler(this.LabelFieldSize_Click);
			// 
			// label5on5
			// 
			this.label5on5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label5on5.AutoSize = true;
			this.label5on5.BackColor = System.Drawing.Color.Transparent;
			this.label5on5.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label5on5.Font = new System.Drawing.Font("Trebuchet MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5on5.ForeColor = System.Drawing.Color.LightGray;
			this.label5on5.Location = new System.Drawing.Point(402, 20);
			this.label5on5.Name = "label5on5";
			this.label5on5.Size = new System.Drawing.Size(87, 40);
			this.label5on5.TabIndex = 1;
			this.label5on5.Text = "5 x 5";
			this.label5on5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.label5on5.Click += new System.EventHandler(this.LabelFieldSize_Click);
			// 
			// label7on7
			// 
			this.label7on7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label7on7.AutoSize = true;
			this.label7on7.BackColor = System.Drawing.Color.Transparent;
			this.label7on7.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label7on7.Font = new System.Drawing.Font("Trebuchet MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label7on7.ForeColor = System.Drawing.Color.LightGray;
			this.label7on7.Location = new System.Drawing.Point(692, 20);
			this.label7on7.Name = "label7on7";
			this.label7on7.Size = new System.Drawing.Size(87, 40);
			this.label7on7.TabIndex = 2;
			this.label7on7.Text = "7 x 7";
			this.label7on7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.label7on7.Click += new System.EventHandler(this.LabelFieldSize_Click);
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
			this.buttonTimerEnabled.Location = new System.Drawing.Point(42, 560);
			this.buttonTimerEnabled.Margin = new System.Windows.Forms.Padding(0);
			this.buttonTimerEnabled.Name = "buttonTimerEnabled";
			this.buttonTimerEnabled.Size = new System.Drawing.Size(140, 40);
			this.buttonTimerEnabled.TabIndex = 8;
			this.buttonTimerEnabled.TabStop = false;
			this.buttonTimerEnabled.Text = " Timer";
			this.buttonTimerEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonTimerEnabled.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.buttonTimerEnabled.UseVisualStyleBackColor = false;
			this.buttonTimerEnabled.Click += new System.EventHandler(this.ButtonTimerEnabled_Click);
			this.buttonTimerEnabled.MouseEnter += new System.EventHandler(this.EnableButton_MouseEnter);
			this.buttonTimerEnabled.MouseLeave += new System.EventHandler(this.EnableButton_MouseLeave);
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
			this.buttonPlay.Location = new System.Drawing.Point(659, 608);
			this.buttonPlay.Name = "buttonPlay";
			this.buttonPlay.Size = new System.Drawing.Size(220, 50);
			this.buttonPlay.TabIndex = 9;
			this.buttonPlay.TabStop = false;
			this.buttonPlay.Text = "Play";
			this.buttonPlay.Click += new System.EventHandler(this.ButtonPlay_Click);
			// 
			// flpAvatar
			// 
			this.flpAvatar.AutoScroll = true;
			this.flpAvatar.BackColor = System.Drawing.Color.Transparent;
			this.flpAvatar.Location = new System.Drawing.Point(12, 264);
			this.flpAvatar.Name = "flpAvatar";
			this.flpAvatar.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
			this.flpAvatar.Size = new System.Drawing.Size(560, 280);
			this.flpAvatar.TabIndex = 7;
			// 
			// buttonChangeOpponentName
			// 
			this.buttonChangeOpponentName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
			this.buttonChangeOpponentName.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonChangeOpponentName.FlatAppearance.BorderSize = 0;
			this.buttonChangeOpponentName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonChangeOpponentName.IconChar = FontAwesome.Sharp.IconChar.Pencil;
			this.buttonChangeOpponentName.IconColor = System.Drawing.Color.White;
			this.buttonChangeOpponentName.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.buttonChangeOpponentName.IconSize = 38;
			this.buttonChangeOpponentName.Location = new System.Drawing.Point(398, 207);
			this.buttonChangeOpponentName.Name = "buttonChangeOpponentName";
			this.buttonChangeOpponentName.Size = new System.Drawing.Size(41, 41);
			this.buttonChangeOpponentName.TabIndex = 6;
			this.buttonChangeOpponentName.TabStop = false;
			this.buttonChangeOpponentName.UseVisualStyleBackColor = false;
			this.buttonChangeOpponentName.Click += new System.EventHandler(this.ButtonChangeOpponentName_Click);
			// 
			// textBoxOpponentName
			// 
			this.textBoxOpponentName.BackColor = System.Drawing.Color.Black;
			this.textBoxOpponentName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxOpponentName.Font = new System.Drawing.Font("Trebuchet MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxOpponentName.ForeColor = System.Drawing.Color.White;
			this.textBoxOpponentName.Location = new System.Drawing.Point(42, 210);
			this.textBoxOpponentName.Name = "textBoxOpponentName";
			this.textBoxOpponentName.ReadOnly = true;
			this.textBoxOpponentName.Size = new System.Drawing.Size(350, 34);
			this.textBoxOpponentName.TabIndex = 5;
			this.textBoxOpponentName.TabStop = false;
			this.textBoxOpponentName.Text = "Player 2";
			this.textBoxOpponentName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxOpponentName_KeyDown);
			this.textBoxOpponentName.Leave += new System.EventHandler(this.TextBoxOpponentName_Leave);
			// 
			// numericUpDownNumberOfRounds
			// 
			this.numericUpDownNumberOfRounds.BackColor = System.Drawing.Color.Black;
			this.numericUpDownNumberOfRounds.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDownNumberOfRounds.ForeColor = System.Drawing.Color.White;
			this.numericUpDownNumberOfRounds.Location = new System.Drawing.Point(283, 117);
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
			this.numericUpDownNumberOfRounds.TabIndex = 4;
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
			this.labelNumberOfRounds.Location = new System.Drawing.Point(42, 120);
			this.labelNumberOfRounds.Name = "labelNumberOfRounds";
			this.labelNumberOfRounds.Size = new System.Drawing.Size(241, 35);
			this.labelNumberOfRounds.TabIndex = 3;
			this.labelNumberOfRounds.Text = "Number of rounds:";
			// 
			// SinglePCGameSettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.ClientSize = new System.Drawing.Size(891, 670);
			this.Controls.Add(this.numericUpDownNumberOfRounds);
			this.Controls.Add(this.labelNumberOfRounds);
			this.Controls.Add(this.flpAvatar);
			this.Controls.Add(this.textBoxOpponentName);
			this.Controls.Add(this.buttonPlay);
			this.Controls.Add(this.buttonChangeOpponentName);
			this.Controls.Add(this.buttonTimerEnabled);
			this.Controls.Add(this.label7on7);
			this.Controls.Add(this.label5on5);
			this.Controls.Add(this.label3on3);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SinglePCGameSettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "GameSettingsForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SinglePCGameSettingsForm_FormClosed);
			this.Load += new System.EventHandler(this.SinglePCGameSettingsForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfRounds)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label3on3;
		private System.Windows.Forms.Label label5on5;
		private System.Windows.Forms.Label label7on7;
		private FontAwesome.Sharp.IconButton buttonTimerEnabled;
		private Guna.UI2.WinForms.Guna2GradientButton buttonPlay;
		private System.Windows.Forms.FlowLayoutPanel flpAvatar;
		private FontAwesome.Sharp.IconButton buttonChangeOpponentName;
		private System.Windows.Forms.TextBox textBoxOpponentName;
		private System.Windows.Forms.NumericUpDown numericUpDownNumberOfRounds;
		private System.Windows.Forms.Label labelNumberOfRounds;
	}
}