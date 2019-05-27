using System.Linq;
using Appslx.Core.Models;
using Appslx.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Appslx.Repository.Products
{
    public class ProductRepository:GenericRepository<Product>,IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }

        public IQueryable<Product> GetForPagination()
        {
            return _dbset.AsNoTracking();
        }

        public Product GetById(int id)
        {
            return _dbset.FirstOrDefaultAsync(x => x.Id == id).Result;
        }

        public int GetCount()
        {
            return _dbset.CountAsync().Result;
        }
    }
}
