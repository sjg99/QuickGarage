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
        public List<product> products = new List<product>();
        public List<service> services = new List<service>();
        public DetailsLists()
        {
            orderpdetails = ordpd;
            ordersdetails = ordsd;
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
            }
        }
    }
}