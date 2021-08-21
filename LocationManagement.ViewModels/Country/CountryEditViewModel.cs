using LocationManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationManagement.ViewModels
{
    public class CountryEditViewModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "CountryId is required")]
        public int ID { get; set; }
        [Required]
        public string CountryName { get; set; }
       


    }
    public static class EditCountryExtension
    {
        public static Country ToModel(this CountryEditViewModel viewModel)
        {
            return new Models.Country
            {

                ID=viewModel.ID,
                CountryName=viewModel.CountryName

            };
        }

    }
}
