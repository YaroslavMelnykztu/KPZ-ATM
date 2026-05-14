using ATM.Services;
using System;
using System.Windows.Forms;

namespace ATM.UI
{
    public partial class PaymentsForm : Form
    {
        private PaymentService paymentService;
        private ATMService atmService;
        private string currentCardNumber;

        public PaymentsForm(string cardNumber)
        {
            InitializeComponent();
            currentCardNumber = cardNumber;
            paymentService = new PaymentService();
            atmService = new ATMService(new ATM.Strategies.DefaultCommission());

            cmbServiceType.SelectedIndex = 0;
            UpdateBalance();
        }

        private void UpdateBalance()
        {
            double balance = atmService.GetBalance(currentCardNumber);
            lblBalance.Text = "Поточний баланс: " + balance.ToString() + " UAH";
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            InputValidator validator = new InputValidator();
            string service = cmbServiceType.SelectedItem.ToString();
            string target = txtAccountDetails.Text;
            double amount;

            if (string.IsNullOrWhiteSpace(target))
            {
                MessageBox.Show("Введіть реквізити або номер телефону");
                return;
            }

            if (validator.IsValidAmount(txtAmount.Text, out amount))
            {
                bool success = paymentService.PayService(currentCardNumber, service, target, amount);

                if (success)
                {
                    string receipt = paymentService.GetReceipt(service, amount, target);
                    MessageBox.Show(receipt, "Платіж успішний");
                    UpdateBalance();
                    txtAmount.Clear();
                    txtAccountDetails.Clear();
                }
                else
                {
                    MessageBox.Show("Помилка платежу або недостатньо коштів");
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