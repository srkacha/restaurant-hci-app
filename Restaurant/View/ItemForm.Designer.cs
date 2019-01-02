namespace Restaurant.View
{
    partial class ItemForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtItemDescription = new System.Windows.Forms.RichTextBox();
            this.nudItemPrice = new System.Windows.Forms.NumericUpDown();
            this.cmbItemType = new System.Windows.Forms.ComboBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnActivateItem = new System.Windows.Forms.Button();
            this.pbItemImage = new System.Windows.Forms.PictureBox();
            this.lblNameValid = new System.Windows.Forms.Label();
            this.lblDescValid = new System.Windows.Forms.Label();
            this.lblPriceValid = new System.Windows.Forms.Label();
            this.lblTypeValid = new System.Windows.Forms.Label();
            this.lblImageValid = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemPrice)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Opis";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cijena";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(447, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Slika";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 396);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tip";
            // 
            // txtItemName
            // 
            this.txtItemName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtItemName.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(104, 34);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(305, 27);
            this.txtItemName.TabIndex = 5;
            // 
            // txtItemDescription
            // 
            this.txtItemDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtItemDescription.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemDescription.Location = new System.Drawing.Point(104, 88);
            this.txtItemDescription.Name = "txtItemDescription";
            this.txtItemDescription.Size = new System.Drawing.Size(305, 221);
            this.txtItemDescription.TabIndex = 6;
            this.txtItemDescription.Text = "";
            // 
            // nudItemPrice
            // 
            this.nudItemPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudItemPrice.DecimalPlaces = 2;
            this.nudItemPrice.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudItemPrice.Location = new System.Drawing.Point(104, 335);
            this.nudItemPrice.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudItemPrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudItemPrice.Name = "nudItemPrice";
            this.nudItemPrice.Size = new System.Drawing.Size(305, 30);
            this.nudItemPrice.TabIndex = 7;
            this.nudItemPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbItemType
            // 
            this.cmbItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbItemType.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbItemType.FormattingEnabled = true;
            this.cmbItemType.Location = new System.Drawing.Point(104, 393);
            this.cmbItemType.Name = "cmbItemType";
            this.cmbItemType.Size = new System.Drawing.Size(305, 32);
            this.cmbItemType.TabIndex = 8;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel7.Controls.Add(this.btnReset);
            this.panel7.Controls.Add(this.btnActivateItem);
            this.panel7.Location = new System.Drawing.Point(12, 469);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(776, 100);
            this.panel7.TabIndex = 29;
            // 
            // btnActivateItem
            // 
            this.btnActivateItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnActivateItem.FlatAppearance.BorderSize = 0;
            this.btnActivateItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivateItem.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivateItem.ForeColor = System.Drawing.Color.White;
            this.btnActivateItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActivateItem.Location = new System.Drawing.Point(493, 27);
            this.btnActivateItem.Name = "btnActivateItem";
            this.btnActivateItem.Size = new System.Drawing.Size(259, 53);
            this.btnActivateItem.TabIndex = 6;
            this.btnActivateItem.Text = "Dodaj stavku";
            this.btnActivateItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActivateItem.UseVisualStyleBackColor = false;
            this.btnActivateItem.Click += new System.EventHandler(this.btnActivateItem_Click);
            // 
            // pbItemImage
            // 
            this.pbItemImage.BackColor = System.Drawing.Color.White;
            this.pbItemImage.BackgroundImage = global::Restaurant.Properties.Resources.icons8_plus_96;
            this.pbItemImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbItemImage.Location = new System.Drawing.Point(452, 86);
            this.pbItemImage.Name = "pbItemImage";
            this.pbItemImage.Size = new System.Drawing.Size(316, 316);
            this.pbItemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbItemImage.TabIndex = 30;
            this.pbItemImage.TabStop = false;
            this.pbItemImage.Click += new System.EventHandler(this.pbItemImage_Click);
            // 
            // lblNameValid
            // 
            this.lblNameValid.AutoSize = true;
            this.lblNameValid.BackColor = System.Drawing.Color.Transparent;
            this.lblNameValid.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameValid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNameValid.Location = new System.Drawing.Point(100, 10);
            this.lblNameValid.Name = "lblNameValid";
            this.lblNameValid.Size = new System.Drawing.Size(216, 21);
            this.lblNameValid.TabIndex = 31;
            this.lblNameValid.Text = "Polje ne smije ostati prazno";
            // 
            // lblDescValid
            // 
            this.lblDescValid.AutoSize = true;
            this.lblDescValid.BackColor = System.Drawing.Color.Transparent;
            this.lblDescValid.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescValid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDescValid.Location = new System.Drawing.Point(100, 64);
            this.lblDescValid.Name = "lblDescValid";
            this.lblDescValid.Size = new System.Drawing.Size(216, 21);
            this.lblDescValid.TabIndex = 32;
            this.lblDescValid.Text = "Polje ne smije ostati prazno";
            // 
            // lblPriceValid
            // 
            this.lblPriceValid.AutoSize = true;
            this.lblPriceValid.BackColor = System.Drawing.Color.Transparent;
            this.lblPriceValid.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceValid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPriceValid.Location = new System.Drawing.Point(100, 311);
            this.lblPriceValid.Name = "lblPriceValid";
            this.lblPriceValid.Size = new System.Drawing.Size(242, 21);
            this.lblPriceValid.TabIndex = 33;
            this.lblPriceValid.Text = "Vrijednost mora biti veca od 0";
            // 
            // lblTypeValid
            // 
            this.lblTypeValid.AutoSize = true;
            this.lblTypeValid.BackColor = System.Drawing.Color.Transparent;
            this.lblTypeValid.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeValid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTypeValid.Location = new System.Drawing.Point(100, 369);
            this.lblTypeValid.Name = "lblTypeValid";
            this.lblTypeValid.Size = new System.Drawing.Size(262, 21);
            this.lblTypeValid.TabIndex = 34;
            this.lblTypeValid.Text = "Morate odabrati neku vrijednost";
            // 
            // lblImageValid
            // 
            this.lblImageValid.AutoSize = true;
            this.lblImageValid.BackColor = System.Drawing.Color.Transparent;
            this.lblImageValid.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageValid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblImageValid.Location = new System.Drawing.Point(512, 40);
            this.lblImageValid.Name = "lblImageValid";
            this.lblImageValid.Size = new System.Drawing.Size(175, 21);
            this.lblImageValid.TabIndex = 35;
            this.lblImageValid.Text = "Morate odabrati sliku";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.Location = new System.Drawing.Point(92, 27);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(301, 53);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Resetuj vrijednosti";
            this.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // ItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(800, 581);
            this.Controls.Add(this.lblImageValid);
            this.Controls.Add(this.lblTypeValid);
            this.Controls.Add(this.lblPriceValid);
            this.Controls.Add(this.lblDescValid);
            this.Controls.Add(this.lblNameValid);
            this.Controls.Add(this.pbItemImage);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.cmbItemType);
            this.Controls.Add(this.nudItemPrice);
            this.Controls.Add(this.txtItemDescription);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ItemForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dodavanje stavke";
            ((System.ComponentModel.ISupportInitialize)(this.nudItemPrice)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbItemImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.RichTextBox txtItemDescription;
        private System.Windows.Forms.NumericUpDown nudItemPrice;
        private System.Windows.Forms.ComboBox cmbItemType;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnActivateItem;
        private System.Windows.Forms.PictureBox pbItemImage;
        private System.Windows.Forms.Label lblNameValid;
        private System.Windows.Forms.Label lblDescValid;
        private System.Windows.Forms.Label lblPriceValid;
        private System.Windows.Forms.Label lblTypeValid;
        private System.Windows.Forms.Label lblImageValid;
        private System.Windows.Forms.Button btnReset;
    }
}