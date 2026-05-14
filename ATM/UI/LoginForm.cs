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

            FileStorage storage = FileStorage.GetInstance();
            System.Collections.Generic.List<Account> accounts = storage.LoadAccounts();
            PasswordHasher hasher = new PasswordHasher();

            Account user = accounts.FirstOrDefault(a => a.CardNumber == card && hasher.VerifyPassword(pin, a.PinCode));

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