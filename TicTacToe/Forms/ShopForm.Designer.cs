namespace TicTacToe.Forms
{
    partial class ShopForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShopForm));
			this.labelPoints = new System.Windows.Forms.Label();
			this.labelBackMenu = new System.Windows.Forms.Label();
			this.labelAvatar = new System.Windows.Forms.Label();
			this.labelBackGame = new System.Windows.Forms.Label();
			this.flpBackMenu = new System.Windows.Forms.FlowLayoutPanel();
			this.flpAvatar = new System.Windows.Forms.FlowLayoutPanel();
			this.flpBackGame = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// labelPoints
			// 
			this.labelPoints.BackColor = System.Drawing.Color.Khaki;
			this.labelPoints.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelPoints.ForeColor = System.Drawing.Color.Black;
			this.labelPoints.Location = new System.Drawing.Point(966, 9);
			this.labelPoints.Name = "labelPoints";
			this.labelPoints.Size = new System.Drawing.Size(206, 31);
			this.labelPoints.TabIndex = 0;
			this.labelPoints.Text = "99999";
			this.labelPoints.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelBackMenu
			// 
			this.labelBackMenu.AutoSize = true;
			this.labelBackMenu.BackColor = System.Drawing.Color.Transparent;
			this.labelBackMenu.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelBackMenu.Location = new System.Drawing.Point(32, 50);
			this.labelBackMenu.Name = "labelBackMenu";
			this.labelBackMenu.Size = new System.Drawing.Size(249, 35);
			this.labelBackMenu.TabIndex = 1;
			this.labelBackMenu.Text = "Menu background:";
			// 
			// labelAvatar
			// 
			this.labelAvatar.AutoSize = true;
			this.labelAvatar.BackColor = System.Drawing.Color.Transparent;
			this.labelAvatar.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelAvatar.Location = new System.Drawing.Point(32, 477);
			this.labelAvatar.Name = "labelAvatar";
			this.labelAvatar.Size = new System.Drawing.Size(108, 35);
			this.labelAvatar.TabIndex = 3;
			this.labelAvatar.Text = "Avatar:";
			// 
			// labelBackGame
			// 
			this.labelBackGame.AutoSize = true;
			this.labelBackGame.BackColor = System.Drawing.Color.Transparent;
			this.labelBackGame.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelBackGame.Location = new System.Drawing.Point(32, 886);
			this.labelBackGame.Name = "labelBackGame";
			this.labelBackGame.Size = new System.Drawing.Size(252, 35);
			this.labelBackGame.TabIndex = 5;
			this.labelBackGame.Text = "Game background:";
			// 
			// flpBackMenu
			// 
			this.flpBackMenu.AutoScroll = true;
			this.flpBackMenu.BackColor = System.Drawing.Color.CornflowerBlue;
			this.flpBackMenu.Location = new System.Drawing.Point(38, 88);
			this.flpBackMenu.Name = "flpBackMenu";
			this.flpBackMenu.Size = new System.Drawing.Size(1040, 320);
			this.flpBackMenu.TabIndex = 2;
			// 
			// flpAvatar
			// 
			this.flpAvatar.AutoScroll = true;
			this.flpAvatar.BackColor = System.Drawing.Color.CornflowerBlue;
			this.flpAvatar.Location = new System.Drawing.Point(38, 515);
			this.flpAvatar.Name = "flpAvatar";
			this.flpAvatar.Size = new System.Drawing.Size(1040, 320);
			this.flpAvatar.TabIndex = 4;
			// 
			// flpBackGame
			// 
			this.flpBackGame.AutoScroll = true;
			this.flpBackGame.BackColor = System.Drawing.Color.CornflowerBlue;
			this.flpBackGame.Location = new System.Drawing.Point(38, 924);
			this.flpBackGame.Name = "flpBackGame";
			this.flpBackGame.Size = new System.Drawing.Size(1040, 320);
			this.flpBackGame.TabIndex = 6;
			// 
			// ShopForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.SteelBlue;
			this.ClientSize = new System.Drawing.Size(1201, 761);
			this.Controls.Add(this.flpBackGame);
			this.Controls.Add(this.flpAvatar);
			this.Controls.Add(this.flpBackMenu);
			this.Controls.Add(this.labelBackGame);
			this.Controls.Add(this.labelAvatar);
			this.Controls.Add(this.labelBackMenu);
			this.Controls.Add(this.labelPoints);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ShopForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Shop";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Shop_FormClosed);
			this.Load += new System.EventHandler(this.ShopForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPoints;
        private System.Windows.Forms.Label labelBackMenu;
        private System.Windows.Forms.Label labelAvatar;
        private System.Windows.Forms.Label labelBackGame;
		private System.Windows.Forms.FlowLayoutPanel flpBackMenu;
		private System.Windows.Forms.FlowLayoutPanel flpAvatar;
		private System.Windows.Forms.FlowLayoutPanel flpBackGame;
	}
}