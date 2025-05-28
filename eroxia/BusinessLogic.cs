using eroxia.model;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eroxia
{
    internal class BusinessLogic : ILogic
    {
        private IStorage Storage { get; set; }

        private List<Employee>? Employees { get; set; }
        private List<Product>? Products { get; set; }
        private List<Client>? Customers { get; set; }
        public BusinessLogic(IStorage storage)
        {
            Storage = storage;
        }

        public  List<Employee> GetAllEmployees()
        {
            if (Employees == null)
            {
                try
                {
                    Employees = Storage.GetAllEmployeesFromDB().Result;
                }
                catch (Exception ex)
                {

                    Employees = new List<Employee>();

                }
            }
            return Employees;
        }

        public List<Product> GetAllProducts()
        {
            if (Products == null)
            {
                try
                {
                    Products = Storage.GetAllProductsFromDB().Result;
                }
                catch (Exception ex)
                {

                    Products = new List<Product>();

                }
            }
            return Products;
        }

        public bool DeleteProduct(int productId)
        {
            var result = Storage.DeleteProductFromDB(productId).Result;
            if (result)
            {
               Products?.RemoveAll(p => p.ProductId == productId);
               
            }
            return result;
        }

        public bool InsertProduct(Product product)
        {
            var resultId = Storage.InsertProductToDB(product).Result;
            if (resultId > 0)
            {
                product.ProductId = resultId;
                Products?.Add(product);
                return true;
            }
            return false;
        }

        public List<Client> GetAllCustomers()
        {
            if (Customers == null)
            {
                try
                {
                    Customers = Storage.GetAllCustomersFromDB().Result;
                }
                catch (Exception ex)
                {
                    Customers = new List<Client>();
                }
            }
            return Customers;
        }

        public List<Employee> GetBestEmployee()
        {
            if (Employees == null)
            {
                try
                {
                    Employees = Storage.GetBestEmployeesFromDB().Result;
                }
                catch (Exception ex)
                {

                    Employees = new List<Employee>();

                }
            }
            return Employees;
        }
    }
}
