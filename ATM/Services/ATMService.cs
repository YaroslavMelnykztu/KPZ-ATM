using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Data;
using ATM.Models;
using ATM.Strategies;
using ATM.Factories;

namespace ATM.Services
{
    public class ATMService
    {
        private ICommissionStrategy _commission;
        private FileStorage _storage;
        private List<Account> _accounts;
        private TransactionFactory _factory;

        public ATMService(ICommissionStrategy strategy)
        {
            this._commission = strategy;
            this._storage = FileStorage.GetInstance();
            this._accounts = _storage.LoadAccounts();
            this._factory = new TransactionFactory();
        }

        private Account GetAccount(string cardNumber)
        {
            return _accounts.FirstOrDefault(a => a.CardNumber == cardNumber);
        }

        private void SaveAndLog(BaseTransaction transaction, string cardNumber)
        {
            _storage.SaveAccounts(_accounts);
            _storage.LogTransaction(transaction.GetDetails() + " | Карта: " + cardNumber);
        }

        public double GetBalance(string cardNumber)
        {
            Account account = GetAccount(cardNumber);
            return account?.Balance ?? 0;
        }

        public bool Withdraw(string cardNumber, double amount)
        {
            Account account = GetAccount(cardNumber);
            if (account == null) return false;

            double fee = _commission.Calculate(amount);
            double total = amount + fee;

            if (account.Balance >= total)
            {
                account.Balance -= total;
                var transaction = _factory.CreateWithdraw(amount, fee);
                SaveAndLog(transaction, cardNumber);
                return true;
            }

            return false;
        }

        public bool Deposit(string cardNumber, double amount)
        {
            Account account = GetAccount(cardNumber);
            if (account == null) return false;

            account.Balance += amount;
            var transaction = _factory.CreateDeposit(amount);
            SaveAndLog(transaction, cardNumber);
            return true;
        }

        public bool Transfer(string fromCard, string toCard, double amount)
        {
            Account sender = GetAccount(fromCard);
            Account receiver = GetAccount(toCard);

            if (sender != null && receiver != null && sender.Balance >= amount)
            {
                sender.Balance -= amount;
                receiver.Balance += amount;
                var transaction = _factory.CreateTransfer(amount, toCard);
                SaveAndLog(transaction, fromCard);
                return true;
            }

            return false;
        }
    }
}
