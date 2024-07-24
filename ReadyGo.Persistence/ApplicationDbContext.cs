using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReadyGo.Domain.Entities;
using ReadyGo.Domain.Entities.Identity;
using ReadyGo.Persistence.Seeds;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyGo.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>, IApplicationDbContext
    {
        public DbSet<EmailSettings> MailSettings { get; set; }

        public DbSet<LogInformation> LogInformation { get; set; }

        public readonly IWebHostEnvironment _webHostEnvironment;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IWebHostEnvironment webHostEnvironment) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
            _webHostEnvironment = webHostEnvironment;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "User");
                entity.Property(x => x.IsActive).HasDefaultValue(true);
                entity.HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");
                entity.Property(x => x.IsActive).HasDefaultValue(true);
                entity.HasOne(x => x.Route).WithMany(y => y.Customers).HasForeignKey(x => x.RouteId);
            });

            modelBuilder.Entity<ResourceFile>()
                .HasOne(x => x.ImageUser)
                .WithOne(x => x.ProfileImage);
            modelBuilder.Entity<ResourceFile>()
             .HasOne(x => x.ImageCustomer)
             .WithOne(x => x.ProfilePicture);

            modelBuilder.Entity<Route>()
             .Property(x => x.IsActive).HasDefaultValue(true);

            modelBuilder.Entity<PriceHistory>()
             .Property(x => x.Tax).HasDefaultValue(0);

            modelBuilder.Entity<DeliveryReport>()
            .Property(x => x.IsMarked).HasDefaultValue(false);

            modelBuilder.Entity<UserNotification>()
             .Property(x => x.IsRead).HasDefaultValue(false);


            modelBuilder.Entity<ApplicationRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });


            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.Ignore("AspNetUserId");
                entity.Ignore("AspNetRoleId");
                entity.ToTable("UserRoles");
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });

            modelBuilder.Entity<EmailSettings>(entity =>
            {
                entity.ToTable("MailConfiguration");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(x => x.IsMarked).HasDefaultValue(false);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(x => x.IsMarked).HasDefaultValue(false);
            });

            modelBuilder.Seed(_webHostEnvironment);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<ResourceFile> ResourceFiles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<AssignStock> AssignStock { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ReturnOrder> ReturnOrders { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<TransferStock> TransferStocks { get; set; }
        public DbSet<PriceHistory> PriceHistory { get; set; }
        public DbSet<WasteOrders> WasteOrders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<DeliveryReport> DeliveryReports { get; set; }
    }
}