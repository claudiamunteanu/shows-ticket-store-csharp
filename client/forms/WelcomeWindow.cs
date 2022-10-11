using app.model;
using System;
using System.Windows.Forms;

namespace app.client.forms
{
    public partial class WelcomeWindow : Form
    {
        private AppClientController Controller;
        
        public WelcomeWindow(AppClientController ctrl)
        {
            Controller = ctrl;
            this.Text = "Welcome!";
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginWindow loginForm = new LoginWindow(Controller);
            loginForm.Text = "Login";
            this.Hide();
            loginForm.ShowDialog();
            User user = Controller.GetUser();
            if (user != null)
                this.Close();
            else
                this.Show();
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            NewUserWindow newUserForm = new NewUserWindow(Controller);
            newUserForm.Text = "Create new account";
            this.Hide();
            newUserForm.ShowDialog();
            User user = Controller.GetUser();
            if (user != null)
                this.Close();
            else
                this.Show();
        }
    }
}
