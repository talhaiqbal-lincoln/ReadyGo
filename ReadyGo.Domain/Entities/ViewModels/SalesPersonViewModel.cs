using System;
using System.Collections.Generic;
using System.Text;

namespace ReadyGo.Domain.Entities.ViewModels
{
    public class SalesPersonViewModel
    {

    }
    public class SpCustomers
    {
        public string Name { get; set; }
        public string Orders { get; set; }
        public string OrderLatitude { get; set; }
        public string OrderLongitude { get; set; }
        public string CustomerLongitude { get; set; }
        public string CustomerLatitude { get; set; }
        public DateTime Time { get; set; }
    }
    public class SpDetailsPageModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public List<OrderInfo> Orders { get; set; }
        public List<CustomerInfo> Customers { get; set; }
    
    }
    public class OrderInfo
    {
        public string Address1 { get; set; }
        public string FullName { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
    public class CustomerInfo
    {
        public string Address1 { get; set; }
        public string FullName { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
