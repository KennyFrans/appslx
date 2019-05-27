using Appslx.Repository;
using Appslx.Repository.Base;
using Autofac;
using Microsoft.EntityFrameworkCore;

namespace Appslx.Web.Modules
{
    public class EFModule:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //https://autofac.readthedocs.io/en/latest/integration/aspnetcore.html#differences-from-asp-net-classic
            builder.RegisterModule(new RepositoryModule());

            builder.RegisterType(typeof(BaseContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerLifetimeScope();
        }
    }
}
