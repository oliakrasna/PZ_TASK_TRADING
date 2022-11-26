using BLL.Interfaces;
using System;
using System.Windows.Forms;


namespace WindowsForms
{
    public partial class LogIn : Form
    {
        protected readonly IAuthentication _auth;
        protected readonly IRegistered _reg;
        public LogIn(IAuthentication auth, IRegistered reg)
        {

            InitializeComponent();
            _reg = reg;
            _auth = auth;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            doLogin();
        }

        private void tbLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                tbPassword.Select();
            }
        }

        private void doLogin()
        {
            if (_auth.Login(tbLogin.Text, tbPassword.Text))
            {
                DialogResult = DialogResult.OK;
                Program.CurrentUserID = _auth.GetUserByLogin(tbLogin.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid credentials");
            }
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                doLogin();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}