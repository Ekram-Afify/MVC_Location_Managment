using LocationManagement.Data;
using LocationManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LocationManagement.Repositories
{
    public class Repository<T> where T : BaseModel
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        protected string[] defaultExcludedEditProperties = new string[]
          {
              "AddedDate",
                 "ID"
          };

        public Repository(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork.Context;
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.Where(obj => !obj.IsDeleted).AsQueryable();
        }

        public T Add(T obj)
        {
            obj.AddedDate = DateTime.Now;
            return _dbSet.Add(obj);
        }


        public virtual T Edit(T entity)
        {
            if (defaultExcludedEditProperties.Any())
            {
                var oldEntity = _context.Set<T>().Local.FirstOrDefault(e => e.ID == entity.ID);
                if (oldEntity != null)
                    _context.Entry<T>(oldEntity).State = EntityState.Detached;

                _dbSet.Attach(entity);
                foreach (var name in defaultExcludedEditProperties)
                {
                    _context.Entry(entity).Property(name).IsModified = false;
                }
                var takenProp = _context.Entry<T>(entity).CurrentValues.PropertyNames.Except(defaultExcludedEditProperties);
                foreach (var name in takenProp)
                {
                    _context.Entry(entity).Property(name).IsModified = true;
                }
                entity.UpdatedDate = DateTime.Now;
            }
            else
            {
               
                entity.AddedDate = DateTime.Now;
                _context.Entry<T>(entity).State = EntityState.Modified;
            }
            return entity;
        }

       

        public virtual T SaveIncluded(T entity, params string[] included)
        {
            var oldEntity = _context.Set<T>().Local.FirstOrDefault(e => e.ID == entity.ID);
            if (oldEntity != null)
                _context.Entry<T>(oldEntity).State = EntityState.Detached;

            _dbSet.Attach(entity);
            _context.Configuration.ValidateOnSaveEnabled = false;
            foreach (var name in included)
            {
                _context.Entry(entity).Property(name).IsModified = true;
            }
            var excludedProps = _context.Entry<T>(entity).CurrentValues.PropertyNames.Except(included);
            foreach (var name in excludedProps)
            {
                _context.Entry(entity).Property(name).IsModified = false;
            }

            entity.UpdatedDate = DateTime.Now;

            return entity;
        }

        public virtual T SaveExcluded(T entity, params string[] excludedProperties)
        {
            var oldEntity = _context.Set<T>().Local.FirstOrDefault(e => e.ID == entity.ID);
            if (oldEntity != null)
                _context.Entry<T>(oldEntity).State = EntityState.Detached;

            _dbSet.Attach(entity);
            _context.Configuration.ValidateOnSaveEnabled = false;
        
            foreach (var name in excludedProperties)
            {
                _context.Entry(entity).Property(name).IsModified = false;
            }
            var takenProp = _context.Entry<T>(entity).CurrentValues.PropertyNames.Except(excludedProperties).Except(new[] { "ID" });
            foreach (var name in takenProp)
            {
                _context.Entry(entity).Property(name).IsModified = true;
            }

            entity.UpdatedDate = DateTime.Now;
            

            return entity;
        }

        public void Remove(int id)
        {
            T entity = _dbSet.FirstOrDefault(i => i.ID == id);
            RemoveByIncluded(entity);
        }

        public void RemoveRange(IEnumerable<int> Ids)
        {
            foreach (int id in Ids)
                Remove(id);
        }

        public void RemoveByIncluded(T entity)
        {
            entity.IsDeleted = true;
            SaveIncluded(entity, "IsDeleted");
        }

      

        public virtual T GetById(int id)
        {
            return _dbSet.Where(entity => !entity.IsDeleted && entity.ID == id).FirstOrDefault();
        }
    }
}