using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ReadyGo.Domain.Enum
{
    public enum Roles
    {
        [Description("Sales Person")]
        [Display(Name = "Sales Person")]
        SalesPerson,
        [Description("Sales Manager")]
        [Display(Name = "Sales Manager")]
        SalesManager,
        [Description("Marketing Manager")]
        [Display(Name = "Marketing Manager")]
        MarketingManager,
        [Description("Admin")]
        [Display(Name = "Admin")]
        Admin,
    }
    public enum LogActions
    {
        [Description("Import: ")]
        Import,
        [Description("Get: ")]
        Get,
        [Description("Delete: ")]
        Delete,
        [Description("Delete order no: ")]
        DeleteOrder,
        [Description("Add: ")]
        Add,
        [Description("Update: ")]
        Update,
        [Description("Update order no: ")]
        UpdateOrder,
        [Description("Change status of ")]
        ChangeStatus,
        [Description("Re-Activate: ")]
        ReActivate,
        [Description("Send invite to ")]
        SendInvite,
        [Description("Mail configuration changed")]
        ConfigurationChanged,
        [Description("Stock assigned to ")]
        StockAssigned,
        [Description("Stock edited for ")]
        StockEdited,
        [Description("Delete payment no: ")]
        DeletePayment,
        [Description("Discount automatically approved for")]
        DiscountApprovedAuto,
        [Description("Discount approved by")]
        DiscountApprovedBy,
        [Description("Discount re-adjusted by")]
        DiscountReAdjustBy,
        [Description("Discount applied to ")]
        DiscountApplied,
        [Description("Update discount id:")]
        DiscountUpdated,
        [Description("Discount id: ")]
        DiscountStatus,
        [Description("Discount deleted id: ")]
        DiscountDeleted,

    }
    public enum LogsActionSrc
    {
        GenericRepo,
        UserManagement,
        CustomerManagement,
        StockManagement,
        DiscountManagement,
        MailSettings,
        SPManagement,
        PromoManagement
    }
    public enum NotficationEnums
    {
        SalesPerson,
        SalesManager,
        MarketingManager,
        DiscountedOrder,
        SalesPersonRoute,
        CustomerAdded
    }
    public enum ApprovalStatus
    {
        Approved,
        Pending,
        ReAdjusted
    }
    public enum ApprovalFor
    {
        MarketingManager,
        SalesManager,
        NotRequired
    }

}
