using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Appslx.Core.Models;
using Appslx.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Appslx.Repository.Users
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public List<int> FindRole(int userid)
        {
            var roleId = _entities.Set<Role>().Include("UserRoles").Where(r => r.UserRoles.Any(z => z.UserId == userid))
                .Select(y => y.Id).ToList();
            return roleId;
        }

        public User GetById(int id)
        {
            return _dbset.FirstOrDefaultAsync(x => x.Id == id).Result;
        }

        public override void Edit(User entity)
        {
                var oldUserRole = _dbset.Include("UserRoles").FirstOrDefault(x => x.Id == entity.Id);
                var oldRole = oldUserRole.UserRoles.Select(x => x.RoleId).ToList();
                entity.UserRoles = oldUserRole.UserRoles.ToList();

                _entities.Entry(oldUserRole).State = EntityState.Detached;

                _dbset.Attach(entity);
                _entities.Entry(entity).State = EntityState.Modified;
                _entities.ChangeTracker.DetectChanges();

                if (entity.SelectedUserRole != null)
                {
                    var newRole = entity.SelectedUserRole.ToList();

                    var toDelRole = oldRole.Except(newRole).ToList();
                    var toAddRole = newRole.Except(oldRole).ToList();

                    foreach (var delRole in toDelRole)
                    {
                        var role = _entities.Set<Role>().Find(delRole);
                        var userrole =
                            _entities.Set<UserRole>().FirstOrDefault(x => x.UserId == entity.Id && x.RoleId == role.Id);
                        entity.UserRoles.Remove(userrole);
                    }

                    foreach (var addRole in toAddRole)
                    {
                        var role = _entities.Set<Role>().Find(addRole);
                        var userrole = new UserRole
                        {
                            UserId = entity.Id,
                            RoleId = role.Id
                        };
                        entity.UserRoles.Add(userrole);
                    }                    
                }
        }

        public override List<User> GetAll()
        {
            using (var context = new BaseContext())
            {
                var e = context.Users.Include("UserRoles").ToList();
                return e;
            }
        }

        public override User Add(User entity)
        {
            _dbset.Add(entity);
            if (entity.SelectedUserRole != null)
            {
                foreach (var roleid in entity.SelectedUserRole)
                {
                    var nRole = _entities.Set<Role>().Find(roleid);
                    var userrole = new UserRole
                    {
                        UserId = entity.Id,
                        RoleId = nRole.Id
                    };
                    entity.UserRoles.Add(userrole);
                }
            }

            return entity;
        }
    }
}
