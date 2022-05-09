using System;

namespace SigmaHW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product monitor = new Product("Монитор LG 24\'", 4999.90, 2.5);
            Product keyboard = new Product("Клавиатура Logitech", 1000, 1);
            Product mouse = new Product("Мышка A4Tech", 489.90, 0.3);

            Buy buy1 = new(monitor, keyboard);
            buy1.Add(2, monitor);
            buy1.Add(3, keyboard);

            Buy buy2 = new(keyboard);
            buy2.Add(9, keyboard);

            Buy buy3 = new(keyboard);
            buy3.Add(6, keyboard);
            buy3.Add(1, mouse, monitor, keyboard);

            Check.ShowBuy(buy1);   
            Check.ShowBuy(buy2);
            Check.ShowBuy(buy3);




            Meat fryChicken = new Meat("Жаренная цыпа", 60, 0.3, CategoryMeat.Первый_сорт, KindMeat.Курятина);
            DairyProducts milk = new DairyProducts("Молоко 3%", 30, 0.9, 14);
            DairyProducts milk2 = new DairyProducts("Молоко 0%", 21, 0.9, 21);
            DairyProducts milk3 = new DairyProducts("Молоко 1%", 26, 0.9, 16);
            DairyProducts milk4 = new DairyProducts("Молоко 2%", 38, 0.9, 8);

            Console.WriteLine(mouse.ToString());
            Console.WriteLine($"\tHashCode: {mouse.GetHashCode()}");
            Console.WriteLine($"{mouse.Equals(mouse)}\n");
            
            Console.WriteLine(fryChicken.ToString());
            Console.WriteLine($"\tHashCode: {fryChicken.GetHashCode()}\n");

            Console.WriteLine(milk.ToString());
            Console.WriteLine($"\tHashCode: {milk.GetHashCode()}\n");
            Console.WriteLine(milk2.ToString());
            Console.WriteLine($"\tHashCode: {milk2.GetHashCode()}\n");
            Console.WriteLine(milk3.ToString());
            Console.WriteLine($"\tHashCode: {milk3.GetHashCode()}\n");
            Console.WriteLine(milk4.ToString());

            Console.WriteLine(Product.ReferenceEquals(milk, milk2));
            Console.WriteLine(Product.ReferenceEquals(milk2, milk2));

        }
    }
}
