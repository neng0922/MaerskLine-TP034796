﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaerskLine.Models;
using Microsoft.Ajax.Utilities;

namespace MaerskLine.Controllers
{
    public class ScheduleController : Controller
    {
        private ApplicationDbContext dbContext;

        public ScheduleController()
        {
            dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }

        // GET: Schedule
        [Authorize(Roles = "Admin")]
        public ActionResult ScheduleForm()
        {
            var shipList = dbContext.Ships.Where(s => s.ShipAvailability.Equals(true)).ToList();
            var viewModel = new ShipScheduleViewModal
            {
                Ships = shipList

            };

            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult SaveSchedule(ShipScheduleViewModal ssvm)
        {
            if (ssvm.Schedule.ScheduleID == 0)
            {
                var scheduleDB = ssvm.Schedule;

                dbContext.Schedules.Add(scheduleDB);
            }
            else
            {
                var scheduleInDB = dbContext.Schedules.Include(s => s.Ship).SingleOrDefault(c => c.ScheduleID == ssvm.Schedule.ScheduleID);

                scheduleInDB.ScheduleOrigin = ssvm.Schedule.ScheduleOrigin;
                scheduleInDB.ScheduleDestination = ssvm.Schedule.ScheduleDestination;
                scheduleInDB.ScheduleDepartureDateTime = ssvm.Schedule.ScheduleDepartureDateTime;
                scheduleInDB.ScheduleArrivalDateTime = ssvm.Schedule.ScheduleArrivalDateTime;
                scheduleInDB.ShipID = ssvm.Schedule.ShipID;
                scheduleInDB.ScheduleAvailability = ssvm.Schedule.ScheduleAvailability;
            }

            dbContext.SaveChanges();

            TempData["ScheduleSuccessMsg"] = true;

            var scheduleList = dbContext.Schedules.Include(s => s.Ship).ToList();

            return View("ViewSchedule", scheduleList);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ViewSchedule()
        {
            TempData["ScheduleSuccessMsg"] = false;

            var schedule = dbContext.Schedules.Include(s => s.Ship).ToList();

            return View(schedule);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditSchedule(int scheduleID)
        {
            var schedule = dbContext.Schedules.Include(s => s.Ship).SingleOrDefault(c => c.ScheduleID == scheduleID);

            if (schedule == null)
            {
                return HttpNotFound();
            }

            ShipScheduleViewModal ssvm = new ShipScheduleViewModal
            {
                Schedule = schedule,
                Ships = dbContext.Ships.DistinctBy(s => s.ShipName).Where(s => s.ShipAvailability.Equals(true)).ToList()
                
            };
            //ssvm.Schedule.ScheduleID = scheduleID;
            //ssvm.Schedule.ScheduleOrigin = schedule.ScheduleOrigin;
            //ssvm.Schedule.ScheduleDestination = schedule.ScheduleDestination;
            //ssvm.Schedule.ScheduleDepartureDateTime = schedule.ScheduleDepartureDateTime;
            //ssvm.Schedule.ScheduleArrivalDateTime = schedule.ScheduleArrivalDateTime;
            //ssvm.Schedule.ShipID = schedule.ShipID;
            //ssvm.Schedule.ScheduleAvailability = schedule.ScheduleAvailability;

            return View("ScheduleForm", ssvm);
        }
    }
}