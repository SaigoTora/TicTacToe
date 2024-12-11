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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartNetworkGameForm));
			this.buttonCreateGame = new Guna.UI2.WinForms.Guna2GradientButton();
			this.flpLobbyPreviews = new System.Windows.Forms.FlowLayoutPanel();
			this.buttonJoin = new Guna.UI2.WinForms.Guna2GradientButton();
			this.buttonRefresh = new FontAwesome.Sharp.IconButton();
			this.SuspendLayout();
			// 
			// buttonCreateGame
			// 
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
			this.buttonCreateGame.Location = new System.Drawing.Point(12, 438);
			this.buttonCreateGame.Name = "buttonCreateGame";
			this.buttonCreateGame.Size = new System.Drawing.Size(200, 50);
			this.buttonCreateGame.TabIndex = 3;
			this.buttonCreateGame.TabStop = false;
			this.buttonCreateGame.Text = "Create";
			this.buttonCreateGame.Click += new System.EventHandler(this.ButtonCreateGame_Click);
			// 
			// flpLobbyPreviews
			// 
			this.flpLobbyPreviews.AutoScroll = true;
			this.flpLobbyPreviews.BackColor = System.Drawing.Color.Transparent;
			this.flpLobbyPreviews.Location = new System.Drawing.Point(12, 53);
			this.flpLobbyPreviews.Name = "flpLobbyPreviews";
			this.flpLobbyPreviews.Size = new System.Drawing.Size(776, 350);
			this.flpLobbyPreviews.TabIndex = 0;
			this.flpLobbyPreviews.Tag = "needToMoveParentDown";
			// 
			// buttonJoin
			// 
			this.buttonJoin.Animated = true;
			this.buttonJoin.BackColor = System.Drawing.Color.Transparent;
			this.buttonJoin.BorderRadius = 20;
			this.buttonJoin.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.buttonJoin.BorderThickness = 1;
			this.buttonJoin.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonJoin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.buttonJoin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.buttonJoin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonJoin.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonJoin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.buttonJoin.Enabled = false;
			this.buttonJoin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(239)))), ((int)(((byte)(125)))));
			this.buttonJoin.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(153)))), ((int)(((byte)(142)))));
			this.buttonJoin.Font = new System.Drawing.Font("Cooper Black", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonJoin.ForeColor = System.Drawing.Color.White;
			this.buttonJoin.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonJoin.Location = new System.Drawing.Point(588, 438);
			this.buttonJoin.Name = "buttonJoin";
			this.buttonJoin.Size = new System.Drawing.Size(200, 50);
			this.buttonJoin.TabIndex = 10;
			this.buttonJoin.TabStop = false;
			this.buttonJoin.Text = "Join";
			this.buttonJoin.Click += new System.EventHandler(this.ButtonJoin_Click);
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.buttonRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonRefresh.FlatAppearance.BorderSize = 0;
			this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRefresh.IconChar = FontAwesome.Sharp.IconChar.RotateForward;
			this.buttonRefresh.IconColor = System.Drawing.Color.White;
			this.buttonRefresh.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.buttonRefresh.IconSize = 35;
			this.buttonRefresh.Location = new System.Drawing.Point(12, 12);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(35, 35);
			this.buttonRefresh.TabIndex = 11;
			this.buttonRefresh.TabStop = false;
			this.buttonRefresh.UseVisualStyleBackColor = false;
			this.buttonRefresh.Visible = false;
			this.buttonRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
			// 
			// StartNetworkGameForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.ClientSize = new System.Drawing.Size(800, 500);
			this.Controls.Add(this.buttonRefresh);
			this.Controls.Add(this.buttonJoin);
			this.Controls.Add(this.flpLobbyPreviews);
			this.Controls.Add(this.buttonCreateGame);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "StartNetworkGameForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StartNetworkGameForm_FormClosed);
			this.Load += new System.EventHandler(this.StartNetworkGameForm_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StartNetworkGameForm_KeyDown);
			this.ResumeLayout(false);

		}

		#endregion

		private Guna.UI2.WinForms.Guna2GradientButton buttonCreateGame;
		private System.Windows.Forms.FlowLayoutPanel flpLobbyPreviews;
		private Guna.UI2.WinForms.Guna2GradientButton buttonJoin;
		private FontAwesome.Sharp.IconButton buttonRefresh;
	}
}