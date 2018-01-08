using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaerskLine.Models
{
    public class Customer
    {
        [Key]
        public int custID { get; set; }
        public String custName { get; set; }
        public String custGender { get; set; }
    }
}