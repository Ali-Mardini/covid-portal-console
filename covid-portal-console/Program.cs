using System;
using System.Collections.Generic;

namespace covid_portal_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>
            {
                new Car{ CarId = 1, CarBrand = "Test1"},
                new Car{ CarId = 2, CarBrand = "Test2"}
            };

            var excel = new WriteToExcel<Car>(cars);
            var result = excel.CreateFile(cars);

            var formatedResult = result.Replace(",", "\t");

            Console.WriteLine(formatedResult);
        }

    }
}
