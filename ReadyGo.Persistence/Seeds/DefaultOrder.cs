using Microsoft.EntityFrameworkCore;
using ReadyGo.Domain.Entities;
using ReadyGo.Domain.Entities.Identity;
using System;

namespace ReadyGo.Persistence.Seeds
{
    public class DefaultOrder
    {
        public static void GetOrder(ModelBuilder modelBuilder)
        {
            ApplicationUser sp = new ApplicationUser()
            {
                Id= "0daec62b-312f-4016-9c5e-a15354259c90",
                FirstName="Order",
                LastName="SalesPerson",
                Email = "order@sp.com",
                UserName = "order@sp.com",
                RoleId = "c057793d-9d0d-4f1d-9fb0-2335480d82e2",
                Province = "lahore",
                City = "Lahore",
                PhoneNumber = "0900786012",
                IsActive = true,
                Address1 = "LahoreLahore",
                EmailConfirmed = true,
            };
            modelBuilder.Entity<ApplicationUser>().HasData(sp);


            Route route = new Route()
            {
                AxCode = "RH-00011",
                Name = "OrderRoute",
                Id = new Guid("0daec62b-312f-4016-9c5e-a15354259c92"),
                IsActive = true,
                Description = "Route for Order seeding",
                SyncedAt = new DateTime(2020, 12, 29)
            };
            modelBuilder.Entity<Route>().HasData(route);

            AssignedRoute assignedRoute = new AssignedRoute()
            {
                Id = new Guid("0daec62b-312f-4016-9c5e-a15354259c93"),
                SalesPersonId = sp.Id,
                RouteId = route.Id,
                TemporaryAssignedTill = null,
            };
            modelBuilder.Entity<AssignedRoute>().HasData(assignedRoute);

            Customer customer = new Customer()
            {
                Id = new Guid("0daec62b-312f-4016-9c5e-a15354259c91"),
                FirstName = "Order",
                LastName = "Customer",
                Email = "order@customer.com",
                Province = "Karachi",
                City = "Karachi",
                Address1 = "KarachiKarachi",
                IsActive = true,
                PhoneNumber = "1234567890",
                CreatedById = sp.Id,
                CreatedAt = new DateTime(2021,11,12),
                RouteId = route.Id
            };
            modelBuilder.Entity<Customer>().HasData(customer);

            Order order = new Order()
            {
                CustomerId = customer.Id,
                SalesPersonId = sp.Id,
                Id = new Guid("0daec62b-312f-4016-9c5e-a15354259c95"),
                CreatedAt = new DateTime(2021, 11, 18),
                Discount = 0,
                VehicleId = new Guid("c7be1d28-2b81-42e9-90e9-5396492a90e0"),
                DriverName = "Zeeshan",
            };
            modelBuilder.Entity<Order>().HasData(order);


            ReturnOrder retOrder = new ReturnOrder()
            {
                Id = new Guid("0daec62b-312f-4016-9c5e-a15354259c96"),
                OrderId = order.Id,
                Quantity = 10,
                ReturnReason = "Expired",
                Price = 20,
                Discount = 10,
                ProductId = new Guid("8C74FC65-B701-4ADE-9F07-7A7A744E2E59"),
            };
            modelBuilder.Entity<ReturnOrder>().HasData(retOrder);

            OrderDetail orderDet = new OrderDetail()
            {
                Id = new Guid("0daec62b-312f-4016-9c5e-a15354259c97"),
                OrderId = order.Id,
                Quantity = 100,
                Price = 20,
                ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E50"),
            };
            modelBuilder.Entity<OrderDetail>().HasData(orderDet);

        }
    }
}
