using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Recommender
{
    public partial class UserLoginForm : Form
    {
        public UserLoginForm()
        {
            InitializeComponent();
        }


        private bool validateUserCredentials(string username, string password)
        {
            Configuration roamingConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming);
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = roamingConfig.FilePath;
            Configuration configManager = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            bool returnVal = false;

 
            if (configManager.AppSettings.Settings.AllKeys.Contains(username) == true && configManager.AppSettings.Settings[username].Value == password)
            {
                returnVal = true;
            }
            else
            {
                configManager.AppSettings.Settings.Add(username, password);
                configManager.Save(ConfigurationSaveMode.Modified);

                returnVal = false;
            }


            return returnVal;
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            // TODO: Add code here to authenticate user credentials

            if (txtboxUsername.Text == "" && txtboxPassword.Text == "")
            {
                txtboxUsername.BackColor = Color.Red;
                txtboxPassword.BackColor = Color.Red;
                MessageBox.Show("Please enter your username.\nPlease enter your password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtboxUsername.Text == "")
            {
                txtboxUsername.BackColor = Color.Red;
                MessageBox.Show("Please enter your username.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtboxPassword.Text == "")
            {
                txtboxPassword.BackColor = Color.Red;
                MessageBox.Show("Please enter your password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (validateUserCredentials(txtboxUsername.Text, txtboxPassword.Text) == false)
            {
                MessageBox.Show("Invalid username/password pair.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtboxUsername_Enter(object sender, EventArgs e)
        {
            txtboxUsername.BackColor = Color.White;
        }

        private void txtboxPassword_Enter(object sender, EventArgs e)
        {
            txtboxPassword.BackColor = Color.White;
        }
    }
}
