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
                Console.WriteLine("5. Exit");
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
            throw new NotImplementedException();
        }

        private void DeleteProduct()
        {
            throw new NotImplementedException();
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
    }
}
