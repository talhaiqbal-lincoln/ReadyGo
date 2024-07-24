using System;
using System.Collections.Generic;
using System.Text;

namespace ReadyGo.Domain.Entities.ViewModels
{
    public class EditOrderViewModel
    {
        public string Total { get; set; }
        public string CustomerBalance { get; set; }
        public string OrderId { get; set; }
        public string Discount { get; set; }
        public string DiscountPercent { get; set; }
        public List<OrderList> Orders { get; set;}
        public List<OrderList> ReturnOrders { get; set;}
        public List<OrderList> WasteOrders { get; set; }
    }
    public class OrderList
    {
        public string ProductId { get; set; }
        public string Quantity { get; set; }
        public string ReturnReason { get; set; }
        public string PromoId { get; set; }
        public string Price { get; set; }
        public string Discount { get; set; }
    }
}
