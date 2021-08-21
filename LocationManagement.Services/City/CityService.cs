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
    public class CityService: ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository, IUnitOfWork unitOfWork)
        {
            _cityRepository = cityRepository;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<SelectedItem> GetList(int CountryId)
        {
            var cities = _cityRepository.GetAll()
                                      .Where(c=>c.CountryID== CountryId)
                                      .Select(c => new SelectedItem
                                      {
                                          Value=c.ID,
                                          Text=c.CityName,
                                      }).ToList();

            return cities;


        }

        public PagingViewModel Search(string name = "", int countryId = -1, string orderBy = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 20)
        {

            var query = _cityRepository.GetAll()
                                       .Where(r =>(countryId == -1 || r.CountryID == countryId) &&
                                             (name == "" || name == null || r.CityName.Contains(name)));

            int records = query.Count();
            if (records <= pageSize || pageIndex <= 0) pageIndex = 1;
            int pages = (int)Math.Ceiling((double)records / pageSize);
            int excludedRows = (pageIndex - 1) * pageSize;

            var result = query.Select(c => new CityViewModel()
            {
                ID = c.ID,
                CityName =c.CityName ,
                CountryName = c.Country.CountryName,
                CreatedDate=c.AddedDate

            }).OrderByPropertyName(orderBy, isAscending).Skip(excludedRows).Take(pageSize).ToList();

            return new PagingViewModel() { PageIndex = pageIndex, PageSize = pageSize, Result = result, Records = records, Pages = pages };
        }

        public CityCreateViewModel GetById(int id)
        {
            return _cityRepository.GetById(id).ToVModel();
        }

        public void Create(CityCreateViewModel viewModel)
        {
            _cityRepository.Add(viewModel.ToModel());
            _unitOfWork.Save();
        }
        public void Update(CityCreateViewModel viewModel)
        {
            _cityRepository.Edit(viewModel.ToModel());
            _unitOfWork.Save();
        }
        public void Delete(int id)
        {
            _cityRepository.Remove(id);
            _unitOfWork.Save();
        }

        public bool IsExist(int id)
        {
            return _cityRepository.GetAll().Any(c => c.ID == id);

        }
        public bool IsCityNameExist(string name)
        {
            return _cityRepository.GetAll().Any(c => c.CityName.ToLower().Contains(name.ToLower()));

        }
        public bool IsCityNameExistById(string name,int Id)
        {
            return _cityRepository.GetAll().Any(c => c.CityName.ToLower().Contains(name.ToLower()) && c.ID !=Id);

        }


    }
}
