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
    }
}
