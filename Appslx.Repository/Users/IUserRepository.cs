using System.Collections.Generic;
using Appslx.Core.Models;
using Appslx.Repository.Base;

namespace Appslx.Repository.Users
{
    public interface IUserRepository:IGenericRepository<User>
    {
        List<int> FindRole(int userid);
        User GetById(int id);
    }
}
