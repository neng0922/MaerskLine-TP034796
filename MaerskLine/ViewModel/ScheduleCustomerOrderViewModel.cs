using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MaerskLine.Models;

namespace MaerskLine.ViewModel
{
    public class ScheduleCustomerOrderViewModel
    {
        public Schedule Schedule { get; set; }

        public List<Customer> Customers { get; set; }

        public Customer Customer { get; set; }

        public List<Container> Containers { get; set; }

        public Container Container { get; set; }

        public Order Order { get; set; }
    }
}