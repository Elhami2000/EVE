using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EVE.Models
{
    public class OrderTicket
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public double TicketPrice { get; set; }

        public int BusId { get; set; }
        [ForeignKey("BusId")]
        public  BusInfo BusInfo { get; set; }



        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

    }
}
