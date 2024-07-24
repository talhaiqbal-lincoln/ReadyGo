using System;
using System.Collections.Generic;
using System.Text;

namespace ReadyGo.Domain.Entities.ViewModels
{
    public class DashboardViewModel
    {
        public double Sales { get; set; }
        public double SalesPercentage { get; set; }
        public double Waste { get; set; }
        public double WastePercentage { get; set; }
        public double Return { get; set; }
        public double ReturnPercentage { get; set; }
        public double Balance { get; set; }
        public double BalancePercentage { get; set; }
        public int SMOrders { get; set; }
        public int SMApprovedOrders { get; set; }
        public int SMReAdjustOrders { get; set; }
        public int MMOrders { get; set; }
        public int MMApprovedOrders { get; set; }
        public int MMReAdjustOrders { get; set; }
        public IEnumerable<SalesPerson> SalesPersons { get; set; }
    }
    public class SalesPerson
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class SpDashboardTable
    {
        public string Name { get; set; }
        public string ProfileImage { get; set; }
        public double Sales { get; set; }
        public double Waste { get; set; }
        public double Discount { get; set; }
    }
}
