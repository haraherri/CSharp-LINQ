using System;
using System.Collections.Generic;
using System.Linq;

namespace HoGiaHuy_LINQ
{
    internal class Program
    {
        class Verhical
        {
            public string Manufacturer { get; set; }
            public int Year { get; set; }
            public double Price { get; set; }
        }
        class Car : Verhical
        {
            public string Model { get; set; }
        }

        class Truck : Verhical
        {
            public string CompanyOwner { get; set; }
            public double LoadCapacity { get; set; }
        }
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>
        {
            new Car { Manufacturer = "Toyota", Model = "Camry", Year = 2018, Price = 150000 },
            new Car { Manufacturer = "Honda", Model = "Civic", Year = 2022, Price = 200000 },
            new Car { Manufacturer = "Ford", Model = "Mustang", Year = 1995, Price = 300000 },
            new Car { Manufacturer = "Chevrolet", Model = "Cruze", Year = 2015, Price = 120000 },
            new Car { Manufacturer = "Toyota", Model = "Corolla", Year = 2020, Price = 180000 }
        };
            Console.WriteLine("Cac xe co gia trong khoang 100.000 den 250.000:");
            var carsInPriceRange = cars.Where(c => c.Price >= 100000 && c.Price <= 250000);
            foreach (var car in carsInPriceRange)
            {
                Console.WriteLine($"{car.Manufacturer} {car.Model} - Nam: {car.Year} - Gia: {car.Price}");
            }
            Console.WriteLine();

            Console.WriteLine("Cac xe co nam san suat > 1990");
            var carAfter1990 = cars.Where(c => c.Year > 1990);
            foreach (var car in carAfter1990)
            {
                Console.WriteLine($"{car.Manufacturer} {car.Model} - Nam: {car.Year} - Gia: {car.Price}");

            }
            Console.WriteLine();
            Console.WriteLine("Tong gia tri xe theo hang san xuat:");
            var carGroupedByManufacturer = cars.GroupBy(c => c.Manufacturer);
            foreach (var group in carGroupedByManufacturer)
            {
                double totalPrice = group.Sum(c => c.Price);
                Console.WriteLine($"Hãng {group.Key}: Tong gia tri = {totalPrice}");
            }
            Console.WriteLine();

            List<Truck> trucks = new List<Truck>
        {
            new Truck { Manufacturer = "Volvo", Year = 2015, Price = 500000, CompanyOwner = "XYZ Company", LoadCapacity = 10000 },
            new Truck { Manufacturer = "Scania", Year = 2020, Price = 600000, CompanyOwner = "ABC Company", LoadCapacity = 15000 },
            new Truck { Manufacturer = "Mack", Year = 2018, Price = 450000, CompanyOwner = "DEF Company", LoadCapacity = 12000 },
            new Truck { Manufacturer = "Peterbilt", Year = 2022, Price = 700000, CompanyOwner = "GHI Company", LoadCapacity = 18000 }
        };

            // 3.a. Hiển thị danh sách Truck theo thứ tự năm sản xuất mới nhất
            Console.WriteLine("Danh sach Truck theo thu tu nam san xuat moi nhat:");
            var trucksSortedByYear = trucks.OrderByDescending(t => t.Year);
            foreach (var truck in trucksSortedByYear)
            {
                Console.WriteLine($"{truck.Manufacturer} - Nam: {truck.Year} - Gia: {truck.Price} - Cong ty chu quan: {truck.CompanyOwner} - Tai trong: {truck.LoadCapacity}");
            }
            Console.WriteLine();

            // 3.b. Hiển thị tên công ty chủ quản của Truck
            Console.WriteLine("Ten cong ty chu quan cua Truck:");
            var companyOwners = trucks.Select(t => t.CompanyOwner).Distinct();
            foreach (var companyOwner in companyOwners)
            {
                Console.WriteLine(companyOwner);
            }

            Console.ReadLine();

        }
    }
}
