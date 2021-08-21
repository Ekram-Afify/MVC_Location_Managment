
using LocationManagement.Data;
using LocationManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LocationManagement.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(IUnitOfWork unitOfWork)
               : base(unitOfWork) { }




        public void RemoveAll(int countryId)
        {
            var citiesIds = GetAll().Where(c => c.CountryID == countryId).Select(c => c.ID).ToList(); ;

            RemoveRange(citiesIds);
        }


    }
}
