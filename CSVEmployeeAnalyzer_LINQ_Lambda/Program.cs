using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CSVEmployeeAnalyzer_LINQ_Lambda.Entities;

namespace CSVProductAnalyzer_LINQ_Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();
            Console.WriteLine("____________________");
            Console.WriteLine();

            List<Employee> list = new List<Employee>();

            using (StreamReader sr = File.OpenText(path))
            {
                while(!sr.EndOfStream) 
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    string email = fields[1];
                    double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
                    list.Add(new Employee(name, email, salary));
                }
            }

            Console.Write("Enter Salary: ");
            double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine();

            var sup = list.Where(p => p.Salary > value).OrderBy(p => p.Email).Select(p => p.Email);
            Console.WriteLine("Email of people whose salary is more than " + value.ToString("F2", CultureInfo.InvariantCulture) + ": ");
            foreach (string email in sup) 
            {
                Console.WriteLine("- " + email);
            }

            Console.WriteLine();
            var sum = list.Where(p => p.Name[0] == 'M').Sum(p => p.Salary);
            Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sum.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}