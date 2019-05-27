using Appslx.Core.Models;
using Appslx.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Appslx.Repository.OrderStatuses
{
    public class OrderStatusRepository:GenericRepository<OrderStatus>,IOrderStatusRepository
    {
        public OrderStatusRepository(DbContext context) : base(context)
        {
        }

        public OrderStatus GetById(int id)
        {
            return _dbset.FirstOrDefaultAsync(x => x.Id == id).Result;
        }
    }
}
