using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LocationManagement.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T Add(T entity);
        T Edit(T entity);
        void Remove(int id);
        T SaveIncluded(T entity, params string[] includedProperties);
        T SaveExcluded(T entity, params string[] excludedProperties);
        void RemoveByIncluded(T entity);
        T GetById(int id);

    }
}
