using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaerskLine.Models;
using MaerskLine.ViewModel;

namespace MaerskLine.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Random()
        {
            var orders = new Order() {orderDetail = "Liquid" };

            var customers = new List<Customer>
            {
                new Customer {custName = "ken" },
                new Customer {custName = "peter" }
            };

            var viewModel = new CustomerOrderViewModel
            {
                Orders = orders,
                Customers = customers
            };

            return View(viewModel);
        }
    }
}