using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ReadyGo.Domain.Enum
{
    public enum ApiStatus
    {
        Success,
        Error
    }

    public enum ApiErrors
    {
        [Description("Unauthorized access")]
        Unauthorized,

        [Description("Model state is not valid")]
        ModelState,

        [Description("not found")]
        NotFound,

        [Description("Something went wrong")]
        DefaultError,

        [Description("User is either inactive or deleted")]
        InActive,

        [Description("Only sales person are allowed to login")]
        InValidRole,

        [Description("The Provided credentials are not correct")]
        WrongEmailPass,

        [Description("Already exists")]
        AreadyExists,

        [Description("Old Password is incorrect")]
        IncorrectOldPassword
    }

    public enum EmptyOrderReasonEnum
    {
        [Description("Sufficient stock available.")]
        StockAvailable,

        [Description("Cash Problem.")]
        CashProblem,

        [Description("Purchaser not available.")]
        PurchaserNotAvailable,

        [Description("Shop Closed.")]
        ShopClosed
    }
    public enum ReturnOrderReasonEnum
    {
        [Description("Item has been Expired")]
        [Display(Name = "Item has been Expired")]
        ExpiredItem,

        [Description("Item has been found Damaged")]
        [Display(Name = "Item has been found Damaged")]
        DamagedItem,

        [Description("Stale Item was delivered")]
        [Display(Name = "Stale Item was delivered")]
        StaleItem,

        [Description("Wrong Item was delivered")]
        [Display(Name = "Wrong Item was delivered")]
        WrongItem,

        [Description("Packaging for the item has been updated")]
        [Display(Name = "Packaging for the item has been updated")]
        PackagingUpdated,

        [Description("Other, Please Specify")]
        [Display(Name = "Other, Please Specify")]
        Other

    }

}