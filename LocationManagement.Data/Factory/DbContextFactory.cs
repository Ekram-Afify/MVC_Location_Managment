using System;
using System.Data.Entity;

namespace LocationManagement.Data
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContext _context;

        public DbContextFactory()
        {
           _context= _context ?? new Context();
        }

        public DbContext GetDbContext()
        {
            return _context;
        }

  
    }
}