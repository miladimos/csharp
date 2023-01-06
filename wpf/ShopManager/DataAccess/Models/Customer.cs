using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Customer : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ulong PhoneNumber { get; set; }
        public string Address { get; set; }


        public string GetBasicInfo()
        {
            string finalStr = FirstName + " " + LastName +
                "\n Phone:" + PhoneNumber +
                "\n Address: " + Address;
            return finalStr;
        }
    }



}
