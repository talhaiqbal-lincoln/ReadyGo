using System;
using System.Collections.Generic;
using System.Text;

namespace ReadyGo.Domain.Entities.ViewModels
{
    public class DeliveryReportViewModel
    {
        public Guid Id { get; set; }
        public bool IsMarked { get; set; }
        public DateTime CreatedAt { get; set; }
        public string VehicleNumber { get; set; }
        public string RouteName { get; set; }
        public ResourceFile ProfilePicture { get; set; }
        public string SalesPersonName { get; set; }
        public double Total { get; set; }
        public double TotalDiscount { get; set; }
        public double TotalReturn { get; set; }
        public double TotalGross { get; set; }
        public double TotalCash { get; set; }
        public double TotalBalance { get; set; }
        public double Unsold { get; set; }
        public double Dispatch { get; set; }
        public string DriverName { get; set; }
        public double CashShort { get; set; }
        public List<OrderProducts> OrderProducts { get; set; }
        public List<Orders> Orders { get; set; }
        public List<Payments> Payments { get; set; }
    }
    public class Orders
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public double Gross { get; set; }
        public double Discount { get; set; }
        public double Return { get; set; }
        public double Total { get; set; }
        public string BusinessName { get; set; }
        public string CustomerCode { get; set; }
    }
    public class OrderProducts
    {
        public float Assigned { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public float Quantity { get; set; }
        public float WasteQuantity { get; set; }
        public float ReturnQuantity { get; set; }
        public double Price { get; set; }
        public double Gross { get; set; }
        public string ProductCode { get; set; }
    }
    public class Payments
    {
        public Guid PaymentId { get; set; }
        public string PaymentCode { get; set; }
        public string BusinessName { get; set; }
        public string CustomerCode { get; set; }
        public double Payment { get; set; }
    }
}
