using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Data;
using ATM.Models;
using ATM.Strategies;

namespace ATM.Services
{
    public class ATMService
    {
        private ICommissionStrategy _commission;
        private FileStorage _storage;
        private List<Account> _accounts;

        public ATMService(ICommissionStrategy strategy)
        {
            this._commission = strategy;
            this._storage = FileStorage.GetInstance();
            this._accounts = _storage.LoadAccounts();
        }

        public double GetBalance(string cardNumber)
        {
            Account account = _accounts.FirstOrDefault(a => a.CardNumber == cardNumber);
            if (account != null)
            {
                return account.Balance;
            }
            return 0;
        }

        public bool Withdraw(string cardNumber, double amount)
        {
            Account account = _accounts.FirstOrDefault(a => a.CardNumber == cardNumber);

            if (account == null) return false;

            double fee = _commission.Calculate(amount);
            double total = amount + fee;

            if (account.Balance >= total)
            {
                account.Balance -= total;
                _storage.SaveAccounts(_accounts);
                _storage.LogTransaction("Зняття: " + amount + " | Комісія: " + fee + " | Карта: " + cardNumber);
                return true;
            }

            return false;
        }

        public bool Deposit(string cardNumber, double amount)
        {
            Account account = _accounts.FirstOrDefault(a => a.CardNumber == cardNumber);

            if (account != null)
            {
                account.Balance += amount;
                _storage.SaveAccounts(_accounts);
                _storage.LogTransaction("Поповнення: " + amount + " | Карта: " + cardNumber);
                return true;
            }

            return false;
        }

        public bool Transfer(string fromCard, string toCard, double amount)
        {
            Account sender = _accounts.FirstOrDefault(a => a.CardNumber == fromCard);
            Account receiver = _accounts.FirstOrDefault(a => a.CardNumber == toCard);

            if (sender != null && receiver != null && sender.Balance >= amount)
            {
                sender.Balance -= amount;
                receiver.Balance += amount;
                _storage.SaveAccounts(_accounts);
                _storage.LogTransaction("Переказ: " + amount + " з " + fromCard + " на " + toCard);
                return true;
            }

            return false;
        }
    }
}
