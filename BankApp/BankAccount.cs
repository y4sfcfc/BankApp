    using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankApp
{
    internal class BankAccount
    {
        public int AccountNumber { get; set; }
        public string OwnerName  { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> TransactionList  = new List<Transaction>();
        public BankAccount CreateAccount(string fullName)
        {
            BankAccount account = new BankAccount();
            account.OwnerName = fullName;
            account.Balance = 0;
            account.AccountNumber = new Random().Next(1,100);
            Console.Write("Zehmet olmasa tam adinizi daxil edin : ");
            account.OwnerName = Console.ReadLine();
            Console.WriteLine($"{account.AccountNumber} nomreli hesabiniz aktivleshdirildi...");
            Console.WriteLine($"Cari balans {account.Balance} AZN teskil edir");
            return account;
        }

        public decimal MakeDeposit(decimal amount, string description)
        {                        
            Transaction transaction = Transaction.CreateTransaction(amount,TransactionType.Deposit,OperationType.Success,description);      
            TransactionList.Add(transaction);
            Balance += amount;
            Console.WriteLine($"Balansiniza {amount} AZN elave edildi");
            return Balance;
        }

        public decimal MakeCredit(decimal amount, string description)
        {
            Transaction transaction = new Transaction();
            if (amount < Balance)
            {
                transaction = Transaction.CreateTransaction(amount, TransactionType.Credit, OperationType.Success, description);
                Balance -= amount;
                Console.WriteLine($"Balansinizdan {amount} AZN cixildi");
            }
            else
            {
                transaction = Transaction.CreateTransaction(amount, TransactionType.Deposit, OperationType.Fail, description);
                Console.WriteLine("Balansinizda kifayet qeder mebleg yoxdur");
            }
            TransactionList.Add(transaction);
            return Balance;
        }        
        public void GetBalance()
        { Console.WriteLine($"Balansiniz {Balance} AZN teskil edir"); }

        public void GetTransAction()
        {
        foreach (Transaction transaction in TransactionList)
            {
                Console.WriteLine(transaction.ToString());
            }
        
        
        }
              
    }
}
