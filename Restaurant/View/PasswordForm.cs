using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Restaurant.Model;
using Restaurant.Util;

namespace Restaurant.View
{
    public partial class PasswordForm : Form
    {
        private account myAccount = null;
        private AccountUtil accountUtil = new AccountUtil();

        public PasswordForm()
        {
            InitializeComponent();
        }

        public PasswordForm(account myAcc)
        {
            InitializeComponent();
            this.myAccount = myAcc;
            hideValidationLabels();
        }

        private void hideValidationLabels()
        {
            lblOldPasswordValid.Visible = false;
            lblPasswordValid.Visible = false;
            lblRePasswordValid.Visible = false;
        }

        private bool isInputValid()
        {
            hideValidationLabels();
            bool valid = true;

            if (txtOldPassword.Text.Equals(""))
            {
                lblOldPasswordValid.Text = "Polje ne smije ostati prazno";
                lblOldPasswordValid.Visible = true;
                valid = false;
            }
            else if (!txtOldPassword.Text.Equals(myAccount.password))
            {
                lblOldPasswordValid.Text = "Lozinka nije ispravna";
                lblOldPasswordValid.Visible = true;
                valid = false;
            }
            if (txtPassword.Text.Equals(""))
            {
                lblPasswordValid.Visible = true;
                valid = false;
            }
            if (txtRePassword.Text.Equals(""))
            {
                lblRePasswordValid.Text = "Polje ne smije ostati prazno";
                lblRePasswordValid.Visible = true;
                valid = false;
            }
            if (!txtPassword.Text.Equals("") && !txtRePassword.Text.Equals("") && !txtPassword.Text.Equals(txtRePassword.Text))
            {
                lblRePasswordValid.Text = "Lozinke moraju biti iste";
                lblPasswordValid.Visible = false;
                lblRePasswordValid.Visible = true;
                valid = false;
            }

            return valid;
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            if (isInputValid())
            {
                if(accountUtil.updatePassword(myAccount.id, txtPassword.Text))
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
