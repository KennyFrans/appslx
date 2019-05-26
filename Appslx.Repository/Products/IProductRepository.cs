using Appslx.Core.Models;
using Appslx.Repository.Base;

namespace Appslx.Repository.Products
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        Product GetById(int id);
    }
}
