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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultForm));
			this.labelResult = new System.Windows.Forms.Label();
			this.labelCoinsResult = new System.Windows.Forms.Label();
			this.labelDifficultTitle = new System.Windows.Forms.Label();
			this.labelDifficult = new System.Windows.Forms.Label();
			this.labelCurrentCoinsTitle = new System.Windows.Forms.Label();
			this.labelCurrentCoins = new System.Windows.Forms.Label();
			this.labelTimeToClose = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// labelResult
			// 
			this.labelResult.AutoSize = true;
			this.labelResult.Font = new System.Drawing.Font("Trebuchet MS", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelResult.ForeColor = System.Drawing.Color.Black;
			this.labelResult.Location = new System.Drawing.Point(12, 9);
			this.labelResult.Name = "labelResult";
			this.labelResult.Size = new System.Drawing.Size(298, 49);
			this.labelResult.TabIndex = 0;
			this.labelResult.Text = "Win/Loss/Draw";
			// 
			// labelCoinsResult
			// 
			this.labelCoinsResult.AutoSize = true;
			this.labelCoinsResult.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCoinsResult.ForeColor = System.Drawing.Color.Lime;
			this.labelCoinsResult.Location = new System.Drawing.Point(367, 22);
			this.labelCoinsResult.Name = "labelCoinsResult";
			this.labelCoinsResult.Size = new System.Drawing.Size(91, 36);
			this.labelCoinsResult.TabIndex = 1;
			this.labelCoinsResult.Text = "+100";
			// 
			// labelDifficultTitle
			// 
			this.labelDifficultTitle.AutoSize = true;
			this.labelDifficultTitle.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDifficultTitle.ForeColor = System.Drawing.Color.Black;
			this.labelDifficultTitle.Location = new System.Drawing.Point(12, 125);
			this.labelDifficultTitle.Name = "labelDifficultTitle";
			this.labelDifficultTitle.Size = new System.Drawing.Size(138, 35);
			this.labelDifficultTitle.TabIndex = 2;
			this.labelDifficultTitle.Text = "Difficulty:";
			// 
			// labelDifficult
			// 
			this.labelDifficult.AutoSize = true;
			this.labelDifficult.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDifficult.ForeColor = System.Drawing.Color.Black;
			this.labelDifficult.Location = new System.Drawing.Point(178, 125);
			this.labelDifficult.Name = "labelDifficult";
			this.labelDifficult.Size = new System.Drawing.Size(67, 35);
			this.labelDifficult.TabIndex = 3;
			this.labelDifficult.Text = "Easy";
			// 
			// labelCurrentCoinsTitle
			// 
			this.labelCurrentCoinsTitle.AutoSize = true;
			this.labelCurrentCoinsTitle.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCurrentCoinsTitle.ForeColor = System.Drawing.Color.Black;
			this.labelCurrentCoinsTitle.Location = new System.Drawing.Point(12, 175);
			this.labelCurrentCoinsTitle.Name = "labelCurrentCoinsTitle";
			this.labelCurrentCoinsTitle.Size = new System.Drawing.Size(277, 35);
			this.labelCurrentCoinsTitle.TabIndex = 4;
			this.labelCurrentCoinsTitle.Text = "Current coins count:";
			// 
			// labelCurrentCoins
			// 
			this.labelCurrentCoins.AutoSize = true;
			this.labelCurrentCoins.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCurrentCoins.ForeColor = System.Drawing.Color.Khaki;
			this.labelCurrentCoins.Location = new System.Drawing.Point(324, 175);
			this.labelCurrentCoins.Name = "labelCurrentCoins";
			this.labelCurrentCoins.Size = new System.Drawing.Size(72, 36);
			this.labelCurrentCoins.TabIndex = 5;
			this.labelCurrentCoins.Text = "999";
			// 
			// labelTimeToClose
			// 
			this.labelTimeToClose.AutoSize = true;
			this.labelTimeToClose.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelTimeToClose.ForeColor = System.Drawing.Color.Black;
			this.labelTimeToClose.Location = new System.Drawing.Point(12, 300);
			this.labelTimeToClose.Name = "labelTimeToClose";
			this.labelTimeToClose.Size = new System.Drawing.Size(361, 29);
			this.labelTimeToClose.TabIndex = 6;
			this.labelTimeToClose.Text = "This window will close in: 7 sec.";
			// 
			// ResultForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(470, 350);
			this.Controls.Add(this.labelTimeToClose);
			this.Controls.Add(this.labelCurrentCoins);
			this.Controls.Add(this.labelCurrentCoinsTitle);
			this.Controls.Add(this.labelDifficult);
			this.Controls.Add(this.labelDifficultTitle);
			this.Controls.Add(this.labelCoinsResult);
			this.Controls.Add(this.labelResult);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ResultForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Results";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.ResultForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelResult;
		private System.Windows.Forms.Label labelCoinsResult;
		private System.Windows.Forms.Label labelDifficultTitle;
		private System.Windows.Forms.Label labelDifficult;
		private System.Windows.Forms.Label labelCurrentCoinsTitle;
		private System.Windows.Forms.Label labelCurrentCoins;
		private System.Windows.Forms.Label labelTimeToClose;
	}
}