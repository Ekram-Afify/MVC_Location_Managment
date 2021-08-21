using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationManagement.Models
{
    [Table("Country")]
    public class Country:BaseModel
    {
       
        [Required]
        public string CountryName { get; set; }
        public virtual ICollection<City> Cities { get; set; }
 
    }


}
