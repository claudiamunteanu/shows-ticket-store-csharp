using System;
using System.Windows.Forms;
using app.services;

namespace app.client.forms
{
    public partial class LoginWindow : Form
    {
        AppClientController Controller;
        
        public LoginWindow(AppClientController ctrl)
        {
            Controller = ctrl;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                String username = textBoxUsername.Text;
                String password = textBoxPassword.Text;
                Controller.Login(username, password);
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
