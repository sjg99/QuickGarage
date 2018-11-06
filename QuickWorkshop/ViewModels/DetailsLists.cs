using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuickWorkshop.Models;

namespace QuickWorkshop.ViewModels
{
    public class DetailsLists
    {
        public static List<orderpdetail> ordpd = new List<orderpdetail>();
        public static List<ordersdetail> ordsd = new List<ordersdetail>();
        public List<orderpdetail> orderpdetails = new List<orderpdetail>();
        public List<ordersdetail> ordersdetails = new List<ordersdetail>();
        public order order = new order();
        public List<product> products = new List<product>();
        public List<service> services = new List<service>();
        public List<product> productsopt = new List<product>();
        public List<service> servicesopt = new List<service>();
        public DetailsLists()
        {
            int acup = 0, acus = 0;
            double prip=0, pris=0;
            orderpdetails = ordpd;
            ordersdetails = ordsd;
            foreach(var p in orderpdetails)
            {
                acup += p.Quantity;
                prip += p.Price;
            }
            foreach (var s in ordersdetails)
            {
                acus++;
                pris += s.Price;
            }
            OrdersLoading.ord.ProductQ = acup;
            OrdersLoading.ord.ServiceQ = acus;
            OrdersLoading.ord.TotalPrice = prip + pris;
            order = OrdersLoading.ord;
            using (QWDBEntities db = new QWDBEntities())
            {
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
                var GetProducts = db.products.Where(x => x.ProductId > 0);
                var GetServices = db.services.Where(x => x.ServiceID > 0);
                foreach (var r in GetProducts)
                {
                    productsopt.Add(r);
                }
                foreach (var r in GetServices)
                {
                    servicesopt.Add(r);
                }
            }
        }
    }
}