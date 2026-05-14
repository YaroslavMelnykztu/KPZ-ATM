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
    public partial class TransferForm : Form
    {
        private ATMService atmService;
        private string currentCardNumber;

        public TransferForm(string cardNumber)
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

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            InputValidator validator = new InputValidator();
            double amount;
            string target = txtTargetCard.Text;

            if (!validator.IsValidCardNumber(target))
            {
                MessageBox.Show("Невірний формат картки отримувача");
                return;
            }

            if (validator.IsValidAmount(txtAmount.Text, out amount))
            {
                bool success = atmService.Transfer(currentCardNumber, target, amount);
                if (success)
                {
                    MessageBox.Show("Переказ виконано успішно");
                    UpdateBalance();
                    txtAmount.Clear();
                    txtTargetCard.Clear();
                }
                else
                {
                    MessageBox.Show("Помилка переказу або недостатньо коштів");
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