using SuperShop.Data.Entities;
using SuperShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public Product ToProduct(ProductViewModel model, Guid imageId, bool isNew)
        {
            return new Product
            {
                Id = isNew ? 0 : model.Id,
                ImageId = imageId,
                Name = model.Name,
                IsAvailable = model.IsAvailable,
                LastPurchase = model.LastPurchase,
                LastSale = model.LastSale,
                Stock = model.Stock,
                User = model.User,
                Price = model.Price
            };
        }

        public ProductViewModel ToProductViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                IsAvailable = product.IsAvailable,
                LastPurchase = product.LastPurchase,
                LastSale = product.LastSale,
                ImageId= product.ImageId,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                User = product.User,
            };
        }
    }
}
