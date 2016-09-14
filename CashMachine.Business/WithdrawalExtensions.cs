using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashMachine.Model;

namespace CashMachine.Business
{
    public static class WithdrawalExtensions
    {
        public static void AddItemUnit(this Withdrawal withdrawal, Item item)
        {
            var itemTypeExists = withdrawal.WithdrawnItems.Count(x => x.Size == item.Size && x.Type == item.Type) > 0;
            if (itemTypeExists)
            {
                var itemToIncrement = withdrawal.WithdrawnItems.First(x => x.Size == item.Size && x.Type == item.Type);
                itemToIncrement.NumberOfAvailableItems++;
            }
            else
            {
                withdrawal.WithdrawnItems.Add(new Item { NumberOfAvailableItems = 1, Size = item.Size, Type = item.Type });
            }
        }
    }
}
