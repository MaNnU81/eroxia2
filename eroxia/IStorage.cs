using eroxia.model;

namespace eroxia
{
    internal interface IStorage
    {
        public Task<List<Product>> GetAllProductsFromDB();
        public Task<List<Employee>> GetAllEmployeesFromDB();
        Task<bool> DeleteProductFromDB(int productId);
        Task <int> InsertProductToDB(Product product);
        public Task<List<Client>>GetAllCustomersFromDB();

        public Task<List<Employee>> GetBestEmployeesFromDB();
        
    }
}