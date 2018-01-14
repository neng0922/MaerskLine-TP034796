using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MaerskLine.Models;
using Microsoft.AspNet.Identity;

namespace MaerskLine.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext dbContext;

        public CustomerController()
        {
            dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }

        // GET: Customer
        [Authorize]
        public ActionResult CustomerForm()
        {
            return View();
        }

        [Authorize]
        public ActionResult SaveCustomer(Customer customer)
        {
            var currentUser = User.Identity.Name;

            if (customer.CustID == 0)
            {
                customer.CustAgent = currentUser;

                dbContext.Customers.Add(customer);
            }
            else
            {
                var custInDB = dbContext.Customers.SingleOrDefault(c => c.CustID == customer.CustID);

                custInDB.CustName = customer.CustName;
                custInDB.CustPhoneNum = customer.CustPhoneNum;
                custInDB.CustEmail = customer.CustEmail;
            }

            dbContext.SaveChanges();

            //TempData["AddShipSuccessMsg"] = "<script language='javascript' type='text/javascript'>alert     ('Ship Added Successfully !!!');</script>";

            var customerList = dbContext.Customers.Where(c => c.CustAgent == User.Identity.Name).ToList();

            return View("ViewCustomer", customerList);
        }

        [Authorize]
        public ActionResult ViewCustomer()
        {

            if (User.IsInRole("Admin"))
            {
                var cust = dbContext.Customers.ToList();
                return View(cust);
            }
            else
            {
                var cust = dbContext.Customers.Where(c => c.CustAgent == User.Identity.Name).ToList();
                return View(cust);
            }
        }

        [Authorize]
        public ActionResult EditCustomer(int custID)
        {
            var cust = dbContext.Customers.SingleOrDefault(c => c.CustID == custID);

            if (cust == null)
            {
                return HttpNotFound();
            }

            Customer custModel = new Customer();
            custModel.CustID = cust.CustID;
            custModel.CustName = cust.CustName;
            custModel.CustPhoneNum = cust.CustPhoneNum;
            custModel.CustEmail = cust.CustEmail;

            return View("CustomerForm", custModel);
        }
    }
}