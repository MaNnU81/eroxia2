using eroxia.model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eroxia
{

    internal class DBStorage : IStorage
    {
        public static string postgresConnectionString = "Host=localhost;Port=5432;Database=eroxia;Username=postgres;Password=Diva;";

        public async Task<List<Product>> GetAllProductsFromDB()
        {

            var dataSourceBuilder = new NpgsqlDataSourceBuilder(postgresConnectionString);

            using var dataSource = dataSourceBuilder.Build();

            using var conn = await dataSource.OpenConnectionAsync();

            using var query = new NpgsqlCommand("SELECT id_product, name, manufacturer, price, material, color FROM product", conn);

            using var reader = query.ExecuteReader();

            var products = new List<Product>();

            while (reader.Read())
            {

                var product = new Product(
                    reader.GetInt32(0), // ProductId
                    reader.GetString(1), // Name
                    reader.GetString(2), // Manufacturer
                    reader.GetDecimal(3) // Price
                )
                {
                    Material = reader.IsDBNull(4) ? null : reader.GetString(4), // Material
                    Color = reader.IsDBNull(5) ? null : reader.GetString(5) // Color
                };
                products.Add(product);

            }

            return products;
        }


        public async Task<List<Employee>> GetAllEmployeesFromDB()
        {

            var dataSourceBuilder = new NpgsqlDataSourceBuilder(postgresConnectionString);

            using var dataSource = dataSourceBuilder.Build();

            using var conn = await dataSource.OpenConnectionAsync();

            using var query = new NpgsqlCommand("SELECT fiscal_code, name, surname, dob FROM employee", conn);

            using var reader = query.ExecuteReader();

            var employees = new List<Employee>();

            while (reader.Read())
            {

                var employee = new Employee(
                    reader.GetString(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetDateTime(3)
                );

                employees.Add(employee);

            }

            return employees;
        }

        public async Task<bool> DeleteProductFromDB(int productId)
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(postgresConnectionString);

            using var dataSource = dataSourceBuilder.Build();

            using var conn = await dataSource.OpenConnectionAsync();

            var queryString = @"BEGIN;

                                 DELETE FROM purchase_product WHERE id_product = @productId;

                                 DELETE FROM product  WHERE id_product = @productId;
                                 COMMIT;
                                 ";

            using var query = new NpgsqlCommand(queryString, conn);
            query.Parameters.AddWithValue("productId", productId);

            var result = await query.ExecuteNonQueryAsync();

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }




        }

        public async Task<int> InsertProductToDB(Product product)
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(postgresConnectionString);

            using var dataSource = dataSourceBuilder.Build();

            using var conn = await dataSource.OpenConnectionAsync();

            var queryString = @"INSERT INTO product (name, manufacturer, price, material, color)
                                VALUES (@name, @manufacturer, @price, @material, @color)
                                RETURNING id_product";

            using var query = new NpgsqlCommand(queryString, conn);

            query.Parameters.AddWithValue("name", product.Name);
            query.Parameters.AddWithValue("manufacturer", product.Manufacturer);
            query.Parameters.AddWithValue("price", product.Price);
            query.Parameters.AddWithValue("material", String.IsNullOrEmpty(product.Material) ? DBNull.Value : product.Material);
            query.Parameters.AddWithValue("color", String.IsNullOrEmpty(product.Color) ? DBNull.Value : product.Color);


            object? resultId = null;
            try
            {
                resultId = await query.ExecuteScalarAsync();
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred while inserting the product into the database.");
                throw;
            }


            if (resultId != null && int.TryParse(resultId.ToString(), out int productId))
            {
                return productId;
            }
            else
            {
                throw new Exception("Failed to insert product into the database.");
            }
        }

        public async Task<List<Client>> GetAllCustomersFromDB()
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(postgresConnectionString);

            using var dataSource = dataSourceBuilder.Build();
            using var conn = await dataSource.OpenConnectionAsync();
            using var query = new NpgsqlCommand("SELECT fiscal_code, fiscal_code_employee, name, surname, address FROM client", conn);
            using var reader = query.ExecuteReader();

            var customers = new List<Client>();

            while (reader.Read())
            {
                var customer = new Client(
                    reader.GetString(0),
                    reader.IsDBNull(1) ? null : reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4)
                );

                customers.Add(customer);
            }

            return customers;
        }
    }

}
