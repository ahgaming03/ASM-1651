using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_1651
{
    internal abstract class Employee
    {
        public String Id { get; set; }
        public String FullName { get; set; }
        public int YearOfBirth { get; set; }
        public String Address { get; set; }

        public virtual void InputInfo()
        {
            Console.Write("\nInput Id: ");
            Id = Console.ReadLine();
            Console.Write("Input Full Name: ");
            FullName = Console.ReadLine();
            Console.Write("Input Year of birth: ");
            int year;
            while(!int.TryParse(Console.ReadLine(), out year))
                Console.Write("Wrong input, please re-enter: ");
            YearOfBirth = year;
            Console.Write("Input Address: ");
            Address = Console.ReadLine();
        }

        public virtual void OutputInfo()
        {
            Console.WriteLine("\nId: " + Id);
            Console.WriteLine("Full name: " + FullName);
            Console.WriteLine("Year of birth: " + YearOfBirth);
            Console.WriteLine("Address: " + Address);
            Console.WriteLine("Salary: $" + CalculateSalary());
        }
        protected virtual double CalculateSalary()
        {
            return 0;
        }
    }
}
