using System;
using System.Collections.Generic;
using System.Text;
using Appslx.Core.Models;
using Appslx.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Appslx.Repository.OrderDetails
{
    public class OrderDetailRepository:GenericRepository<OrderDetail>,IOrderDetailRepository
    {
        public OrderDetailRepository(DbContext context) : base(context)
        {
        }

        public OrderDetail GetById(int id)
        {
            return _dbset.FirstOrDefaultAsync(x => x.Id == id).Result;
        }
    }
}
