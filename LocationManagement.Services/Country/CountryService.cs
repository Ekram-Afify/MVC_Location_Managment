using LocationManagement.Data;
using LocationManagement.Data.Extentions;
using LocationManagement.Repositories;
using LocationManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationManagement.Services
{
    public class CountryService: ICountryService
    {
        public const int PI=15;
        public readonly int PI2=80;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICountryRepository _countryRepository;
        private readonly ICityRepository _cityRepository;
        public CountryService(ICountryRepository countryRepository,
            ICityRepository cityRepository,
            IUnitOfWork unitOfWork)
        {
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
            _unitOfWork = unitOfWork;
         
        }
        public IEnumerable<SelectedItem> GetList()
        {
            
            SelectedItem v = new SelectedItem { Text = "", Value = PI2 };
             var countries = _countryRepository.GetAll()
                                      
                                      .Select(c => new SelectedItem
                                      {
                                          Value=c.ID,
                                          Text=c.CountryName,
                                      }).ToList();

            return countries;


        }

        public PagingViewModel Search(string name = "", string orderBy = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 20)
        {

            var query = _countryRepository.GetAll()
                                       .Where(c=>name == "" || name == null || c.CountryName.Contains(name));

            int records = query.Count();
            if (records <= pageSize || pageIndex <= 0) pageIndex = 1;
            int pages = (int)Math.Ceiling((double)records / pageSize);
            int excludedRows = (pageIndex - 1) * pageSize;

            var result = query.Select(c => new CountryViewModel()
            {
                ID = c.ID,
                CountryName =c.CountryName ,
                CreatedDate=c.AddedDate

            }).OrderByPropertyName(orderBy, isAscending).Skip(excludedRows).Take(pageSize).ToList();

            return new PagingViewModel() { PageIndex = pageIndex, PageSize = pageSize, Result = result, Records = records, Pages = pages };
        }

        public CountryCreateViewModel GetById(int id)
        {
            return _countryRepository.GetById(id).ToViewModel();
        }

        public void Create(CountryCreateViewModel viewModel)
        {
            _countryRepository.Add(viewModel.ToModel());
            _unitOfWork.Save();
        }
        public void Update(CountryCreateViewModel viewModel)
        {
            _countryRepository.Edit(viewModel.ToModel());
            _unitOfWork.Save();
        }
        public void Delete(int id)
        {
            _cityRepository.RemoveAll(id);
            _countryRepository.Remove(id);
            _unitOfWork.Save();
        }

        public bool IsExist(int id)
        {
            return _countryRepository.GetAll().Any(c => c.ID == id);

        }

        public bool IsNameExist(string name)
        {
            return _countryRepository.GetAll().Any(c => c.CountryName.ToLower()==name.ToLower());

        }
        public bool IsNameExistById(int id,string name)
        {
            return _countryRepository.GetAll().Any(c => c.CountryName.ToLower() == name.ToLower() && c.ID!=id);
        }




    }
}
