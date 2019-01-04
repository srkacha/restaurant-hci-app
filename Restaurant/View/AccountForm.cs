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
    public partial class AccountForm : Form
    {
        private AccountTypeUtil accountTypeUtil = new AccountTypeUtil();
        private AccountUtil accountUtil = new AccountUtil();
        private TableUtil tableUtil = new TableUtil();

        public AccountForm()
        {
            InitializeComponent();

            //loading the account types
            loadAccountTypeData();

            //hiding the validation labels
            hideValidationLabels();

            hideTableNumberInput();
        }

        private void hideTableNumberInput()
        {
            this.Height = 440;
            lblTable.Visible = false;
            lblNumberValid.Visible = false;
            nudTableNumber.Visible = false; ;
        }

        private void loadAccountTypeData()
        {
            List<accounttype> acctypes = accountTypeUtil.getAllAccountTypes();
            if (acctypes != null)
            {
                foreach (var acc in acctypes)
                {
                    cmbAccType.Items.Add(acc);
                }
            }
        }

        private void hideValidationLabels()
        {
            lblPasswordValid.Visible = false;
            lblRePasswordValid.Visible = false;
            lblTypeValid.Visible = false;
            lblUsernameValid.Visible = false;
            lblNumberValid.Visible = false;
        }

        private bool isInputValid()
        {
            hideValidationLabels();

            bool valid = true;
            if (txtUsername.Text.Equals(""))
            {
                lblUsernameValid.Text = "Polje ne smije ostati prazno";
                lblUsernameValid.Visible = true;
                valid = false;
            }
            if (accountUtil.usernameExists(txtUsername.Text))
            {
                lblUsernameValid.Text = "Korisnicko ime postoji";
                lblUsernameValid.Visible = true;
                valid = false;
            }
            if (txtUsername.Text.Equals(""))
            {
                lblUsernameValid.Text = "Polje ne smije ostati prazno";
                lblUsernameValid.Visible = true;
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
            if(!txtPassword.Text.Equals("") && !txtRePassword.Text.Equals("") && !txtPassword.Text.Equals(txtRePassword.Text))
            {
                lblRePasswordValid.Text = "Lozinke moraju biti iste";
                lblPasswordValid.Visible = false;
                lblRePasswordValid.Visible = true;
                valid = false;
            }
            if (cmbAccType.Text.Equals(""))
            {
                lblTypeValid.Visible = true;
                valid = false;
            }else if (cmbAccType.Text.Equals("Sto"))
            {
                if(nudTableNumber.Value <= 0)
                {
                    lblNumberValid.Text = "Vrijendost mora biti veca od 0";
                    lblNumberValid.Visible = true;
                    valid = false;
                }else if (tableUtil.tableNumberExists((int)nudTableNumber.Value))
                {
                    lblNumberValid.Text = "Sto sa datim brojem vec postoji";
                    lblNumberValid.Visible = true;
                    valid = false;
                }
            }

            return valid;
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            if (isInputValid())
            {
                if (cmbAccType.Text.Equals("Sto"))
                {
                    addTableAccount();
                }else if (cmbAccType.Text.Equals("Zaposleni"))
                {
                    addStaffAccount();
                }
            }
        }

        private void addStaffAccount()
        {
            int accTypeId = ((accounttype)cmbAccType.SelectedItem).id;
            if(accountUtil.addAccount(txtUsername.Text, txtPassword.Text, accTypeId))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void addTableAccount()
        {
            int accTypeId = ((accounttype)cmbAccType.SelectedItem).id;
            if (accountUtil.addAccountAndTable(txtUsername.Text, txtPassword.Text, accTypeId, (int)nudTableNumber.Value))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void cmbAccType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAccType.Text.Equals("Sto"))
            {
                this.Height = 540;
                lblTable.Visible = true;
                lblNumberValid.Visible = false;
                nudTableNumber.Visible = true;
            }else if (cmbAccType.Text.Equals("Zaposleni"))
            {
                this.Height = 440;
                lblTable.Visible = false; ;
                lblNumberValid.Visible = false;
                nudTableNumber.Visible = false; ;
            }
        }
    }
}
