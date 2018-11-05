using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuickWorkshop.Models;

namespace QuickWorkshop.ViewModels
{
    public class OrdersLoading
    {
        public order order = new order();
        public orderpdetail orderpdetail = new orderpdetail();
        public ordersdetail ordersdetail = new ordersdetail();
        public List<product> products = new List<product>();
        public List<service> services = new List<service>();

        public OrdersLoading()
        {
            using (QWDBEntities db = new QWDBEntities())
            {
                try
                {
                    var GetOrder = db.orders.Where(x => x.OrderId > 0).Last();
                    order.OrderId = GetOrder.OrderId + 1;

                }                
                catch
                {
                    order.OrderId = 1;
                }                
                order.Date = DateTime.Now.ToString();
                order.Status = "Por Iniciar";
                order.ProductQ = 0;
                order.ServiceQ = 0;
                order.TotalPrice = 0;
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