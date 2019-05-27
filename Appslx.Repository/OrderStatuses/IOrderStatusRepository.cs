using Appslx.Core.Models;
using Appslx.Repository.Base;

namespace Appslx.Repository.OrderStatuses
{
    public interface IOrderStatusRepository:IGenericRepository<OrderStatus>
    {
        OrderStatus GetById(int id);
    }
}
