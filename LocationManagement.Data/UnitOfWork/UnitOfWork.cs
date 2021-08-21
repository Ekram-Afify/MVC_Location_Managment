using LocationManagement.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationManagement.Data
{
    public class UnitOfWork : IDisposable , IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private bool _disposed;
        
        public DbContext Context
        {
            get { return _dbContext; }
        }
        public UnitOfWork(IDbContextFactory dbContextFactory)
        {
            _dbContext = dbContextFactory.GetDbContext();
        }
        public void Save()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch(DbEntityValidationException exception)
            {
                throw exception;
            }

        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

    }
}
