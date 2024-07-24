using Microsoft.EntityFrameworkCore;
using ReadyGo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReadyGo.Persistence.Seeds
{
    public class DefaultStocks
    {
        public static List<Category> CategoriesListClient()
        {
            var categories = new List<Category>
            {
                new Category { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E70"), Name = "Bread", Position = 10 },
                new Category { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E71"), Name = "Buns", Position = 11 },
                new Category { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E72"), Name = "Cakes", Position = 12 },
                new Category { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E73"), Name = "Rusks", Position = 13 },
                new Category { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E74"), Name = "Bakarkhani", Position = 14 },
                new Category { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E75"), Name = "Pita", Position = 15 },
                new Category { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E76"), Name = "Cupcakes", Position = 16 }
            };
            return categories;
        }

        public static List<Product> ProductsListClient(ModelBuilder modelBuilder, Microsoft.AspNetCore.Hosting.IWebHostEnvironment enviroment)
        {
            // TODO: Fix for environemt is required
            string path = Directory.GetCurrentDirectory();
            DirectoryInfo d = new DirectoryInfo(Path.Combine(path, "wwwroot", "resource_files", "ProductImages"));
            int appendingId = 11;
            FileInfo[] files = d.GetFiles(); //Getting Text files
            string id = string.Empty;
            Byte[] imageByteArray;
            ResourceFile image;
            List<ResourceFile> images = new List<ResourceFile>();
            foreach (var file in files)
            {
                imageByteArray = File.ReadAllBytes(file.FullName);
                id = "0C74FC65-B791-4ADE-9F97-7A7A744E2E" + appendingId;
                image = new ResourceFile()
                {
                    Id = new Guid(id),
                    File = imageByteArray,
                    MimeType = "Image",
                    Name = Path.GetFileNameWithoutExtension(file.FullName),
                };
                images.Add(image);
                appendingId += 1;
            }
            modelBuilder.Entity<ResourceFile>().HasData(images);


            List<Product> products = new List<Product>();
            List<PriceHistory> priceHistory = new List<PriceHistory>();
            // white bread
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E60"), Name = "White Bread", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E70") });
            //varients of white bread
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E61"), Name = "Small", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E70"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E60"), AxCode = "LH-10001" });
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E62"), Name = "Medium", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E70"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E60"), AxCode = "LH-10002" });
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E63"), Name = "Large", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E70"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E60"), AxCode = "LH-10003" });
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E64"), Name = "Slices Small (4 Pcs)", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E70"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E60"), AxCode = "LH-10004" });
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E65"), Name = "Slices Large (4 Pcs)", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E70"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E60"), AxCode = "LH-10005" });

            //White bread varients Prices
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E70"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E61"), Price = 63, From = new DateTime(2022,1,1) });
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E71"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E62"), Price = 90, From = new DateTime(2022,1,1) });
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E72"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E63"), Price = 118, From = new DateTime(2022,1,1) });
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E73"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E64"), Price = 18, From = new DateTime(2022,1,1) });
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E74"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E65"), Price = 22, From = new DateTime(2022,1,1) });

            //Milky Bread
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E66"), Name = "Milky Bread", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E70")});
            //Milky bread varients
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E67"), Name = "Small", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E70"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E66"), AxCode = "LH-10011" });
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E68"), Name = "Medium", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E70"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E66"), AxCode = "LH-10012" });
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E69"), Name = "Large", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E70"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E66"), AxCode = "LH-10013" });
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E70"), Name = "Slices Small (4 Pcs)", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E70"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E66"), AxCode = "LH-10014" });
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E71"), Name = "Slices Large (4 Pcs)", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E70"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E66"), AxCode = "LH-10015" });
            //Milky bread varients prices
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E75"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E67"), Price = 63, From = new DateTime(2022,1,1) });
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E76"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E68"), Price = 90, From = new DateTime(2022,1,1) });
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E77"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E69"), Price = 118, From = new DateTime(2022,1,1) });
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E78"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E70"), Price = 18, From = new DateTime(2022,1,1) });
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E79"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E71"), Price = 22, From = new DateTime(2022,1,1) });

            //Brean bread
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E72"), Name = "Bran Bread", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E70") });
            //Bran bread varients
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E73"), Name = "Small", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E70"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E72"), AxCode = "LH-10021" });
            //Bran bread varients prices
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E80"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E73"), Price = 81, From = new DateTime(2022,1,1) });

            //Multigrain bread
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E74"), Name = "Multigrain", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E70")});
            //Multigrain varients
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E75"), Name = "Small", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E70"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E74"), AxCode = "LH-10021" });
            //Multigrain varients prices
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E81"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E75"), Price = 99, From = new DateTime(2022,1,1) });

            //Sandwitch bread
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E76"), Name = "Sandwich Bread", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E70"), AxCode = "LH-10023" });
            //Sandwitch bread price
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E82"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E76"), Price = 145, From = new DateTime(2022,1,1) });

            //Bread Crumbs
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E77"), Name = "Bread Crumbs", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E70")});
            //Bread crumbs varients
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E78"), Name = "200 g", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E70"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E77"), AxCode = "LH-10421" });
            //Bread Crumbs varients prices
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E83"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E78"), Price = 90, From = new DateTime(2022,1,1) });


            //Burger Bun-4
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E79"), Name = "Burger Bun-4", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E70") });
            //Burger Bun-4 varients
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E80"), Name = "2 Pcs", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E70"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E79"), AxCode = "LH-10101" });
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E81"), Name = "4 Pcs", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E70"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E79"), AxCode = "LH-10102" });
            //Burger Bun-4 varients prices
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E84"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E80"), Price = 36, From = new DateTime(2022,1,1) });
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E85"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E81"), Price = 68, From = new DateTime(2022,1,1) });

            //Burger Bun-3.8
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E82"), Name = "Burger Bun-3.8", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E70") });
            //Burger Bun-3.8 varients
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E83"), Name = "2 Pcs", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E70"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E82"), AxCode = "LH-10110" });
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E84"), Name = "4 Pcs", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E70"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E82"), AxCode = "LH-10113" });
            //Burger Bun-3.8 varients prices
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E86"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E83"), Price = 36, From = new DateTime(2022,1,1) });
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E87"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E84"), Price = 68, From = new DateTime(2022,1,1) });

            //tower bun -4
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E85"), Name = "Tower Bun-4", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E71") });
            //tower bun-4 varient
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E86"), Name = "2 Pcs, Double - Cut", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E71"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E85"), AxCode = "LH-10103" });
            //tower bun-4 varient price
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E88"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E86"), Price = 50, From = new DateTime(2022,1,1) });

            //grand bun -4.5
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E87"), Name = "Grand Bun 4.5", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E71") });
            //grand bun-4.5 varient
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E88"), Name = "2 Pcs", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E71"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E87"), AxCode = "LH-10104" });
            //grand bun-4.5 varient price
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E89"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E88"), Price = 50, From = new DateTime(2022,1,1) });

            //long bun
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E89"), Name = "Long bun", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E71") });
            //long bun  varient
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E90"), Name = "2 Pcs", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E71"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E89"), AxCode = "LH-10105" });
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E91"), Name = "4 Pcs", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E71"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E89"), AxCode = "LH-10106" });
            //long bun varient price
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E90"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E90"), Price = 36, From = new DateTime(2022,1,1) });
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E91"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E91"), Price = 68, From = new DateTime(2022,1,1) });


            //fruit bun
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E92"), Name = "Fruit Bun", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E71"), AxCode = "LH-10107" });
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E92"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E92"), Price = 27, From = new DateTime(2022,1,1) });

            //mini fruit bun
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E93"), Name = "Mini Fruit Bun", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E71"), AxCode = "LH-10108" });
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E93"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E93"), Price = 18, From = new DateTime(2022,1,1) });

            //Sheermal
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E94"), Name = "Sheermal", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E71"), AxCode = "LH-10406" });
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E94"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E94"), Price = 31, From = new DateTime(2022,1,1) });

            //Plain cake
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E95"), Name = "Plain Cake", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E72") });
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E96"), Name = "Small", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E72"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E95"), AxCode = "LH-10201" });
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E97"), Name = "Large", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E72"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E95"), AxCode = "LH-10202" });
            //plain cake prices
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E95"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E96"), Price = 59, From = new DateTime(2022,1,1) });
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E96"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E97"), Price = 99, From = new DateTime(2022,1,1) });


            //Fruit cake
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E98"), Name = "Fruit Cake", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E72")});
            products.Add(new Product { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E99"), Name = "Small", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E72"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E98"), AxCode = "LH-10203" });
            products.Add(new Product { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E01"), Name = "Large", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E72"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E98"), AxCode = "LH-10204" });
            //Fruit cake prices
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E97"), ProductId = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E97"), Price = 59, From = new DateTime(2022,1,1) });
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E98"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E01"), Price = 103, From = new DateTime(2022,1,1) });


            //Plain Rusks
            products.Add(new Product { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E02"), Name = "Plain Rusk", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E73") });
            products.Add(new Product { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E03"), Name = "Small", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E73"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E02"), AxCode = "LH-10205" });
            products.Add(new Product { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E04"), Name = "Large", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E73"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E02"), AxCode = "LH-10206" });
            products.Add(new Product { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E05"), Name = "Mini Pack", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E73"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E02"), AxCode = "LH-10207" });
            //Plain Rusks prices
            priceHistory.Add(new PriceHistory { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E99"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E03"), Price = 72, From = new DateTime(2022,1,1) });
            priceHistory.Add(new PriceHistory { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E01"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E04"), Price = 145, From = new DateTime(2022,1,1) });
            priceHistory.Add(new PriceHistory { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E02"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E05"), Price = 130, From = new DateTime(2022,1,1) });

            //Tea rusks    
            products.Add(new Product { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E06"), Name = "Tea Rusk(Round)", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E73"), AxCode = "LH-10311" });
            priceHistory.Add(new PriceHistory { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E03"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E06"), Price = 131, From = new DateTime(2022,1,1) });

            //Bakarkhani
            products.Add(new Product { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E07"), Name = "Bakarkhani(2 Pcs)", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E74"), AxCode = "LH-10401" });
            priceHistory.Add(new PriceHistory { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E04"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E07"), Price = 54, From = new DateTime(2022,1,1) });

            //Pita
            products.Add(new Product { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E08"), Name = "Pitta Bread - 6 (4 Pcs)", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E75"), AxCode = "LH-10411" });
            priceHistory.Add(new PriceHistory { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E05"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E08"), Price = 58, From = new DateTime(2022,1,1) });


            products.Add(new Product { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E09"), Name = "Pitta Bread - 5 (5 Pcs)", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E75"), AxCode = "LH-10112" });
            priceHistory.Add(new PriceHistory { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E06"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E09"), Price = 58, From = new DateTime(2022,1,1) });

            products.Add(new Product { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E10"), Name = "Tortilla Bread (8 Pcs)", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E75"), AxCode = "LH-10114" });
            priceHistory.Add(new PriceHistory { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E07"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E10"), Price = 234, From = new DateTime(2022,1,1) });

            products.Add(new Product { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E11"), Name = "Cup Cake Vanilla", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E76") });
            products.Add(new Product { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E12"), Name = "Small (12 Pcs)", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E76"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E11"), AxCode = "LH-10501" });
            products.Add(new Product { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E13"), Name = "Large (6 Pcs)", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E76"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E11"), AxCode = "LH-10502" });

            products.Add(new Product { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E14 "), Name = "Cup Cake Mango", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E76") });
            products.Add(new Product { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E15"), Name = "Small (12 Pcs)", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E76"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E14"), AxCode = "LH-10502" });
            products.Add(new Product { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E16"), Name = "Large (6 Pcs)", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E76"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E14"), AxCode = "LH-10503" });


            products.Add(new Product { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E17"), Name = "Cup Cake Starwberry", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E76") });
            products.Add(new Product { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E18"), Name = "Small (12 Pcs)", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E76"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E17"), AxCode = "LH-10505" });
            products.Add(new Product { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E19"), Name = "Large (6 Pcs)", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E76"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E17"), AxCode = "LH-10506" });

            products.Add(new Product { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E20"), Name = "Cup Cake Chocolate", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E76") });
            products.Add(new Product { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E21"), Name = "Small (12 Pcs)", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E76"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E20"), AxCode = "LH-10508" });
            products.Add(new Product { Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E22"), Name = "Large (6 Pcs)", CategoryId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E76"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E20"), AxCode = "LH-10509" });


            priceHistory.Add(new PriceHistory { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E08"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E12"), Price = 108, From = new DateTime(2022,1,1) });
            priceHistory.Add(new PriceHistory { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E09"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E13"), Price = 105, From = new DateTime(2022,1,1) });
            priceHistory.Add(new PriceHistory { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E10"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E15"), Price = 108, From = new DateTime(2022,1,1) });
            priceHistory.Add(new PriceHistory { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E11"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E16"), Price = 105, From = new DateTime(2022,1,1) });
            priceHistory.Add(new PriceHistory { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E12"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E18"), Price = 108, From = new DateTime(2022,1,1) });
            priceHistory.Add(new PriceHistory { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E13"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E19"), Price = 105, From = new DateTime(2022,1,1) });
            priceHistory.Add(new PriceHistory { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E14"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E21"), Price = 108, From = new DateTime(2022,1,1) });
            priceHistory.Add(new PriceHistory { Id = new Guid("9C74FC65-B791-4ADE-9F97-7A7A744E2E15"), ProductId = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E22"), Price = 105, From = new DateTime(2022,1,1) });

            foreach(var product in products)
            {
                var pic = images.FirstOrDefault(x => x.Name.Equals(product.AxCode));
                if (pic != null)
                {
                    product.ImageId = pic.Id;
                }
            }
            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<PriceHistory>().HasData(priceHistory);


            return products;
        }



        public static List<Category> CategoriesList()
        {
            var categories = new List<Category>();
            for (int i = 0; i < 10; i++)
            {
                categories.Add(
                    new Category
                    {
                        Id = new Guid("8C74FC65-B791-4ADE-9F97-7A7A744E2E5"+i),
                        Name = "Category" + i,
                        Position = i
                    }) ;
            }
            return categories;
        }
        public static List<Product> ProductsList(List<Category> categories, ModelBuilder modelBuilder)
        {
            List<Product> products = new List<Product>();
            int catCount = 0;
            foreach(var category in categories)
            {
                for (int i = 0; i < 10; i++)
                {
                    products.Add(
                        new Product
                        {
                            Id = new Guid(i + category.Id.ToString()[1..]),
                            Name = "Product " + i,
                            CategoryId = category.Id,
                            Description = "Product " + i + " is a dairy product",
                            AxCode = "LH-000" + i + catCount
                        });
                }
                catCount++;
            }
            List<string> sizes = new List<string> { "Small", "Medium", "Large" };
            int count = 0, j = 0;

            while(j<10)
            {
                products.Add(new Product{
                    Id = new Guid("8C74FC65-B701-4ADE-9F"+j+"7-7A7A744E2E59"),
                    Name = sizes[count],
                    ProductId = products[j].Id,
                    Quantity = 100,
                    CategoryId = products[j].CategoryId,
                    Description = "Variant of "+ products[j].Name,
                    AxCode = "LH-1000" + j
                });
                count = count != 3 ? count = 0 : count += 1;
                j += 1;
            }
            var price = 0;
            int k = 0;
            var id = "";
            foreach (var product in products)
            {
                if (product.Variants == null)
                {
                    if (k < 10)
                    {
                        id = "0" + k.ToString();
                    }
                    else
                    {
                        id = k.ToString();
                    }
                    var productPrice = new PriceHistory()
                    {
                        Id = Guid.NewGuid(),
                        CreatedAt = new DateTime(2021, 11, 17),
                        ProductId = product.Id,
                        Price = price,
                        From = new DateTime(2021, 11, 17)
                    };
                    price += 5;
                    k += 1;
                    modelBuilder.Entity<PriceHistory>().HasData(productPrice);
                }
            }
            return products;
        }
      
    }
}
