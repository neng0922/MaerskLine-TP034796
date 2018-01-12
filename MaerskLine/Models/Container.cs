using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaerskLine.Models
{
    public class Container
    {
        [Key]
        public int ContainerID { get; set; }

        [Required]
        [Display(Name = "Item to deliver")]
        public int ContainerItem { get; set; }
      
        [Required]
        [Display(Name = "Number of containers")]
        public int ContainerNum { get; set; }

        [Required]
        [Display(Name = "Weight of containers")]
        public double ContainerWeight { get; set; }

        public int CustID { get; set; }

        public Customer Customer { get; set; }
    }
}