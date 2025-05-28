using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eroxia
{
    internal class Tui
    {
        private ILogic Logic { get; set; }
        public Tui(ILogic logic)
        {
            Logic = logic;
        }

        public void Start()
        {
            Console.WriteLine("Welcome to Eroxia!");
            while (true)
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. View all employees");
                Console.WriteLine("2. View all products");
                Console.WriteLine("3. Insert product");
                Console.WriteLine("4. Delete product"); 
                Console.WriteLine("5. View all customers of given employee");
                Console.WriteLine("6. The best employee");

                Console.WriteLine("7. Exit");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ViewAllEmployees();
                        break;
                    case "2":
                        ViewAllProducts();
                        break;
                    case "3":
                        InsertProduct();
                        break;
                    case "4":
                        DeleteProduct();
                        break;
                    case "5":
                        ViewAllCustomers();
                        break;
                    case "6":
                        BestEmployee();
                        break;
                    case "7":
                        Console.WriteLine("Exiting... Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }



        private void InsertProduct()
        {
          Console.Write("Enter Product Name: ");
            var name = Console.ReadLine();
            Console.Write("Enter Manufacturer: ");
            var manufacturer = Console.ReadLine();
            Console.Write("Enter Price: (optional)");
            var priceInput = Console.ReadLine();
            decimal price;
            if (!decimal.TryParse(priceInput, out price))
            {
                Console.WriteLine("Invalid price format.");
                return;
            }
            Console.Write("Enter Material (optional): ");
            var material = Console.ReadLine();
            Console.Write("Enter Color (optional): ");
            var color = Console.ReadLine();
            var product = new model.Product(name, manufacturer, price)
            {
                Material = string.IsNullOrEmpty(material) ? null : material,
                Color = string.IsNullOrEmpty(color) ? null : color
            };

            Console.WriteLine($"Product inserted: {product}");

            var success = Logic.InsertProduct(product);
            if (success)
            {
                Console.WriteLine($"Product '{name}' inserted successfully.");
            }
            else
            {
                Console.WriteLine("Failed to insert product.");
            }

        }

        private void DeleteProduct()
        {
            Console.Write("Enter the Product ID to delete: ");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int productId))
            {
                var success = Logic.DeleteProduct(productId);
                if (success)
                {
                    Console.WriteLine("Product  deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Product not found or could not be deleted.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Product ID.");
            }
        }

        private void ViewAllProducts()
        {
            var products = Logic.GetAllProducts();
            foreach (var prod in products)
            {
                Console.WriteLine(prod.ToString());
            }
        }

        private void ViewAllEmployees()
        {
            var employees = Logic.GetAllEmployees();
            foreach (var employee in employees) { 
                Console.WriteLine(employee.ToString());
            }
        }


        private void ViewAllCustomers()
        {
            var customers = Logic.GetAllCustomers();
            foreach (var customer  in customers)
            {
                Console.WriteLine(customer.ToString());
            }
        }

        private void BestEmployee()
        {
            var employees = Logic.GetBestEmployee();
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.ToString());
            }
        }
    }
}
