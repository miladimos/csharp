using System;
using DataAccess.Models;


namespace DataAccess
{
    public class ProductDataAccess
    {
        public ProductDataAccess()
        {
            ReadProdutcs();
        }

        public List<Product> Products { get; set; }

        private void ReadProdutcs()
        {
            Product p1 = new Product()
            {
                Id = 1,
                Name = "Test",
                Author = "Author",
                AvailableCount = 10,
                Price = 17,
            };

            Product p2 = new Product()
            {
                Id = 2,
                Name = "Book 2",
                Author = "Author 2",
                AvailableCount = 20,
                Price = 15,
            };

            Products.Add(p1);
            Products.Add(p2);


        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void RemoveProduct(int id) {
            Product tempProduct = Products.First(p => p.Id == id);  
            Products.Remove(tempProduct);   
        }

        public void GetProduct(int id) { }
        public void EditProduct(Product product) {
            Product tempProduct = Products.First(x => x.Id == product.Id);
            Products.Remove(tempProduct);
            int index = Products.IndexOf(product);

            Products.Insert(index, product);
        }

        public int GetNextId()
        {
            int index = Products.Any() ? Products.Max(x=>x.Id)+1 : 1;
            return index;
        }
    }
}
