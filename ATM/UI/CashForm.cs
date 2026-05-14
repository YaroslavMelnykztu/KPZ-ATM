using ATM.Data;
using ATM.Models;
using ATM.Services;
using ATM.Strategies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM.UI
{
    public partial class CashForm : Form
    {
        private ATMService atmService;
        private string currentCardNumber;

        public CashForm(string cardNumber)
        {
            InitializeComponent();
            currentCardNumber = cardNumber;
            atmService = new ATMService(new DefaultCommission());
            UpdateBalance();
        }

        private void UpdateBalance()
        {
            double balance = atmService.GetBalance(currentCardNumber);
            lblBalance.Text = "Поточний баланс: " + balance.ToString() + " UAH";
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            InputValidator validator = new InputValidator();
            double amount;

            if (validator.IsValidAmount(txtAmount.Text, out amount))
            {
                bool success = atmService.Withdraw(currentCardNumber, amount);
                if (success)
                {
                    MessageBox.Show("Гроші успішно знято");
                    UpdateBalance();
                    txtAmount.Clear();
                }
                else
                {
                    MessageBox.Show("Недостатньо коштів або помилка");
                }
            }
            else
            {
                MessageBox.Show("Введіть коректну суму більше нуля");
            }
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            InputValidator validator = new InputValidator();
            double amount;

            if (validator.IsValidAmount(txtAmount.Text, out amount))
            {
                bool success = atmService.Deposit(currentCardNumber, amount);
                if (success)
                {
                    MessageBox.Show("Рахунок поповнено");
                    UpdateBalance();
                    txtAmount.Clear();
                }
                else
                {
                    MessageBox.Show("Помилка поповнення");
                }
            }
            else
            {
                MessageBox.Show("Введіть коректну суму більше нуля");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}