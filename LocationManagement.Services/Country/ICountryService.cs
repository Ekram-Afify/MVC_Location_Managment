using LocationManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationManagement.Services
{
    public interface ICountryService
    {
        IEnumerable<SelectedItem> GetList();
        PagingViewModel Search(string name = "", string orderBy = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 20);
        void Create(CountryCreateViewModel model);
        void Update(CountryCreateViewModel model);
        CountryCreateViewModel GetById(int id);
        void Delete(int id);
        bool IsExist(int id);
        bool IsNameExist(string name);
        bool IsNameExistById(int id, string name);


    }
}
