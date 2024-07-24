using ReadyGo.Domain.Entities.ViewModels;
using System;
using System.Collections.Generic;

namespace ReadyGo.Domain.Entities.ApiModels
{
    public class CategoryResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public  List<ProductWithImageResponseModel> Products { get; set; }
    }

    public class ProductResposneModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Guid? ProductId { get; set; }
        public string AxCode { get; set; }

    }

    public class ProductWithImageResponseModel : ProductResposneModel
    {
        public string Image { get; set; }
        public List<PriceHistoryViewModel> Prices { get; set; }
        public List<DiscountApiViewModel> Discounts { get; set; }
    }

    public class StockResponseModel : ProductResposneModel
    {
        public float Quantity { get; set; }   
    }

    public class VehicleResponseModel
    {
        public Guid? Id { get; set; }
        public string AXCode { get; set; }
        public string VehicleNumber { get; set; }
        public string DriverName { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
    }

}
