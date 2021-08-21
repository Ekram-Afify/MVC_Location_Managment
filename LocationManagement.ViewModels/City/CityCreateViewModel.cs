using LocationManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationManagement.ViewModels
{
    public class CityCreateViewModel
    {
        public int ID { get; set; }
        [Required]
        public string CityName { get; set; }
        [Range(1,int.MaxValue,ErrorMessage ="CountryId is required")]
        public int CountryId { get; set; }

        public string CountryName { get; set; }

       

    }
    public static class CityExtension
    {
        public static City ToModel(this CityCreateViewModel viewModel)
        {
            return new Models.City
            {
                ID=viewModel.ID,
                CountryID = viewModel.CountryId,
                CityName = viewModel.CityName,
               
            };
        }

        public static CityCreateViewModel ToVModel(this City model)
        {
            return new CityCreateViewModel
            {

                ID = model.ID,
                CityName = model.CityName,
                CountryName = model.Country.CountryName,
               
                CountryId = model.CountryID,

            };
        }
    }
}
