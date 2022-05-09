using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHW
{
    internal static class Check
    {
        public static void ShowBuy(Buy buy)
        {
            Console.WriteLine($"------------------------------------------------------\n\n\t\t\tЧек {buy.number}\n");
            foreach(var prod in buy.prods)
            {
                Console.WriteLine($"{prod.name} ({prod.weight / prod.count}кг.) {Math.Round((prod.price/prod.count), 2)}грн. x{prod.count}шт. : "+"{0:F2}грн.", prod.price);
            }
            Console.WriteLine("\n----------------------\nВсего: {0}шт. ({1:F2}кг.)\nСумма: {2:F2}грн.\n", buy.CountAll, buy.WeightAll, buy.PriceAll);
        }
    }
}
