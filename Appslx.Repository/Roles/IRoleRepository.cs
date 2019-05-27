using System;
using System.Collections.Generic;
using System.Text;
using Appslx.Core.Models;
using Appslx.Repository.Base;

namespace Appslx.Repository.Roles
{
    public interface IRoleRepository:IGenericRepository<Role>
    {
        Role GetById(int id);
    }
}
