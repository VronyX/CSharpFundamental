using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesB.BEncapsulation
{
    public class Example02
    {
        public void Example02Encapsulation()
        {
            Employee fran = new Employee(260215885)
            {
                FullName = "Fran Dello",
                Age = 22
            };
            fran.SetPassword("123");

            //Console.WriteLine("EmployeeId: " + fran.id); // tidak bisa diakses karena private
            //Console.WriteLine("EmployeeId: " + fran.GetId());
            Console.WriteLine("EmployeeName: " + fran.FullName);
            Console.WriteLine("EmployeeAge: " + fran.Age);
            Console.WriteLine("Salary: " + fran.Salary);
            Console.WriteLine("Annual Salary: " + fran.AnnualSalary);
            Console.WriteLine();

            //fran.Salary(-1);
            fran.Introduction();
            Console.WriteLine();

        }
    }
}
