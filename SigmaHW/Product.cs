using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHW
{
    internal class Product
    {
        public string Name { get; private set; }
        public double Price { get; private set; }
        public double Weight { get; private set; }

        public static int ID { get; private protected set; } = 0;
        public int Id { get; private protected set; } = 0;


        public Product(string name, double price, double weight)
        {
            if (!string.IsNullOrWhiteSpace(name) && price > 0 && weight > 0)
            {
                Name = name;
                Price = price;
                Weight = weight;
                SetID();
            }
            else
            {
                throw new ArgumentException("Invalid args specified!");
            }
        }

        internal virtual void SetID()
        {
            Id = 110 * 1000 + ++ID;
        }

        public override string ToString()
        {
            return $"{Id} \"{Name}\" {Price}грн. {Weight}кг.";
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

        public static bool ReferenceEquals(Product lhs, Product rhs)
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
