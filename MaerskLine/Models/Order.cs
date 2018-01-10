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
		[Display(Name = "Order ID")]
		public int orderID { get; set; }

		[Display(Name = "Customer Name")]
		public String orderCustomerName { get; set; }

		[Display(Name = "Order Details")]
		public String orderDetail { get; set; }

		[Display(Name = "Required Lot Number")]
		public int orderLotNum { get; set; }

		[Display(Name = "Order Delivered")]
		public bool orderDelivered { get; set; }

		public int ScheduleID { get; set; }

		public Schedule Schedule { get; set; }
	}
}