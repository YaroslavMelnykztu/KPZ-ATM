using System;
using System.Linq;
using System.Windows.Forms;
using ATM.Data;
using ATM.Models;
using ATM.Services;

namespace ATM.UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            btnLogin.Click += new EventHandler(btnLogin_Click);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string card = txtCardNumber.Text;
            string pin = txtPin.Text;

            AuthService authService = new AuthService();
            Account user = authService.Login(card, pin);

            if (user != null)
            {
                MainForm mainForm = new MainForm(user.CardNumber);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Невірний номер картки або пін-код");
            }
        }
    }
}