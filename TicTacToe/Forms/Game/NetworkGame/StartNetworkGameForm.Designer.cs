namespace TicTacToe.Forms.Game.NetworkGame
{
	partial class StartNetworkGameForm
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
			this.buttonCreateGame = new Guna.UI2.WinForms.Guna2GradientButton();
			this.flpLobbyPreviews = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// buttonCreateGame
			// 
			this.buttonCreateGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonCreateGame.Animated = true;
			this.buttonCreateGame.AutoRoundedCorners = true;
			this.buttonCreateGame.BackColor = System.Drawing.Color.Transparent;
			this.buttonCreateGame.BorderRadius = 24;
			this.buttonCreateGame.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.buttonCreateGame.BorderThickness = 1;
			this.buttonCreateGame.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonCreateGame.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.buttonCreateGame.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.buttonCreateGame.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonCreateGame.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonCreateGame.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.buttonCreateGame.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(168)))), ((int)(((byte)(23)))));
			this.buttonCreateGame.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(176)))), ((int)(((byte)(46)))));
			this.buttonCreateGame.Font = new System.Drawing.Font("Cooper Black", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonCreateGame.ForeColor = System.Drawing.Color.White;
			this.buttonCreateGame.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonCreateGame.Location = new System.Drawing.Point(12, 388);
			this.buttonCreateGame.Name = "buttonCreateGame";
			this.buttonCreateGame.Size = new System.Drawing.Size(200, 50);
			this.buttonCreateGame.TabIndex = 3;
			this.buttonCreateGame.TabStop = false;
			this.buttonCreateGame.Text = "Create";
			this.buttonCreateGame.Click += new System.EventHandler(this.ButtonCreateGame_Click);
			// 
			// flpLobbyPreviews
			// 
			this.flpLobbyPreviews.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flpLobbyPreviews.AutoScroll = true;
			this.flpLobbyPreviews.BackColor = System.Drawing.Color.DarkGray;
			this.flpLobbyPreviews.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flpLobbyPreviews.Location = new System.Drawing.Point(12, 12);
			this.flpLobbyPreviews.Name = "flpLobbyPreviews";
			this.flpLobbyPreviews.Size = new System.Drawing.Size(776, 317);
			this.flpLobbyPreviews.TabIndex = 0;
			// 
			// StartNetworkGameForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.flpLobbyPreviews);
			this.Controls.Add(this.buttonCreateGame);
			this.Name = "StartNetworkGameForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StartNetworkGameForm_FormClosed);
			this.Load += new System.EventHandler(this.StartNetworkGameForm_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private Guna.UI2.WinForms.Guna2GradientButton buttonCreateGame;
		private System.Windows.Forms.FlowLayoutPanel flpLobbyPreviews;
	}
}