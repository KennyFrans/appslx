using System;
using System.Collections.Generic;
using System.Text;
using Appslx.Core.Models;
using Appslx.Repository.Base;

namespace Appslx.Repository.OrderDetails
{
    public interface IOrderDetailRepository:IGenericRepository<OrderDetail>
    {
        OrderDetail GetById(int id);
    }
}
