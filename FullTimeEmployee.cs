using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_1651
{
    internal class FullTimeEmployee : Employee
    {
        public double BasicSalary { get; set; }
        public int OverTime { get; set; }
        public int Position { get; set; }

        protected override double CalculateSalary()
        {
            double salary = BasicSalary;
            switch(Position)
            {
                case 1:
                    salary += 1000;
                    break;
                case 2:
                    salary += 500;
                    break;
                case 3:
                    salary += 200;
                    break;
            }

            salary += OverTime * 20;

            return salary;
        }

        public override void InputInfo()
        {
            base.InputInfo();
            Console.Write("Input Basic Salary: ");
            double salary;
            while(!double.TryParse(Console.ReadLine(), out salary))
            {
                Console.Write("Wrong input, please re-enter: ");
            }
            BasicSalary = salary;

            Console.Write("Input Over time: ");
            int time;
            while(!int.TryParse(Console.ReadLine(), out time))
            {
                Console.Write("Wrong input, please re-enter: ");
            }
            OverTime = time;

            Console.WriteLine("Positions:");
            Console.WriteLine("1. Director");
            Console.WriteLine("2. Manager");
            Console.WriteLine("3. Employee");
            Console.Write("Chose a position: ");
            string choose;
            do
            {
                switch(choose = Console.ReadLine())
                {
                    case "1":
                        Position = 1;
                        break;
                    case "2":
                        Position = 2;
                        break;
                    case "3":
                        Position = 3;
                        break;
                    default:
                        Console.WriteLine("Invalid this position. Please try again.");
                        break;
                }
            } while(!Array.Exists(new String[] { "1", "2", "3" }, c => c == choose));
        }

        public override void OutputInfo()
        {
            base.OutputInfo();
            Console.WriteLine("\t - Basic Salary: $" + BasicSalary);

            switch(Position)
            {
                case 1:
                    Console.WriteLine("\t - Position: Director");
                    break;
                case 2:
                    Console.WriteLine("\t - Position: Manager");
                    break;
                case 3:
                    Console.WriteLine("\t - Position: Employee");
                    break;
            }

            Console.WriteLine("\t - OverTime: " + OverTime);
        }
    }
}
