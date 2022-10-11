using System;
using System.Windows.Forms;
using app.services;

namespace app.client.forms
{
    public partial class NewUserWindow : Form
    {
        AppClientController Controller;
     
        public NewUserWindow(AppClientController ctrl)
        {
            Controller = ctrl;
            InitializeComponent();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            String username = textBoxUsername.Text;
            String password = textBoxPassword.Text;
            String confirmPassword = textBoxConfirmPassword.Text;

            try
            {
                Controller.NewUserLogin(username, password, confirmPassword);
                this.Close();
            }
            catch (AppException ex)
            {
                labelErrors.Text = ex.Message;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
