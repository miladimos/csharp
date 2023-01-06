using System;
using DataAccess.Models;


namespace DataAccess
{
    public class CustomerDataAccess
    {
        public CustomerDataAccess()
        {
            ReadProdutcs();
        }

        public List<Customer> Customers { get; set; }

        private void ReadProdutcs()
        {
            Customer p1 = new Customer()
            {
                Id = 1,
                FirstName = "FirstName",
                LastName = "LastName",
                Address = "Test Address",
                PhoneNumber = 912212313,
            };

            Customer p2 = new Customer()
            {
                Id = 1,
                FirstName = "Ali",
                LastName = "LastName",
                Address = "Address",
                PhoneNumber = 914212313,
            };

            Customers.Add(p1);
            Customers.Add(p2);

        }

        public void AddCustomer(Customer Customer)
        {
            Customers.Add(Customer);
        }

        public void RemoveCustomer(int id) {
            Customer tempCustomer = Customers.First(p => p.Id == id);  
            Customers.Remove(tempCustomer);   
        }

        public void GetCustomer(int id) { }
        public void EditCustomer(Customer Customer) {
            Customer tempCustomer = Customers.First(x => x.Id == Customer.Id);
            Customers.Remove(tempCustomer);
            int index = Customers.IndexOf(Customer);

            Customers.Insert(index, Customer);
        }

        public int GetNextId()
        {
            int index = Customers.Any() ? Customers.Max(x=>x.Id)+1 : 1;
            return index;
        }
    }
}
