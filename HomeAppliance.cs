using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_C_
{
    public class HomeAppliance : IComparable<HomeAppliance>, ICloneable
    {
        protected string model;
        protected string manufacturer;
        protected double price;
        protected int year;

        public HomeAppliance(string m = "Unknown", string manu = "Unknown", double p = 0.0, int y = 2000)
        {
            model = m;
            manufacturer = manu;
            price = p;
            year = y;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Model: {model}, Manufacturer: {manufacturer}, Price: {price} USD, Year: {year}");
        }

        // Геттеры
        public string GetModel() => model;
        public string GetManufacturer() => manufacturer;
        public double GetPrice() => price;
        public int GetYear() => year;

        // Сеттеры
        public void SetPrice(double p)
        {
            if (p < 0)
            {
                throw new ArgumentException("Price cannot be negative.");
            }
            price = p;
        }

        public void SetYear(int y)
        {
            int currentYear = 2023;
            if (y < 1980 || y > currentYear)
            {
                throw new ArgumentException($"Year must be between 1980 and {currentYear}.");
            }
            year = y;
        }

        // Реализация IComparable
        public int CompareTo(HomeAppliance other)
        {
            if (other == null) return 1;

            // Сравниваем по цене
            return this.price.CompareTo(other.price);
        }

        // Реализация ICloneable (глубокое копирование)
        public object Clone()
        {
            return new HomeAppliance(this.model, this.manufacturer, this.price, this.year);
        }

        // Переопределение ToString для удобства вывода
        public override string ToString()
        {
            return $"{manufacturer} {model} - {price} USD ({year})";
        }
    }

    // Класс-компаратор для сравнения по году выпуска
    public class HomeApplianceYearComparer : IComparer<HomeAppliance>
    {
        public int Compare(HomeAppliance x, HomeAppliance y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            return x.GetYear().CompareTo(y.GetYear());
        }
    }

    // Класс-компаратор для сравнения по производителю и модели
    public class HomeApplianceManufacturerModelComparer : IComparer<HomeAppliance>
    {
        public int Compare(HomeAppliance x, HomeAppliance y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            int manufacturerComparison = string.Compare(x.GetManufacturer(), y.GetManufacturer());
            if (manufacturerComparison != 0)
            {
                return manufacturerComparison;
            }

            return string.Compare(x.GetModel(), y.GetModel());
        }
    }
}