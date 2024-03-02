using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class Transaction
    {
        public decimal Amount { get; set; }
        public DateTime OperationDate { get; set; }
        public TransactionType TransactionType { get; set; }
        public OperationType OperationType { get; set; }
        public string Description { get; set; }


        public static Transaction CreateTransaction(decimal amount, TransactionType transactionType, OperationType operationType, string description)
        {
            Transaction transaction = new Transaction();
            transaction.Amount = amount;
            transaction.TransactionType = transactionType;
            transaction.OperationType = operationType;
            transaction.Description = description;
            transaction.OperationDate = DateTime.Now;
            return transaction;
        }
       

        public override string ToString()
        {
            return $"Mebleg : {this.Amount}, Kocurmenin tipi : {this.TransactionType}, Kocurmenin neticesi : {this.OperationType} , Kocurmenin detallari : {this.Description}";
        }

    }
}
