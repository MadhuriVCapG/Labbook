using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Q1
{

    class Employee
    {
        private string _employeeID;
        private string _employeeName;
        private string _address;
        private string _city;
        private string _department;
        private double _salary;

        public string EmployeeID { set => _employeeID = value; }
        public string EmployeeName { get =>  _employeeName;  set => _employeeName = value; }
        public string Address { set => _address = value; }
        public string City { set => _city = value; }
        public string Department { set => _department = value; }
        public double Salary { get => _salary; set => _salary = value; }
    }
    class Program
    {
        static void Main()
        {
            Employee em = new Employee();
            Console.WriteLine("Enter employee ID: ");
            em.EmployeeID = Console.ReadLine();
            Console.WriteLine("Enter employee name: ");
            em.EmployeeName = Console.ReadLine();
            Console.WriteLine("Enter employee address: ");
            em.Address = Console.ReadLine();
            Console.WriteLine("Enter city: ");
            em.City = Console.ReadLine();
            Console.WriteLine("Enter department: ");
            em.Department = Console.ReadLine();
            Console.WriteLine("Enter salary: ");
            em.Salary = Convert.ToDouble(Console.ReadLine());

            Employee[] emlist = new Employee[10];

            for(int i=0; i < 10; i++)
            {
                Console.WriteLine("Enter employee ID: ");
                emlist[i].EmployeeID = Console.ReadLine();
                Console.WriteLine("Enter employee name: ");
                emlist[i].EmployeeName = Console.ReadLine();
                Console.WriteLine("Enter employee address: ");
                emlist[i].Address = Console.ReadLine();
                Console.WriteLine("Enter city: ");
                emlist[i].City = Console.ReadLine();
                Console.WriteLine("Enter department: ");
                emlist[i].Department = Console.ReadLine();
                Console.WriteLine("Enter salary: ");
                emlist[i].Salary = Convert.ToDouble(Console.ReadLine());
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Employee Name: "+ emlist[i].EmployeeName);
                Console.WriteLine("Employee Salary: " + emlist[i].Salary);

            }
            Console.ReadKey();
        }
    }
}
