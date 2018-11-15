using QuickWorkshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickWorkshop.ViewModels
{
    public class ViewOrderLoading
    {
        public List<orderpdetail> orderpdetails = new List<orderpdetail>();
        public List<ordersdetail> ordersdetails = new List<ordersdetail>();
        public order order = new order();
        public List<product> products = new List<product>();
        public List<service> services = new List<service>();
        public ViewOrderLoading(int id)
        {
            using (QWDBEntities db = new QWDBEntities())
            {
                order = db.orders.Find(id);
                var GetOrderpDetails = db.orderpdetails.Where(x => x.OrderId == id);
                var GetOrdersDetails = db.ordersdetails.Where(x => x.OrderId == id);
                foreach (var p in GetOrderpDetails)
                {
                    orderpdetails.Add(p);
                }
                foreach (var s in GetOrdersDetails)
                {
                    ordersdetails.Add(s);
                }
                foreach (var p in orderpdetails)
                {
                    var GetProduct = db.products.Find(p.Productid);
                    products.Add(GetProduct);
                }
                foreach (var s in ordersdetails)
                {
                    var GetService = db.services.Find(s.ServiceId);
                    services.Add(GetService);
                }
            }
        }
    }
}