using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuickWorkshop.Models;

namespace QuickWorkshop.ViewModels
{
    public class ManagementLoading
    {        
        public List<product> products = new List<product>();
        public List<service> services = new List<service>();
        public List<user> users = new List<user>();
        public List<order> orders = new List<order>();

        public ManagementLoading()
        {
            using (QWDBEntities db = new QWDBEntities())
            {
                var GetProducts = db.products.Where(x => x.ProductId > 0);
                var GetServices = db.services.Where(x => x.ServiceID > 0);
                var GetUsers = db.users.Where(x => x.Status == "Activo");
                var GetOrders = db.orders.Where(x => x.OrderId > 0);
                foreach (var r in GetProducts)
                {
                    products.Add(r);
                }
                foreach (var r in GetServices)
                {
                    services.Add(r);
                }
                foreach(var r in GetUsers)
                {
                    users.Add(r);
                }
                foreach(var r in GetOrders)
                {
                    orders.Add(r);
                }
            }
        }
    }
}