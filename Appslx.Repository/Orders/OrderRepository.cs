using Appslx.Core.Models;
using Appslx.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Appslx.Repository.Orders
{
    public class OrderRepository:GenericRepository<Order>,IOrderRepository
    {
        public OrderRepository(DbContext context) : base(context)
        {
        }

        public Order GetById(int id)
        {
            return _dbset.FirstOrDefaultAsync(x => x.Id == id).Result;
        }
    }
}
