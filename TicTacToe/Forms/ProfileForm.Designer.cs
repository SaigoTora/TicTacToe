namespace TicTacToe.Forms
{
	partial class ProfileForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileForm));
			this.labelBackgroundMenu = new System.Windows.Forms.Label();
			this.labelAvatar = new System.Windows.Forms.Label();
			this.labelBackgroundGame = new System.Windows.Forms.Label();
			this.flpBackgroundMenu = new System.Windows.Forms.FlowLayoutPanel();
			this.flpAvatar = new System.Windows.Forms.FlowLayoutPanel();
			this.flpBackgroundGame = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// labelBackgroundMenu
			// 
			this.labelBackgroundMenu.AutoSize = true;
			this.labelBackgroundMenu.BackColor = System.Drawing.Color.Transparent;
			this.labelBackgroundMenu.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelBackgroundMenu.Location = new System.Drawing.Point(32, 50);
			this.labelBackgroundMenu.Name = "labelBackgroundMenu";
			this.labelBackgroundMenu.Size = new System.Drawing.Size(249, 35);
			this.labelBackgroundMenu.TabIndex = 0;
			this.labelBackgroundMenu.Text = "Menu background:";
			// 
			// labelAvatar
			// 
			this.labelAvatar.AutoSize = true;
			this.labelAvatar.BackColor = System.Drawing.Color.Transparent;
			this.labelAvatar.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelAvatar.Location = new System.Drawing.Point(32, 477);
			this.labelAvatar.Name = "labelAvatar";
			this.labelAvatar.Size = new System.Drawing.Size(108, 35);
			this.labelAvatar.TabIndex = 2;
			this.labelAvatar.Text = "Avatar:";
			// 
			// labelBackgroundGame
			// 
			this.labelBackgroundGame.AutoSize = true;
			this.labelBackgroundGame.BackColor = System.Drawing.Color.Transparent;
			this.labelBackgroundGame.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelBackgroundGame.Location = new System.Drawing.Point(32, 886);
			this.labelBackgroundGame.Name = "labelBackgroundGame";
			this.labelBackgroundGame.Size = new System.Drawing.Size(252, 35);
			this.labelBackgroundGame.TabIndex = 4;
			this.labelBackgroundGame.Text = "Game background:";
			// 
			// flpBackgroundMenu
			// 
			this.flpBackgroundMenu.AutoScroll = true;
			this.flpBackgroundMenu.BackColor = System.Drawing.Color.CornflowerBlue;
			this.flpBackgroundMenu.Location = new System.Drawing.Point(38, 88);
			this.flpBackgroundMenu.Name = "flpBackgroundMenu";
			this.flpBackgroundMenu.Size = new System.Drawing.Size(1040, 320);
			this.flpBackgroundMenu.TabIndex = 1;
			// 
			// flpAvatar
			// 
			this.flpAvatar.AutoScroll = true;
			this.flpAvatar.BackColor = System.Drawing.Color.CornflowerBlue;
			this.flpAvatar.Location = new System.Drawing.Point(38, 515);
			this.flpAvatar.Name = "flpAvatar";
			this.flpAvatar.Size = new System.Drawing.Size(1040, 320);
			this.flpAvatar.TabIndex = 3;
			// 
			// flpBackgroundGame
			// 
			this.flpBackgroundGame.AutoScroll = true;
			this.flpBackgroundGame.BackColor = System.Drawing.Color.CornflowerBlue;
			this.flpBackgroundGame.Location = new System.Drawing.Point(38, 924);
			this.flpBackgroundGame.Name = "flpBackgroundGame";
			this.flpBackgroundGame.Size = new System.Drawing.Size(1040, 320);
			this.flpBackgroundGame.TabIndex = 5;
			// 
			// ProfileForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.SteelBlue;
			this.ClientSize = new System.Drawing.Size(1218, 761);
			this.Controls.Add(this.flpBackgroundGame);
			this.Controls.Add(this.flpAvatar);
			this.Controls.Add(this.flpBackgroundMenu);
			this.Controls.Add(this.labelBackgroundGame);
			this.Controls.Add(this.labelAvatar);
			this.Controls.Add(this.labelBackgroundMenu);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProfileForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Profile";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Shop_FormClosed);
			this.Load += new System.EventHandler(this.ProfileForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label labelBackgroundMenu;
		private System.Windows.Forms.Label labelAvatar;
		private System.Windows.Forms.Label labelBackgroundGame;
		private System.Windows.Forms.FlowLayoutPanel flpBackgroundMenu;
		private System.Windows.Forms.FlowLayoutPanel flpAvatar;
		private System.Windows.Forms.FlowLayoutPanel flpBackgroundGame;
	}
}