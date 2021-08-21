using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationManagement.Data
{
    public interface IUnitOfWork
    {
        DbContext Context { get; }
        void Save();
    }
}
