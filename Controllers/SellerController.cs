using ABCD.Models;
using ABCD.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABCD.Controllers
{
    public class SellerController : Controller
    {
        private SellerServices sellerServices;

        // GET: Seller
        public ActionResult List()
        {
            sellerServices = new SellerServices();
            var model = sellerServices.GetSellerList();

            return View(model);
        }

        public ActionResult AddSeller()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSeller(Seller seller)
        {
            sellerServices = new SellerServices();

            sellerServices.InsertSeller(seller);

            return RedirectToAction("List");

        }

        public ActionResult EditSeller( int Id)
        {
            sellerServices = new SellerServices();

            var model = sellerServices.GetEditByID(Id);

            return View(model);
        }
        [HttpPost]
        public ActionResult EditSeller(Seller seller)
        {
            sellerServices = new SellerServices();

            sellerServices.UpdateSeller(seller);
            return RedirectToAction("List");
        }
         
        public ActionResult DeleteSeller(int Id)
        {
            sellerServices = new SellerServices();

            sellerServices.DeleteSeller(Id);
            return RedirectToAction("List");
        }
    }
} 