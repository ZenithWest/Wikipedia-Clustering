using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recommender
{
    public partial class UserLoginForm : Form
    {
        public UserLoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // TODO: Add code here to authenticate user credentials

            if (txtboxUsername.Text == "" && txtboxPassword.Text == "")
            {
                MessageBox.Show("Please enter your username.\nPlease enter your password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtboxUsername.Text == "")
            {
                MessageBox.Show("Please enter your username.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtboxPassword.Text == "")
            {
                MessageBox.Show("Please enter your password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }
    }
}
