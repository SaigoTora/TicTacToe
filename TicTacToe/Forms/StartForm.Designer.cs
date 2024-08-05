namespace TicTacToe.Forms
{
    partial class StartForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
			this.labelGreeting = new System.Windows.Forms.Label();
			this.labelName = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.labelAvatar = new System.Windows.Forms.Label();
			this.pictureBoxWoman = new System.Windows.Forms.PictureBox();
			this.pictureBoxMan = new System.Windows.Forms.PictureBox();
			this.buttonReady = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxWoman)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxMan)).BeginInit();
			this.SuspendLayout();
			// 
			// labelGreeting
			// 
			this.labelGreeting.AutoSize = true;
			this.labelGreeting.Font = new System.Drawing.Font("Trebuchet MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelGreeting.Location = new System.Drawing.Point(12, 9);
			this.labelGreeting.Name = "labelGreeting";
			this.labelGreeting.Size = new System.Drawing.Size(530, 40);
			this.labelGreeting.TabIndex = 0;
			this.labelGreeting.Text = "Welcome to the game \"Tic Tac Toe\"!";
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelName.Location = new System.Drawing.Point(120, 111);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(210, 27);
			this.labelName.TabIndex = 1;
			this.labelName.Text = "Enter your nickname:";
			// 
			// textBoxName
			// 
			this.textBoxName.BackColor = System.Drawing.Color.MintCream;
			this.textBoxName.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxName.ForeColor = System.Drawing.Color.Black;
			this.textBoxName.Location = new System.Drawing.Point(336, 107);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(250, 31);
			this.textBoxName.TabIndex = 2;
			// 
			// labelAvatar
			// 
			this.labelAvatar.AutoSize = true;
			this.labelAvatar.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelAvatar.Location = new System.Drawing.Point(159, 159);
			this.labelAvatar.Name = "labelAvatar";
			this.labelAvatar.Size = new System.Drawing.Size(171, 27);
			this.labelAvatar.TabIndex = 3;
			this.labelAvatar.Text = "Select an avatar:";
			// 
			// pictureBoxWoman
			// 
			this.pictureBoxWoman.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxWoman.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBoxWoman.Image = global::TicTacToe.Properties.Resources.womanAvatar1;
			this.pictureBoxWoman.Location = new System.Drawing.Point(516, 159);
			this.pictureBoxWoman.Name = "pictureBoxWoman";
			this.pictureBoxWoman.Size = new System.Drawing.Size(150, 150);
			this.pictureBoxWoman.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxWoman.TabIndex = 5;
			this.pictureBoxWoman.TabStop = false;
			this.pictureBoxWoman.Click += new System.EventHandler(this.PictureBoxAvatar_Click);
			// 
			// pictureBoxMan
			// 
			this.pictureBoxMan.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxMan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBoxMan.Image = global::TicTacToe.Properties.Resources.manAvatar1;
			this.pictureBoxMan.Location = new System.Drawing.Point(336, 159);
			this.pictureBoxMan.Name = "pictureBoxMan";
			this.pictureBoxMan.Size = new System.Drawing.Size(150, 150);
			this.pictureBoxMan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxMan.TabIndex = 4;
			this.pictureBoxMan.TabStop = false;
			this.pictureBoxMan.Click += new System.EventHandler(this.PictureBoxAvatar_Click);
			// 
			// buttonReady
			// 
			this.buttonReady.BackColor = System.Drawing.Color.LightGreen;
			this.buttonReady.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonReady.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonReady.Location = new System.Drawing.Point(40, 259);
			this.buttonReady.Name = "buttonReady";
			this.buttonReady.Size = new System.Drawing.Size(250, 50);
			this.buttonReady.TabIndex = 6;
			this.buttonReady.Text = "Ready";
			this.buttonReady.UseVisualStyleBackColor = false;
			this.buttonReady.Click += new System.EventHandler(this.ButtonReady_Click);
			// 
			// StartForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(704, 321);
			this.Controls.Add(this.buttonReady);
			this.Controls.Add(this.pictureBoxWoman);
			this.Controls.Add(this.pictureBoxMan);
			this.Controls.Add(this.labelAvatar);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.labelGreeting);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "StartForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Welcome";
			this.Load += new System.EventHandler(this.StartForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxWoman)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxMan)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGreeting;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelAvatar;
        private System.Windows.Forms.PictureBox pictureBoxMan;
        private System.Windows.Forms.PictureBox pictureBoxWoman;
        private System.Windows.Forms.Button buttonReady;
    }
}