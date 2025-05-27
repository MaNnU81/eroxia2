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

        private List<Employee> Employees { get; set; }
        private List<Product> Products { get; set; }

        public BusinessLogic(IStorage storage)
        {
            Storage = storage;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
