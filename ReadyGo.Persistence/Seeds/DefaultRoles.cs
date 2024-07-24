using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities.Identity;
using ReadyGo.Domain.Enum;
using System.Collections.Generic;
using System;
using System.ComponentModel;

namespace ReadyGo.Persistence.Seeds
{
    public static class DefaultRoles
    {
        public static List<ApplicationRole> IdentityRoleList()
        {
            return new List<ApplicationRole>()
            {
                new ApplicationRole
                {
                    Id = AppConstants.Admin,
                    Name = Roles.Admin.GetDescription(),
                    NormalizedName = Roles.Admin.GetDescription()
                },
                new ApplicationRole
                {
                    Id = AppConstants.MarketingManager,
                    Name = Roles.MarketingManager.GetDescription(),
                    NormalizedName = Roles.MarketingManager.GetDescription()
                },
                new ApplicationRole
                {
                    Id = AppConstants.SalesManager,
                    Name = Roles.SalesManager.GetDescription(),
                    NormalizedName = Roles.SalesManager.GetDescription()
                },
                new ApplicationRole
                {
                    Id = AppConstants.SalePerson,
                    Name = Roles.SalesPerson.GetDescription(),
                    NormalizedName = Roles.SalesPerson.GetDescription()
                }
            };
        }
    }

    public static class EnumExtension
    {
        public static string GetDescription(this Enum enumValue)
        {
            //Look for DescriptionAttributes on the enum field
            object[] attr = enumValue.GetType().GetField(enumValue.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attr.Length > 0) // a DescriptionAttribute exists; use it
                return ((DescriptionAttribute)attr[0]).Description;

            //The above code is all you need if you always use DescriptionAttributes;

            return enumValue.ToString();
        }
    }
}
