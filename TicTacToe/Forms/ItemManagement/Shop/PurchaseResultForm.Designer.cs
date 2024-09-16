namespace TicTacToe.Forms.ItemManagement.Shop
{
	partial class PurchaseResultForm
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
			this.pictureBoxItem = new System.Windows.Forms.PictureBox();
			this.labelName = new System.Windows.Forms.Label();
			this.labelPrice = new System.Windows.Forms.Label();
			this.pictureBoxCoin = new System.Windows.Forms.PictureBox();
			this.labelDescription = new System.Windows.Forms.Label();
			this.buttonOK = new Guna.UI2.WinForms.Guna2GradientButton();
			this.buttonSelect = new Guna.UI2.WinForms.Guna2GradientButton();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoin)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxItem
			// 
			this.pictureBoxItem.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxItem.Location = new System.Drawing.Point(12, 12);
			this.pictureBoxItem.Name = "pictureBoxItem";
			this.pictureBoxItem.Size = new System.Drawing.Size(250, 250);
			this.pictureBoxItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxItem.TabIndex = 0;
			this.pictureBoxItem.TabStop = false;
			// 
			// labelName
			// 
			this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelName.BackColor = System.Drawing.Color.Transparent;
			this.labelName.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.labelName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.labelName.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelName.ForeColor = System.Drawing.Color.White;
			this.labelName.Location = new System.Drawing.Point(268, 12);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(470, 70);
			this.labelName.TabIndex = 1;
			this.labelName.Text = "Item name\r\n";
			// 
			// labelPrice
			// 
			this.labelPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelPrice.BackColor = System.Drawing.Color.Transparent;
			this.labelPrice.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.labelPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.labelPrice.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelPrice.ForeColor = System.Drawing.Color.Khaki;
			this.labelPrice.Location = new System.Drawing.Point(316, 85);
			this.labelPrice.Name = "labelPrice";
			this.labelPrice.Size = new System.Drawing.Size(422, 70);
			this.labelPrice.TabIndex = 3;
			this.labelPrice.Text = "999 999";
			// 
			// pictureBoxCoin
			// 
			this.pictureBoxCoin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxCoin.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxCoin.Image = global::TicTacToe.Properties.Resources.coin;
			this.pictureBoxCoin.Location = new System.Drawing.Point(268, 82);
			this.pictureBoxCoin.Name = "pictureBoxCoin";
			this.pictureBoxCoin.Size = new System.Drawing.Size(42, 42);
			this.pictureBoxCoin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxCoin.TabIndex = 2;
			this.pictureBoxCoin.TabStop = false;
			// 
			// labelDescription
			// 
			this.labelDescription.BackColor = System.Drawing.Color.Transparent;
			this.labelDescription.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.labelDescription.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.labelDescription.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDescription.ForeColor = System.Drawing.Color.Gainsboro;
			this.labelDescription.Location = new System.Drawing.Point(12, 270);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(726, 113);
			this.labelDescription.TabIndex = 4;
			this.labelDescription.Text = "Item description\r\n";
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.Animated = true;
			this.buttonOK.BackColor = System.Drawing.Color.Transparent;
			this.buttonOK.BorderRadius = 20;
			this.buttonOK.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.buttonOK.BorderThickness = 1;
			this.buttonOK.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonOK.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.buttonOK.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.buttonOK.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonOK.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonOK.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.buttonOK.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(239)))), ((int)(((byte)(125)))));
			this.buttonOK.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(153)))), ((int)(((byte)(142)))));
			this.buttonOK.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonOK.ForeColor = System.Drawing.Color.White;
			this.buttonOK.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonOK.Location = new System.Drawing.Point(528, 393);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(200, 45);
			this.buttonOK.TabIndex = 6;
			this.buttonOK.TabStop = false;
			this.buttonOK.Text = "OK";
			this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
			// 
			// buttonSelect
			// 
			this.buttonSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSelect.Animated = true;
			this.buttonSelect.BackColor = System.Drawing.Color.Transparent;
			this.buttonSelect.BorderRadius = 20;
			this.buttonSelect.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.buttonSelect.BorderThickness = 1;
			this.buttonSelect.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonSelect.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.buttonSelect.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.buttonSelect.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonSelect.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonSelect.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.buttonSelect.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(168)))), ((int)(((byte)(23)))));
			this.buttonSelect.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(176)))), ((int)(((byte)(46)))));
			this.buttonSelect.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonSelect.ForeColor = System.Drawing.Color.White;
			this.buttonSelect.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonSelect.Location = new System.Drawing.Point(22, 393);
			this.buttonSelect.Name = "buttonSelect";
			this.buttonSelect.Size = new System.Drawing.Size(200, 45);
			this.buttonSelect.TabIndex = 5;
			this.buttonSelect.TabStop = false;
			this.buttonSelect.Text = "Select";
			this.buttonSelect.Click += new System.EventHandler(this.ButtonSelect_Click);
			// 
			// PurchaseResultForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.ClientSize = new System.Drawing.Size(750, 450);
			this.Controls.Add(this.buttonSelect);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.labelDescription);
			this.Controls.Add(this.pictureBoxCoin);
			this.Controls.Add(this.labelPrice);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.pictureBoxItem);
			this.Name = "PurchaseResultForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PurchaseResultForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PurchaseResultForm_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoin)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxItem;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.Label labelPrice;
		private System.Windows.Forms.PictureBox pictureBoxCoin;
		private System.Windows.Forms.Label labelDescription;
		private Guna.UI2.WinForms.Guna2GradientButton buttonOK;
		private Guna.UI2.WinForms.Guna2GradientButton buttonSelect;
	}
}