namespace TicTacToe.Forms.Game.Games5on5
{
	partial class Game5on5NetworkForm
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
			// Game5on5NetworkForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(825, 1010);
			this.Name = "Game5on5NetworkForm";
			this.Text = "Game5on5NetworkForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Game5on5NetworkForm_FormClosed);
			this.Load += new System.EventHandler(this.Game5on5NetworkForm_Load);
			this.ResumeLayout(false);

		}

		#endregion
	}
}