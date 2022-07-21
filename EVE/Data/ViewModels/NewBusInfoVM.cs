using EVE.Data;
using EVE.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EVE.Models
{
    public class NewBusInfoVM
    {

        public int ID { get; set; }

        [Display(Name = " Bus line URL")]
        [Required(ErrorMessage ="Bus line URL is required.")]
        public string BusPhoto { get; set; }

        [Display(Name = " Bus type")]
        [Required(ErrorMessage = "Bus type is required.")]
        public string BusType { get; set; }

        [Display(Name = "Bus line pershkrimi")]
        [Required(ErrorMessage = "Pershkrimi i bus line eshte required.")]
        public string Pershkrimi { get; set; }

        [Display(Name = "Bus line start date")]
        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartLineDate { get; set; }

        [Display(Name = "Bus line end date")]
        [Required(ErrorMessage = "End date is required.")]
        public DateTime EndLineDate { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required.")]
        public double TicketPrice { get; set; }

        [Display(Name = " Bus category")]
        [Required(ErrorMessage = "Bus category is required.")]
        public BusCategory BusCategory { get; set; }

        //Relationships
        [Display(Name = "Select bus drivers")]
        [Required(ErrorMessage = "Bus drivers are required.")]
        public List<int> BusDriverIDs { get; set; }
    }
}
