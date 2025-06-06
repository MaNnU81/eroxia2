﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eroxia.model
{
    internal class Purchase
    {
        public int PurchaseId { get; set; }
        public Client Client { get; set; }        
        public DateTime CreationDate { get; set; }
        public DateTime? ExpeditionDate { get; set; }
        public List<PurchaseProduct> PurchaseProducts { get; set; } = new List<PurchaseProduct>();
        public decimal TotalPrice
        {
            get { return PurchaseProducts.Sum(pp => pp.TotalPrice); }
        }
        public Purchase(int purchaseId, Client client, DateTime creationDate)
        {
            PurchaseId = purchaseId;
            Client = client;
            CreationDate = creationDate;
        }
    }
}
