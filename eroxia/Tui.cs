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
                Console.WriteLine("3. Exit");
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
                        Console.WriteLine("Exiting... Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        private void ViewAllProducts()
        {
            throw new NotImplementedException();
        }

        private void ViewAllEmployees()
        {
            throw new NotImplementedException();
        }
    }
}
