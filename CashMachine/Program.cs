using System;
using System.Runtime.Remoting.Messaging;
using CashMachine.Business;
using CashMachine.Model;

namespace CashMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = Repository.Repository.GetInitRepository(); //In a Web.Api real world solution I would have injected the repository to the Controllers contructors

            Console.Write("Press (1) for Algorithm 1");
            Console.WriteLine();
            Console.Write("Press (2) for Algorithm 2");
            Console.WriteLine();

            var keyPressed = Console.ReadKey();
            switch (keyPressed.KeyChar)
            {
                case '1':
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Introduce the amount with the format xxx.xx");
                    Console.WriteLine();

                    double amount = 0.00;
                    var readAmount = Console.ReadLine();
                    try
                    {
                        amount = double.Parse(readAmount);
                    }
                    catch(Exception)
                    {
                        ReturnError("Introduce the amount with the format xxx.xx");
                    }

                    var cashMachineBusiness = new CashMachineOperations();
                    var withdrawal = cashMachineBusiness.ReturnLeastNumberOfItems(amount, repository);

                    PrintWithdrawal(withdrawal);

                    break;
            }
        }

        private static void PrintWithdrawal(Withdrawal withdrawal)
        {
            foreach (Item item in withdrawal.WithdrawnItems)
            {
                Console.Write($"£{item.Size}x{item.NumberOfAvailableItems}, ");
            }
            Console.WriteLine();
            Console.WriteLine($"£{withdrawal.BalanceAfter} balance");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Environment.Exit(0);
        }

        private static void ReturnError(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
