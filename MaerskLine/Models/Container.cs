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
        public int ContainerItem { get; set; }

        [Required]
        public double ContainerWeight { get; set; }

        public int CustID { get; set; }

        public Customer Customer { get; set; }
    }
}