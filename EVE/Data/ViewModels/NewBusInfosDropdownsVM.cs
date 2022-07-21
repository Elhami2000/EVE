using EVE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVE.Data.ViewModels
{
    public class NewBusInfosDropdownsVM
    {
        public NewBusInfosDropdownsVM()
        {
            BusDrivers = new List<BusDriver>();
        }

        public List<BusDriver> BusDrivers { get; set; }
    }
}
