using System;
using System.Collections.Generic;
using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var employees = new Dictionary<string, List<Employee>>();

            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split();

                string name = input[0];
                decimal salary = decimal.Parse(input[1]);
                string position = input[2];
                string department = input[3];

                Employee employee = CreateEmployee(employees, input, name, salary, position, department);

                employees[department].Add(employee);
            }

            var departmentWithHighestSalary = employees
                .OrderByDescending(x => x.Value.Average(e => e.Salary))
                .First();

            Console.WriteLine($"Highest Average Salary: {departmentWithHighestSalary.Key}");

            departmentWithHighestSalary.Value
                .OrderByDescending(x => x.Salary)
                .ToList()
                .ForEach(Console.WriteLine);
        }

        private static Employee CreateEmployee(Dictionary<string, List<Employee>> employees, string[] input, string name, decimal salary, string position, string department)
        {
            Employee employee = null;

            if (input.Length == 4)
            {
                employee = new Employee(name, salary, position, department);
            }

            if (input.Length == 5)
            {
                if (int.TryParse(input[4], out int result))
                {
                    int age = result;
                    employee = new Employee(name, salary, position, department, age);
                }

                else
                {
                    string email = input[4];
                    employee = new Employee(name, salary, position, department, email);
                }
            }

            if (input.Length == 6)
            {
                string email = input[4];
                int age = int.Parse(input[5]);
                employee = new Employee(name, salary, position, department, email, age);
            }

            if (!employees.ContainsKey(department))
            {
                employees[department] = new List<Employee>();
            }

            return employee;
        }
    }

