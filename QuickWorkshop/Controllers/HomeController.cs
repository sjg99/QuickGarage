using QuickWorkshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickWorkshop.Controllers
{
    public class HomeController : Controller
    {   
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(user usermodel)
        {
            using(QWDBEntities db = new QWDBEntities())
            {
                var UserConfirmation = db.users.Where(x => x.Email == usermodel.Email && x.Password == usermodel.Password).FirstOrDefault();
                if (UserConfirmation == null)
                {
                    usermodel.LoginError = "Email o Contraseña Incorrectos";
                    usermodel.Password = null;                    
                    return View("IndexW", usermodel);
                }
                else
                {
                    Session["id"] = UserConfirmation.UserID;
                    Session["email"] = UserConfirmation.Email;
                    Session["name"] = UserConfirmation.Name;
                    Session["position"] = UserConfirmation.Position;
                    if (UserConfirmation.Position == "Administrador")
                    {
                        return RedirectToAction("Index", "Management");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Employee");
                    }
                }
            }
        }
    }
}