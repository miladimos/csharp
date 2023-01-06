using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Employee : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ulong PhoneNumber { get; set; }
        public string Address { get; set; }

        public Department Department { get; set; }

        public decimal BaseSalary { get; set; }


        public Employee() { }

        public string GetBasicInfo()
        {
            string finalStr = FirstName + " " + LastName +
                "\n Phone:" + PhoneNumber +
                "\n Address: " + Address +
                "\n Department: " + Department + "\n BaseSalary: " + BaseSalary;
            return finalStr;
        }
    }

    public enum Department
    {
        Production,
        Sales,
        Advertisment,
        Management
    }
}
