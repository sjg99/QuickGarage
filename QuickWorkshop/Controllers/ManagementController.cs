using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuickWorkshop.Models;
using QuickWorkshop.ViewModels;

namespace QuickWorkshop.Controllers
{
    public class ManagementController : Controller
    {
        // GET: Management
        private ManagementLoading managementLoading()
        {
            ManagementLoading ml = new ManagementLoading();
            return ml;
        }
        public ActionResult Index()
        {
            return View(managementLoading());
        }
        public ActionResult GetProducts()
        {
            return View("Index", managementLoading());
        }
        public ActionResult GetServices()
        {
            return View("IndexSer", managementLoading());
        }
        public ActionResult GetUsers()
        {
            return View("IndexUs", managementLoading());
        }
        public ActionResult GetOrders()
        {
            return View("IndexOrd", managementLoading());
        }
        [HttpPost]
        public ActionResult AddPro(product productmodel)
        {
            
            using (QWDBEntities db = new QWDBEntities())
            {
                try
                {
                    int idp;
                    product LastProduct;
                    try
                    {
                        LastProduct = db.products.Where(x => x.ProductId > 0).OrderByDescending(x => x.ProductId).First();
                        idp = LastProduct.ProductId + 1;
                    }
                    catch
                    {
                        idp = 1;
                    }
                    var ProductCreation = db.Set<product>();
                    ProductCreation.Add(new product { ProductId = idp, Name = productmodel.Name, Price = productmodel.Price, Quantity = productmodel.Quantity });
                    db.SaveChanges();
                    return RedirectToAction("Index", "Management");
                }
                catch (Exception ex)
                {
                    productmodel.AddPError = "Couldn't create new Product" + ex;
                    return PartialView("_ProAdd", productmodel);
                }
            }
        }
        public ActionResult EditPro(product productmodel)
        {
            return PartialView("_ProEdit", productmodel);
        }
        [HttpPost]
        public ActionResult UpdatePro(product productmodel)
        {           
            using (QWDBEntities db = new QWDBEntities())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(productmodel).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("GetProducts");
                }
                else
                {
                    productmodel.AddPError = "Couldn't edit Product";
                    return PartialView("_ProEdit", productmodel);
                }
            }
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}