using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_08_11
{
    internal class Program
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
        static void Main(string[] args)
        {
            List<Department> departments = new List<Department>()
            {
                new Department(){Id = 1, Country = "Ukraine", City = "Donetsk"},
                new Department(){Id = 2, Country = "Ukraine", City = "Kyiv"},
                new Department(){Id = 3, Country = "France", City = "Paris"},
                new Department(){Id = 4, Country = "russia", City = "moscow"}
            };

            List<Employee> employees = new List<Employee>()
            {
                new Employee(){Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 32, DepId = 2},
                new Employee(){Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1},
                new Employee(){Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3},
                new Employee(){Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2},
                new Employee(){Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4},
                new Employee(){Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2},
                new Employee(){Id = 7, FirstName = "Nikita", LastName = "Krotov", Age = 27, DepId = 4},
            };


            //1) Выбрать имена и фамилии сотрудников, работающих в Украине, но не в Донецке.

            var task1 = employees.Join(departments,
                employee => employee.DepId,
                department => department.Id,
                (employee, department) => new
                {
                    employee.FirstName,
                    employee.LastName,
                    department.Country,
                    department.City
                })
            .Where(item => item.Country == "Ukraine" && item.City != "Donetsk")
            .OrderBy(item => item.FirstName)
            .Select(item => $"{item.FirstName} {item.LastName}");

            foreach (var t in task1)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine();
            Console.WriteLine();



            //2) Вывести список стран без повторений.

            var task2 = departments.Select(p => p.Country).Distinct();

            foreach (var t in task2)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine();
            Console.WriteLine();



            //3) Выбрать трёх первых сотруников, возраст которых превышает 25 лет.

            var task3 = employees.Where(p => p.Age > 23).Take(3);

            foreach (var t in task3)
            {
                Console.WriteLine($"{t.FirstName} {t.LastName}");
            }
            Console.WriteLine();
            Console.WriteLine();



            //4) Выбрать имена, фамилии и возраст сотрудников из Киева, возраст которых превышает 23 года.
            // Изменил возраст одному из сотрудников, так как там ни одному из Киева не было больше 23.

            var task4 = employees.Join(departments,
                employee => employee.DepId,
                department => department.Id,
                (employee, department) => new
                {
                    employee.FirstName,
                    employee.LastName,
                    employee.Age,
                    department.City
                })
            .Where(item => item.City == "Kyiv" && item.Age > 23);

            foreach (var t in task4)
            {
                Console.WriteLine($"{t.FirstName} {t.LastName} {t.Age}");
            }

            Console.Read();
        }
    }
}
