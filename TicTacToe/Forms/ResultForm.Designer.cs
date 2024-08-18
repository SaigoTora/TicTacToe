namespace TicTacToe.Forms
{
	partial class ResultForm
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
			this.labelResult = new System.Windows.Forms.Label();
			this.labelCoinsResult = new System.Windows.Forms.Label();
			this.labelDifficultTitle = new System.Windows.Forms.Label();
			this.labelDifficult = new System.Windows.Forms.Label();
			this.labelCurrentCoinsTitle = new System.Windows.Forms.Label();
			this.labelTimeToClose = new System.Windows.Forms.Label();
			this.guna2BorderlessForm = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
			this.pictureBoxCoin = new System.Windows.Forms.PictureBox();
			this.labelCurrentCoins = new System.Windows.Forms.Label();
			this.buttonBack = new Guna.UI2.WinForms.Guna2GradientButton();
			this.buttonPlay = new Guna.UI2.WinForms.Guna2GradientButton();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoin)).BeginInit();
			this.SuspendLayout();
			// 
			// labelResult
			// 
			this.labelResult.Font = new System.Drawing.Font("Trebuchet MS", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelResult.ForeColor = System.Drawing.Color.White;
			this.labelResult.Location = new System.Drawing.Point(125, 9);
			this.labelResult.Name = "labelResult";
			this.labelResult.Size = new System.Drawing.Size(250, 50);
			this.labelResult.TabIndex = 0;
			this.labelResult.Text = "Draw!";
			this.labelResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// labelCoinsResult
			// 
			this.labelCoinsResult.AutoSize = true;
			this.labelCoinsResult.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCoinsResult.ForeColor = System.Drawing.Color.Lime;
			this.labelCoinsResult.Location = new System.Drawing.Point(381, 23);
			this.labelCoinsResult.Name = "labelCoinsResult";
			this.labelCoinsResult.Size = new System.Drawing.Size(91, 36);
			this.labelCoinsResult.TabIndex = 1;
			this.labelCoinsResult.Text = "+999";
			// 
			// labelDifficultTitle
			// 
			this.labelDifficultTitle.AutoSize = true;
			this.labelDifficultTitle.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDifficultTitle.ForeColor = System.Drawing.Color.White;
			this.labelDifficultTitle.Location = new System.Drawing.Point(138, 125);
			this.labelDifficultTitle.Name = "labelDifficultTitle";
			this.labelDifficultTitle.Size = new System.Drawing.Size(138, 35);
			this.labelDifficultTitle.TabIndex = 2;
			this.labelDifficultTitle.Text = "Difficulty:";
			// 
			// labelDifficult
			// 
			this.labelDifficult.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDifficult.ForeColor = System.Drawing.Color.White;
			this.labelDifficult.Location = new System.Drawing.Point(276, 125);
			this.labelDifficult.Name = "labelDifficult";
			this.labelDifficult.Size = new System.Drawing.Size(198, 35);
			this.labelDifficult.TabIndex = 3;
			this.labelDifficult.Text = "Impossible";
			this.labelDifficult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelCurrentCoinsTitle
			// 
			this.labelCurrentCoinsTitle.AutoSize = true;
			this.labelCurrentCoinsTitle.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCurrentCoinsTitle.ForeColor = System.Drawing.Color.White;
			this.labelCurrentCoinsTitle.Location = new System.Drawing.Point(12, 175);
			this.labelCurrentCoinsTitle.Name = "labelCurrentCoinsTitle";
			this.labelCurrentCoinsTitle.Size = new System.Drawing.Size(264, 35);
			this.labelCurrentCoinsTitle.TabIndex = 4;
			this.labelCurrentCoinsTitle.Text = "Current coins count:";
			// 
			// labelTimeToClose
			// 
			this.labelTimeToClose.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.labelTimeToClose.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelTimeToClose.ForeColor = System.Drawing.Color.White;
			this.labelTimeToClose.Location = new System.Drawing.Point(0, 380);
			this.labelTimeToClose.Name = "labelTimeToClose";
			this.labelTimeToClose.Size = new System.Drawing.Size(500, 40);
			this.labelTimeToClose.TabIndex = 9;
			this.labelTimeToClose.Text = "This window will close in: 60 sec.";
			this.labelTimeToClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
			// pictureBoxCoin
			// 
			this.pictureBoxCoin.Image = global::TicTacToe.Properties.Resources.coin;
			this.pictureBoxCoin.Location = new System.Drawing.Point(282, 172);
			this.pictureBoxCoin.Name = "pictureBoxCoin";
			this.pictureBoxCoin.Size = new System.Drawing.Size(37, 37);
			this.pictureBoxCoin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxCoin.TabIndex = 5;
			this.pictureBoxCoin.TabStop = false;
			// 
			// labelCurrentCoins
			// 
			this.labelCurrentCoins.BackColor = System.Drawing.Color.Transparent;
			this.labelCurrentCoins.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCurrentCoins.ForeColor = System.Drawing.Color.Khaki;
			this.labelCurrentCoins.Location = new System.Drawing.Point(325, 177);
			this.labelCurrentCoins.Name = "labelCurrentCoins";
			this.labelCurrentCoins.Size = new System.Drawing.Size(149, 27);
			this.labelCurrentCoins.TabIndex = 6;
			this.labelCurrentCoins.Text = "999 999";
			this.labelCurrentCoins.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonBack
			// 
			this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBack.Animated = true;
			this.buttonBack.BackColor = System.Drawing.Color.Transparent;
			this.buttonBack.BorderRadius = 20;
			this.buttonBack.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.buttonBack.BorderThickness = 1;
			this.buttonBack.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.buttonBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.buttonBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonBack.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.buttonBack.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(24)))), ((int)(((byte)(13)))));
			this.buttonBack.FillColor2 = System.Drawing.Color.Maroon;
			this.buttonBack.Font = new System.Drawing.Font("Cooper Black", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonBack.ForeColor = System.Drawing.Color.White;
			this.buttonBack.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonBack.Location = new System.Drawing.Point(22, 300);
			this.buttonBack.Name = "buttonBack";
			this.buttonBack.Size = new System.Drawing.Size(200, 50);
			this.buttonBack.TabIndex = 7;
			this.buttonBack.TabStop = false;
			this.buttonBack.Text = "Back";
			// 
			// buttonPlay
			// 
			this.buttonPlay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
			this.buttonPlay.Location = new System.Drawing.Point(278, 300);
			this.buttonPlay.Name = "buttonPlay";
			this.buttonPlay.Size = new System.Drawing.Size(200, 50);
			this.buttonPlay.TabIndex = 8;
			this.buttonPlay.TabStop = false;
			this.buttonPlay.Text = "Play";
			this.buttonPlay.Click += new System.EventHandler(this.ButtonPlay_Click);
			// 
			// ResultForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
			this.ClientSize = new System.Drawing.Size(500, 420);
			this.Controls.Add(this.buttonPlay);
			this.Controls.Add(this.buttonBack);
			this.Controls.Add(this.pictureBoxCoin);
			this.Controls.Add(this.labelCurrentCoins);
			this.Controls.Add(this.labelTimeToClose);
			this.Controls.Add(this.labelCurrentCoinsTitle);
			this.Controls.Add(this.labelDifficult);
			this.Controls.Add(this.labelDifficultTitle);
			this.Controls.Add(this.labelCoinsResult);
			this.Controls.Add(this.labelResult);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ResultForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.TopMost = true;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ResultForm_FormClosed);
			this.Load += new System.EventHandler(this.ResultForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoin)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelResult;
		private System.Windows.Forms.Label labelCoinsResult;
		private System.Windows.Forms.Label labelDifficultTitle;
		private System.Windows.Forms.Label labelDifficult;
		private System.Windows.Forms.Label labelCurrentCoinsTitle;
		private System.Windows.Forms.Label labelTimeToClose;
		private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm;
		private System.Windows.Forms.PictureBox pictureBoxCoin;
		private System.Windows.Forms.Label labelCurrentCoins;
		private Guna.UI2.WinForms.Guna2GradientButton buttonBack;
		private Guna.UI2.WinForms.Guna2GradientButton buttonPlay;
	}
}