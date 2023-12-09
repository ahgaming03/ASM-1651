using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_1651
{
    internal class PartTimeEmployee : Employee
    {
        public int WorkHour { get; set; }

        protected override double CalculateSalary()
        {
            double salary = WorkHour * 20;

            return salary;
        }

        public override void InputInfo()
        {
           base.InputInfo();
            Console.Write("Input work hour: ");
            int hour;
            while(!int.TryParse(Console.ReadLine(), out hour))
            {
                Console.Write("Wrong input, please re-enter: ");
            }
            WorkHour = hour;
        }



        public override void OutputInfo()
        {
            base.OutputInfo();
            Console.WriteLine("\t - Work hour: " + WorkHour);
        }
    }
}
