using System;
using System.Collections.Generic;
using System.Text;
using Appslx.Common;

namespace Appslx.Service.Base
{
    public interface IService
    {
    }
    public interface IEntityService<T> : IService
        where T : BaseEntity
    {
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
}
