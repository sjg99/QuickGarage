using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
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
        private OrdersLoading ordersLoading()
        {
            OrdersLoading ol = new OrdersLoading();
            return ol;
        }
        private DetailsLists detailsLists()
        {
            DetailsLists dl = new DetailsLists();
            return dl;
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
            return View("IndexUsr", managementLoading());
        }
        public ActionResult GetOrders()
        {
            return View("IndexOrd", managementLoading());
        }
        public ActionResult GetAddOrd()
        {
            OrdersLoading.ord = new order();
            DetailsLists.ordpd.Clear();
            DetailsLists.ordsd.Clear();
            return View("OrdAdd", ordersLoading());
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
                    return RedirectToAction("GetProducts", "Management");
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
        [HttpPost]
        public ActionResult AddSer(service servicemodel)
        {

            using (QWDBEntities db = new QWDBEntities())
            {
                try
                {
                    int ids;
                    service LastService;
                    try
                    {
                        LastService = db.services.Where(x => x.ServiceID > 0).OrderByDescending(x => x.ServiceID).First();
                        ids = LastService.ServiceID + 1;
                    }
                    catch
                    {
                        ids = 1;
                    }
                    var ServiceCreation = db.Set<service>();
                    ServiceCreation.Add(new service { ServiceID = ids, Name = servicemodel.Name, Price = servicemodel.Price});
                    db.SaveChanges();
                    return RedirectToAction("GetServices", "Management");
                }
                catch (Exception ex)
                {
                    servicemodel.AddSError = "Couldn't create new Service" + ex;
                    return PartialView("_SerAdd", servicemodel);
                }
            }
        }
        public ActionResult EditSer(service servicemodel)
        {
            return PartialView("_SerEdit", servicemodel);
        }
        [HttpPost]
        public ActionResult UpdateSer(service servicemodel)
        {
            using (QWDBEntities db = new QWDBEntities())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(servicemodel).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("GetServices");
                }
                else
                {
                    servicemodel.AddSError = "Couldn't edit Service";
                    return PartialView("_SerEdit", servicemodel);
                }
            }
        }
        [HttpPost]
        public ActionResult AddUsr(user usermodel)
        {

            using (QWDBEntities db = new QWDBEntities())
            {
                try
                {
                    var UserCreation = db.Set<user>();
                    UserCreation.Add(new user { UserID = usermodel.UserID, Email = usermodel.Email, Password = usermodel.Password, Name = usermodel.Name, Position = usermodel.Position, Status = "Activo" });
                    db.SaveChanges();
                    return RedirectToAction("GetUsers", "Management");
                }
                catch (Exception ex)
                {
                    usermodel.AddUError = "Couldn't create new User" + ex;
                    return PartialView("_UsrAdd", usermodel);
                }
            }
        }
        public ActionResult EditUsr(user usermodel)
        {
            return PartialView("_UsrEdit", usermodel);
        }
        [HttpPost]
        public ActionResult UpdateUsr(user usermodel)
        {
            using (QWDBEntities db = new QWDBEntities())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(usermodel).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("GetUsers");
                }
                else
                {
                    usermodel.AddUError = "Couldn't edit User";
                    return PartialView("_UsrEdit", usermodel);
                }
            }
        }
        public ActionResult AddPDet (orderpdetail orderpdetailmodel, int id)
        {
            orderpdetailmodel.OrderId = id;
            using (QWDBEntities db = new QWDBEntities())
            {
                var GetProductPrice = db.products.Find(orderpdetailmodel.Productid).Price;
                orderpdetailmodel.Price = GetProductPrice * orderpdetailmodel.Quantity;
            }
            DetailsLists.ordpd.Add(orderpdetailmodel);
            return PartialView("_AddedDet", detailsLists());
        }
        public ActionResult AddSDet(ordersdetail ordersdetailmodel, int id)
        {
            ordersdetailmodel.OrderId = id;
            using (QWDBEntities db = new QWDBEntities())
            {
                var GetServicePrice = db.services.Find(ordersdetailmodel.ServiceId).Price;
                ordersdetailmodel.Price = GetServicePrice;
            }
            DetailsLists.ordsd.Add(ordersdetailmodel);
            return PartialView("_AddedDet", detailsLists());
        }
        public ActionResult AddCustomerId (order ordermodel)
        {
            OrdersLoading.ord.CustomerId = ordermodel.CustomerId;           
            return PartialView("_AddedDet", detailsLists());
        }
        public ActionResult AddOrd()
        {
            using (QWDBEntities db = new QWDBEntities())
            {
                try{
                    int uid = (int)Session["id"];
                    var OrderCreation = db.Set<order>();
                    OrderCreation.Add(new order { CustomerId = OrdersLoading.ord.CustomerId, Date = OrdersLoading.ord.Date, ProductQ = OrdersLoading.ord.ProductQ, ServiceQ = OrdersLoading.ord.ServiceQ, Status = OrdersLoading.ord.Status, TotalPrice = OrdersLoading.ord.TotalPrice, UserId = uid });
                    db.SaveChanges();
                    foreach (var p in DetailsLists.ordpd)
                    {
                        db.Database.ExecuteSqlCommand("INSERT INTO orderpdetails VALUES ("+p.OrderId+","+p.Productid+","+p.Quantity+","+p.Price+")");                      
                        db.SaveChanges();
                    }
                    foreach (var s in DetailsLists.ordsd)
                    {
                        db.Database.ExecuteSqlCommand("INSERT INTO ordersdetails VALUES (" + s.OrderId + "," + s.ServiceId + "," + s.Price + ")");
                        db.SaveChanges();
                    }
                    return RedirectToAction("GetOrders");
                }
                catch 
                {
                    return new EmptyResult();
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