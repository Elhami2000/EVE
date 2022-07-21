using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EVE.Models
{
    public class TicketCart
    {
        [Key]
        public int Id { get; set; }
        public BusInfo BusInfo { get; set; }
        public int Amount { get; set; }

        public string CartId { get; set; }

        internal object GetTicketCart()
        {
            throw new NotImplementedException();
        }
    }
}
