using System;
using System.Data.Common;
using System.Transactions;

namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args) {

            BankAccount account = new BankAccount();
            
            bool IsContinue = true;

            while (IsContinue)
        {
            Console.WriteLine("1. Yeni hesab ac");
            
            Console.WriteLine("2. Balansi artir");
            
            Console.WriteLine("3. Nagdlashdirma");
           
            Console.WriteLine("4. Balansi ekranda goster");

            Console.WriteLine("5. Hesab uzre emeliyyatlari goster");

            Console.WriteLine("6. Cixis");

            Console.Write("Seçiminizi edin: ");
            int secim = int.Parse(Console.ReadLine());

            switch (secim)
            {
                case 1:
                        account.CreateAccount(account.OwnerName);
                    break;
                case 2:
                        Console.Write("Meblegi qeyd edin : ");
                        decimal Amount = decimal.Parse(Console.ReadLine());
                        Console.Write("Kocurmenin detallari : ");
                        string Description = Console.ReadLine();
                        account.MakeDeposit(Amount, Description);
                    break;
                case 3:
                        Console.Write("Meblegi qeyd edin : ");
                        Amount = decimal.Parse(Console.ReadLine());
                        Console.Write("Kocurmenin detallari : ");
                        Description = Console.ReadLine();
                        account.MakeCredit(Amount, Description);
                    break;
                case 4:
                        account.GetBalance();
                    break;
                case 5:
                        account.GetTransAction();
                        break;
                case 6:
                        Console.WriteLine("Proqramdan cixilir...");
                        Thread.Sleep(2000);
                        IsContinue = false;
                    break;
                 default: 
                        Console.Clear();
                        Console.WriteLine("Zehmet olmasa yeniden secim edin...");
                        break;

            }
}
        }
    }
}
