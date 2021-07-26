using ABCD.Models;
using ABCD.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABCD.Controllers
{
    public class ProductController : Controller
    {
        private ProductServices ProductServices;

        // GET: Product
        public ActionResult List()
        {
            ProductServices = new ProductServices();
            var model = ProductServices.GetProductList();

            return View(model);
        }

        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product Product)
        {
            ProductServices = new ProductServices();

            ProductServices.InsertProduct(Product);

            return RedirectToAction("List");

        }

        public ActionResult EditProduct(int Id)
        {
            ProductServices = new ProductServices();

            var model = ProductServices.GetEditByID(Id);

            return View(model);
        }
        [HttpPost]
        public ActionResult EditProduct(Product Product)
        {
            ProductServices = new ProductServices();

            ProductServices.UpdateProduct(Product);
            return RedirectToAction("List");
        }

        public ActionResult DeleteProduct(int Id)
        {
            ProductServices = new ProductServices();

            ProductServices.DeleteProduct(Id);
            return RedirectToAction("List");
        }
    }
}