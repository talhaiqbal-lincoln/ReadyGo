using ReadyGo.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ReadyGo.Persistence.Seeds
{
    public class DefaultRoutes
    {
        public static List<Route> ClientRoutesList()
        {
            var routes = new List<Route>
            {
                new Route { Name = "RaiwndRoad", Id = new Guid("B3A64FC0-F699-49E5-9198-A7D7F7074270") },
                new Route { Name = "Sanda", Id = new Guid("B3A64FC0-F699-49E5-9198-A7D7F7074271") },
                new Route { Name = "Fateh Garh", Id = new Guid("B3A64FC0-F699-49E5-9198-A7D7F7074272") },
                new Route { Name = "Nishtar", Id = new Guid("B3A64FC0-F699-49E5-9198-A7D7F7074273") },
                new Route { Name = "Lal Pull", Id = new Guid("B3A64FC0-F699-49E5-9198-A7D7F7074274") },
                new Route { Name = "Saddar", Id = new Guid("B3A64FC0-F699-49E5-9198-A7D7F7074275") },
                new Route { Name = "Tajpura", Id = new Guid("B3A64FC0-F699-49E5-9198-A7D7F7074276") },
                new Route { Name = "R.A Bazar", Id = new Guid("B3A64FC0-F699-49E5-9198-A7D7F7074277") },
                new Route { Name = "Bilal Gunj", Id = new Guid("B3A64FC0-F699-49E5-9198-A7D7F7074278") },
                new Route { Name = "MuslimTown", Id = new Guid("B3A64FC0-F699-49E5-9198-A7D7F7074279") },
                new Route { Name = "Qasor Pura", Id = new Guid("B3A64FC0-F699-49E5-9198-A7D7F7074280") },
                new Route { Name = "Iqbal Town", Id = new Guid("B3A64FC0-F699-49E5-9198-A7D7F7074290") },
                new Route { Name = "AwanMarket", Id = new Guid("B3A64FC0-F699-49E5-9198-A7D7F7074291") },
                new Route { Name = "BhataChowk", Id = new Guid("B3A64FC0-F699-49E5-9198-A7D7F7074292") },
                new Route { Name = "Gulberg", Id = new Guid("B3A64FC0-F699-49E5-9198-A7D7F7074293") },
                new Route { Name = "WaltonRoad", Id = new Guid("B3A64FC0-F699-49E5-9198-A7D7F7074294") },
                new Route { Name = "Canal View", Id = new Guid("B3A64FC0-F699-49E5-9198-A7D7F7074295") },
                new Route { Name = "Shadbagh", Id = new Guid("B3A64FC0-F699-49E5-9198-A7D7F7074296") },
                new Route { Name = "Islampura", Id = new Guid("B3A64FC0-F699-49E5-9198-A7D7F7074297") },
                new Route { Name = "Wapda Town", Id = new Guid("B3A64FC0-F699-49E5-9198-A7D7F7074298") },
                new Route { Name = "MT LinkRd", Id = new Guid("B3A64FC0-F699-49E5-9198-A7D7F7074299") },
                new Route { Name = "ORDER BASE", Id = new Guid("B3A64FC0-F699-49E5-9198-A7D7F7074300") }
            };
            return routes;
        }
    }
}