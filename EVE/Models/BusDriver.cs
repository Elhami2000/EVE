using EVE.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EVE.Models
{
    public class BusDriver:IEntityBase
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Profile Picture URL")]
        [Required(ErrorMessage ="Shto profile picture")]
        public string BusDriverPic { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Shkruani Emrin e plote")]
        [StringLength(50,MinimumLength = 3, ErrorMessage ="Emri duhet te jete ne mes 3 dhe 50 karaktereve")]
        public string Emri { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Shkruani Bion")]
        public string Bio { get; set; }
        public List<BusDriver_BusInfo>  BusDrivers_BusInfos  {get; set;}

        
    }
}
