namespace TicTacToe.Forms.Game.Games7on7
{
	partial class Game7on7NetworkForm
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
			// Game7on7NetworkForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(750, 955);
			this.Name = "Game7on7NetworkForm";
			this.Text = "Game7on7NetworkForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Game7on7NetworkForm_FormClosed);
			this.Load += new System.EventHandler(this.Game7on7NetworkForm_Load);
			this.ResumeLayout(false);

		}

		#endregion
	}
}