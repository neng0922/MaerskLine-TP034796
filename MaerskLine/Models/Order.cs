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
		public int OrderID { get; set; }

		[Display(Name = "Order Delivered")]
		public bool OrderDelivered { get; set; }

		public int ScheduleID { get; set; }

		public Schedule Schedule { get; set; }

	    public int ContainerID { get; set; }

	    public Container Container { get; set; }
	}
}