namespace TicTacToe.Forms.Game.Games3on3
{
	partial class Game3on3NetworkForm
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
			this.SuspendLayout();
			// 
			// Game3on3NetworkForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(618, 822);
			this.Name = "Game3on3NetworkForm";
			this.Text = "Game3on3NetworkForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Game3on3NetworkForm_FormClosed);
			this.Load += new System.EventHandler(this.Game3on3NetworkForm_Load);
			this.ResumeLayout(false);

		}

		#endregion
	}
}