using EVE.Data;
using EVE.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EVE.Models
{
    public class BusInfo:IEntityBase
    {
        [Key]
         public int  ID { get; set; }

        public string BusPhoto { get; set; }

        public string BusType { get; set; }

        public string Pershkrimi { get; set; }

        public DateTime StartLineDate { get; set; }

        public DateTime EndLineDate { get; set; }

        public double TicketPrice { get; set; }

        public BusCategory BusCategory { get; set; }

        //Relationships
        public List<BusDriver_BusInfo> BusDrivers_BusInfos { get; set; }
    }
}
