using AutoMapper;
using Microsoft.AspNetCore.Http;
using ReadyGo.Domain.Entities;
using ReadyGo.Domain.Entities.ApiModels;
using ReadyGo.Domain.Entities.Identity;
using ReadyGo.Domain.Entities.ViewModels;
using System;
using System.Security.Claims;

namespace ReadyGo.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap().
                           ForMember(dest => dest.Address2, act => act.MapFrom(src => string.IsNullOrEmpty(src.Address2) ? string.Empty : src.Address2.Trim())).
                          ForMember(dest => dest.LastName, act => act.MapFrom(src => string.IsNullOrEmpty(src.LastName) ? string.Empty : src.LastName.Trim())).
                          ForMember(dest => dest.City, act => act.MapFrom(src => string.IsNullOrEmpty(src.City) ? string.Empty : src.City.Trim())).
                           ForMember(dest => dest.Province, act => act.MapFrom(src => string.IsNullOrEmpty(src.Province) ? string.Empty : src.Province.Trim())).
                          ForMember(dest => dest.Address1, act => act.MapFrom(src => src.Address1.Trim())).
                          ForMember(dest => dest.UserName, act => act.MapFrom(src => src.Email.Trim().ToLower())).
                          ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<InviteTableViewModel, ApplicationUser>().ReverseMap().
                         ForMember(dest => dest.UserRole, act => act.MapFrom(src => src.Role.NormalizedName)).
                         ForMember(dest => dest.LastName, act => act.MapFrom(src => string.IsNullOrEmpty(src.LastName) ? "---" : src.LastName)).
                         ForMember(dest => dest.FirstName, act => act.MapFrom(src => string.IsNullOrEmpty(src.FirstName) ? "---" : src.FirstName)).
                         ForMember(dest => dest.ProfileImage, act => act.MapFrom(src => src.ProfileImage != null ? "data:image;base64," + Convert.ToBase64String(src.ProfileImage.File) : "/resource_files/default_user.jpg")).
                         ForMember(dest => dest.TimeFlag, act => act.MapFrom(src => src.InviteTime != null ? src.InviteTime > DateTime.Now.AddHours(-24) && src.InviteTime <= DateTime.Now : false)).
                         ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UserTableViewModel, ApplicationUser>().ReverseMap().
                        ForMember(dest => dest.UserRole, act => act.MapFrom(src => src.Role.NormalizedName)).
                        ForMember(dest => dest.ProfileImage, act => act.MapFrom(src => src.ProfileImage != null ? "data:image;base64," + Convert.ToBase64String(src.ProfileImage.File) : "resource_files/default_user.jpg")).
                         ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<NotificationTableViewModel, UserNotification>().ReverseMap().
                        ForMember(dest => dest.ProfileImage, act => act.MapFrom(src => src.Notification.CreatedBy.ProfileImage != null ? "data:image;base64," + Convert.ToBase64String(src.Notification.CreatedBy.ProfileImage.File) : "resource_files/default_user.jpg")).
                        ForMember(dest => dest.CreatedBy, act => act.MapFrom(src => src.Notification.CreatedBy.FirstName + " " + src.Notification.CreatedBy.LastName)).
                        ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<AssignStock, AssignStockViewModel>().ReverseMap().
                          ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Category, CategoryViewModel>().ReverseMap().
                          ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Configuration, ConfigurationViewModel>().ReverseMap().
                          ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Customer, CustomerViewModel>().ReverseMap().ForMember(x => x.Id, opt => opt.Ignore()).ForMember(x => x.Balance, opt => opt.Ignore()).
                          ForMember(x => x.Route, opt => opt.Ignore()).
                          ForMember(dest => dest.Address2, act => act.MapFrom(src => string.IsNullOrEmpty(src.Address2) ? string.Empty : src.Address2.Trim())).
                          ForMember(dest => dest.LastName, act => act.MapFrom(src => string.IsNullOrEmpty(src.LastName) ? string.Empty : src.LastName.Trim())).
                          ForMember(dest => dest.City, act => act.MapFrom(src => string.IsNullOrEmpty(src.City) ? string.Empty : src.City.Trim())).
                          ForMember(dest => dest.BusinessName, act => act.MapFrom(src => src.BusinessName.Trim())).
                          ForMember(dest => dest.Province, act => act.MapFrom(src => string.IsNullOrEmpty(src.Province) ? string.Empty : src.Province.Trim())).
                          ForMember(dest => dest.Address1, act => act.MapFrom(src => src.Address1.Trim())).
                          ForMember(dest => dest.Longitude, act => act.MapFrom(src => src.Longitude ?? null)).
                          ForMember(dest => dest.Latitude, act => act.MapFrom(src => src.Latitude ?? null)).
                          ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<PaymentViewModel, Payment>().ReverseMap().
                ForMember(dest => dest.SpName, act => act.MapFrom(src => src.SalesPerson.FirstName + " " + src.SalesPerson.LastName));


            CreateMap<CustomerInfoViewModel, Customer>().ReverseMap().
                        ForMember(dest => dest.Address2, act => act.MapFrom(src => string.IsNullOrEmpty(src.Address2) ? string.Empty : src.Address2.Trim())).
                        ForMember(dest => dest.Name, act => act.MapFrom(src => src.FirstName + " " + src.LastName)).
                        ForMember(dest => dest.City, act => act.MapFrom(src => string.IsNullOrEmpty(src.City) ? string.Empty : src.City.Trim())).
                        ForMember(dest => dest.BusinessName, act => act.MapFrom(src => src.BusinessName.Trim())).
                        ForMember(dest => dest.Province, act => act.MapFrom(src => string.IsNullOrEmpty(src.Province) ? string.Empty : src.Province.Trim())).
                        ForMember(dest => dest.Address1, act => act.MapFrom(src => src.Address1.Trim())).
                        ForMember(dest => dest.Address2, act => act.MapFrom(src => src.Address2.Trim())).
                        ForMember(dest => dest.Image, act => act.MapFrom(src => src.ProfilePicture)).
                        ForMember(dest => dest.Longitude, act => act.MapFrom(src => src.Longitude ?? null)).
                        ForMember(dest => dest.Latitude, act => act.MapFrom(src => src.Latitude ?? null)).
                        ForMember(dest => dest.RouteName, act => act.MapFrom(src => src.Route != null ? src.Route.Name : string.Empty)).
                        ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CustomerViewModel, CustomerApiViewModel>().ReverseMap().ForMember(x => x.Id, opt => opt.Ignore()).
                          ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CustomerApiViewModel, Customer>().ReverseMap()
               .ForMember(dest => dest.CreatedAt, act => act.MapFrom(src => src.CreatedAt))
              .ForMember(dest => dest.Image, act => act.MapFrom(src => src.ProfilePicture != null ? "data:image; base64," + Convert.ToBase64String(src.ProfilePicture.File) : null)).ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<DeliveryReportViewModel, DeliveryReport>().ReverseMap()
               .ForMember(dest => dest.CreatedAt, act => act.MapFrom(src => src.CreatedAt.ToString("dd/MM/yyy HH:mm:ss")))
              .ForMember(dest => dest.VehicleNumber, act => act.MapFrom(src => src.VehicleId != null ? src.Vehicle.VehicleNumber : "---"))
              .ForMember(dest => dest.SalesPersonName, act => act.MapFrom(src => src.SalesPerson.FirstName + " " + src.SalesPerson.LastName))
              .ForMember(dest => dest.RouteName, act => act.MapFrom(src => src.RouteId != null ? src.Route.Name : "---"))
              .ForMember(dest => dest.ProfilePicture, act => act.MapFrom(src => src.SalesPerson.ProfileImage));

            CreateMap<AssignStock, AssignStockViewModel>().ReverseMap().
                          ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Discount, DiscountViewModel>().ReverseMap().
                          ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<OrderDetail, OrderDetailViewModel>().ReverseMap().
                          ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Order, OrderViewModel>().ReverseMap().
                          ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Product, ProductViewModel>().ReverseMap().
                          ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Promotion, PromotionViewModel>().ReverseMap().
                          ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ReturnOrder, ReturnOrderViewModel>().ReverseMap().
                          ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ResourceFile, ResourceFileViewModel>().ReverseMap().
                          ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Route, RouteApiViewModel>().ReverseMap();

            CreateMap<ApplicationUser, SetPasswordViewModel>().ReverseMap().ForMember(x => x.Id, opt => opt.Ignore()).
               ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<AssignStockViewModel, TransferStock>().ForMember(x => x.CreatedAt, opt => opt.Ignore())
                .ForMember(x => x.CreatedById, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<AssignStockApiViewModel, TransferStock>().ForMember(x => x.CreatedAt, opt => opt.Ignore())
                .ForMember(x => x.CreatedById, opt => opt.Ignore())
                .ForMember(x=>x.AssignStocks,opt=>opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<EmailSettings, EmailSettingsViewModel>().ReverseMap().
              ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Promotion, PromoTableViewModel>().ForMember(dest => dest.BaseProduct, act => act.MapFrom(src => src.BaseProduct.ProductId != null ?
                                     src.BaseProduct.VariantOf.Name + " - " + src.BaseProduct.Name
                                     : src.BaseProduct.Name)).
                          ForMember(dest => dest.BaseQuantity, act => act.MapFrom(src => src.BaseProductQuantity)).
                           ForMember(dest => dest.MaxQuantity, act => act.MapFrom(src => src.MaxPromoQuantity == null ? "-" :
                            src.MaxPromoQuantity.Value.ToString())).
                          ForMember(dest => dest.IsActive, act => act.MapFrom(src => src.StartDate <= DateTime.Now &&
                          src.EndDate >= DateTime.Now ? src.IsActive : false)).
                          ForMember(dest => dest.IsExpired, act => act.MapFrom(src => src.StartDate <= DateTime.Now &&
                          src.EndDate >= DateTime.Now ? false : true)).
                          ForMember(dest => dest.PromoProduct, act => act.MapFrom(src => src.PromoProduct.ProductId != null ?
                                    src.PromoProduct.VariantOf.Name + " - " + src.PromoProduct.Name
                                    : src.PromoProduct.Name)).
                          ForMember(dest => dest.PromoQuantity, act => act.MapFrom(src => src.PromoProductQuantity)).
                          ForMember(dest => dest.StartDate, act => act.MapFrom(src => src.StartDate.Date.ToString("dd/MM/yyyy"))).
                          ForMember(dest => dest.EndDate, act => act.MapFrom(src => src.EndDate.Date.ToString("dd/MM/yyyy"))).
                          ForMember(dest => dest.RouteName, act => act.MapFrom(src => src.Route != null ? src.Route.Name : string.Empty)).
                          ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            #region ApiModels
            CreateMap<ApplicationUser, UserApiViewModel>().
                       ForMember(dest => dest.Image, act => act.MapFrom(src => src.ProfileImage != null ? Convert.ToBase64String(src.ProfileImage.File) : null)).
                       ForMember(dest => dest.UserName, act => act.MapFrom(src => src.FirstName + " " + src.LastName)).
                       ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<PaymentApiViewModel, Payment>().ReverseMap();
            CreateMap<OrderPaymentApiViewModel, Payment>().ReverseMap();

            CreateMap<Discount, DiscountApiViewModel>()
                .ForMember(dest => dest.ProductID, act => act.MapFrom(src => src.ProductID == null ? null : src.ProductID))
                .ForMember(dest => dest.CustomerId, act => act.MapFrom(src => src.CustomerId == null ? null : src.CustomerId));

            CreateMap<CustomerApiViewModel, Customer>().ReverseMap().
              ForMember(dest => dest.Image, act => act.MapFrom(src => src.ProfilePicture != null ? Convert.ToBase64String(src.ProfilePicture.File) : null)).
              ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<PriceHistory, PriceHistoryViewModel>().ReverseMap();
            CreateMap<Product, ProductResposneModel>();

            CreateMap<Product, ProductWithImageResponseModel>()
                .ForMember(dest => dest.Image, act => act.MapFrom(src => src.Image != null ? Convert.ToBase64String(src.Image.File) : null));

            CreateMap<Category, CategoryResponseModel>();

            CreateMap<Vehicle, VehicleResponseModel>();


            CreateMap<AssignStock, StockResponseModel>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Product.Id))
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.Quantity, act => act.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.CategoryId, act => act.MapFrom(src => src.Product.CategoryId))
                .ForMember(dest => dest.Description, act => act.MapFrom(src => src.Product.Description))
                .ForMember(dest => dest.ProductId, act => act.MapFrom(src => src.Product.ProductId));

            CreateMap<Vehicle, VehicleViewModel>().ReverseMap();



            CreateMap<OrderDataModel, Order>()
                .ForMember(dest => dest.Orders, act => act.Ignore())
                .ForMember(dest => dest.ReturnOrders, act => act.Ignore())
                .ForMember(dest => dest.WasteOrders, act => act.Ignore())
                .ForMember(dest => dest.Payment, act => act.Ignore())
                .ForMember(dest => dest.PaymentId, act => act.Ignore());


            CreateMap<OrderDetail, OrderDetailsModel>();
            CreateMap<WasteOrders, WasteOrderModel>();
            CreateMap<ReturnOrder, ReturnOrderModel>();

            CreateMap<Order, OrderDataModel>()
                .ForMember(dest => dest.OrderDetails, act => act.MapFrom(src => src.Orders));


            //CreateMap<Order, OrderDataModel>();

            CreateMap<Promotion, PromotionApiViewModel>()
                .ForMember(dest => dest.RouteId, act => act.MapFrom(src => src.RouteId == null ? null : src.RouteId))
                .ForMember(dest => dest.CustomerId, act => act.MapFrom(src => src.CustomerId == null ? null : src.CustomerId));

            CreateMap<DeliveryReportApiViewModel, DeliveryReport>();

            #endregion

        }
    }
}