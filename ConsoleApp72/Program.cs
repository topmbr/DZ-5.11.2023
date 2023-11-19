using System;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApp72
{
    class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int DepId { get; set; }
    }

    class Department
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<Department> departments = new List<Department>() {
            new Department() { Id = 1, Country = "Ukraine", City = "Donetsk" },
            new Department() { Id = 2, Country = "Ukraine", City = "Kyiv" },
            new Department() { Id = 3, Country = "France", City = "Paris" },
            new Department() { Id = 4, Country = "Russia", City = "Moscow" } };

            List<Employee> employees = new List<Employee>()
        {
            new Employee() { Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
            new Employee() { Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
            new Employee() { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 },
            new Employee() { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
            new Employee() { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
            new Employee() { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age= 22, DepId = 2 },
            new Employee() { Id = 7 , FirstName = "Nikita", LastName = "Krotov", Age = 27, DepId = 4 } };

            // 1) Выбрать имена и фамилии сотрудников, работающих в Украине, но не в Донецке.
            var ukrainianEmployees = employees
                .Where(e => departments.Any(d => d.Id == e.DepId && d.Country == "Ukraine" && d.City != "Donetsk"))
                .Select(e => new { e.FirstName, e.LastName });

            Console.WriteLine("1) Имена и фамилии сотрудников, работающих в Украине, но не в Донецке:");
            foreach (var emp in ukrainianEmployees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName}");
            }

            // 2) Вывести список стран без повторений.
            var uniqueCountries = departments.Select(d => d.Country).Distinct();

            Console.WriteLine("\n2) Список стран без повторений:");
            foreach (var country in uniqueCountries)
            {
                Console.WriteLine(country);
            }

            // 3) Выбрать 3-х первых сотрудников, возраст которых превышает 25 лет.
            var employeesOver25 = employees
                .Where(e => e.Age > 25)
                .Take(3)
                .Select(e => new { e.FirstName, e.LastName, e.Age });

            Console.WriteLine("\n3) Имена, фамилии и возраст 3-х первых сотрудников, возраст которых превышает 25 лет:");
            foreach (var emp in employeesOver25)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName}, возраст: {emp.Age} лет");
            }

            // 4) Выбрать имена, фамилии и возраст сотрудников из Киева, возраст которых превышает 23 года.
            var kyivEmployeesOver23 = employees
                .Where(e => departments.Any(d => d.Id == e.DepId && d.City == "Kyiv") && e.Age > 23)
                .Select(e => new { e.FirstName, e.LastName, e.Age });

            Console.WriteLine("\n4) Имена, фамилии и возраст сотрудников из Киева, возраст которых превышает 23 года:");
            foreach (var emp in kyivEmployeesOver23)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName}, возраст: {emp.Age} лет");
            }
        }
    }

}