
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVE.Models
{
    public class BusDriver_BusInfo
    {
        public int BusDriverID { get; set; }
        public BusDriver BusDriver { get; set; }

        public int BusInfoID { get; set; }
        public BusInfo BusInfo { get; set; }

    }
}
