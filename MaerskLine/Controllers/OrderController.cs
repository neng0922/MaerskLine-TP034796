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

        public ActionResult SelectSchedule()
        {
            var schedule = dbContext.Schedules.Include(s => s.Ship).ToList();

            return View(schedule);
        }

        public ActionResult SelectCustomer(int scheduleID)
        {
            var schedule = dbContext.Schedules.Include(s => s.Ship).SingleOrDefault(c => c.ScheduleID == scheduleID);

            var customer = dbContext.Customers.ToList();

            ScheduleCustomerOrderViewModel scovm = new ScheduleCustomerOrderViewModel()
            {
                Schedule = schedule,
                Customers = customer
            };

            return View(scovm);
        }

        public ActionResult OrderForm(int custID, int scheduleID)
        {
            var customer = dbContext.Customers.SingleOrDefault(c => c.CustID == custID);

            var schedule = dbContext.Schedules.Include(s => s.Ship).SingleOrDefault(c => c.ScheduleID == scheduleID);

            ScheduleCustomerOrderViewModel scovm = new ScheduleCustomerOrderViewModel()
            {
                Schedule = schedule,
                Customer = customer
            };

            return View(scovm);
        }

        public ActionResult SaveOrder(ScheduleCustomerOrderViewModel scovm)
        {
            var order = new Order
            {
                ScheduleID = scovm.Schedule.ScheduleID,
                CustID = scovm.Customer.CustID
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

            if (container.ContainerNum > getContainerNum.ShipContainerNumRemaining)
            {
                // false

                return View("OrderForm", scovm);
            }
            else
            {
                getContainerNum.ShipContainerNumRemaining -= scovm.Container.ContainerNum;

                dbContext.Orders.Add(order);

                dbContext.Containers.Add(container);

                dbContext.SaveChanges();

                //var orderList = dbContext.Orders.Include(s => s.Schedule.Ship).Include(s => s.Schedule).Include(c => c.Customer).ToList();

                var orderList = dbContext.Containers.Include(o => o.Order).Include(s => s.Order.Schedule)
                    .Include(s => s.Order.Schedule.Ship).Include(s => s.Order.Customer).ToList();

                return View("ViewOrder", orderList);
            }

        }

        public ActionResult ViewOrder()
        {
            var orderList = dbContext.Containers.Include(o => o.Order).Include(s => s.Order.Schedule)
                .Include(s => s.Order.Schedule.Ship).Include(s => s.Order.Customer).ToList();

            return View(orderList);
        }

    }
}