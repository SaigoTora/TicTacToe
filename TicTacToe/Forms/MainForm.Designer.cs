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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.buttonPlay = new System.Windows.Forms.Button();
			this.labelPoints = new System.Windows.Forms.Label();
			this.labelAuthor = new System.Windows.Forms.Label();
			this.labelEasy = new System.Windows.Forms.Label();
			this.labelMedium = new System.Windows.Forms.Label();
			this.labelHard = new System.Windows.Forms.Label();
			this.labelDifficult = new System.Windows.Forms.Label();
			this.buttonExit = new System.Windows.Forms.Button();
			this.labelNumberOfRounds = new System.Windows.Forms.Label();
			this.labelPlayerName = new System.Windows.Forms.Label();
			this.buttonShop = new System.Windows.Forms.Button();
			this.pictureBoxAvatar = new System.Windows.Forms.PictureBox();
			this.buttonProfile = new System.Windows.Forms.Button();
			this.pictureBoxShowSettings = new System.Windows.Forms.PictureBox();
			this.numericUpDownNumberOfRounds = new System.Windows.Forms.NumericUpDown();
			this.labelImpossible = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowSettings)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfRounds)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonPlay
			// 
			this.buttonPlay.BackColor = System.Drawing.Color.RosyBrown;
			this.buttonPlay.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.buttonPlay.FlatAppearance.BorderSize = 2;
			this.buttonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonPlay.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonPlay.ForeColor = System.Drawing.Color.Black;
			this.buttonPlay.Location = new System.Drawing.Point(309, 125);
			this.buttonPlay.Name = "buttonPlay";
			this.buttonPlay.Size = new System.Drawing.Size(300, 60);
			this.buttonPlay.TabIndex = 3;
			this.buttonPlay.Text = "Play";
			this.buttonPlay.UseVisualStyleBackColor = false;
			this.buttonPlay.Click += new System.EventHandler(this.ButtonPlay_Click);
			// 
			// labelPoints
			// 
			this.labelPoints.BackColor = System.Drawing.Color.Khaki;
			this.labelPoints.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelPoints.ForeColor = System.Drawing.Color.Black;
			this.labelPoints.Location = new System.Drawing.Point(637, 9);
			this.labelPoints.Name = "labelPoints";
			this.labelPoints.Size = new System.Drawing.Size(170, 27);
			this.labelPoints.TabIndex = 2;
			this.labelPoints.Text = "99999";
			this.labelPoints.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelAuthor
			// 
			this.labelAuthor.AutoSize = true;
			this.labelAuthor.BackColor = System.Drawing.Color.Transparent;
			this.labelAuthor.Font = new System.Drawing.Font("Lobster", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelAuthor.ForeColor = System.Drawing.Color.Silver;
			this.labelAuthor.Location = new System.Drawing.Point(636, 721);
			this.labelAuthor.Name = "labelAuthor";
			this.labelAuthor.Size = new System.Drawing.Size(171, 31);
			this.labelAuthor.TabIndex = 15;
			this.labelAuthor.Text = "Author: SaigoTora";
			// 
			// labelEasy
			// 
			this.labelEasy.BackColor = System.Drawing.Color.LightSteelBlue;
			this.labelEasy.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelEasy.ForeColor = System.Drawing.Color.Black;
			this.labelEasy.Location = new System.Drawing.Point(9, 228);
			this.labelEasy.Name = "labelEasy";
			this.labelEasy.Size = new System.Drawing.Size(167, 27);
			this.labelEasy.TabIndex = 6;
			this.labelEasy.Text = "Easy";
			this.labelEasy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labelEasy.Click += new System.EventHandler(this.LabelDifficulty_Click);
			this.labelEasy.MouseEnter += new System.EventHandler(this.LabelDifficulty_MouseEnter);
			this.labelEasy.MouseLeave += new System.EventHandler(this.LabelDifficulty_MouseLeave);
			// 
			// labelMedium
			// 
			this.labelMedium.BackColor = System.Drawing.Color.LightSteelBlue;
			this.labelMedium.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelMedium.ForeColor = System.Drawing.Color.Black;
			this.labelMedium.Location = new System.Drawing.Point(9, 255);
			this.labelMedium.Name = "labelMedium";
			this.labelMedium.Size = new System.Drawing.Size(167, 27);
			this.labelMedium.TabIndex = 7;
			this.labelMedium.Text = "Medium";
			this.labelMedium.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labelMedium.Click += new System.EventHandler(this.LabelDifficulty_Click);
			this.labelMedium.MouseEnter += new System.EventHandler(this.LabelDifficulty_MouseEnter);
			this.labelMedium.MouseLeave += new System.EventHandler(this.LabelDifficulty_MouseLeave);
			// 
			// labelHard
			// 
			this.labelHard.BackColor = System.Drawing.Color.LightSteelBlue;
			this.labelHard.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelHard.ForeColor = System.Drawing.Color.Black;
			this.labelHard.Location = new System.Drawing.Point(9, 282);
			this.labelHard.Name = "labelHard";
			this.labelHard.Size = new System.Drawing.Size(167, 27);
			this.labelHard.TabIndex = 8;
			this.labelHard.Text = "Hard";
			this.labelHard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labelHard.Click += new System.EventHandler(this.LabelDifficulty_Click);
			this.labelHard.MouseEnter += new System.EventHandler(this.LabelDifficulty_MouseEnter);
			this.labelHard.MouseLeave += new System.EventHandler(this.LabelDifficulty_MouseLeave);
			// 
			// labelDifficult
			// 
			this.labelDifficult.AutoSize = true;
			this.labelDifficult.BackColor = System.Drawing.Color.LightSteelBlue;
			this.labelDifficult.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDifficult.ForeColor = System.Drawing.Color.Black;
			this.labelDifficult.Location = new System.Drawing.Point(9, 188);
			this.labelDifficult.Name = "labelDifficult";
			this.labelDifficult.Size = new System.Drawing.Size(167, 27);
			this.labelDifficult.TabIndex = 5;
			this.labelDifficult.Text = "Select difficulty:";
			// 
			// buttonExit
			// 
			this.buttonExit.BackColor = System.Drawing.Color.Maroon;
			this.buttonExit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.buttonExit.FlatAppearance.BorderSize = 2;
			this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonExit.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonExit.ForeColor = System.Drawing.Color.Black;
			this.buttonExit.Location = new System.Drawing.Point(309, 500);
			this.buttonExit.Name = "buttonExit";
			this.buttonExit.Size = new System.Drawing.Size(300, 60);
			this.buttonExit.TabIndex = 14;
			this.buttonExit.Text = "Exit";
			this.buttonExit.UseVisualStyleBackColor = false;
			this.buttonExit.Click += new System.EventHandler(this.ButtonExit_Click);
			// 
			// labelNumberOfRounds
			// 
			this.labelNumberOfRounds.AutoSize = true;
			this.labelNumberOfRounds.BackColor = System.Drawing.Color.LightSteelBlue;
			this.labelNumberOfRounds.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelNumberOfRounds.ForeColor = System.Drawing.Color.Black;
			this.labelNumberOfRounds.Location = new System.Drawing.Point(9, 353);
			this.labelNumberOfRounds.Name = "labelNumberOfRounds";
			this.labelNumberOfRounds.Size = new System.Drawing.Size(186, 27);
			this.labelNumberOfRounds.TabIndex = 10;
			this.labelNumberOfRounds.Text = "Number of rounds:";
			// 
			// labelPlayerName
			// 
			this.labelPlayerName.AutoSize = true;
			this.labelPlayerName.BackColor = System.Drawing.Color.Transparent;
			this.labelPlayerName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.labelPlayerName.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelPlayerName.Location = new System.Drawing.Point(115, 9);
			this.labelPlayerName.Name = "labelPlayerName";
			this.labelPlayerName.Size = new System.Drawing.Size(132, 27);
			this.labelPlayerName.TabIndex = 1;
			this.labelPlayerName.Text = "Player name";
			this.labelPlayerName.MouseEnter += new System.EventHandler(this.LabelName_MouseEnter);
			this.labelPlayerName.MouseLeave += new System.EventHandler(this.LabelName_MouseLeave);
			// 
			// buttonShop
			// 
			this.buttonShop.BackColor = System.Drawing.Color.DarkKhaki;
			this.buttonShop.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.buttonShop.FlatAppearance.BorderSize = 2;
			this.buttonShop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonShop.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonShop.ForeColor = System.Drawing.Color.Black;
			this.buttonShop.Location = new System.Drawing.Point(309, 312);
			this.buttonShop.Name = "buttonShop";
			this.buttonShop.Size = new System.Drawing.Size(300, 60);
			this.buttonShop.TabIndex = 13;
			this.buttonShop.Text = "Shop";
			this.buttonShop.UseVisualStyleBackColor = false;
			this.buttonShop.Click += new System.EventHandler(this.ButtonShop_Click);
			// 
			// pictureBoxAvatar
			// 
			this.pictureBoxAvatar.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxAvatar.Image = global::TicTacToe.Properties.Resources.manAvatar1;
			this.pictureBoxAvatar.Location = new System.Drawing.Point(9, 9);
			this.pictureBoxAvatar.Name = "pictureBoxAvatar";
			this.pictureBoxAvatar.Size = new System.Drawing.Size(100, 100);
			this.pictureBoxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxAvatar.TabIndex = 0;
			this.pictureBoxAvatar.TabStop = false;
			// 
			// buttonProfile
			// 
			this.buttonProfile.BackColor = System.Drawing.Color.DarkKhaki;
			this.buttonProfile.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.buttonProfile.FlatAppearance.BorderSize = 2;
			this.buttonProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonProfile.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonProfile.ForeColor = System.Drawing.Color.Black;
			this.buttonProfile.Location = new System.Drawing.Point(309, 222);
			this.buttonProfile.Name = "buttonProfile";
			this.buttonProfile.Size = new System.Drawing.Size(300, 60);
			this.buttonProfile.TabIndex = 12;
			this.buttonProfile.Text = "Profile";
			this.buttonProfile.UseVisualStyleBackColor = false;
			this.buttonProfile.Click += new System.EventHandler(this.ButtonProfile_Click);
			// 
			// pictureBoxShowSettings
			// 
			this.pictureBoxShowSettings.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxShowSettings.Image = global::TicTacToe.Properties.Resources.eyeOpen;
			this.pictureBoxShowSettings.Location = new System.Drawing.Point(270, 155);
			this.pictureBoxShowSettings.Name = "pictureBoxShowSettings";
			this.pictureBoxShowSettings.Size = new System.Drawing.Size(30, 30);
			this.pictureBoxShowSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxShowSettings.TabIndex = 4;
			this.pictureBoxShowSettings.TabStop = false;
			this.pictureBoxShowSettings.Click += new System.EventHandler(this.PictureBoxShowSettings_Click);
			// 
			// numericUpDownNumberOfRounds
			// 
			this.numericUpDownNumberOfRounds.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDownNumberOfRounds.Location = new System.Drawing.Point(201, 353);
			this.numericUpDownNumberOfRounds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownNumberOfRounds.Name = "numericUpDownNumberOfRounds";
			this.numericUpDownNumberOfRounds.Size = new System.Drawing.Size(75, 29);
			this.numericUpDownNumberOfRounds.TabIndex = 11;
			this.numericUpDownNumberOfRounds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownNumberOfRounds.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// labelImpossible
			// 
			this.labelImpossible.BackColor = System.Drawing.Color.LightSteelBlue;
			this.labelImpossible.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelImpossible.ForeColor = System.Drawing.Color.Black;
			this.labelImpossible.Location = new System.Drawing.Point(9, 309);
			this.labelImpossible.Name = "labelImpossible";
			this.labelImpossible.Size = new System.Drawing.Size(167, 27);
			this.labelImpossible.TabIndex = 9;
			this.labelImpossible.Text = "Impossible";
			this.labelImpossible.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labelImpossible.Click += new System.EventHandler(this.LabelDifficulty_Click);
			this.labelImpossible.MouseEnter += new System.EventHandler(this.LabelDifficulty_MouseEnter);
			this.labelImpossible.MouseLeave += new System.EventHandler(this.LabelDifficulty_MouseLeave);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.BackgroundImage = global::TicTacToe.Properties.Resources.background1;
			this.ClientSize = new System.Drawing.Size(818, 761);
			this.Controls.Add(this.labelImpossible);
			this.Controls.Add(this.numericUpDownNumberOfRounds);
			this.Controls.Add(this.pictureBoxShowSettings);
			this.Controls.Add(this.buttonProfile);
			this.Controls.Add(this.buttonShop);
			this.Controls.Add(this.labelPlayerName);
			this.Controls.Add(this.pictureBoxAvatar);
			this.Controls.Add(this.labelNumberOfRounds);
			this.Controls.Add(this.buttonExit);
			this.Controls.Add(this.labelDifficult);
			this.Controls.Add(this.labelHard);
			this.Controls.Add(this.labelMedium);
			this.Controls.Add(this.labelEasy);
			this.Controls.Add(this.labelAuthor);
			this.Controls.Add(this.labelPoints);
			this.Controls.Add(this.buttonPlay);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Tic Tac Toe";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.VisibleChanged += new System.EventHandler(this.Menu_VisibleChanged);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowSettings)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfRounds)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Label labelPoints;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelEasy;
        private System.Windows.Forms.Label labelMedium;
        private System.Windows.Forms.Label labelHard;
        private System.Windows.Forms.Label labelDifficult;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelNumberOfRounds;
        private System.Windows.Forms.Label labelPlayerName;
        private System.Windows.Forms.Button buttonShop;
        public System.Windows.Forms.PictureBox pictureBoxAvatar;
		private System.Windows.Forms.Button buttonProfile;
		public System.Windows.Forms.PictureBox pictureBoxShowSettings;
		private System.Windows.Forms.NumericUpDown numericUpDownNumberOfRounds;
		private System.Windows.Forms.Label labelImpossible;
	}
}

