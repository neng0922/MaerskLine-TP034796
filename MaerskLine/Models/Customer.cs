using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaerskLine.Models
{
    public class Customer
    {
        [Key]
        public int CustID { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public String CustName { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public String CustPhoneNum { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public String CustEmail { get; set; }

        [Required]
        public String CustAgent { get; set; }

    }
}