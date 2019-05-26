using System;
using System.Collections.Generic;
using System.Text;
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

        public Product GetById(int id)
        {
            return _dbset.FirstOrDefaultAsync(x => x.Id == id).Result;
        }
    }
}
