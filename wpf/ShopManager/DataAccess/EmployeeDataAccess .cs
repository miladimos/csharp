using System;
using DataAccess.Models;


namespace DataAccess
{
    public class EmployeeDataAccess
    {
        public EmployeeDataAccess()
        {
            ReadProdutcs();
        }

        public List<Employee> Employees { get; set; }

        private void ReadProdutcs()
        {
            Employee p1 = new Employee()
            {
                Id = 1,
                FirstName = "FirstName",
                LastName = "LastName",
                Address = "Test Address",
                PhoneNumber = 912212313,
                BaseSalary= 1000,
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

        public void AddEmployee(Employee Employee)
        {
            Employees.Add(Employee);
        }

        public void RemoveEmployee(int id) {
            Employee tempEmployee = Employees.First(p => p.Id == id);  
            Employees.Remove(tempEmployee);   
        }

        public void GetEmployee(int id) { }
        public void EditEmployee(Employee Employee) {
            Employee tempEmployee = Employees.First(x => x.Id == Employee.Id);
            Employees.Remove(tempEmployee);
            int index = Employees.IndexOf(Employee);

            Employees.Insert(index, Employee);
        }

        public int GetNextId()
        {
            int index = Employees.Any() ? Employees.Max(x=>x.Id)+1 : 1;
            return index;
        }
    }
}
