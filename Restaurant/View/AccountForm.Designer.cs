namespace Restaurant.View
{
    partial class AccountForm
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
            this.lblUsernameValid = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPasswordValid = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRePasswordValid = new System.Windows.Forms.Label();
            this.txtRePassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTypeValid = new System.Windows.Forms.Label();
            this.cmbAccType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.lblNumberValid = new System.Windows.Forms.Label();
            this.lblTable = new System.Windows.Forms.Label();
            this.nudTableNumber = new System.Windows.Forms.NumericUpDown();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTableNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsernameValid
            // 
            this.lblUsernameValid.AutoSize = true;
            this.lblUsernameValid.BackColor = System.Drawing.Color.Transparent;
            this.lblUsernameValid.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsernameValid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUsernameValid.Location = new System.Drawing.Point(184, 16);
            this.lblUsernameValid.Name = "lblUsernameValid";
            this.lblUsernameValid.Size = new System.Drawing.Size(216, 21);
            this.lblUsernameValid.TabIndex = 34;
            this.lblUsernameValid.Text = "Polje ne smije ostati prazno";
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(188, 40);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(305, 27);
            this.txtUsername.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 25);
            this.label1.TabIndex = 32;
            this.label1.Text = "Korisnicko ime";
            // 
            // lblPasswordValid
            // 
            this.lblPasswordValid.AutoSize = true;
            this.lblPasswordValid.BackColor = System.Drawing.Color.Transparent;
            this.lblPasswordValid.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordValid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPasswordValid.Location = new System.Drawing.Point(184, 77);
            this.lblPasswordValid.Name = "lblPasswordValid";
            this.lblPasswordValid.Size = new System.Drawing.Size(216, 21);
            this.lblPasswordValid.TabIndex = 37;
            this.lblPasswordValid.Text = "Polje ne smije ostati prazno";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(188, 101);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(305, 27);
            this.txtPassword.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 25);
            this.label3.TabIndex = 35;
            this.label3.Text = "Lozinka";
            // 
            // lblRePasswordValid
            // 
            this.lblRePasswordValid.AutoSize = true;
            this.lblRePasswordValid.BackColor = System.Drawing.Color.Transparent;
            this.lblRePasswordValid.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRePasswordValid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRePasswordValid.Location = new System.Drawing.Point(184, 137);
            this.lblRePasswordValid.Name = "lblRePasswordValid";
            this.lblRePasswordValid.Size = new System.Drawing.Size(216, 21);
            this.lblRePasswordValid.TabIndex = 40;
            this.lblRePasswordValid.Text = "Polje ne smije ostati prazno";
            // 
            // txtRePassword
            // 
            this.txtRePassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRePassword.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRePassword.Location = new System.Drawing.Point(188, 161);
            this.txtRePassword.Name = "txtRePassword";
            this.txtRePassword.PasswordChar = '●';
            this.txtRePassword.Size = new System.Drawing.Size(305, 27);
            this.txtRePassword.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 25);
            this.label5.TabIndex = 38;
            this.label5.Text = "Ista lozinka";
            // 
            // lblTypeValid
            // 
            this.lblTypeValid.AutoSize = true;
            this.lblTypeValid.BackColor = System.Drawing.Color.Transparent;
            this.lblTypeValid.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeValid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTypeValid.Location = new System.Drawing.Point(184, 206);
            this.lblTypeValid.Name = "lblTypeValid";
            this.lblTypeValid.Size = new System.Drawing.Size(262, 21);
            this.lblTypeValid.TabIndex = 43;
            this.lblTypeValid.Text = "Morate odabrati neku vrijednost";
            // 
            // cmbAccType
            // 
            this.cmbAccType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAccType.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAccType.FormattingEnabled = true;
            this.cmbAccType.Location = new System.Drawing.Point(188, 230);
            this.cmbAccType.Name = "cmbAccType";
            this.cmbAccType.Size = new System.Drawing.Size(305, 32);
            this.cmbAccType.TabIndex = 42;
            this.cmbAccType.SelectedIndexChanged += new System.EventHandler(this.cmbAccType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 25);
            this.label6.TabIndex = 41;
            this.label6.Text = "Tip naloga";
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel7.Controls.Add(this.btnAddAccount);
            this.panel7.Location = new System.Drawing.Point(12, 389);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(481, 100);
            this.panel7.TabIndex = 44;
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAddAccount.FlatAppearance.BorderSize = 0;
            this.btnAddAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAccount.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAccount.ForeColor = System.Drawing.Color.White;
            this.btnAddAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddAccount.Location = new System.Drawing.Point(208, 22);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(259, 53);
            this.btnAddAccount.TabIndex = 6;
            this.btnAddAccount.Text = "Dodaj nalog";
            this.btnAddAccount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddAccount.UseVisualStyleBackColor = false;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // lblNumberValid
            // 
            this.lblNumberValid.AutoSize = true;
            this.lblNumberValid.BackColor = System.Drawing.Color.Transparent;
            this.lblNumberValid.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberValid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNumberValid.Location = new System.Drawing.Point(184, 279);
            this.lblNumberValid.Name = "lblNumberValid";
            this.lblNumberValid.Size = new System.Drawing.Size(216, 21);
            this.lblNumberValid.TabIndex = 47;
            this.lblNumberValid.Text = "Polje ne smije ostati prazno";
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTable.Location = new System.Drawing.Point(12, 309);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(108, 25);
            this.lblTable.TabIndex = 45;
            this.lblTable.Text = "Broj stola";
            // 
            // nudTableNumber
            // 
            this.nudTableNumber.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTableNumber.Location = new System.Drawing.Point(188, 307);
            this.nudTableNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTableNumber.Name = "nudTableNumber";
            this.nudTableNumber.Size = new System.Drawing.Size(305, 34);
            this.nudTableNumber.TabIndex = 48;
            this.nudTableNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(509, 501);
            this.Controls.Add(this.nudTableNumber);
            this.Controls.Add(this.lblNumberValid);
            this.Controls.Add(this.lblTable);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.lblTypeValid);
            this.Controls.Add(this.cmbAccType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblRePasswordValid);
            this.Controls.Add(this.txtRePassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblPasswordValid);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblUsernameValid);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dodavanje naloga";
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudTableNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsernameValid;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPasswordValid;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRePasswordValid;
        private System.Windows.Forms.TextBox txtRePassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTypeValid;
        private System.Windows.Forms.ComboBox cmbAccType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.Label lblNumberValid;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.NumericUpDown nudTableNumber;
    }
}