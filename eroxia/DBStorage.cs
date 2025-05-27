using eroxia.model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eroxia
{
    
    internal class DBStorage: IStorage
    {
        public static string postgresConnectionString = "Host=localhost;Port=5432;Database=eroxia;Username=postgres;Password=superpippo;";

        public async Task<List<Product>> GetAllProductsFromDB()
        {

            var dataSourceBuilder = new NpgsqlDataSourceBuilder(postgresConnectionString);

            using var dataSource = dataSourceBuilder.Build();

            using var conn = await dataSource.OpenConnectionAsync();

            using var query = new NpgsqlCommand("SELECT id_product, name, manufacturer, price, material, color FROM product", conn);

            using var reader = query.ExecuteReader();

            var products = new List<Product>();

            while (reader.Read()) {
                
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
    }
}
