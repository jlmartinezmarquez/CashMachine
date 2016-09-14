using CashMachine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine.Repository
{
    public static class Repository  //In a real world solution we'd have Entities and Model for DTO's, with converters per DTO
    {
        public static List<Item> GetInitRepository()
        {
            return new List<Item>
            {
                new Item { Size = Size.One, NumberOfAvailableItems = 100, Type = ItemType.Penny },
                new Item { Size = Size.Two, NumberOfAvailableItems = 100, Type = ItemType.Penny },
                new Item { Size = Size.Five, NumberOfAvailableItems = 100, Type = ItemType.Penny },
                new Item { Size = Size.Ten, NumberOfAvailableItems = 100, Type = ItemType.Penny },
                new Item { Size = Size.Twenty, NumberOfAvailableItems = 100, Type = ItemType.Penny },
                new Item { Size = Size.Fifty, NumberOfAvailableItems = 100, Type = ItemType.Penny },
                new Item { Size = Size.One, NumberOfAvailableItems = 100, Type = ItemType.Pound },
                new Item { Size = Size.Two, NumberOfAvailableItems = 100, Type = ItemType.Pound },
                new Item { Size = Size.Five, NumberOfAvailableItems = 50, Type = ItemType.Pound },
                new Item { Size = Size.Ten, NumberOfAvailableItems = 50, Type = ItemType.Pound },
                new Item { Size = Size.Twenty, NumberOfAvailableItems = 50, Type = ItemType.Pound },
                new Item { Size = Size.Fifty, NumberOfAvailableItems = 50, Type = ItemType.Pound },
            };
        }

        public static double CalculateBalance(List<Item> repository)
        {
            var balance = 0.00;
            foreach (var item in repository)
            {
                balance += item.Value;
            }

            return balance;
        }
    }
}
