using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaerskLine.Models;
using MaerskLine.ViewModel;
using System.Diagnostics;

namespace MaerskLine.Controllers
{
    public class OrderController : Controller
    {
        private ApplicationDbContext dbContext;

        public OrderController()
        {
            dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }

        // GET: Order
        [Authorize]
        public ActionResult SelectSchedule()
        {
            var schedule = dbContext.Schedules.Include(s => s.Ship).Where(s => s.ScheduleAvailability.Equals(true)).ToList();

            return View(schedule);
        }

        [Authorize]
        public ActionResult SelectCustomer(int scheduleID)
        {
            var schedule = dbContext.Schedules.Include(s => s.Ship).SingleOrDefault(c => c.ScheduleID == scheduleID);

            var customer = dbContext.Customers.Where(c => c.CustAgent == User.Identity.Name).ToList();

            ScheduleCustomerOrderViewModel scovm = new ScheduleCustomerOrderViewModel()
            {
                Schedule = schedule,
                Customers = customer
            };

            return View(scovm);
        }

        [Authorize]
        public ActionResult OrderForm(int custID, int scheduleID)
        {
            TempData["OrderFailMsg"] = false;

            var customer = dbContext.Customers.SingleOrDefault(c => c.CustID == custID);

            var schedule = dbContext.Schedules.Include(s => s.Ship).SingleOrDefault(c => c.ScheduleID == scheduleID);

            ScheduleCustomerOrderViewModel scovm = new ScheduleCustomerOrderViewModel()
            {
                Schedule = schedule,
                Customer = customer
            };

            return View(scovm);
        }

        [Authorize]
        public ActionResult SaveOrder(ScheduleCustomerOrderViewModel scovm)
        {
            var order = new Order
            {
                ScheduleID = scovm.Schedule.ScheduleID,
                CustID = scovm.Customer.CustID,
                OrderAgent = User.Identity.Name
            };

            var container = new Container()
            {
                ContainerID = scovm.Container.ContainerID,
                ContainerItem = scovm.Container.ContainerItem,
                ContainerNum = scovm.Container.ContainerNum,
                ContainerWeight = scovm.Container.ContainerWeight,
                OrderID = scovm.Order.OrderID
            };

            var getContainerNum = dbContext.Ships.SingleOrDefault(c => c.ShipID == scovm.Schedule.ShipID);

            if (container.ContainerNum > getContainerNum.ShipContainerNumRemaining || container.ContainerNum == 0)
            {
                // false

                TempData["OrderFailMsg"] = true;

                return View("OrderForm", scovm);
            }
            else
            {
                getContainerNum.ShipContainerNumRemaining -= scovm.Container.ContainerNum;

                dbContext.Orders.Add(order);

                dbContext.Containers.Add(container);

                dbContext.SaveChanges();

                TempData["OrderSuccessMsg"] = true;

                //var orderList = dbContext.Orders.Include(s => s.Schedule.Ship).Include(s => s.Schedule).Include(c => c.Customer).ToList();
                if (User.IsInRole("Admin"))
                {
                    var orderList = dbContext.Containers.Include(o => o.Order).Include(s => s.Order.Schedule)
                        .Include(s => s.Order.Schedule.Ship).Include(s => s.Order.Customer).ToList();

                    return View("ViewOrder",orderList);
                }
                else
                {
                    var orderList = dbContext.Containers.Include(o => o.Order).Include(s => s.Order.Schedule)
                        .Include(s => s.Order.Schedule.Ship).Include(s => s.Order.Customer).Where(o => o.Order.OrderAgent == User.Identity.Name).ToList();

                    return View("ViewOrder",orderList);
                }
            }

        }

        [Authorize]
        public ActionResult ViewOrder()
        {
            TempData["OrderSuccessMsg"] = false;

            if (User.IsInRole("Admin"))
            {
                var orderList = dbContext.Containers.Include(o => o.Order).Include(s => s.Order.Schedule)
                    .Include(s => s.Order.Schedule.Ship).Include(s => s.Order.Customer).ToList();

                return View(orderList);
            }
            else
            {
                var orderList = dbContext.Containers.Include(o => o.Order).Include(s => s.Order.Schedule)
                    .Include(s => s.Order.Schedule.Ship).Include(s => s.Order.Customer).Where(o => o.Order.OrderAgent == User.Identity.Name).ToList();

                return View(orderList);
            }

        }

    }
}