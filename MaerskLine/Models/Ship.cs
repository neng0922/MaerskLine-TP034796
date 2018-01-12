using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaerskLine.Models
{
    public class Ship
    {
        [Key]
        [Display(Name = "Ship ID")]
        public int ShipID { get; set; }

        [Required]
        [Display(Name = "Ship Name")]
        public String ShipName { get; set; }

        [Required]
        [Display(Name = "Number of Containers")]
        public int ShipContainerNum { get; set; }

        [Display(Name = "Remaining Containers")]
        public int ShipContainerNumRemaining { get; set; }

        [Display(Name = "Availability")]
        public Boolean ShipAvailability { get; set; }
    }
}