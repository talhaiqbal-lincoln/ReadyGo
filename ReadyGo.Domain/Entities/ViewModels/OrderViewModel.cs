using ReadyGo.Domain.Entities.Identity;
using ReadyGo.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReadyGo.Domain.Entities.ViewModels
{
    public class OrderViewModel : BaseEntity
    {
        [Required]
        public string SalesPersonId { get; set; }
        [Required]
        public string CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ApplicationUser SalesPerson { get; set; }
    }
    public class OrdersTableViewModel : BaseEntity
    {
        public double TotalDiscount { get; set; }
        public string CustomerName { get; set; }
        public string SalesPersonName { get; set; }
        public double Total { get; set; }
        public double Gross { get; set; }
        public double Waste { get; set; }
        public double Return { get; set; }
        public double Credit { get; set; }
        public double InvoiceDiscount { get; set; }
        public double TotalDiscountPercentage { get; set; }
        public double InvoiceDiscountPercentage { get; set; }
        public string Status { get; set; }
        public string OrderCode { get; set; }
        public double Payment { get; set; }
        public string RouteName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    public class OrderDetailsViewModel : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public double ProductsDiscount { get; set; }
        public double InvoiceDiscount { get; set; }
        public double TotalDiscountPercentage { get; set; }
        public double InvoiceDiscountPercentage { get; set; }
        public double TotalDiscount { get; set; }
        public double TotalTax { get; set; }
        public double TotalReturnTax { get; set; }
        public double Payment { get; set; }
        public string OrderCode { get; set; }
        public string DriverName { get; set; }
        public string VehicleNo { get; set; }
        public string CustomerCode { get; set; }
        public string BusinessName { get; set; }
        public string Address { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public string SalesPersonId { get; set; }
        public double Total { get; set; }
        public double Gross { get; set; }
        public double Waste { get; set; }
        public double Return { get; set; }
        public double Credit { get; set; }
        public bool IsMarked { get; set; }
        public DateTime CreatedAt { get; set; }
        public string RouteName { get; set; }
        public string SalesPersonName { get; set; }
        public ApprovalStatus Status { get; set; }
        public ApprovalFor ApprovalFor { get; set; }
        public List<OrderDetailsTableViewModel> Details { get; set; }

    }
    public class OrderDetailsTableViewModel
    {
        public string ProductCode { get; set; }
        public string Reason { get; set; }
        public double Tax { get; set; }
        public string ProductName { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Waste { get; set; }
        public string Promos { get; set; }
        public double Gross { get; set; }
        public double Discount { get; set; }
        public bool IsWaste { get; set; } = false;
    }
}
