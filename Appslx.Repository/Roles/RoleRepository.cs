using System;
using System.Collections.Generic;
using System.Text;
using Appslx.Core.Models;
using Appslx.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Appslx.Repository.Roles
{
    public class RoleRepository:GenericRepository<Role>,IRoleRepository
    {
        public RoleRepository(DbContext context) : base(context)
        {
        }

        public Role GetById(int id)
        {
            return _dbset.FirstOrDefaultAsync(x => x.Id == id).Result;
        }
    }
}
