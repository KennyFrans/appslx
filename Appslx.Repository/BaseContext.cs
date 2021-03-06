﻿using Appslx.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using Appslx.Core.Models;
using Microsoft.AspNetCore.Http;

namespace Appslx.Repository
{
    public class BaseContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Role> Roles
        {
            get;
            set;
        }
        public DbSet<User> Users
        {
            get;
            set;
        }
        public DbSet<UserRole> UserRoles
        {
            get;
            set;
        }
        public BaseContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=FRANSKE;Initial Catalog=Slxsys;Integrated Security=False;User ID=sa;Password=abc123");
            //optionsBuilder.UseSqlServer(@"Server=.;Database=Store ;integrated security=True;");
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity
                            && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                if (entry.Entity is IAuditableEntity entity)
                {
                    var user = new CurrentUser(new HttpContextAccessor());
                    var identityName = user.GetUser();

                    var now = DateTime.UtcNow;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedBy = identityName;
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    entity.UpdatedBy = identityName;
                    entity.UpdatedDate = now;
                }
            }

            return base.SaveChanges();
        }
    }
}
