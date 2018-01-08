using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaerskLine.Models
{
	public class Order
	{
        [Key]
        public int orderID { get; set; }

        public String custName { get; set; }

        public String orderDetail { get; set; }

        public int orderLotNum { get; set; }

        public DateTime orderDateTime { get; set; }
    }
}