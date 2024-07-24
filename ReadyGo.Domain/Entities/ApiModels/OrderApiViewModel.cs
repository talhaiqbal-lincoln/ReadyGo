using Newtonsoft.Json;
using ReadyGo.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReadyGo.Domain.Entities.ApiModels
{
    public class OrderDataModel
    {
        public Guid? Id { get; set; }
        public string SalesPersonId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
        public float Discount { get; set; } = 0;
        public bool IsMarked { get; set; }
        public Guid? VehicleId { get; set; }
        public float BalanceUsed { get; set; } = 0;
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string OrderCode { get; set; }
        public double Total { get; set; }
        public Guid? PaymentId { get; set; }
        public EmptyOrderReasonEnum? Reason { get; set; } = null;
        public string Remarks { get; set; }
        public string DeviceName { get; set; }
        public string DriverName { get; set; }
        public ApprovalStatus Status { get; set; }
        public List<OrderDetailsModel> OrderDetails { get; set; }
        public List<ReturnOrderModel> ReturnOrders { get; set; }
        public List<WasteOrderModel> WasteOrders { get; set; }
        public OrderPaymentApiViewModel? Payment { get; set; }
    }

    public class OrderTypeBaseModel
    {
        public Guid? Id { get; set; }
        public float Quantity { get; set; }
        public Guid? OrderId { get; set; }
        public Guid ProductId { get; set; }
        public double Price { get; set; }
    }

    //Use To store data of newly created order
    public class OrderDetailsModel : OrderTypeBaseModel
    {
        public float Discount { get; set; }
        public Guid? PromotionId { get; set; }
    }

    //Use To store data of Returned order
    public class ReturnOrderModel : OrderTypeBaseModel
    {
        public ReturnOrderReasonEnum? Reason { get; set; }
        public string ReturnReason { get; set; }
        public float Discount { get; set; }
    }

    //Use To store data of wasted order
    public class WasteOrderModel : OrderTypeBaseModel
    {
        public ReturnOrderReasonEnum? Reason { get; set; }
        public string WasteReason { get; set; }
        public double Discount { get; set; }
    }
}
