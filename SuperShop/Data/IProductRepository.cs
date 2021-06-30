using SuperShop.Data.Entities;
using System.Linq;

namespace SuperShop.Data
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public IQueryable GetAllWithUser();
    }
}
