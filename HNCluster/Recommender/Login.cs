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
        public bool userIsAuthenticated;
        public string userName;

        public UserLoginForm()
        {
            InitializeComponent();
            txtboxUsername.Text = "brice";
            txtboxPassword.Text = "a";
            userIsAuthenticated = false;
            userName = txtboxUsername.Text;
        }

        private bool createNewUserAndPassword(string username, string password)
        {
            Configuration roamingConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming);
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = roamingConfig.FilePath;
            Configuration configManager = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);


            if (configManager.AppSettings.Settings.AllKeys.Contains(username))
            {
                DialogResult res = MessageBox.Show("Our records show that username has already been created.\n\nWould you like to overwrite the current profile and create a new one with the username and password specified above?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (res == DialogResult.Cancel) return false;
            }

            configManager.AppSettings.Settings.Add(new KeyValueConfigurationElement(username, password));
            configManager.Save(ConfigurationSaveMode.Modified);

            userIsAuthenticated = true;
            userName = username;
            return true;
        }


        private bool validateUserCredentials(string username, string password)
        {
            Configuration roamingConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming);
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = roamingConfig.FilePath;
            Configuration configManager = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            return (configManager.AppSettings.Settings.AllKeys.Contains(username) == true && configManager.AppSettings.Settings[username].Value == password);
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {

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

            else
            {
                userIsAuthenticated = validateUserCredentials(txtboxUsername.Text, txtboxPassword.Text); ;

                if (userIsAuthenticated == true)
                {
                    userName = txtboxUsername.Text;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username/password pair.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            bool res = createNewUserAndPassword(txtboxUsername.Text, txtboxPassword.Text);
            if (res == true) this.Close();
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
