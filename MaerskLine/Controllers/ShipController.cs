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
        public ActionResult ShipForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveShip(Ship ship)
        {
            if (ship.ShipID == 0)
            {
                dbContext.Ships.Add(ship);
            }
            else
            {
                var shipInDB = dbContext.Ships.SingleOrDefault(c => c.ShipID == ship.ShipID);

                //shipInDB.ShipID = ship.ShipID;
                shipInDB.ShipName = ship.ShipName;
                shipInDB.ShipLotNum = ship.ShipLotNum;
                shipInDB.ShipOrigin = ship.ShipOrigin;
                shipInDB.ShipDestination = ship.ShipDestination;
                shipInDB.ShipDepartingTime = ship.ShipDepartingTime;
                shipInDB.ShipArrivingTime = ship.ShipArrivingTime;
                shipInDB.ShipAvailability = ship.ShipAvailability;
            }
            
            dbContext.SaveChanges();

            //TempData["AddShipSuccessMsg"] = "<script language='javascript' type='text/javascript'>alert     ('Ship Added Successfully !!!');</script>";

            var shipList = dbContext.Ships.ToList();

            return View("ViewShip", shipList);
        }

        [Authorize]
        public ActionResult ViewShip()
        {
            var ship = dbContext.Ships.ToList();

            return View(ship);
        }

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
            shipModel.ShipLotNum = ship.ShipLotNum;
            shipModel.ShipOrigin = ship.ShipOrigin;
            shipModel.ShipDestination = ship.ShipDestination;
            shipModel.ShipDepartingTime = ship.ShipDepartingTime;
            shipModel.ShipArrivingTime = ship.ShipArrivingTime;
            shipModel.ShipAvailability = ship.ShipAvailability;

            return View("ShipForm", shipModel);
        }

        //public ActionResult ShipDetails(int shipID)
        //{
        //    var ship = dbContext.Ships.SingleOrDefault(c => c.ShipID == shipID);

        //    if(shipID == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(ship);
        //}

        public ActionResult DeleteShip()
        {
            return View();
        }


    }
}