using Microsoft.AspNetCore.Mvc;
using ReadyGo.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReadyGo.Domain.Entities.ViewModels
{
    public class AssignRouteViewModel
    {
        public string SalesPersonId { get; set; }
        public string SPName { get; set; }
        public Guid? RouteId { get; set; }

        [Remote("CheckDate", "SalesPerson", AdditionalFields = "TemporaryAssignedTill", HttpMethod = "POST", ErrorMessage = "Select a time period for this route")]
        public Guid? TempRouteId { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Not a valid date")]
        [Remote("CorrectDate", "SalesPerson", HttpMethod = "POST", ErrorMessage = ValidationErrorConstants.WrongDateError)]
        public DateTime? TemporaryAssignedTill { get; set; }

        public bool IsActive { get; set; }
        public List<Customer> Customers { get; set; }
    }

    public class AssignedTableViewModel
    {
        public string SalesPersonId { get; set; }
        public string SalesPersonName { get; set; }
        public string RouteName { get; set; }
        public string TempRouteName { get; set; }
        public DateTime? TempRouteTime { get; set; }
        public int CustomersCount { get; set; }
        public bool? IsActive { get; set; }
        public string RouteTempSp { get; set; }
        public string Email { get; set; }
        public string EmployeeCode { get; set; }
        public bool IsActiveRoute { get; set; } = false;
        public string Image { get; set; }
    }
}