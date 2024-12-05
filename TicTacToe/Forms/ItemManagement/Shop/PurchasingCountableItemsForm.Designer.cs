namespace TicTacToe.Forms.ItemManagement.Shop
{
	partial class PurchasingCountableItemsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchasingCountableItemsForm));
			this.pictureBoxItem = new System.Windows.Forms.PictureBox();
			this.labelName = new System.Windows.Forms.Label();
			this.labelPrice = new System.Windows.Forms.Label();
			this.pictureBoxCoin = new System.Windows.Forms.PictureBox();
			this.labelDescription = new System.Windows.Forms.Label();
			this.buttonBuy = new Guna.UI2.WinForms.Guna2GradientButton();
			this.buttonBack = new Guna.UI2.WinForms.Guna2GradientButton();
			this.numericUpDownNumberOfItems = new System.Windows.Forms.NumericUpDown();
			this.labelNumberOfItems = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfItems)).BeginInit();
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
			this.labelDescription.TabIndex = 6;
			this.labelDescription.Text = "Item description\r\n";
			// 
			// buttonBuy
			// 
			this.buttonBuy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBuy.Animated = true;
			this.buttonBuy.BackColor = System.Drawing.Color.Transparent;
			this.buttonBuy.BorderRadius = 20;
			this.buttonBuy.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.buttonBuy.BorderThickness = 1;
			this.buttonBuy.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonBuy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.buttonBuy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.buttonBuy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonBuy.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonBuy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.buttonBuy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(239)))), ((int)(((byte)(125)))));
			this.buttonBuy.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(153)))), ((int)(((byte)(142)))));
			this.buttonBuy.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonBuy.ForeColor = System.Drawing.Color.White;
			this.buttonBuy.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonBuy.Location = new System.Drawing.Point(528, 393);
			this.buttonBuy.Name = "buttonBuy";
			this.buttonBuy.Size = new System.Drawing.Size(200, 45);
			this.buttonBuy.TabIndex = 8;
			this.buttonBuy.TabStop = false;
			this.buttonBuy.Text = "Buy";
			this.buttonBuy.Click += new System.EventHandler(this.ButtonBuy_Click);
			// 
			// buttonBack
			// 
			this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBack.Animated = true;
			this.buttonBack.BackColor = System.Drawing.Color.Transparent;
			this.buttonBack.BorderRadius = 20;
			this.buttonBack.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.buttonBack.BorderThickness = 1;
			this.buttonBack.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.buttonBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.buttonBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonBack.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.buttonBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.buttonBack.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(24)))), ((int)(((byte)(13)))));
			this.buttonBack.FillColor2 = System.Drawing.Color.Maroon;
			this.buttonBack.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonBack.ForeColor = System.Drawing.Color.White;
			this.buttonBack.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
			this.buttonBack.Location = new System.Drawing.Point(22, 393);
			this.buttonBack.Name = "buttonBack";
			this.buttonBack.Size = new System.Drawing.Size(200, 45);
			this.buttonBack.TabIndex = 7;
			this.buttonBack.TabStop = false;
			this.buttonBack.Text = "Back";
			this.buttonBack.Click += new System.EventHandler(this.ButtonExit_Click);
			// 
			// numericUpDownNumberOfItems
			// 
			this.numericUpDownNumberOfItems.BackColor = System.Drawing.Color.Black;
			this.numericUpDownNumberOfItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.numericUpDownNumberOfItems.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDownNumberOfItems.ForeColor = System.Drawing.Color.White;
			this.numericUpDownNumberOfItems.Location = new System.Drawing.Point(592, 188);
			this.numericUpDownNumberOfItems.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownNumberOfItems.Name = "numericUpDownNumberOfItems";
			this.numericUpDownNumberOfItems.Size = new System.Drawing.Size(90, 36);
			this.numericUpDownNumberOfItems.TabIndex = 5;
			this.numericUpDownNumberOfItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownNumberOfItems.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownNumberOfItems.ValueChanged += new System.EventHandler(this.NumericUpDownNumberOfItems_ValueChanged);
			// 
			// labelNumberOfItems
			// 
			this.labelNumberOfItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelNumberOfItems.AutoSize = true;
			this.labelNumberOfItems.BackColor = System.Drawing.Color.Transparent;
			this.labelNumberOfItems.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.labelNumberOfItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.labelNumberOfItems.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelNumberOfItems.ForeColor = System.Drawing.Color.White;
			this.labelNumberOfItems.Location = new System.Drawing.Point(269, 194);
			this.labelNumberOfItems.Name = "labelNumberOfItems";
			this.labelNumberOfItems.Size = new System.Drawing.Size(317, 29);
			this.labelNumberOfItems.TabIndex = 4;
			this.labelNumberOfItems.Text = "Number of items purchased:";
			// 
			// PurchasingCountableItemsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.ClientSize = new System.Drawing.Size(750, 450);
			this.Controls.Add(this.labelNumberOfItems);
			this.Controls.Add(this.numericUpDownNumberOfItems);
			this.Controls.Add(this.buttonBack);
			this.Controls.Add(this.buttonBuy);
			this.Controls.Add(this.labelDescription);
			this.Controls.Add(this.pictureBoxCoin);
			this.Controls.Add(this.labelPrice);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.pictureBoxItem);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PurchasingCountableItemsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PurchaseResultForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PurchaseResultForm_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfItems)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxItem;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.Label labelPrice;
		private System.Windows.Forms.PictureBox pictureBoxCoin;
		private System.Windows.Forms.Label labelDescription;
		private Guna.UI2.WinForms.Guna2GradientButton buttonBuy;
		private Guna.UI2.WinForms.Guna2GradientButton buttonBack;
		private System.Windows.Forms.NumericUpDown numericUpDownNumberOfItems;
		private System.Windows.Forms.Label labelNumberOfItems;
	}
}