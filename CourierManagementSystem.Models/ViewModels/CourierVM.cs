using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.Models.ViewModels
{
    public class CourierVM
    {
        public IEnumerable<Courier> courier { get; set; }

        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
    }
}
