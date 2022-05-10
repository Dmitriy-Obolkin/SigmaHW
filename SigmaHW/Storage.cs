using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHW
{
    internal static class Storage
    {
        public static Dictionary<int, Product> products = new Dictionary<int, Product>();

        public static void Start()
        {
            Console.WriteLine(@"Выберите действие:
                        1. Наполнение информацией данных в режиме диалога;
                        2. Наполнение информацией данных путём инициализации;
                        3. Печать полной информации про все товары;
                        4. Найти все продукты по категории;
                        5. Изменить цену для всех товаров на указанный %;
                        6. Вывести информацию о товаре по его Id.
                        ");
            int pick;
            do
            {
                Console.Write("Ваш выбор: ");
                int.TryParse(Console.ReadLine(), out pick);
            }
            while (pick < 1 || pick > 6);

            switch(pick)
            {
                case 1:
                    AddFromDialog();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
            }
        }

        public static void AddFromDialog()
        {
            Console.WriteLine("\n----------------------------------------------------\n\nНаполнение информацией данных в режиме диалога:\n");
            Console.WriteLine(@"Выберите категорию товара:
                        1. Стандартный товар;
                        2. Мясо;
                        3. Молочные продукты.
                        ");
            int pick;
            do
            {
                Console.Write("Ваш выбор: ");
                int.TryParse(Console.ReadLine(), out pick);
            }
            while (pick < 1 || pick > 3);

            bool validEnter = false;
            string name = "";
            double price = 0;
            double weight = 0;
            do
            {
                try
                {
                    Console.Write("Введите название: ");
                    name = Console.ReadLine();
                    Console.Write("Введите цену: ");
                    price = double.Parse(Console.ReadLine());
                    Console.Write("Введите вес: ");
                    weight = double.Parse(Console.ReadLine());
                    validEnter = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка!\nПовторите ввод!\n{ex.Message}");
                }
            }
            while(!validEnter);
            

            switch (pick)
            {
                case 1:
                    Product newProduct = new Product(name, price, weight);
                    break;
                case 2:
                    CategoryMeat categoryMeat = CategoryMeat.Первый_сорт;
                    KindMeat kindMeat = KindMeat.Свинина;

                    Console.WriteLine($"Введите категорию мяса:\n\t\t\t1. {CategoryMeat.Высший_сорт}\n\t\t\t2. {CategoryMeat.Первый_сорт}\n\t\t\t3. {CategoryMeat.Второй_сорт}");
                    int pickCategoryMeat = 0;
                    do
                    {
                        Console.Write("Ваш выбор: ");
                        int.TryParse(Console.ReadLine(), out pickCategoryMeat);
                    }
                    while(pickCategoryMeat < 1 || pickCategoryMeat > 3);
                    switch(pickCategoryMeat)
                    {
                        case 1:
                            categoryMeat = CategoryMeat.Высший_сорт;
                            break;
                        case 2:
                            categoryMeat = CategoryMeat.Первый_сорт;
                            break;
                        case 3:
                            categoryMeat = CategoryMeat.Второй_сорт;
                            break;
                    }

                    Console.WriteLine($"Введите вид мяса:\n\t\t\t1. {KindMeat.Баранина}\n\t\t\t2. {KindMeat.Телятина}\n\t\t\t3. {KindMeat.Свинина}\n\t\t\t4. {KindMeat.Курятина}");
                    int pickKindMeat = 0;
                    do
                    {
                        Console.Write("Ваш выбор: ");
                        int.TryParse(Console.ReadLine(), out pickKindMeat);
                    }
                    while (pickKindMeat < 1 || pickKindMeat > 4);
                    switch (pickKindMeat)
                    {
                        case 1:
                            kindMeat = KindMeat.Баранина;
                            break;
                        case 2:
                            kindMeat = KindMeat.Телятина;
                            break;
                        case 3:
                            kindMeat = KindMeat.Свинина;
                            break;
                        case 4:
                            kindMeat = KindMeat.Курятина;
                            break;
                    }

                    Product newMeat = new Meat(name, price, weight, categoryMeat, kindMeat);
                    break;
                case 3:
                    break;
            }


        }
    }
}
