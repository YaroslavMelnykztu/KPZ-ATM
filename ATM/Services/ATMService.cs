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
        private readonly ICommissionStrategy _commission;
        private readonly FileStorage _storage;
        private List<Account> _accounts;

        public ATMService(ICommissionStrategy strategy)
        {
            _commission = strategy;
            _storage = FileStorage.GetInstance();
            _accounts = _storage.LoadAccounts();
        }

        private Account GetAccount(string cardNumber) =>
            _accounts.FirstOrDefault(a => a.CardNumber == cardNumber);

        private void CommitTransaction(string logMessage)
        {
            _storage.SaveAccounts(_accounts);
            _storage.LogTransaction(logMessage);
        }

        public double GetBalance(string cardNumber) =>
            GetAccount(cardNumber)?.Balance ?? 0;

        public bool Withdraw(string cardNumber, double amount)
        {
            var account = GetAccount(cardNumber);
            if (account == null) return false; 

            double fee = _commission.Calculate(amount);
            double total = amount + fee;

            if (account.Balance < total) return false; 
            account.Balance -= total;
            CommitTransaction($"Зняття: {amount} | Комісія: {fee} | Карта: {cardNumber}");
            return true;
        }

        public bool Deposit(string cardNumber, double amount)
        {
            var account = GetAccount(cardNumber);
            if (account == null) return false;

            account.Balance += amount;
            CommitTransaction($"Поповнення: {amount} | Карта: {cardNumber}");
            return true;
        }

        public bool Transfer(string fromCard, string toCard, double amount)
        {
            var sender = GetAccount(fromCard);
            var receiver = GetAccount(toCard);

            if (sender == null || receiver == null || sender.Balance < amount) return false;

            sender.Balance -= amount;
            receiver.Balance += amount;
            CommitTransaction($"Переказ: {amount} з {fromCard} на {toCard}");
            return true;
        }
    }
}
