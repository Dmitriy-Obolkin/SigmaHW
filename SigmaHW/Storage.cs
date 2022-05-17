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
            do
            {
                Console.WriteLine(@"Выберите действие:
                            1. Наполнение информацией данных в режиме диалога;
                            2. Наполнение информацией данных путём инициализации;
                            3. Печать полной информации про все товары;
                            4. Найти все продукты по категории;
                            5. Изменить цену для всех товаров на указанный %;
                            6. Вывести информацию о товаре по его Id;
                            7. Закрыть программу.
                            ");
                int pick;
                do
                {
                    Console.Write("Ваш выбор: ");
                    int.TryParse(Console.ReadLine(), out pick);
                }
                while (pick < 1 || pick > 7);

                Console.WriteLine();

                switch (pick)
                {
                    case 1:

                        AddFromDialog();
                        break;

                    case 2:

                        InitializingStorage();
                        break;

                    case 3:

                        PrintAllStorage();
                        break;

                    case 4:

                        Console.WriteLine(@"Выберите категорию товара:
                                    1. Стандартный товар;
                                    2. Мясо;
                                    3. Молочные продукты.
                                    ");
                        pick = 0;
                        do
                        {
                            Console.Write("Ваш выбор: ");
                            int.TryParse(Console.ReadLine(), out pick);
                        }
                        while (pick < 1 || pick > 3);
                        string category = "";

                        switch(pick)
                        {
                            case 1: 
                                category = "Product";
                                break;
                            case 2:
                                category = "Meat";
                                break;
                            case 3:
                                category = "DairyProducts";
                                break;
                        }

                        FindByCategory(category);
                        break;

                    case 5:

                        double percent = 0;
                        do
                        {
                            Console.Write("Введите процент скидки (не больше 80%): ");
                            double.TryParse(Console.ReadLine(), out percent);
                        }
                        while (pick < 1 || pick > 80);

                        ChangePrice(percent);

                        break;
                    case 6:

                        int Id = 0;
                        do
                        {
                            Console.Write("Введите Id товара: ");
                            int.TryParse(Console.ReadLine(), out Id);
                        }
                        while (pick < 1 || pick > 999999);
                        FindById(Id);

                        break;
                    case 7:

                        Console.WriteLine("Нажмите любую клавишу чтобы продолжить...");
                        return;
                }
            }
            while (true);
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

            Console.WriteLine($"\n Новый товар {name} успешно добавлен!");
            Console.WriteLine("\n----------------------------------------------------\n\n");
        }
        public static void InitializingStorage()
        {
            Console.WriteLine("\n----------------------------------------------------\n\nНаполнение информацией данных путём инициализации:\n");

            Product monitor = new Product("Монитор LG 24\'", 4999.90, 2.5);
            Product keyboard = new Product("Клавиатура Logitech", 1000, 1);
            Product mouse = new Product("Мышка A4Tech", 489.90, 0.3);
            Product fryChicken = new Meat("Жаренная цыпа", 60, 0.3, CategoryMeat.Первый_сорт, KindMeat.Курятина);
            Product milk = new DairyProducts("Молоко 3%", 30, 0.9, 14);
            Product milk2 = new DairyProducts("Молоко 0%", 21, 0.9, 21);
            Product milk3 = new DairyProducts("Молоко 1%", 26, 0.9, 16);
            Product milk4 = new DairyProducts("Молоко 2%", 38, 0.9, 8);

            Console.WriteLine($"\n Данные успешно проинициализированны, новый товар добавлен в storage!");
            Console.WriteLine("\n----------------------------------------------------\n\n");
        }
        public static void PrintAllStorage()
        {
            Console.WriteLine("\n----------------------------------------------------\n\nПечать полной информации про все товары:\n");

            foreach (var product in products.Values)
            {
                Console.WriteLine($"{ product.ToString() }");
            }

            Console.WriteLine("\n----------------------------------------------------\n\n");
        }
        public static List<Product> FindByCategory(string category)
        {
            Console.WriteLine($"\n----------------------------------------------------\n\nПоиск всех товаров по категории {category}:\n");

            List<Product> tempProducts = new List<Product>();

            foreach (var product in products.Values)
            {
                if(product.GetType().ToString().Contains($".{category}"))
                {
                    Console.WriteLine(product);
                    tempProducts.Add(product);
                }
            }

            Console.WriteLine("\n----------------------------------------------------\n\n");

            return tempProducts;
        }
        public static void ChangePrice(double percent)
        {
            Console.WriteLine($"\n----------------------------------------------------\n\nИзменить цену для всех товаров на {percent}%:\n");

            foreach (var product in products.Values)
            {
                product.ChangePrice(percent);
            }

            Console.WriteLine("\n----------------------------------------------------\n\n");
        }
        public static Product FindById(int Id)
        {
            Console.WriteLine($"\n----------------------------------------------------\n\nВывести информацию о товаре по Id {Id}:\n");

            Product tempProduct = null;

            bool finded = false;
            foreach (var product in products)
            {
                if (product.Key == Id)
                {
                    finded = true;
                    Console.WriteLine(product.Value);
                    tempProduct = product.Value;
                }
            }

            if(!finded)
            {
                Console.WriteLine($"Товар с Id {Id} не существует!");
                return null;
            }

            Console.WriteLine("\n----------------------------------------------------\n\n");

            return tempProduct;
        }
    }
}
