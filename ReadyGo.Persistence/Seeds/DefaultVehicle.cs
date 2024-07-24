using ReadyGo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadyGo.Persistence.Seeds
{
    public class DefaultVehicle
    {
        public static List<Vehicle> VehicleList()
        {
            var vehicles = new List<Vehicle>();
            for (int i = 0; i < 3; i++)
            {
                vehicles.Add(
                    new Vehicle
                    {
                        Id = new Guid("c7be1d28-2b81-42e9-90e9-5396492a90e" + i),
                        AXCode = "AX-Code" + i,
                        Model = "Model" + i,
                        VehicleNumber = "LHR-000" + i,
                        Type = "Type" + i,
                        DriverName = "Driver" + i
                    });
            }
            return vehicles;
        }
    }
}
