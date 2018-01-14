using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaerskLine.Models;

namespace MaerskLine.Controllers
{
    public class ShipController : Controller
    {
        private ApplicationDbContext dbContext;

        public ShipController()
        {
            dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }

        // GET: Ship
        [Authorize(Roles = "Admin")]
        public ActionResult ShipForm()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult SaveShip(Ship ship)
        {
            if (ship.ShipID == 0)
            {
                ship.ShipContainerNumRemaining = ship.ShipContainerNum;

                dbContext.Ships.Add(ship);
            }
            else
            {
                var shipInDB = dbContext.Ships.SingleOrDefault(c => c.ShipID == ship.ShipID);

                //shipInDB.ShipID = ship.ShipID;
                shipInDB.ShipName = ship.ShipName;
                shipInDB.ShipContainerNum = ship.ShipContainerNum;
                shipInDB.ShipContainerNumRemaining = shipInDB.ShipContainerNumRemaining;
                shipInDB.ShipAvailability = ship.ShipAvailability;
            }
            
            dbContext.SaveChanges();

            ViewBag.ShipSuccessMsg = true;

            var shipList = dbContext.Ships.ToList();

            return View("ViewShip", shipList);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ViewShip()
        {
            ViewBag.ShipSuccessMsg = false;

            var ship = dbContext.Ships.ToList();

            return View(ship);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditShip(int shipID)
        {
            var ship = dbContext.Ships.SingleOrDefault(c => c.ShipID == shipID);

            if (ship == null)
            {
                return HttpNotFound();
            }

            Ship shipModel = new Ship();
            shipModel.ShipID = ship.ShipID;
            shipModel.ShipName = ship.ShipName;
            shipModel.ShipContainerNum = ship.ShipContainerNum;
            //shipModel.ShipOrigin = ship.ShipOrigin;
            //shipModel.ShipDestination = ship.ShipDestination;
            //shipModel.ShipDepartingTime = ship.ShipDepartingTime;
            //shipModel.ShipArrivingTime = ship.ShipArrivingTime;
            shipModel.ShipAvailability = ship.ShipAvailability;

            return View("ShipForm", shipModel);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteShip()
        {
            return View();
        }


    }
}