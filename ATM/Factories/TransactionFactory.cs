using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Data;
using ATM.Models;
using ATM.Services;
using ATM.Strategies;
using ATM.Factories;

namespace ATM.Factories
{
    public class TransactionFactory
    {
        public BaseTransaction CreateWithdraw(double amount, double commission)
        {
            var transaction = new WithdrawTransaction();
            transaction.Id = Guid.NewGuid().ToString();
            transaction.Date = DateTime.Now;
            transaction.Amount = amount;
            transaction.Commission = commission;
            return transaction;
        }

        public BaseTransaction CreateDeposit(double amount)
        {
            var transaction = new DepositTransaction();
            transaction.Id = Guid.NewGuid().ToString();
            transaction.Date = DateTime.Now;
            transaction.Amount = amount;
            return transaction;
        }

        public BaseTransaction CreateTransfer(double amount, string targetCard)
        {
            var transaction = new TransferTransaction();
            transaction.Id = Guid.NewGuid().ToString();
            transaction.Date = DateTime.Now;
            transaction.Amount = amount;
            transaction.TargetCard = targetCard;
            return transaction;
        }
    }
}
