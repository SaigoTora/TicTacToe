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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
			this.labelGreeting = new System.Windows.Forms.Label();
			this.labelName = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.labelAvatar = new System.Windows.Forms.Label();
			this.pictureBoxMan = new System.Windows.Forms.PictureBox();
			this.pictureBoxWoman = new System.Windows.Forms.PictureBox();
			this.guna2BorderlessForm = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.buttonReady = new Guna.UI2.WinForms.Guna2GradientButton();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxMan)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxWoman)).BeginInit();
			this.SuspendLayout();
			// 
			// labelGreeting
			// 
			this.labelGreeting.BackColor = System.Drawing.Color.Transparent;
			this.labelGreeting.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelGreeting.Font = new System.Drawing.Font("Unispace", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelGreeting.ForeColor = System.Drawing.Color.White;
			this.labelGreeting.Location = new System.Drawing.Point(0, 0);
			this.labelGreeting.Name = "labelGreeting";
			this.labelGreeting.Size = new System.Drawing.Size(944, 60);
			this.labelGreeting.TabIndex = 0;
			this.labelGreeting.Text = "Welcome to the game Tic Tac Toe!";
			this.labelGreeting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.BackColor = System.Drawing.Color.Transparent;
			this.labelName.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelName.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelName.ForeColor = System.Drawing.Color.White;
			this.labelName.Location = new System.Drawing.Point(58, 148);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(244, 29);
			this.labelName.TabIndex = 1;
			this.labelName.Text = "Enter your nickname:";
			this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labelName.Click += new System.EventHandler(this.LabelName_Click);
			this.labelName.MouseEnter += new System.EventHandler(this.LabelName_MouseEnter);
			this.labelName.MouseLeave += new System.EventHandler(this.LabelName_MouseLeave);
			// 
			// textBoxName
			// 
			this.textBoxName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBoxName.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxName.ForeColor = System.Drawing.Color.White;
			this.textBoxName.Location = new System.Drawing.Point(322, 147);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(300, 32);
			this.textBoxName.TabIndex = 2;
			this.textBoxName.TabStop = false;
			this.textBoxName.Enter += new System.EventHandler(this.TextBoxName_Enter);
			this.textBoxName.Leave += new System.EventHandler(this.TextBoxName_Leave);
			// 
			// labelAvatar
			// 
			this.labelAvatar.BackColor = System.Drawing.Color.Transparent;
			this.labelAvatar.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelAvatar.ForeColor = System.Drawing.Color.White;
			this.labelAvatar.Location = new System.Drawing.Point(307, 220);
			this.labelAvatar.Name = "labelAvatar";
			this.labelAvatar.Size = new System.Drawing.Size(330, 40);
			this.labelAvatar.TabIndex = 3;
			this.labelAvatar.Text = "Select an avatar:";
			this.labelAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pictureBoxMan
			// 
			this.pictureBoxMan.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxMan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBoxMan.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBoxMan.Image = global::TicTacToe.Properties.Resources.manAvatar1;
			this.pictureBoxMan.Location = new System.Drawing.Point(307, 261);
			this.pictureBoxMan.Name = "pictureBoxMan";
			this.pictureBoxMan.Size = new System.Drawing.Size(150, 150);
			this.pictureBoxMan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxMan.TabIndex = 4;
			this.pictureBoxMan.TabStop = false;
			this.pictureBoxMan.Click += new System.EventHandler(this.PictureBoxAvatar_Click);
			// 
			// pictureBoxWoman
			// 
			this.pictureBoxWoman.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxWoman.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBoxWoman.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBoxWoman.Image = global::TicTacToe.Properties.Resources.womanAvatar1;
			this.pictureBoxWoman.Location = new System.Drawing.Point(487, 261);
			this.pictureBoxWoman.Name = "pictureBoxWoman";
			this.pictureBoxWoman.Size = new System.Drawing.Size(150, 150);
			this.pictureBoxWoman.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxWoman.TabIndex = 5;
			this.pictureBoxWoman.TabStop = false;
			this.pictureBoxWoman.Click += new System.EventHandler(this.PictureBoxAvatar_Click);
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
			// buttonReady
			// 
			this.buttonReady.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
			this.buttonReady.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(239)))), ((int)(((byte)(125)))));
			this.buttonReady.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(153)))), ((int)(((byte)(142)))));
			this.buttonReady.Font = new System.Drawing.Font("Cooper Black", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonReady.ForeColor = System.Drawing.Color.White;
			this.buttonReady.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonReady.Location = new System.Drawing.Point(362, 500);
			this.buttonReady.Name = "buttonReady";
			this.buttonReady.Size = new System.Drawing.Size(220, 50);
			this.buttonReady.TabIndex = 6;
			this.buttonReady.TabStop = false;
			this.buttonReady.Text = "Ready";
			this.buttonReady.Click += new System.EventHandler(this.ButtonReady_Click);
			// 
			// StartForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(944, 601);
			this.Controls.Add(this.buttonReady);
			this.Controls.Add(this.pictureBoxWoman);
			this.Controls.Add(this.pictureBoxMan);
			this.Controls.Add(this.labelAvatar);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.labelGreeting);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.Name = "StartForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StartForm_FormClosed);
			this.Load += new System.EventHandler(this.StartForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxMan)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxWoman)).EndInit();
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
		private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm;
		private Guna.UI2.WinForms.Guna2GradientButton buttonReady;
	}
}