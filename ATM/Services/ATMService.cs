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
        private readonly List<Account> _accounts;

        public ATMService(ICommissionStrategy strategy)
        {
            _commission = strategy;
            _storage = FileStorage.GetInstance();
            _accounts = _storage.LoadAccounts();
        }

        public double GetBalance(string cardNumber)
        {
            Account account = FindAccount(cardNumber);
            return account?.Balance ?? 0;
        }

        public bool Withdraw(string cardNumber, double amount)
        {
            Account account = FindAccount(cardNumber);

            if (account == null)
            {
                return false;
            }

            double fee = _commission.Calculate(amount);
            double total = amount + fee;

            if (account.Balance < total)
            {
                return false;
            }

            account.Balance -= total;

            SaveAndLogTransaction(
                "Зняття: " + amount +
                " | Комісія: " + fee +
                " | Карта: " + cardNumber);

            return true;
        }

        public bool Deposit(string cardNumber, double amount)
        {
            Account account = FindAccount(cardNumber);

            if (account == null)
            {
                return false;
            }

            account.Balance += amount;

            SaveAndLogTransaction(
                "Поповнення: " + amount +
                " | Карта: " + cardNumber);

            return true;
        }

        public bool Transfer(string fromCard, string toCard, double amount)
        {
            Account sender = FindAccount(fromCard);
            Account receiver = FindAccount(toCard);

            if (sender == null || receiver == null)
            {
                return false;
            }

            if (sender.Balance < amount)
            {
                return false;
            }

            sender.Balance -= amount;
            receiver.Balance += amount;

            SaveAndLogTransaction(
                "Переказ: " + amount +
                " з " + fromCard +
                " на " + toCard);

            return true;
        }

        private Account FindAccount(string cardNumber)
        {
            return _accounts.FirstOrDefault(
                account => account.CardNumber == cardNumber
            );
        }

        private void SaveAndLogTransaction(string message)
        {
            _storage.SaveAccounts(_accounts);
            _storage.LogTransaction(message);
        }
    }
}