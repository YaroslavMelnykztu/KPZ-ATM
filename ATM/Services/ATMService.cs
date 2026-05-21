using System;
using System.Collections.Generic;
using System.Linq;
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
            _commission = strategy;
            _storage = FileStorage.GetInstance();
            _accounts = _storage.LoadAccounts();
        }

        public double GetBalance(string cardNumber)
        {
            return FindAccount(cardNumber)?.Balance ?? 0;
        }

        public bool Withdraw(string cardNumber, double amount)
        {
            Account account = FindAccount(cardNumber);
            if (account == null) return false;

            double fee = _commission.Calculate(amount);
            double total = amount + fee;
            if (account.Balance < total) return false;

            account.Balance -= total;
            return CommitTransaction($"Зняття: {amount} | Комісія: {fee} | Карта: {cardNumber}");
        }

        public bool Deposit(string cardNumber, double amount)
        {
            Account account = FindAccount(cardNumber);
            if (account == null) return false;

            account.Balance += amount;
            return CommitTransaction($"Поповнення: {amount} | Карта: {cardNumber}");
        }

        public bool Transfer(string fromCard, string toCard, double amount)
        {
            Account sender = FindAccount(fromCard);
            Account receiver = FindAccount(toCard);

            if (sender == null || receiver == null || sender.Balance < amount)
                return false;

            sender.Balance -= amount;
            receiver.Balance += amount;
            return CommitTransaction($"Переказ: {amount} з {fromCard} на {toCard}");
        }

        private Account FindAccount(string cardNumber)
        {
            return _accounts.FirstOrDefault(a => a.CardNumber == cardNumber);
        }

        private bool CommitTransaction(string logMessage)
        {
            _storage.SaveAccounts(_accounts);
            _storage.LogTransaction(logMessage);
            return true;
        }
    }
}
