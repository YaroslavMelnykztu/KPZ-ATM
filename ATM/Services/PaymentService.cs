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

        public string GetReceipt(string type, double amount, string details)
        {
            StringBuilder receipt = new StringBuilder();
            receipt.AppendLine("---------- ЧЕК ----------");
            receipt.AppendLine("Тип операції: " + type);
            receipt.AppendLine("Сума: " + amount.ToString("F2") + " UAH");
            receipt.AppendLine("Дата: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
            if (!string.IsNullOrEmpty(details))
            {
                receipt.AppendLine("Деталі: " + details);
            }
            receipt.AppendLine("-------------------------");
            receipt.AppendLine("Дякуємо, що обрали нас!");
            return receipt.ToString();
        }
    }
}