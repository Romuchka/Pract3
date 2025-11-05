using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Laba_C_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ЗАДАНИЕ 1 ===");
            Task1();

            Console.WriteLine("\n=== ЗАДАНИЕ 2 (вариант 6) ===");
            Task2();

            Console.WriteLine("\n=== ЗАДАНИЕ 3 (пользовательский тип) ===");
            Task3();

            Console.WriteLine("\n=== ЗАДАНИЕ 4 (ObservableCollection) ===");
            Task4();
        }

        static void Task1()
        {
            ArrayListDemo.Demonstrate();
        }

        static void Task2()
        {
            DictionaryStackDemo.Demonstrate();
        }

        static void Task3()
        {
            CustomTypeDemo.Demonstrate();
        }

        static void Task4()
        {
            ObservableCollectionDemo.Demonstrate();
        }
    }
}