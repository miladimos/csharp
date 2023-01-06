using System;
using System.Collections.ObjectModel;
using DataAccess.Models;


namespace DataAccess
{
    public class EmployeeDataAccess
    {
        private string path = "@./DBCSVEmployee.csv";

        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();


        public EmployeeDataAccess()
        {
            ReadProdutcs();
        }


        private void ReadProdutcs()
        {

            using (var reader = new StreamReader(path))
            {
                Employees.Clear();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(";");
                    Enum.TryParse(values[5], out Department dep);

                    Employee employee = new Employee()
                    {
                        Id = Convert.ToInt32(values[0]),
                        FirstName = values[1],
                        LastName = values[2],
                        Department = dep,
                    };

                }
            }



            Employee p1 = new Employee()
            {
                Id = 1,
                FirstName = "FirstName",
                LastName = "LastName",
                Address = "Test Address",
                PhoneNumber = 912212313,
                BaseSalary = 1000,
                Department = Department.Production,
            };

            Employee p2 = new Employee()
            {
                Id = 1,
                FirstName = "Ali",
                LastName = "LastName",
                Address = "Address",
                PhoneNumber = 914212313,
                BaseSalary = 2000,
                Department = Department.Sales,
            };


            Employees.Add(p1);
            Employees.Add(p2);


        }

        private void SaveEmployees()
        {

            using (var writer = new StreamWriter(path))
            {
                foreach (Employee employee in Employees)
                {
                    string id = employee.Id.ToString();
                    string firstName = employee.FirstName;

                    string line = string.Format("{0};{1}", id, firstName);
                    writer.WriteLine(line);
                }
            }


        }
        public void AddEmployee(Employee Employee)
        {
            Employees.Add(Employee);
            SaveEmployees();
        }

        public void RemoveEmployee(int id)
        {
            Employee tempEmployee = Employees.First(p => p.Id == id);
            Employees.Remove(tempEmployee);
        }

        public void GetEmployee(int id) { }
        public void EditEmployee(Employee Employee)
        {
            Employee tempEmployee = Employees.First(x => x.Id == Employee.Id);
            int index = Employees.IndexOf(tempEmployee);
            Employees[index] = Employee;
        }

        public int GetNextId()
        {
            int index = Employees.Any() ? Employees.Max(x => x.Id) + 1 : 1;
            return index;
        }
    }
}
