using LocationManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationManagement.Services
{
    public interface ICityService
    {
        IEnumerable<SelectedItem> GetList(int CountryId);
        PagingViewModel Search(string name = "", int countryID = -1, string orderBy = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 20);
        void Create(CityCreateViewModel model);
        void Update(CityCreateViewModel model);
        CityCreateViewModel GetById(int id);
        void Delete(int id);
        bool IsExist(int id);
        bool IsCityNameExist(string name);
        bool IsCityNameExistById(string name, int Id);

    }
}
