using System.Linq;
using Appslx.Core.Models;
using Appslx.Repository.Base;

namespace Appslx.Repository.Products
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        IQueryable<Product> GetForPagination();
        Product GetById(int id);
        int GetCount();
    }
}
