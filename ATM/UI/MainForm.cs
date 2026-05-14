using System;
using System.Windows.Forms;
using ATM.Services;
using ATM.Strategies;

namespace ATM.UI
{
    public partial class MainForm : Form
    {
        private string currentCardNumber;
        private ATMService atmService;

        public MainForm(string cardNumber)
        {
            InitializeComponent();
            currentCardNumber = cardNumber;
            atmService = new ATMService(new DefaultCommission());
            UpdateBalance();
        }

        private void UpdateBalance()
        {
            double balance = atmService.GetBalance(currentCardNumber);
            lblBalance.Text = "Баланс: " + balance.ToString() + " UAH";
            lblCardNumber.Text = "Картка: " + currentCardNumber;
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            CashForm cashForm = new CashForm(currentCardNumber);
            cashForm.ShowDialog();
            UpdateBalance();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            TransferForm transferForm = new TransferForm(currentCardNumber);
            transferForm.ShowDialog();
            UpdateBalance();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            PaymentsForm paymentsForm = new PaymentsForm(currentCardNumber);
            paymentsForm.ShowDialog();
            UpdateBalance();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            HistoryForm historyForm = new HistoryForm(currentCardNumber);
            historyForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }
    }
}