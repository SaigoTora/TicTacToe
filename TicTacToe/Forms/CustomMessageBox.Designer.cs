namespace TicTacToe.Forms
{
	partial class CustomMessageBox
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
			this.iconPicture = new FontAwesome.Sharp.IconPictureBox();
			this.labelText = new System.Windows.Forms.Label();
			this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
			this.button2 = new Guna.UI2.WinForms.Guna2GradientButton();
			this.button1 = new Guna.UI2.WinForms.Guna2GradientButton();
			((System.ComponentModel.ISupportInitialize)(this.iconPicture)).BeginInit();
			this.flpButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// iconPicture
			// 
			this.iconPicture.BackColor = System.Drawing.Color.Transparent;
			this.iconPicture.Dock = System.Windows.Forms.DockStyle.Left;
			this.iconPicture.IconChar = FontAwesome.Sharp.IconChar.Bug;
			this.iconPicture.IconColor = System.Drawing.Color.White;
			this.iconPicture.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconPicture.IconSize = 75;
			this.iconPicture.Location = new System.Drawing.Point(0, 0);
			this.iconPicture.Name = "iconPicture";
			this.iconPicture.Size = new System.Drawing.Size(75, 107);
			this.iconPicture.TabIndex = 0;
			this.iconPicture.TabStop = false;
			// 
			// labelText
			// 
			this.labelText.BackColor = System.Drawing.Color.Transparent;
			this.labelText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelText.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelText.ForeColor = System.Drawing.Color.White;
			this.labelText.Location = new System.Drawing.Point(75, 0);
			this.labelText.Name = "labelText";
			this.labelText.Padding = new System.Windows.Forms.Padding(0, 10, 10, 0);
			this.labelText.Size = new System.Drawing.Size(235, 107);
			this.labelText.TabIndex = 0;
			this.labelText.Text = "labelText";
			// 
			// flpButtons
			// 
			this.flpButtons.BackColor = System.Drawing.Color.Transparent;
			this.flpButtons.Controls.Add(this.button2);
			this.flpButtons.Controls.Add(this.button1);
			this.flpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flpButtons.Location = new System.Drawing.Point(0, 107);
			this.flpButtons.Name = "flpButtons";
			this.flpButtons.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.flpButtons.Size = new System.Drawing.Size(310, 48);
			this.flpButtons.TabIndex = 2;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Animated = true;
			this.button2.BackColor = System.Drawing.Color.Transparent;
			this.button2.BorderRadius = 8;
			this.button2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.button2.BorderThickness = 1;
			this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.button2.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.button2.FillColor = System.Drawing.Color.Black;
			this.button2.FillColor2 = System.Drawing.Color.Black;
			this.button2.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.ForeColor = System.Drawing.Color.White;
			this.button2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.button2.Location = new System.Drawing.Point(172, 3);
			this.button2.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(125, 32);
			this.button2.TabIndex = 1;
			this.button2.TabStop = false;
			this.button2.Text = "Button2";
			this.button2.Click += new System.EventHandler(this.Button_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Animated = true;
			this.button1.BackColor = System.Drawing.Color.Transparent;
			this.button1.BorderRadius = 8;
			this.button1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.button1.BorderThickness = 1;
			this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.button1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.button1.FillColor = System.Drawing.Color.Black;
			this.button1.FillColor2 = System.Drawing.Color.Black;
			this.button1.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.White;
			this.button1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.button1.Location = new System.Drawing.Point(29, 3);
			this.button1.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(125, 32);
			this.button1.TabIndex = 0;
			this.button1.TabStop = false;
			this.button1.Text = "Button1";
			this.button1.Click += new System.EventHandler(this.Button_Click);
			// 
			// CustomMessageBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.ClientSize = new System.Drawing.Size(310, 155);
			this.Controls.Add(this.labelText);
			this.Controls.Add(this.iconPicture);
			this.Controls.Add(this.flpButtons);
			this.Name = "CustomMessageBox";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.TopMost = true;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CustomMessageBox_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.iconPicture)).EndInit();
			this.flpButtons.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private FontAwesome.Sharp.IconPictureBox iconPicture;
		private System.Windows.Forms.Label labelText;
		private System.Windows.Forms.FlowLayoutPanel flpButtons;
		private Guna.UI2.WinForms.Guna2GradientButton button1;
		private Guna.UI2.WinForms.Guna2GradientButton button2;
	}
}