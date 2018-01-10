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

        public ActionResult OrderForm(int scheduleID)
        {
            var schedule = dbContext.Schedules.Include(s => s.Ship).SingleOrDefault(c => c.ScheduleID == scheduleID);

            if (schedule == null)
            {
                return HttpNotFound();
            }

            OrderScheduleViewModel osvm = new OrderScheduleViewModel
            {
                Schedule = schedule
            };

            return View(osvm);
        }

        public ActionResult SaveOrder(OrderScheduleViewModel osvm)
        {
            var order = new Order
            {
                orderCustomerName = osvm.Order.orderCustomerName,
                orderDetail = osvm.Order.orderDetail,
                orderLotNum = osvm.Order.orderLotNum,
                ScheduleID = osvm.Schedule.ScheduleID,
               
            };

            var getLotNum = dbContext.Ships.SingleOrDefault(c => c.ShipID == osvm.Schedule.ShipID);

            if (osvm.Order.orderLotNum > getLotNum.ShipLotNumRemaining)
            {
                // false

                return View("OrderForm",osvm);
            }
            else
            {
                getLotNum.ShipLotNumRemaining -= osvm.Order.orderLotNum;

                dbContext.Orders.Add(order);

                dbContext.SaveChanges();

                var orderList = dbContext.Orders.Include(s => s.Schedule.Ship).Include(s => s.Schedule).ToList();

                return View("ViewOrder", orderList);
            }
            
        }

        public ActionResult ViewOrder()
        {
            var order = dbContext.Orders.Include(s => s.Schedule).Include(s => s.Schedule.Ship).ToList();

            return View(order);
        }
    }
}