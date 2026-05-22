using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using ATM.Data;
using ATM.Models;

namespace ATM.Services
{
    public class PaymentService
    {
        private FileStorage _storage;
        private List<Account> _accounts;

        public PaymentService()
        {
            this._storage = FileStorage.GetInstance();
            this._accounts = _storage.LoadAccounts();
        }

        public bool PayService(string cardNumber, string serviceName, string accountId, double amount)
        {
            Account account = _accounts.FirstOrDefault(a => a.CardNumber == cardNumber);
            if (account != null && account.Balance >= amount)
            {
                account.Balance -= amount;
                _storage.SaveAccounts(_accounts);
                _storage.LogTransaction(serviceName + " (" + accountId + "): " + amount + " | Карта: " + cardNumber);
                return true;
            }
            return false;
        }

        // Оновлений метод з використанням патерну Builder
        public string GetReceipt(string type, double amount, string details)
        {
            IReceiptBuilder builder = new TextReceiptBuilder();

            return builder.SetHeader()
                          .SetOperationType(type)
                          .SetAmount(amount)
                          .SetDate(DateTime.Now)
                          .SetDetails(details)
                          .SetFooter()
                          .Build();
        }
    }
}