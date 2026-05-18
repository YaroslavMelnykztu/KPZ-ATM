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

        private Account FindAccount(string cardNumber)
        {
            if (string.IsNullOrWhiteSpace(cardNumber)) return null;
            return _accounts.FirstOrDefault(a => a.CardNumber == cardNumber);
        }

        public double GetBalance(string cardNumber)
        {
            Account account = FindAccount(cardNumber);
            return account?.Balance ?? 0;
        }

        public bool Withdraw(string cardNumber, double amount)
        {
            Account account = FindAccount(cardNumber);
            if (account == null || amount <= 0) return false;

            double fee = _commission.Calculate(amount);
            double total = amount + fee;

            if (account.Balance < total) return false;

            account.Balance -= total;
            _storage.SaveAccounts(_accounts);
            _storage.LogTransaction($"Зняття: {amount} | Комісія: {fee} | Карта: {cardNumber}");

            return true;
        }

        public bool Deposit(string cardNumber, double amount)
        {
            if (amount <= 0) return false;

            Account account = FindAccount(cardNumber);
            if (account == null) return false;

            account.Balance += amount;
            _storage.SaveAccounts(_accounts);
            _storage.LogTransaction($"Поповнення: {amount} | Карта: {cardNumber}");

            return true;
        }

        public bool Transfer(string fromCard, string toCard, double amount)
        {
            if (amount <= 0 || fromCard == toCard) return false;

            Account sender = FindAccount(fromCard);
            Account receiver = FindAccount(toCard);

            if (sender == null || receiver == null || sender.Balance < amount)
                return false;

            sender.Balance -= amount;
            receiver.Balance += amount;

            _storage.SaveAccounts(_accounts);
            _storage.LogTransaction($"Переказ: {amount} з {fromCard} на {toCard}");

            return true;
        }
    }
}
