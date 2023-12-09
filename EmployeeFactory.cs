using System;

namespace ASM_1651
{
    internal class EmployeeFactory
    {
        private EmployeeFactory() { }

        public static Employee CreateEmployee(string typeEmployee)
        {
            Employee employee = null;
            switch(typeEmployee)
            {
                case "FULLTIME":
                    employee = new FullTimeEmployee();
                    break;
                case "PARTTIME":
                    employee = new PartTimeEmployee();
                    break;
                default:
                    Console.WriteLine($"\n\"{typeEmployee}\" does not support!");
                    break;
            }
            return employee;
        }
    }
}
