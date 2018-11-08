using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuickWorkshop.Models;

namespace QuickWorkshop.ViewModels
{
    public class OrdersLoading
    {
        public static order ord = new order();
        public order order = new order();
        public orderpdetail orderpdetail = new orderpdetail();
        public ordersdetail ordersdetail = new ordersdetail();
        public List<product> products = new List<product>();
        public List<service> services = new List<service>();

        public OrdersLoading()
        {
            using (QWDBEntities db = new QWDBEntities())
            {

                var GetOrder = db.orders.OrderByDescending(x => x.OrderId).First();
                ord.OrderId = GetOrder.OrderId+1;
                               
                
                DateTime dt = DateTime.UtcNow.AddHours(-5);               
                ord.Date = dt.ToString();
                ord.Status = "Por Iniciar";
                ord.ProductQ = 0;
                ord.ServiceQ = 0;
                ord.TotalPrice = 0;
                order = ord;
                var GetProducts = db.products.Where(x => x.ProductId > 0);
                var GetServices = db.services.Where(x => x.ServiceID > 0);
                foreach (var r in GetProducts)
                {
                    products.Add(r);
                }
                foreach (var r in GetServices)
                {
                    services.Add(r);
                }

            }
        }
    }
}