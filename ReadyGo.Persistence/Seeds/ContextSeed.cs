using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using ReadyGo.Domain.Entities;
using ReadyGo.Domain.Entities.Identity;
using System;
using System.Collections.Generic;

namespace ReadyGo.Persistence.Seeds
{
    public static class ContextSeed
    {
        public static void Seed(this ModelBuilder modelBuilder, IWebHostEnvironment enviroment)
        {
            CreateRoles(modelBuilder);

            CreateBasicUsers(modelBuilder);

            AddMailSettings(modelBuilder);

            AddDefaultConfiguration(modelBuilder);

            AddRoutes(modelBuilder);

            AddStocks(modelBuilder, enviroment);

            AddVehicles(modelBuilder);

            //AddPayments(modelBuilder);

            //AddDelivery(modelBuilder);

            //DefaultOrder.GetOrder(modelBuilder);
        }


        private static void CreateRoles(ModelBuilder modelBuilder)
        {
            List<ApplicationRole> roles = DefaultRoles.IdentityRoleList();
            modelBuilder.Entity<ApplicationRole>().HasData(roles);
        }

        private static void CreateBasicUsers(ModelBuilder modelBuilder)
        {
            List<ApplicationUser> users = DefaultUser.IdentityBasicUserList();
            modelBuilder.Entity<ApplicationUser>().HasData(users);
        }

        private static void AddMailSettings(ModelBuilder modelBuilder)
        {
            EmailSettings mailSetting = DefaultMailSettings.MailSetting();
            modelBuilder.Entity<EmailSettings>().HasData(mailSetting);
        }

        private static void AddDefaultConfiguration(ModelBuilder modelBuilder)
        {
            List<Configuration> configs = DefaultConfig.DefaultConfiguration();
            modelBuilder.Entity<Configuration>().HasData(configs);
        }

        private static void AddRoutes(ModelBuilder modelBuilder)
        {
            List<Route> routes = DefaultRoutes.ClientRoutesList();
            modelBuilder.Entity<Route>().HasData(routes);
        }
        private static void AddStocks(ModelBuilder modelBuilder, IWebHostEnvironment enviroment)
        {
            List<Category> categories = DefaultStocks.CategoriesListClient();
            modelBuilder.Entity<Category>().HasData(categories);
            DefaultStocks.ProductsListClient(modelBuilder, enviroment);
            //modelBuilder.Entity<Product>().HasData(products);
        }
        private static void AddVehicles(ModelBuilder modelBuilder)
        {
            List<Vehicle> vehicles = DefaultVehicle.VehicleList();
            modelBuilder.Entity<Vehicle>().HasData(vehicles);
        }

        private static void AddPayments(ModelBuilder modelBuilder)
        {
            List<Payment> payments = DefaultPayment.PaymentList();
            modelBuilder.Entity<Payment>().HasData(payments);
        }
        private static void AddDelivery(ModelBuilder modelBuilder)
        {
            DeliveryReport report = DefaultDeliveryReport.Delievery();
            modelBuilder.Entity<DeliveryReport>().HasData(report);
        }
    }
}