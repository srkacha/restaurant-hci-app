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
    public partial class StaffLoginForm : Form
    {
        private AccountUtil accountUtil = new AccountUtil();
        private TableUtil tableUtil = new TableUtil();
        public account loggedInAccount;

        public StaffLoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            account loginAttempt = accountUtil.getAccountForUsernameAndPassword(txtUsername.Text, txtPassword.Text);
            if (loginAttempt != null && loginAttempt.AccountType_id == 1)
            {
                loggedInAccount = loginAttempt;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                new InfoForm("Korisnicko ime ili lozinka nisu ispravni. Pokusajte ponovno").ShowDialog();
                txtPassword.Clear();
                txtUsername.Clear();
            }
        }
    }
}
