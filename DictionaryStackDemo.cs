using System;
using System.Collections.Generic;

namespace Laba_C_
{
    public static class DictionaryStackDemo
    {
        public static void Demonstrate()
        {
            // Вариант 6: Dictionary<Tkey, TValue> -> Stack<T>
            // Первый тип: String

            // a) Создаем Dictionary и заполняем его
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "Apple");
            dictionary.Add(2, "Banana");
            dictionary.Add(3, "Cherry");
            dictionary.Add(4, "Date");
            dictionary.Add(5, "Elderberry");

            Console.WriteLine("Первая коллекция (Dictionary):");
            foreach (var item in dictionary)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }

            // b) Удаляем n элементов (например, 2 элемента)
            int n = 2;
            for (int i = 0; i < n && dictionary.Count > 0; i++)
            {
                int firstKey = -1;
                foreach (var key in dictionary.Keys)
                {
                    firstKey = key;
                    break;
                }
                if (firstKey != -1)
                {
                    dictionary.Remove(firstKey);
                }
            }

            Console.WriteLine($"\nПосле удаления {n} элементов:");
            foreach (var item in dictionary)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }

            // c) Добавляем другие элементы (все возможные методы)
            dictionary.Add(6, "Fig");
            dictionary[7] = "Grape"; // через индексатор

            Console.WriteLine("\nПосле добавления новых элементов:");
            foreach (var item in dictionary)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }

            // d) Создаем вторую коллекцию Stack<T> и заполняем данными из первой
            Stack<string> stack = new Stack<string>();

            // Берем только значения (TValue) из Dictionary
            foreach (var value in dictionary.Values)
            {
                stack.Push(value);
            }

            // e) Выводим вторую коллекцию
            Console.WriteLine("\nВторая коллекция (Stack):");
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            // f) Поиск заданного значения во второй коллекции
            string searchValue = "Cherry";
            bool found = stack.Contains(searchValue);
            Console.WriteLine($"\nЗначение '{searchValue}' {(found ? "найдено" : "не найдено")} в Stack");
        }
    }
}