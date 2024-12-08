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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkGameSettingsForm));
			this.numericUpDownCoinsBet = new System.Windows.Forms.NumericUpDown();
			this.labelCoinsBet = new System.Windows.Forms.Label();
			this.buttonCreate = new Guna.UI2.WinForms.Guna2GradientButton();
			this.buttonGameAssistsEnabled = new FontAwesome.Sharp.IconButton();
			this.buttonTimerEnabled = new FontAwesome.Sharp.IconButton();
			this.label7on7 = new System.Windows.Forms.Label();
			this.label5on5 = new System.Windows.Forms.Label();
			this.label3on3 = new System.Windows.Forms.Label();
			this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
			this.pictureBoxCoin = new System.Windows.Forms.PictureBox();
			this.labelDescription = new System.Windows.Forms.Label();
			this.labelDescriptionLength = new System.Windows.Forms.Label();
			this.numericUpDownNumberOfRounds = new System.Windows.Forms.NumericUpDown();
			this.labelNumberOfRounds = new System.Windows.Forms.Label();
			this.comboBoxGameMode = new Guna.UI2.WinForms.Guna2ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCoinsBet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfRounds)).BeginInit();
			this.SuspendLayout();
			// 
			// numericUpDownCoinsBet
			// 
			this.numericUpDownCoinsBet.BackColor = System.Drawing.Color.Black;
			this.numericUpDownCoinsBet.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDownCoinsBet.ForeColor = System.Drawing.Color.Khaki;
			this.numericUpDownCoinsBet.Location = new System.Drawing.Point(186, 239);
			this.numericUpDownCoinsBet.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.numericUpDownCoinsBet.Name = "numericUpDownCoinsBet";
			this.numericUpDownCoinsBet.Size = new System.Drawing.Size(100, 38);
			this.numericUpDownCoinsBet.TabIndex = 7;
			this.numericUpDownCoinsBet.TabStop = false;
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
			this.labelCoinsBet.Location = new System.Drawing.Point(42, 240);
			this.labelCoinsBet.Name = "labelCoinsBet";
			this.labelCoinsBet.Size = new System.Drawing.Size(138, 35);
			this.labelCoinsBet.TabIndex = 6;
			this.labelCoinsBet.Text = "Coins bet:";
			// 
			// buttonCreate
			// 
			this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCreate.Animated = true;
			this.buttonCreate.BackColor = System.Drawing.Color.Transparent;
			this.buttonCreate.BorderRadius = 20;
			this.buttonCreate.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.buttonCreate.BorderThickness = 1;
			this.buttonCreate.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonCreate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.buttonCreate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.buttonCreate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonCreate.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonCreate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.buttonCreate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(239)))), ((int)(((byte)(125)))));
			this.buttonCreate.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(153)))), ((int)(((byte)(142)))));
			this.buttonCreate.Font = new System.Drawing.Font("Cooper Black", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonCreate.ForeColor = System.Drawing.Color.White;
			this.buttonCreate.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonCreate.Location = new System.Drawing.Point(659, 658);
			this.buttonCreate.Name = "buttonCreate";
			this.buttonCreate.Size = new System.Drawing.Size(220, 50);
			this.buttonCreate.TabIndex = 14;
			this.buttonCreate.TabStop = false;
			this.buttonCreate.Text = "Create";
			this.buttonCreate.Click += new System.EventHandler(this.ButtonCreate_Click);
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
			this.buttonGameAssistsEnabled.Location = new System.Drawing.Point(232, 606);
			this.buttonGameAssistsEnabled.Margin = new System.Windows.Forms.Padding(0);
			this.buttonGameAssistsEnabled.Name = "buttonGameAssistsEnabled";
			this.buttonGameAssistsEnabled.Size = new System.Drawing.Size(220, 40);
			this.buttonGameAssistsEnabled.TabIndex = 13;
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
			this.buttonTimerEnabled.Location = new System.Drawing.Point(42, 606);
			this.buttonTimerEnabled.Margin = new System.Windows.Forms.Padding(0);
			this.buttonTimerEnabled.Name = "buttonTimerEnabled";
			this.buttonTimerEnabled.Size = new System.Drawing.Size(140, 40);
			this.buttonTimerEnabled.TabIndex = 12;
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
			this.label7on7.ForeColor = System.Drawing.Color.LightGray;
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
			this.label5on5.ForeColor = System.Drawing.Color.LightGray;
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
			this.label3on3.ForeColor = System.Drawing.Color.LightGray;
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
			this.richTextBoxDescription.Location = new System.Drawing.Point(42, 370);
			this.richTextBoxDescription.MaxLength = 110;
			this.richTextBoxDescription.Name = "richTextBoxDescription";
			this.richTextBoxDescription.Size = new System.Drawing.Size(560, 180);
			this.richTextBoxDescription.TabIndex = 10;
			this.richTextBoxDescription.TabStop = false;
			this.richTextBoxDescription.Text = "";
			this.richTextBoxDescription.TextChanged += new System.EventHandler(this.RichTextBoxDescription_TextChanged);
			this.richTextBoxDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RichTextBoxDescription_KeyDown);
			this.richTextBoxDescription.Leave += new System.EventHandler(this.RichTextBoxDescription_Leave);
			// 
			// pictureBoxCoin
			// 
			this.pictureBoxCoin.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxCoin.Image = global::TicTacToe.Properties.Resources.coin;
			this.pictureBoxCoin.Location = new System.Drawing.Point(292, 235);
			this.pictureBoxCoin.Name = "pictureBoxCoin";
			this.pictureBoxCoin.Size = new System.Drawing.Size(45, 45);
			this.pictureBoxCoin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxCoin.TabIndex = 8;
			this.pictureBoxCoin.TabStop = false;
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.labelDescription.BackColor = System.Drawing.Color.Transparent;
			this.labelDescription.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDescription.ForeColor = System.Drawing.Color.White;
			this.labelDescription.Location = new System.Drawing.Point(42, 320);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(163, 35);
			this.labelDescription.TabIndex = 9;
			this.labelDescription.Text = "Description:";
			// 
			// labelDescriptionLength
			// 
			this.labelDescriptionLength.BackColor = System.Drawing.Color.Transparent;
			this.labelDescriptionLength.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDescriptionLength.ForeColor = System.Drawing.Color.LightGray;
			this.labelDescriptionLength.Location = new System.Drawing.Point(412, 553);
			this.labelDescriptionLength.Name = "labelDescriptionLength";
			this.labelDescriptionLength.Size = new System.Drawing.Size(190, 35);
			this.labelDescriptionLength.TabIndex = 11;
			this.labelDescriptionLength.Text = "99999 / 99999";
			this.labelDescriptionLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.labelDescriptionLength.Visible = false;
			// 
			// numericUpDownNumberOfRounds
			// 
			this.numericUpDownNumberOfRounds.BackColor = System.Drawing.Color.Black;
			this.numericUpDownNumberOfRounds.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDownNumberOfRounds.ForeColor = System.Drawing.Color.White;
			this.numericUpDownNumberOfRounds.Location = new System.Drawing.Point(289, 168);
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
			this.numericUpDownNumberOfRounds.TabIndex = 5;
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
			this.labelNumberOfRounds.Location = new System.Drawing.Point(42, 170);
			this.labelNumberOfRounds.Name = "labelNumberOfRounds";
			this.labelNumberOfRounds.Size = new System.Drawing.Size(241, 35);
			this.labelNumberOfRounds.TabIndex = 4;
			this.labelNumberOfRounds.Text = "Number of rounds:";
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
			this.comboBoxGameMode.Location = new System.Drawing.Point(42, 100);
			this.comboBoxGameMode.MaxDropDownItems = 3;
			this.comboBoxGameMode.Name = "comboBoxGameMode";
			this.comboBoxGameMode.Size = new System.Drawing.Size(255, 44);
			this.comboBoxGameMode.StartIndex = 0;
			this.comboBoxGameMode.TabIndex = 3;
			this.comboBoxGameMode.TabStop = false;
			this.comboBoxGameMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.comboBoxGameMode.SelectedIndexChanged += new System.EventHandler(this.ComboBoxGameMode_SelectedIndexChanged);
			// 
			// NetworkGameSettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.ClientSize = new System.Drawing.Size(891, 720);
			this.Controls.Add(this.comboBoxGameMode);
			this.Controls.Add(this.numericUpDownNumberOfRounds);
			this.Controls.Add(this.labelNumberOfRounds);
			this.Controls.Add(this.labelDescriptionLength);
			this.Controls.Add(this.labelDescription);
			this.Controls.Add(this.pictureBoxCoin);
			this.Controls.Add(this.richTextBoxDescription);
			this.Controls.Add(this.numericUpDownCoinsBet);
			this.Controls.Add(this.labelCoinsBet);
			this.Controls.Add(this.buttonCreate);
			this.Controls.Add(this.buttonGameAssistsEnabled);
			this.Controls.Add(this.buttonTimerEnabled);
			this.Controls.Add(this.label7on7);
			this.Controls.Add(this.label5on5);
			this.Controls.Add(this.label3on3);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "NetworkGameSettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "NetworkGameSettingsForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NetworkGameSettingsForm_FormClosed);
			this.Load += new System.EventHandler(this.NetworkGameSettingsForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCoinsBet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfRounds)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown numericUpDownCoinsBet;
		private System.Windows.Forms.Label labelCoinsBet;
		private Guna.UI2.WinForms.Guna2GradientButton buttonCreate;
		private FontAwesome.Sharp.IconButton buttonGameAssistsEnabled;
		private FontAwesome.Sharp.IconButton buttonTimerEnabled;
		private System.Windows.Forms.Label label7on7;
		private System.Windows.Forms.Label label5on5;
		private System.Windows.Forms.Label label3on3;
		private System.Windows.Forms.RichTextBox richTextBoxDescription;
		private System.Windows.Forms.PictureBox pictureBoxCoin;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.Label labelDescriptionLength;
		private System.Windows.Forms.NumericUpDown numericUpDownNumberOfRounds;
		private System.Windows.Forms.Label labelNumberOfRounds;
		private Guna.UI2.WinForms.Guna2ComboBox comboBoxGameMode;
	}
}