using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationManagement.Models
{
    [Table("City")]
    public class City:BaseModel
    {
       
        [Required]
        public string CityName { get; set; }
       
        [Required]
        [ForeignKey("Country")]
        public int CountryID { get; set; }
        public virtual Country Country { get; set; }
       


    }
}
