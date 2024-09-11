using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispensatorApp.Database.ViewModel
{
    public class DispensationQuantitiesViewModel
    {
        public int? DispensationMode { get; set; }
        public int? Amount { get; set; }
        public int? QuatityOf100 { get; set; }
        public int? QuatityOf200 { get; set; }
        public int? QuatityOf500 { get; set; }
        public int? QuantityOf1000 { get; set; }
    }
}
