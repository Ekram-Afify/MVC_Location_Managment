using LocationManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationManagement.ViewModels
{
    public class CityViewModel
    {
        public int ID { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CountryId { get; set; }
    }
    public static class CityListExtension
    {
        public static CityViewModel ToViewModel(this City model)
        {
            return new CityViewModel
            {

                ID=model.ID,
                CityName=model.CityName,
                CountryName=model.Country.CountryName,
                CreatedDate=model.AddedDate,
                CountryId=model.CountryID,

            };
        }

    }
}
