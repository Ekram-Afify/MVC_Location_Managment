using LocationManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationManagement.ViewModels
{
    public class CityEditViewModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "CityId is required")]
        public int ID { get; set; }
        [Required]
        public string CityName { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "CountryId is required")]
        public int CountryId { get; set; }


    }
    public static class EditCityExtension
    {
        public static City ToModel(this CityEditViewModel viewModel)
        {
            return new Models.City
            {

                CountryID = viewModel.CountryId,
                CityName = viewModel.CityName,
               
            };
        }

    }
}
