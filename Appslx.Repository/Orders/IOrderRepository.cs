using System;
using System.Collections.Generic;
using System.Text;
using Appslx.Core.Models;
using Appslx.Repository.Base;

namespace Appslx.Repository.Orders
{
    public interface IOrderRepository:IGenericRepository<Order>
    {
        Order GetById(int id);
    }
}
