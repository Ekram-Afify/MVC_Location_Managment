using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationManagement.ViewModels
{
    public class PagingViewModel
    {
        public int TotalRows { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<object> Result { get; set; }
        public int Records { get; set; }
        public int Pages { get; set; }
    }
}
