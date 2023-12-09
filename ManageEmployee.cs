using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace ASM_1651
{
    internal class ManageEmployee
    {
        private List<Employee> listEmployee;
        public ManageEmployee()
        {
            listEmployee = new List<Employee>();
        }

        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow; // Change menu color to yellow
            Console.WriteLine();
            Console.WriteLine("===== Employee manage system =====");
            Console.WriteLine("1. Add a new employee");
            Console.WriteLine("2. Show all employees");
            Console.WriteLine("3. Show Full-time employees");
            Console.WriteLine("4. Show Part-time employees");
            Console.WriteLine("5. Find employee by Id");
            Console.WriteLine("6. Find employee by Name");
            Console.WriteLine("7. Update an employee information");
            Console.WriteLine("8. Remove an employee");
            Console.WriteLine("9. Generate report");
            Console.WriteLine("0. Exit application");
            Console.Write("Enter your choice: ");
            Console.ResetColor(); // Stop change
        }

        public void Add(String typeEmployee)
        {
            Employee employee = EmployeeFactory.CreateEmployee(typeEmployee.ToUpper());
            if(employee != null)
            {
                employee.InputInfo();
                listEmployee.Add(employee);
                Console.WriteLine("Added a new employee successfully");
            }
        }

        public void ShowAll()
        {

            if(listEmployee.Count > 0)
            {
                listEmployee.ForEach(emp => { emp.OutputInfo(); });
            }
            else
            {
                Console.WriteLine("Do not have any employee in the list.");
            }
        }

        public void ShowFullTime()
        {
            if(listEmployee.Count > 0)
            {
                List<Employee> employees = listEmployee.Where(emp=>emp is FullTimeEmployee).ToList();
                if(employees.Count > 0)
                {
                    employees.ForEach(emp => { emp.OutputInfo(); });
                }
                else
                {
                    Console.WriteLine("Do not have any Full-time employees in the list.");
                }
            }
            else
            {
                Console.WriteLine("Do not have any employee in the list.");
            }

        }

        public void ShowPartTime()
        {
            if(listEmployee.Count > 0)
            {
                List<Employee> employees = listEmployee.Where(emp=>emp is PartTimeEmployee).ToList();
                if(employees.Count > 0)
                {
                    employees.ForEach(emp => { emp.OutputInfo(); });
                }
                else
                {
                    Console.WriteLine("Do not have any Part-time employees in the list.");
                }
            }
            else
            {
                Console.WriteLine("Do not have any employee in the list.");
            }
        }

        public Employee FindEmployee(String id)
        {
            Employee employee = listEmployee.FirstOrDefault(emp => emp.Id.Equals(id,StringComparison.OrdinalIgnoreCase));
            return employee;
        }

        public List<Employee> FindAll(String name)
        {
            List<Employee> employees = listEmployee.Where(emp => emp.FullName.IndexOf(name,StringComparison.OrdinalIgnoreCase)>=0).ToList();
            return employees;
        }
        public void UpadateInfo(String id)
        {
            if(listEmployee.Count == 0)
            {
                Console.WriteLine("Do not have any employee in the list.");
                return;
            }
            Employee empUpdate = listEmployee.FirstOrDefault(emp=>emp.Id.Equals(id,StringComparison.OrdinalIgnoreCase));
            if(empUpdate != null)
            {
                Console.WriteLine("__Before Update__");
                empUpdate.OutputInfo();
                Console.Write("Enter new name (leave empty to keep current): ");
                string newName = Console.ReadLine();
                if(!string.IsNullOrEmpty(newName))
                {
                    empUpdate.FullName = newName;
                }

                Console.Write("Enter new year of birth (leave empty to keep current): ");

                string newYearOfBirth = Console.ReadLine();
                if(int.TryParse(newYearOfBirth, out int yearOfBirth))
                {
                    empUpdate.YearOfBirth = yearOfBirth;
                }

                Console.Write("Enter new address (leave empty to keep current): ");
                string newAddress = Console.ReadLine();
                if(!string.IsNullOrEmpty(newAddress))
                {
                    empUpdate.Address = newAddress;
                }

                // If the employee is a full-time employee, ask for specific full-time info
                if(empUpdate is FullTimeEmployee fullTimeEmployee)
                {
                    Console.Write("Enter new basic salary (leave empty to keep current): ");
                    string newBasicSalary = Console.ReadLine();
                    if(double.TryParse(newBasicSalary, out double basicSalary))
                    {
                        fullTimeEmployee.BasicSalary = basicSalary;
                    }

                    Console.Write("Enter new overtime hours (leave empty to keep current): ");
                    string newOvertime = Console.ReadLine();
                    if(int.TryParse(newOvertime, out int overtime))
                    {
                        fullTimeEmployee.OverTime = overtime;
                    }
                }
                if(empUpdate is PartTimeEmployee partTimeEmployee)
                {
                    Console.Write("Enter new work hour (leave empty to keep current): ");
                    string newWorkHour = Console.ReadLine();
                    if(int.TryParse(newWorkHour, out int workHour))
                    {
                        partTimeEmployee.WorkHour = workHour;
                    }
                }

                Console.WriteLine("Employee information updated successfully.");

                Console.WriteLine("__After update__");
                empUpdate.OutputInfo();
            }
            else
            {
                Console.WriteLine($"Employee with id \"{id}\" not found in list.");
            }
        }
        public void RemoveEmployee(String id)
        {
            if(listEmployee.Count == 0)
            {
                Console.WriteLine("Do not have any employee in the list.");
                return;
            }
            int count = listEmployee.RemoveAll(emp=>emp.Id.Equals(id,StringComparison.OrdinalIgnoreCase));
            if(count > 0)
            {
                Console.WriteLine($"Removed successfully");
            }
            else
            {
                Console.WriteLine($"Employee with id {id} not found.");
            }
        }
        public void GenerateReport()
        {
            Console.WriteLine("- Employees: " + listEmployee.Count);
            Console.WriteLine("+ Part-Time: " + listEmployee.Where(emp => emp is PartTimeEmployee).Count());
            Console.WriteLine("+ Full-Time: " + listEmployee.Where(emp => emp is FullTimeEmployee).Count());
        }
    }
}
