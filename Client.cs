using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_1651
{
    internal class Client
    {
        static void Main(string[] args)
        {
            ManageEmployee manage = new ManageEmployee();
            String selection;

            do
            {
                manage.Menu();
                selection = Console.ReadLine();
                Console.WriteLine("");
                switch(selection)
                {
                    case "1":
                        Console.WriteLine("--- Add a new employee ---");
                        Console.WriteLine("What would you like to add?");
                        Console.Write("Type Employee: ");
                        manage.Add(Console.ReadLine());
                        break;
                    case "2":
                        Console.WriteLine("---- Employee list ---");
                        manage.ShowAll();
                        break;
                    case "3":
                        Console.WriteLine("---- Full-time Employee list ---");
                        manage.ShowFullTime();
                        break;
                    case "4":
                        Console.WriteLine("---- Part-time Employee list ---");
                        manage.ShowPartTime();
                        break;
                    case "5":
                        Console.WriteLine("---- Find employee by ID ---");
                        Console.Write("Employee ID: ");
                        String findID = Console.ReadLine();
                        Employee employee = manage.FindEmployee(findID);
                        if(employee != null)
                        {
                            employee.OutputInfo();
                        }
                        else
                        {
                            Console.WriteLine($"Employee with id \"{findID}\" not found.");
                        }
                        break;
                    case "6":
                        Console.WriteLine("---- Find employees by name ---");
                        Console.Write("Employees name: ");
                        String findName = Console.ReadLine();
                        List<Employee> employees = manage.FindAll(findName);
                        if(employees.Count > 0)
                        {
                            employees.ForEach(emp => emp.OutputInfo());
                        }
                        else
                        {
                            Console.WriteLine($"Employees with name \"{findName}\" not found.");

                        }
                        break;
                    case "7":
                        Console.WriteLine("---- Update an employee information ---");
                        Console.Write("Employee ID: ");
                        manage.UpadateInfo(Console.ReadLine());
                        break;
                    case "8":
                        Console.WriteLine("---- Remove an employee ---");
                        Console.Write("Employee ID: ");
                        manage.RemoveEmployee(Console.ReadLine());
                        break;
                    case "9":
                        Console.WriteLine("---- Report ---");
                        manage.GenerateReport();
                        break;
                    case "0":
                        Console.WriteLine("BYE");
                        break;
                    default:
                        Console.ForegroundColor= ConsoleColor.Red; // Alert is red
                        Console.WriteLine("Invalid your selection. Please try again!!!");
                        Console.ResetColor();
                        break;
                }
            } while(selection != "0");

        }
    }
}
