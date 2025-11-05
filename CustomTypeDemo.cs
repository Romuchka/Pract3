using System;
using System.Collections.Generic;

namespace Laba_C_
{
    public static class CustomTypeDemo
    {
        public static void Demonstrate()
        {
            // Создаем коллекцию Dictionary с пользовательским типом
            Dictionary<int, HomeAppliance> applianceDict = new Dictionary<int, HomeAppliance>();

            // Заполняем коллекцию
            applianceDict.Add(1, new HomeAppliance("Fridge-2000", "Samsung", 899.99, 2022));
            applianceDict.Add(2, new HomeAppliance("Washer-X1", "LG", 649.50, 2023));
            applianceDict.Add(3, new HomeAppliance("Oven-Pro", "Bosch", 1200.00, 2021));
            applianceDict.Add(4, new HomeAppliance("Microwave-Mini", "Panasonic", 199.99, 2023));

            // a) Выводим коллекцию
            Console.WriteLine("Первая коллекция (Dictionary<HomeAppliance>):");
            foreach (var item in applianceDict)
            {
                Console.Write($"Key: {item.Key} - ");
                item.Value.PrintInfo();
            }

            // b) Удаляем n элементов
            int n = 1;
            for (int i = 0; i < n && applianceDict.Count > 0; i++)
            {
                int firstKey = -1;
                foreach (var key in applianceDict.Keys)
                {
                    firstKey = key;
                    break;
                }
                if (firstKey != -1)
                {
                    applianceDict.Remove(firstKey);
                }
            }

            Console.WriteLine($"\nПосле удаления {n} элементов:");
            foreach (var item in applianceDict)
            {
                Console.Write($"Key: {item.Key} - ");
                item.Value.PrintInfo();
            }

            // c) Добавляем другие элементы
            applianceDict.Add(5, new HomeAppliance("Dishwasher-ECO", "Whirlpool", 750.00, 2022));
            applianceDict[6] = new HomeAppliance("TV-Smart", "Sony", 1500.00, 2023);

            Console.WriteLine("\nПосле добавления новых элементов:");
            foreach (var item in applianceDict)
            {
                Console.Write($"Key: {item.Key} - ");
                item.Value.PrintInfo();
            }

            // d) Создаем вторую коллекцию Stack<T> и заполняем данными из первой
            Stack<HomeAppliance> applianceStack = new Stack<HomeAppliance>();

            foreach (var value in applianceDict.Values)
            {
                applianceStack.Push(value);
            }

            // e) Выводим вторую коллекцию
            Console.WriteLine("\nВторая коллекция (Stack<HomeAppliance>):");
            foreach (var appliance in applianceStack)
            {
                appliance.PrintInfo();
            }

            // f) Поиск заданного значения
            HomeAppliance searchAppliance = new HomeAppliance("Washer-X1", "LG", 649.50, 2023);
            bool found = false;
            foreach (var appliance in applianceStack)
            {
                if (appliance.GetModel() == searchAppliance.GetModel() &&
                    appliance.GetManufacturer() == searchAppliance.GetManufacturer())
                {
                    found = true;
                    break;
                }
            }
            Console.WriteLine($"\nБытовая техника '{searchAppliance.GetModel()}' {(found ? "найдена" : "не найдена")} в Stack");

            // Демонстрация интерфейсов IComparable и IComparer
            DemonstrateInterfaces();
        }

        private static void DemonstrateInterfaces()
        {
            Console.WriteLine("\n=== Демонстрация интерфейсов IComparable и IComparer ===");

            List<HomeAppliance> appliances = new List<HomeAppliance>
            {
                new HomeAppliance("Fridge-2000", "Samsung", 899.99, 2022),
                new HomeAppliance("Washer-X1", "LG", 649.50, 2023),
                new HomeAppliance("Oven-Pro", "Bosch", 1200.00, 2021),
                new HomeAppliance("Microwave-Mini", "Panasonic", 199.99, 2023)
            };

            Console.WriteLine("\nИсходный список:");
            foreach (var appliance in appliances)
            {
                appliance.PrintInfo();
            }

            // Сортировка с использованием IComparable (по цене)
            appliances.Sort();
            Console.WriteLine("\nПосле сортировки по цене (IComparable):");
            foreach (var appliance in appliances)
            {
                appliance.PrintInfo();
            }

            // Сортировка с использованием IComparer (по году)
            appliances.Sort(new HomeApplianceYearComparer());
            Console.WriteLine("\nПосле сортировки по году (IComparer):");
            foreach (var appliance in appliances)
            {
                appliance.PrintInfo();
            }

            // Сортировка с использованием IComparer (по производителю и модели)
            appliances.Sort(new HomeApplianceManufacturerModelComparer());
            Console.WriteLine("\nПосле сортировки по производителю и модели (IComparer):");
            foreach (var appliance in appliances)
            {
                appliance.PrintInfo();
            }

            // Демонстрация ICloneable
            Console.WriteLine("\n=== Демонстрация ICloneable ===");
            HomeAppliance original = new HomeAppliance("TV-Smart", "Sony", 1500.00, 2023);
            HomeAppliance cloned = (HomeAppliance)original.Clone();

            Console.WriteLine("Оригинал:");
            original.PrintInfo();
            Console.WriteLine("Клон:");
            cloned.PrintInfo();
            Console.WriteLine($"Это один и тот же объект? {ReferenceEquals(original, cloned)}");
        }
    }
}