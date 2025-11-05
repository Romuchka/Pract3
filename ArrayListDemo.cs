using System;
using System.Collections;

namespace Laba_C_
{
    public static class ArrayListDemo
    {
        public static void Demonstrate()
        {
            // a) Создаем необобщенную коллекцию ArrayList и заполняем 5-ю случайными целыми числами
            ArrayList arrayList = new ArrayList();
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                arrayList.Add(random.Next(1, 101)); // числа от 1 до 100
            }

            Console.WriteLine("После добавления 5 случайных чисел:");
            PrintArrayList(arrayList);

            // b) Добавляем строку
            arrayList.Add("Test String");
            Console.WriteLine("\nПосле добавления строки:");
            PrintArrayList(arrayList);

            // c) Удаляем заданный элемент (например, второй элемент)
            if (arrayList.Count > 1)
            {
                arrayList.RemoveAt(1);
                Console.WriteLine("\nПосле удаления второго элемента:");
                PrintArrayList(arrayList);
            }

            // d) Выводим количество элементов и коллекцию
            Console.WriteLine($"\nКоличество элементов: {arrayList.Count}");
            Console.WriteLine("Коллекция:");
            PrintArrayList(arrayList);

            // e) Выполняем поиск заданного значения
            object searchValue = "Test String";
            int index = arrayList.IndexOf(searchValue);
            if (index != -1)
            {
                Console.WriteLine($"\nЗначение '{searchValue}' найдено на позиции {index}");
            }
            else
            {
                Console.WriteLine($"\nЗначение '{searchValue}' не найдено");
            }
        }

        private static void PrintArrayList(ArrayList list)
        {
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}