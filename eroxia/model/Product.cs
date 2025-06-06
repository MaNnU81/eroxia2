﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eroxia.model
{
    internal class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string? Material { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
        public string? Color { get; set; }

        public Product(int productId, string name, string manufacturer, decimal price)
        {
            ProductId = productId;
            Name = name;
            Manufacturer = manufacturer;
            Price = price;
        }

        public Product(string name, string manufacturer, decimal price)
        {
            
            Name = name;
            Manufacturer = manufacturer;
            Price = price;
        }

        public override string? ToString()
        {
            return $"{ProductId} - {Name} ({Manufacturer}) - {Price:C}";
        }
    }
}
