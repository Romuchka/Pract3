using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Laba_C_
{
    public static class ObservableCollectionDemo
    {
        public static void Demonstrate()
        {
            // Создаем ObservableCollection
            ObservableCollection<HomeAppliance> observableAppliances = new ObservableCollection<HomeAppliance>();

            // Регистрируем обработчик события
            observableAppliances.CollectionChanged += OnCollectionChanged;

            Console.WriteLine("Демонстрация ObservableCollection:");

            // Добавляем элементы
            Console.WriteLine("\n--- Добавление элементов ---");
            observableAppliances.Add(new HomeAppliance("Fridge-2000", "Samsung", 899.99, 2022));
            observableAppliances.Add(new HomeAppliance("Washer-X1", "LG", 649.50, 2023));
            observableAppliances.Add(new HomeAppliance("Oven-Pro", "Bosch", 1200.00, 2021));

            // Вставляем элемент
            Console.WriteLine("\n--- Вставка элемента ---");
            observableAppliances.Insert(1, new HomeAppliance("Microwave-Mini", "Panasonic", 199.99, 2023));

            // Заменяем элемент
            Console.WriteLine("\n--- Замена элемента ---");
            if (observableAppliances.Count > 0)
            {
                observableAppliances[0] = new HomeAppliance("Fridge-3000", "Samsung", 999.99, 2023);
            }

            // Удаляем элемент
            Console.WriteLine("\n--- Удаление элемента ---");
            if (observableAppliances.Count > 0)
            {
                observableAppliances.RemoveAt(0);
            }

            // Перемещаем элемент
            Console.WriteLine("\n--- Перемещение элемента ---");
            if (observableAppliances.Count > 1)
            {
                observableAppliances.Move(0, observableAppliances.Count - 1);
            }

            // Очищаем коллекцию
            Console.WriteLine("\n--- Очистка коллекции ---");
            observableAppliances.Clear();
        }

        private static void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var collection = (ObservableCollection<HomeAppliance>)sender;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine($"Добавлен новый элемент. Позиция: {e.NewStartingIndex}. Всего элементов: {collection.Count}");
                    if (e.NewItems != null)
                    {
                        foreach (HomeAppliance item in e.NewItems)
                        {
                            Console.WriteLine($"  Добавлен: {item.GetModel()}");
                        }
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine($"Удален элемент. Позиция: {e.OldStartingIndex}. Всего элементов: {collection.Count}");
                    if (e.OldItems != null)
                    {
                        foreach (HomeAppliance item in e.OldItems)
                        {
                            Console.WriteLine($"  Удален: {item.GetModel()}");
                        }
                    }
                    break;

                case NotifyCollectionChangedAction.Replace:
                    Console.WriteLine($"Элемент заменен. Позиция: {e.NewStartingIndex}");
                    if (e.NewItems != null && e.OldItems != null)
                    {
                        for (int i = 0; i < e.NewItems.Count; i++)
                        {
                            var newItem = (HomeAppliance)e.NewItems[i];
                            var oldItem = (HomeAppliance)e.OldItems[i];
                            Console.WriteLine($"  Заменен '{oldItem.GetModel()}' на '{newItem.GetModel()}'");
                        }
                    }
                    break;

                case NotifyCollectionChangedAction.Move:
                    Console.WriteLine($"Элемент перемещен с позиции {e.OldStartingIndex} на позицию {e.NewStartingIndex}");
                    if (e.NewItems != null)
                    {
                        foreach (HomeAppliance item in e.NewItems)
                        {
                            Console.WriteLine($"  Перемещен: {item.GetModel()}");
                        }
                    }
                    break;

                case NotifyCollectionChangedAction.Reset:
                    Console.WriteLine("Коллекция очищена");
                    break;

                default:
                    Console.WriteLine("Неизвестное действие с коллекцией");
                    break;
            }
        }
    }
}