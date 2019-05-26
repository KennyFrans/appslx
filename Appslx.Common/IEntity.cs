using System;
using System.Collections.Generic;
using System.Text;

namespace Appslx.Common
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
