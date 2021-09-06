using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop.Prism.Models
{
    public class ProductResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public string ImageUrl { get; set; }

        public object LastPurchase { get; set; }

        public object LastSale { get; set; }

        public bool IsAvailable { get; set; }

        public float Stock { get; set; }

        public UserResponse User { get; set; }

        public string ImageFullPath { get; set; }
    }
}
