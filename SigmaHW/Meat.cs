using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHW
{
    public enum CategoryMeat { Высший_сорт, Первый_сорт, Второй_сорт };
    public enum KindMeat { Баранина, Телятина, Свинина, Курятина };
    internal class Meat : Product
    {
        public CategoryMeat CategoryMeat { get; private set; }
        public KindMeat KindMeat { get; private set; }


        public Meat(string name, double price, double weight, CategoryMeat categoryMeat, KindMeat kindMeat) : base(name, price, weight)
        {
            CategoryMeat = categoryMeat;
            KindMeat = kindMeat;
        }

        internal override void SetID()
        {
            Id = 111 * 1000 + ++ID;
        }

        public override string ToString()
        {
            return $"{Id} \"{Name}\" {Price}грн. {Weight}кг. ({KindMeat}, {CategoryMeat})";
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
        public static bool ReferenceEquals(Meat lhs, Meat rhs)
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
