
using LocationManagement.Data;
using LocationManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationManagement.Repositories
{
    public class CountryRepository: Repository<Country>, ICountryRepository
    {
        public CountryRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork) { }

      
    }
}
