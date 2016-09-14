using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine.Model
{
    public class Item
    {
        public int NumberOfAvailableItems { get; set; }

        public int Size { get; set; }

        /// <summary>
        /// Pound note or penny coin
        /// </summary>
        public double Type { get; set; }

        /// <summary>
        /// Value in pounds of the item
        /// </summary>
        public double Value => NumberOfAvailableItems * Size * Type;

        #region Equality

        protected bool Equals(Item other)
        {
            return NumberOfAvailableItems == other.NumberOfAvailableItems && Size == other.Size && Type.Equals(other.Type);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Item) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = NumberOfAvailableItems;
                hashCode = (hashCode*397) ^ Size;
                hashCode = (hashCode*397) ^ Type.GetHashCode();
                return hashCode;
            }
        }

        #endregion
    }
}
