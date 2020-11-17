using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            int sum = numbers.Sum();
            double avg = numbers.Average();
            Console.WriteLine($"Sum {sum}");
            Console.WriteLine($"Average {avg}");

            //Order numbers in ascending order and decsending order. Print each to console.
            var asc = numbers.OrderBy(num => num);
            Console.WriteLine("-----------------");
            Console.WriteLine("Ascending");

            foreach(var number in asc)
            {
                Console.WriteLine(number);
            }

            var desc = numbers.OrderByDescending(x => x);
            Console.WriteLine("-----------------");
            Console.WriteLine("Descending");
            foreach(var number in desc)
            {
                Console.WriteLine(number);
            }

            //Print to the console only the numbers greater than 6
           var greaterThanSix = numbers.Where(num =>num > 6);
            Console.WriteLine("Numbers greater than six");
            Console.WriteLine("-------------------");
            foreach(int number in greaterThanSix)
            {
                Console.WriteLine(number );
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Four numbers in ascending order");
            Console.WriteLine("-------------------");
            foreach (var num in asc.Take(4))
            {
                Console.WriteLine(num);
            }

            //Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("Changed index 4 in the numbers array to my age of 27 and printed out in descending order.");
            Console.WriteLine("-------------------");
            numbers[4] = 27;
            foreach(var item in numbers.OrderByDescending(num => num))
            {
                Console.WriteLine(item);
            }

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            var filtered = employees.Where(person => person.FirstName[0] == 'C' || person.FirstName[0] == 'S')
                .OrderBy(person => person.FirstName);
            Console.WriteLine("C or S Eployees");
            Console.WriteLine("-------------------");
            foreach (var employee in filtered)
            {
                Console.WriteLine(employee.FullName);
            }

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Employees over the age of 26 in order by age");
            Console.WriteLine("-------------------");
            var overTwentySix = employees.Where(per => per.Age > 26)
                .OrderBy(per => per.Age).ThenBy(per => per.FirstName);
            foreach(var person in overTwentySix)
            {
                Console.WriteLine(person.FullName);
                Console.WriteLine(person.Age);
            }


            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35\ 
            Console.WriteLine("Sum and average");
            Console.WriteLine("-------------------");
            var yearsOfExperience = employees.Where(emp => emp.YearsOfExperience <= 10 && emp.Age > 35).Sum(emp => emp.YearsOfExperience);
            var average = employees.Where(emp => emp.YearsOfExperience <= 10 && emp.Age > 35).Average(emp => emp.YearsOfExperience);
                
            Console.WriteLine(yearsOfExperience);
            Console.WriteLine(average);

            //Add an employee to the end of the list without using employees.Add()

            Employee Steve = new Employee();
            employees.Append(Steve);

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
