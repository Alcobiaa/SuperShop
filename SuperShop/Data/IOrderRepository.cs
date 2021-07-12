using SuperShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IQueryable<Order>> GetOrderAsycn(string userName);

        Task<IQueryable<OrderDetailTemp>> GetDetailsTempsAsycn(string userName);

    }
}
