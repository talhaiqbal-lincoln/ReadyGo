using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities;
using System.Collections.Generic;

namespace ReadyGo.Persistence.Seeds
{
    public static class DefaultConfig
    {
        public static List<Configuration> DefaultConfiguration()
        {
            return new List<Configuration>()
            {
                new Configuration
                {
                    Id=AppConstants.SM_CustomerManagement,
                    ConfigKey="Sales Manager_Customer",
                    Value="1"
                },
                new Configuration
                {
                    Id=AppConstants.SM_SalesPersonManagement,
                    ConfigKey="Sales Manager_SalesPerson",
                    Value="1"
                },
                new Configuration
                {
                    Id=AppConstants.SM_StockManagement,
                    ConfigKey="Sales Manager_Stock",
                    Value="1"
                },
                new Configuration
                {
                    Id=AppConstants.MM_CustomerManagement,
                    ConfigKey="Marketing Manager_Customer",
                    Value="1"
                },
                new Configuration
                {
                    Id=AppConstants.MM_SalesPersonManagement,
                    ConfigKey="Marketing Manager_SalesPerson",
                    Value="1"
                },
                new Configuration
                {
                    Id=AppConstants.MM_StockManagement,
                    ConfigKey="Marketing Manager_Stock",
                    Value="1"
                },
                new Configuration
                {
                    Id=AppConstants.MM_DiscountThrashHold,
                    ConfigKey="SalesManager_DiscountThrashHold",
                    Value="5"
                },
                new Configuration
                {
                    Id=AppConstants.SM_DiscountThrashHold,
                    ConfigKey="MarketingManager_DiscountThrashHold",
                    Value="10"
                },
                new Configuration
                {
                    Id=AppConstants.TermsConditions,
                    ConfigKey="TermsConditions",
                    Value="All Rights Reserved. LightHouse! Privacy and Terms",
                }
            };
        }
    }
}
