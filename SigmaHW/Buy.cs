using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHW
{
    internal class Buy //Чек
    {
        public List<Prod> prods = new List<Prod>(); //Список товаров в чеке
        public int CountAll { get; private set; } = 0;
        public double PriceAll { get; private set; } = 0;
        public double WeightAll { get; private set; } = 0;

        public static int Number { get; private set; } = 0;
        public int number { get; private set; } = 0;    




        public Buy(params Product[] products)
        {
            number = ++Number;
            Add(1, products);
        }

        public void Add(int count, params Product[] products)
        {
            if (count <= 0 || count > 100)   //Проверяем корректность кол-ва
            {
                throw new ArgumentException("Invalid count!");
            }

            foreach (var product in products)
            {
                foreach (Prod prod in prods)
                {
                    if (prod.name == product.Name)
                    {
                        prod.count += count;
                        prod.price += product.Price * count;
                        prod.weight += product.Weight * count;
                        CountAll += count;
                        PriceAll += product.Price * count;
                        WeightAll += product.Weight * count;
                        prods.Insert(prods.IndexOf(prod), prod);
                        prods.Remove(prod);
                        return;
                    }
                }

                Prod prodNew = new Prod();
                prodNew.Id = product.Id;
                prodNew.name = product.Name;
                prodNew.count += count;
                prodNew.price += product.Price * count;
                prodNew.weight += product.Weight * count;
                CountAll += prodNew.count;
                PriceAll += prodNew.price;
                WeightAll += prodNew.weight;

                prods.Add(prodNew);
            }
        }


        
        internal class Prod
        {
            public int Id;
            public string name;
            public int count = 0;
            public double price = 0;
            public double weight = 0;
        }
    }
}

