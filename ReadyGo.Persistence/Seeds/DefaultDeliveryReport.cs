using ReadyGo.Domain.Entities;
using System;

namespace ReadyGo.Persistence.Seeds
{
    public class DefaultDeliveryReport
    {
        public static DeliveryReport Delievery()
        {
            return new DeliveryReport()
            {
                Id = new Guid("713796e0-b93c-4f50-b7a0-99f690a51638"),
                SalesPersonId = "0daec62b-312f-4016-9c5e-a15354259c90",
                RouteId = new Guid("0DAEC62B-312F-4016-9C5E-A15354259C92"),
                VehicleId = new Guid("C7BE1D28-2B81-42E9-90E9-5396492A90E0"),
                DriverName = "Paul Walker",
                CreatedAt = new DateTime(2021,12,29)
            };
        }
    }
}
