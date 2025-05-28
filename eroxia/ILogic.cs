using eroxia.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eroxia
{
    internal interface ILogic
    {
        bool DeleteProduct(int productId);
        public List<Client> GetAllCustomers();
        public List<Employee> GetAllEmployees();
        public List<Product> GetAllProducts();
        public List<Employee> GetBestEmployee();
        bool InsertProduct(Product product);
    }
}
