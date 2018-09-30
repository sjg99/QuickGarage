using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            return View();
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


    }
}