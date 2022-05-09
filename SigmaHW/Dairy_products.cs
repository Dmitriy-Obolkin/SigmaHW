using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHW
{
    internal class DairyProducts : Product
    {
        public int ExpirationDate { get; private set; }


        public DairyProducts(string name, double price, double weight, int expDate) : base(name, price, weight)
        {
            if (expDate > 0)
                ExpirationDate = expDate;
            else
                throw new ArgumentException("Invalid Expiration Date!");
        }

        internal override void SetID()
        {
            Id = 112 * 1000 + ++ID;
        }

        public override string ToString()
        {
            return $"{Id} \"{Name}\" {Price}грн. {Weight}кг. {ExpirationDate} дней";
        }
        public override int GetHashCode()
        {
            int hashCode = 31 * Id.GetHashCode();
            return hashCode;
        }
        public override bool Equals(object obj)
        {
            if (obj is Product product) return Id == product.Id;
            return false;
        }
        public static bool ReferenceEquals(DairyProducts lhs, DairyProducts rhs)
        {
            if (Object.ReferenceEquals(lhs, null))
            {
                if (Object.ReferenceEquals(rhs, null))
                {
                    return true;
                }
                return false;
            }

            return lhs.Equals(rhs);
        }

    }
}
