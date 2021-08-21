using LocationManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationManagement.ViewModels
{
    public class CountryCreateViewModel
    {

        public int ID { get; set; }
        [Required]
        public string CountryName { get; set; }
    

    }
    public static class CountryExtension
    {
        public static Country ToModel(this CountryCreateViewModel viewModel)
        {
            return new Models.Country
            {
               ID=viewModel.ID,
               CountryName=viewModel.CountryName
            };
        }
   
            public static CountryCreateViewModel ToViewModel(this Country model)
            {
                return new CountryCreateViewModel
                {

                    ID = model.ID,
                    CountryName = model.CountryName,
                 

                };
            }

        

    }
}
