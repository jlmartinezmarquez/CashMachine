using CashMachine.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine.Business
{
    public class CashMachineOperations
    {
        /// <summary>
        /// Algorithm 1
        /// Try to refactor it using recursion in case there are performance issues? Although it might overcomplicate the solution if there's no strong reason to use recursion
        /// </summary>
        public Withdrawal ReturnLeastNumberOfItems(double amount, List<Item> repository)
        {
            //Error control
            var initialBalance = Repository.Repository.CalculateBalance(repository);
            if (amount > initialBalance || amount < 0) return null;

            var sortedRepository = repository.OrderByDescending(x => x.Type).ThenByDescending(x => x.Size).ToList();

            var toReturn = GetWithdrawalFromRepository(amount, initialBalance, sortedRepository);

            return toReturn;
        }

        private static Withdrawal GetWithdrawalFromRepository(double amount, double initialBalance, List<Item> repository)
        {
            var toReturn = new Withdrawal {BalanceAfter = initialBalance, WithdrawnItems = new List<Item>()};
            foreach (var item in repository)
            {
                if (amount == 0.00) break; //We have already withdrawn all we needed
                while (item.NumberOfAvailableItems > 0)
                {
                    if (item.Size > amount)
                        break; //The current item is bigger than what we have left. We need to try with a smaller item
                    if (item.Size <= amount)
                    {
                        //Deduct the current (biggest) item from the repository
                        item.NumberOfAvailableItems--;

                        //Add item unit to withdrawal
                        toReturn.AddItemUnit(item);
                        toReturn.BalanceAfter = Repository.Repository.CalculateBalance(repository);

                        amount -= item.Size; //Leave in amount what we have left to take from the repository                
                    }
                }
            }
            return toReturn;
        }

        /// <summary>
        /// Algorithm 2
        /// </summary>
        public Withdrawal ReturnHighestNumberOf20Notes(double amount, List<Item> repository)
        {
            ////Error control
            //var initialBalance = Repository.Repository.CalculateBalance(repository);
            //if (amount > initialBalance || amount < 0) return null;

            ////Withdraw just 20s
            //var numberOf20Notes = (int)Math.Truncate(amount /20);
            //if (numberOf20Notes > 0)
            //{
            //    var item20Repository = repository.First(x => x.Size == Size.Twenty && x.Type == ItemType.Pound);
                


            //    item20Repository.NumberOfAvailableItems -= numberOf20Notes;



            //    var item20ToAdd = new Item
            //    {
            //        NumberOfAvailableItems = numberOf20Notes,
            //        Size = Size.Twenty,
            //        Type = ItemType.Pound
            //    };
            //}

            ////Withdraw the rest
            //GetWithdrawalFromRepository()

            return null;
        }
    }
}
