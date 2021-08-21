using LocationManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationManagement.ViewModels
{
    public class CountryViewModel
    {
        public int ID { get; set; }
        public string CountryName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    
}
