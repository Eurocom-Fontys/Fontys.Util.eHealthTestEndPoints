using EurocomFontysHealth.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EurocomFontysHealth.DataSource
{
    public abstract class DataSourceBase<T>
        where T : Entity
    {
        public abstract IEnumerable<T> GetAll();
    
        public IEnumerable<T> GetFiltered(Func<T, bool> predicate)
        {
            return GetAll().Where(a => predicate(a)).ToList();
        }

        public T GetByID(Guid id)
        {
            return GetAll().Where(a => a.ID == id).FirstOrDefault();
        }
    }
}
