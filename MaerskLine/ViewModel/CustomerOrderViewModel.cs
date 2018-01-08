using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MaerskLine.Models;

namespace MaerskLine.ViewModel
{
    public class CustomerOrderViewModel
    {
        public Order Orders { get; set; }
        public List<Customer> Customers { get; set; }
    }
}