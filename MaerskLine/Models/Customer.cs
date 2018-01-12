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
        public String CustName { get; set; }

        [Required]
        [Phone]
        public String CustPhoneNum { get; set; }

        [Required]
        [EmailAddress]
        public String CustEmail { get; set; }

        [Required]
        public String CustAgent { get; set; }

    }
}