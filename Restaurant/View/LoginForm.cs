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
    public partial class LoginForm : Form
    {
        private AccountUtil accountUtil = new AccountUtil();
        private TableUtil tableUtil = new TableUtil();
        public table loggedInTable;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            account loginAttempt = accountUtil.getAccountForUsernameAndPassword(txtUsername.Text, txtPassword.Text);
            if(loginAttempt != null && loginAttempt.AccountType_id == 2)
            {
                loggedInTable = tableUtil.getTableForAccountId(loginAttempt.id);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Korisnicko ime ili lozinka nisu ispravni. Pokusajte ponovno");
                txtPassword.Clear();
                txtUsername.Clear();
            }
        }
    }
}
