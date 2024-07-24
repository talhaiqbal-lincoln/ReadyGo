using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadyGo.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConfigKey = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    DiscountValue = table.Column<double>(type: "float", nullable: false),
                    IsPercentage = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MailConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmtpHost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmtpPort = table.Column<int>(type: "int", nullable: false),
                    SmtpEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmtpPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnableSSL = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailConfiguration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SyncedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AxCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BaseProductQuantity = table.Column<int>(type: "int", nullable: false),
                    BaseProductCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PromoProductQuantity = table.Column<int>(type: "int", nullable: false),
                    PromoProductCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RouteCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MimeType = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    File = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SyncedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AxCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AXCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    AxCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ResourceFiles_ImageId",
                        column: x => x.ImageId,
                        principalTable: "ResourceFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Province = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    AxCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SyncedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InviteTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_ResourceFiles_ProfileImageId",
                        column: x => x.ProfileImageId,
                        principalTable: "ResourceFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PriceHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceHistory_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssignedRoute",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesPersonId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RouteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TemporaryAssignedTill = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedRoute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignedRoute_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssignedRoute_User_SalesPersonId",
                        column: x => x.SalesPersonId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Province = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AxCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RouteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SyncedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiscountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_ResourceFiles_PictureId",
                        column: x => x.PictureId,
                        principalTable: "ResourceFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LogInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogInformation_User_ChangedById",
                        column: x => x.ChangedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_User_CreatedByid",
                        column: x => x.CreatedByid,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotificationSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NotificationType = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationSettings_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransferStocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AXCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    FromWarehouse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RouteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesPersonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransferStocks_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferStocks_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferStocks_User_SalesPersonId",
                        column: x => x.SalesPersonId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferStocks_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesPersonId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    IsMarked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BalanceUsed = table.Column<float>(type: "real", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_User_SalesPersonId",
                        column: x => x.SalesPersonId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotifications_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserNotifications_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssignStock",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AXCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignStock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignStock_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssignStock_TransferStocks_TransferId",
                        column: x => x.TransferId,
                        principalTable: "TransferStocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PromotionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReturnOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReturnReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReturnOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReturnOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WasteOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WasteReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WasteOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WasteOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WasteOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderPromos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PromoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPromos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderPromos_OrderDetails_OrderDetailId",
                        column: x => x.OrderDetailId,
                        principalTable: "OrderDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderPromos_Promotions_PromoId",
                        column: x => x.PromoId,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DeletedAt", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50"), null, "Category0", 0 },
                    { new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e58"), null, "Category8", 8 },
                    { new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e57"), null, "Category7", 7 },
                    { new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e56"), null, "Category6", 6 },
                    { new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e55"), null, "Category5", 5 },
                    { new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e59"), null, "Category9", 9 },
                    { new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e53"), null, "Category3", 3 },
                    { new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e52"), null, "Category2", 2 },
                    { new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e51"), null, "Category1", 1 },
                    { new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e54"), null, "Category4", 4 }
                });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "ConfigKey", "DeletedAt", "Value" },
                values: new object[,]
                {
                    { new Guid("df802ea6-ffec-45b1-85e0-a6dd74c8bea4"), "Sales Manager_Customer", null, "1" },
                    { new Guid("26c69ac9-68cd-4f80-83a8-979770f3a826"), "Sales Manager_SalesPerson", null, "1" },
                    { new Guid("64f495e3-8fa4-498e-b825-f8df85857e76"), "Sales Manager_Stock", null, "1" },
                    { new Guid("300a3996-9801-4e9d-9fb3-048ac824589f"), "Marketing Manager_Customer", null, "1" },
                    { new Guid("823f8343-acfc-4bf2-90de-6ec2d4bbf427"), "Marketing Manager_SalesPerson", null, "1" },
                    { new Guid("e1a248ed-6925-4252-95c5-a97982987508"), "Marketing Manager_Stock", null, "1" }
                });

            migrationBuilder.InsertData(
                table: "MailConfiguration",
                columns: new[] { "Id", "EnableSSL", "SmtpEmailAddress", "SmtpHost", "SmtpPassword", "SmtpPort" },
                values: new object[] { 1, true, "Lighthousetestmail@gmail.com", "smtp.gmail.com", "ReadyGoWebApp1", 587 });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c057793d-9d0d-4f1d-9fb0-2335480d82e2", "a6393142-b295-4a2f-9f8f-547fe111aa68", "Sales Person", "Sales Person" },
                    { "4ce95b9b-0760-4f11-b576-71dfaa053e74", "dc728e9f-a1da-4d79-a2ac-fa1deb38c753", "Sales Manager", "Sales Manager" },
                    { "f4ea0102-2c6d-453e-8365-cb45c956cc44", "a56c575b-6c7b-42fa-a881-93fa264452d7", "Admin", "Admin" },
                    { "1570902e-48bb-4b03-850c-8ebd63261e33", "4e4d3390-7e79-4067-aa14-3f109247f407", "Marketing Manager", "Marketing Manager" }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "AxCode", "DeletedAt", "Description", "IsActive", "Name", "SyncedAt" },
                values: new object[,]
                {
                    { new Guid("b3a64fc0-f699-49e5-9198-a7d7f7074260"), "RH-00000", null, "Route0 has 10 stops", true, "Route0", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b3a64fc0-f699-49e5-9198-a7d7f7074261"), "RH-00001", null, "Route1 has 10 stops", true, "Route1", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b3a64fc0-f699-49e5-9198-a7d7f7074262"), "RH-00002", null, "Route2 has 10 stops", true, "Route2", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b3a64fc0-f699-49e5-9198-a7d7f7074263"), "RH-00003", null, "Route3 has 10 stops", true, "Route3", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b3a64fc0-f699-49e5-9198-a7d7f7074264"), "RH-00004", null, "Route4 has 10 stops", true, "Route4", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b3a64fc0-f699-49e5-9198-a7d7f7074265"), "RH-00005", null, "Route5 has 10 stops", true, "Route5", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b3a64fc0-f699-49e5-9198-a7d7f7074266"), "RH-00006", null, "Route6 has 10 stops", true, "Route6", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b3a64fc0-f699-49e5-9198-a7d7f7074267"), "RH-00007", null, "Route7 has 10 stops", true, "Route7", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b3a64fc0-f699-49e5-9198-a7d7f7074268"), "RH-00008", null, "Route8 has 10 stops", true, "Route8", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b3a64fc0-f699-49e5-9198-a7d7f7074269"), "RH-00009", null, "Route9 has 10 stops", true, "Route9", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0daec62b-312f-4016-9c5e-a15354259c92"), "RH-00011", null, "Route for Order seeding", true, "OrderRoute", new DateTime(2020, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "AXCode", "DeletedAt", "DriverName", "Model", "Type", "VehicleNumber" },
                values: new object[,]
                {
                    { new Guid("c7be1d28-2b81-42e9-90e9-5396492a90e1"), "AX-Code1", null, "Driver1", "Model1", "Type1", "LHR-0001" },
                    { new Guid("c7be1d28-2b81-42e9-90e9-5396492a90e0"), "AX-Code0", null, "Driver0", "Model0", "Type0", "LHR-0000" },
                    { new Guid("c7be1d28-2b81-42e9-90e9-5396492a90e2"), "AX-Code2", null, "Driver2", "Model2", "Type2", "LHR-0002" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AxCode", "CategoryId", "DeletedAt", "Description", "ImageId", "Name", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e50"), "LH-00000", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50"), null, "Product 0 is a dairy product", null, "Product 0", null, 0f },
                    { new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e57"), "LH-00037", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e57"), null, "Product 3 is a dairy product", null, "Product 3", null, 0f },
                    { new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e57"), "LH-00027", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e57"), null, "Product 2 is a dairy product", null, "Product 2", null, 0f },
                    { new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e57"), "LH-00017", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e57"), null, "Product 1 is a dairy product", null, "Product 1", null, 0f },
                    { new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e57"), "LH-00007", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e57"), null, "Product 0 is a dairy product", null, "Product 0", null, 0f },
                    { new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e56"), "LH-00096", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e56"), null, "Product 9 is a dairy product", null, "Product 9", null, 0f },
                    { new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e56"), "LH-00086", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e56"), null, "Product 8 is a dairy product", null, "Product 8", null, 0f },
                    { new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e56"), "LH-00076", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e56"), null, "Product 7 is a dairy product", null, "Product 7", null, 0f },
                    { new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e56"), "LH-00066", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e56"), null, "Product 6 is a dairy product", null, "Product 6", null, 0f },
                    { new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e56"), "LH-00056", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e56"), null, "Product 5 is a dairy product", null, "Product 5", null, 0f },
                    { new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e56"), "LH-00046", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e56"), null, "Product 4 is a dairy product", null, "Product 4", null, 0f },
                    { new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e56"), "LH-00036", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e56"), null, "Product 3 is a dairy product", null, "Product 3", null, 0f },
                    { new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e56"), "LH-00026", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e56"), null, "Product 2 is a dairy product", null, "Product 2", null, 0f },
                    { new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e56"), "LH-00016", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e56"), null, "Product 1 is a dairy product", null, "Product 1", null, 0f },
                    { new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e56"), "LH-00006", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e56"), null, "Product 0 is a dairy product", null, "Product 0", null, 0f },
                    { new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e55"), "LH-00095", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e55"), null, "Product 9 is a dairy product", null, "Product 9", null, 0f },
                    { new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e55"), "LH-00085", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e55"), null, "Product 8 is a dairy product", null, "Product 8", null, 0f },
                    { new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e55"), "LH-00075", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e55"), null, "Product 7 is a dairy product", null, "Product 7", null, 0f },
                    { new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e55"), "LH-00065", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e55"), null, "Product 6 is a dairy product", null, "Product 6", null, 0f },
                    { new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e55"), "LH-00055", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e55"), null, "Product 5 is a dairy product", null, "Product 5", null, 0f },
                    { new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e55"), "LH-00045", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e55"), null, "Product 4 is a dairy product", null, "Product 4", null, 0f },
                    { new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e55"), "LH-00035", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e55"), null, "Product 3 is a dairy product", null, "Product 3", null, 0f },
                    { new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e57"), "LH-00047", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e57"), null, "Product 4 is a dairy product", null, "Product 4", null, 0f },
                    { new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e57"), "LH-00057", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e57"), null, "Product 5 is a dairy product", null, "Product 5", null, 0f },
                    { new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e57"), "LH-00067", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e57"), null, "Product 6 is a dairy product", null, "Product 6", null, 0f },
                    { new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e57"), "LH-00077", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e57"), null, "Product 7 is a dairy product", null, "Product 7", null, 0f },
                    { new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e59"), "LH-00099", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e59"), null, "Product 9 is a dairy product", null, "Product 9", null, 0f },
                    { new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e59"), "LH-00089", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e59"), null, "Product 8 is a dairy product", null, "Product 8", null, 0f },
                    { new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e59"), "LH-00079", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e59"), null, "Product 7 is a dairy product", null, "Product 7", null, 0f },
                    { new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e59"), "LH-00069", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e59"), null, "Product 6 is a dairy product", null, "Product 6", null, 0f },
                    { new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e59"), "LH-00059", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e59"), null, "Product 5 is a dairy product", null, "Product 5", null, 0f },
                    { new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e59"), "LH-00049", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e59"), null, "Product 4 is a dairy product", null, "Product 4", null, 0f },
                    { new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e59"), "LH-00039", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e59"), null, "Product 3 is a dairy product", null, "Product 3", null, 0f },
                    { new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e59"), "LH-00029", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e59"), null, "Product 2 is a dairy product", null, "Product 2", null, 0f },
                    { new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e59"), "LH-00019", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e59"), null, "Product 1 is a dairy product", null, "Product 1", null, 0f },
                    { new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e59"), "LH-00009", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e59"), null, "Product 0 is a dairy product", null, "Product 0", null, 0f },
                    { new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e55"), "LH-00025", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e55"), null, "Product 2 is a dairy product", null, "Product 2", null, 0f },
                    { new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e58"), "LH-00098", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e58"), null, "Product 9 is a dairy product", null, "Product 9", null, 0f },
                    { new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e58"), "LH-00078", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e58"), null, "Product 7 is a dairy product", null, "Product 7", null, 0f },
                    { new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e58"), "LH-00068", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e58"), null, "Product 6 is a dairy product", null, "Product 6", null, 0f },
                    { new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e58"), "LH-00058", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e58"), null, "Product 5 is a dairy product", null, "Product 5", null, 0f },
                    { new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e58"), "LH-00048", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e58"), null, "Product 4 is a dairy product", null, "Product 4", null, 0f }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AxCode", "CategoryId", "DeletedAt", "Description", "ImageId", "Name", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e58"), "LH-00038", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e58"), null, "Product 3 is a dairy product", null, "Product 3", null, 0f },
                    { new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e58"), "LH-00028", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e58"), null, "Product 2 is a dairy product", null, "Product 2", null, 0f },
                    { new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e58"), "LH-00018", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e58"), null, "Product 1 is a dairy product", null, "Product 1", null, 0f },
                    { new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e58"), "LH-00008", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e58"), null, "Product 0 is a dairy product", null, "Product 0", null, 0f },
                    { new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e57"), "LH-00097", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e57"), null, "Product 9 is a dairy product", null, "Product 9", null, 0f },
                    { new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e57"), "LH-00087", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e57"), null, "Product 8 is a dairy product", null, "Product 8", null, 0f },
                    { new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e58"), "LH-00088", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e58"), null, "Product 8 is a dairy product", null, "Product 8", null, 0f },
                    { new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e55"), "LH-00015", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e55"), null, "Product 1 is a dairy product", null, "Product 1", null, 0f },
                    { new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e55"), "LH-00005", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e55"), null, "Product 0 is a dairy product", null, "Product 0", null, 0f },
                    { new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e54"), "LH-00094", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e54"), null, "Product 9 is a dairy product", null, "Product 9", null, 0f },
                    { new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e52"), "LH-00012", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e52"), null, "Product 1 is a dairy product", null, "Product 1", null, 0f },
                    { new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e52"), "LH-00002", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e52"), null, "Product 0 is a dairy product", null, "Product 0", null, 0f },
                    { new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e51"), "LH-00091", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e51"), null, "Product 9 is a dairy product", null, "Product 9", null, 0f },
                    { new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e51"), "LH-00081", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e51"), null, "Product 8 is a dairy product", null, "Product 8", null, 0f },
                    { new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e51"), "LH-00071", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e51"), null, "Product 7 is a dairy product", null, "Product 7", null, 0f },
                    { new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e51"), "LH-00061", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e51"), null, "Product 6 is a dairy product", null, "Product 6", null, 0f },
                    { new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e51"), "LH-00051", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e51"), null, "Product 5 is a dairy product", null, "Product 5", null, 0f },
                    { new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e51"), "LH-00041", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e51"), null, "Product 4 is a dairy product", null, "Product 4", null, 0f },
                    { new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e51"), "LH-00031", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e51"), null, "Product 3 is a dairy product", null, "Product 3", null, 0f },
                    { new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e51"), "LH-00021", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e51"), null, "Product 2 is a dairy product", null, "Product 2", null, 0f },
                    { new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e51"), "LH-00011", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e51"), null, "Product 1 is a dairy product", null, "Product 1", null, 0f },
                    { new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e51"), "LH-00001", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e51"), null, "Product 0 is a dairy product", null, "Product 0", null, 0f },
                    { new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e50"), "LH-00090", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50"), null, "Product 9 is a dairy product", null, "Product 9", null, 0f },
                    { new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50"), "LH-00080", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50"), null, "Product 8 is a dairy product", null, "Product 8", null, 0f },
                    { new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e50"), "LH-00070", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50"), null, "Product 7 is a dairy product", null, "Product 7", null, 0f },
                    { new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e50"), "LH-00060", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50"), null, "Product 6 is a dairy product", null, "Product 6", null, 0f },
                    { new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e50"), "LH-00050", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50"), null, "Product 5 is a dairy product", null, "Product 5", null, 0f },
                    { new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e50"), "LH-00040", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50"), null, "Product 4 is a dairy product", null, "Product 4", null, 0f },
                    { new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e50"), "LH-00030", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50"), null, "Product 3 is a dairy product", null, "Product 3", null, 0f },
                    { new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e50"), "LH-00020", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50"), null, "Product 2 is a dairy product", null, "Product 2", null, 0f },
                    { new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e50"), "LH-00010", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50"), null, "Product 1 is a dairy product", null, "Product 1", null, 0f },
                    { new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e52"), "LH-00022", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e52"), null, "Product 2 is a dairy product", null, "Product 2", null, 0f },
                    { new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e52"), "LH-00032", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e52"), null, "Product 3 is a dairy product", null, "Product 3", null, 0f },
                    { new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e52"), "LH-00042", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e52"), null, "Product 4 is a dairy product", null, "Product 4", null, 0f },
                    { new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e53"), "LH-00073", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e53"), null, "Product 7 is a dairy product", null, "Product 7", null, 0f },
                    { new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e54"), "LH-00064", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e54"), null, "Product 6 is a dairy product", null, "Product 6", null, 0f },
                    { new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e54"), "LH-00054", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e54"), null, "Product 5 is a dairy product", null, "Product 5", null, 0f },
                    { new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e54"), "LH-00044", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e54"), null, "Product 4 is a dairy product", null, "Product 4", null, 0f },
                    { new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e54"), "LH-00034", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e54"), null, "Product 3 is a dairy product", null, "Product 3", null, 0f },
                    { new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e54"), "LH-00024", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e54"), null, "Product 2 is a dairy product", null, "Product 2", null, 0f },
                    { new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e54"), "LH-00014", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e54"), null, "Product 1 is a dairy product", null, "Product 1", null, 0f },
                    { new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e54"), "LH-00004", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e54"), null, "Product 0 is a dairy product", null, "Product 0", null, 0f }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AxCode", "CategoryId", "DeletedAt", "Description", "ImageId", "Name", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e53"), "LH-00093", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e53"), null, "Product 9 is a dairy product", null, "Product 9", null, 0f },
                    { new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e53"), "LH-00083", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e53"), null, "Product 8 is a dairy product", null, "Product 8", null, 0f },
                    { new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e52"), "LH-00052", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e52"), null, "Product 5 is a dairy product", null, "Product 5", null, 0f },
                    { new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e53"), "LH-00063", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e53"), null, "Product 6 is a dairy product", null, "Product 6", null, 0f },
                    { new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e53"), "LH-00053", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e53"), null, "Product 5 is a dairy product", null, "Product 5", null, 0f },
                    { new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e53"), "LH-00043", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e53"), null, "Product 4 is a dairy product", null, "Product 4", null, 0f },
                    { new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e53"), "LH-00033", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e53"), null, "Product 3 is a dairy product", null, "Product 3", null, 0f },
                    { new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e53"), "LH-00023", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e53"), null, "Product 2 is a dairy product", null, "Product 2", null, 0f },
                    { new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e53"), "LH-00013", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e53"), null, "Product 1 is a dairy product", null, "Product 1", null, 0f },
                    { new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e53"), "LH-00003", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e53"), null, "Product 0 is a dairy product", null, "Product 0", null, 0f },
                    { new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e52"), "LH-00092", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e52"), null, "Product 9 is a dairy product", null, "Product 9", null, 0f },
                    { new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e52"), "LH-00082", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e52"), null, "Product 8 is a dairy product", null, "Product 8", null, 0f },
                    { new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e52"), "LH-00072", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e52"), null, "Product 7 is a dairy product", null, "Product 7", null, 0f },
                    { new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e52"), "LH-00062", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e52"), null, "Product 6 is a dairy product", null, "Product 6", null, 0f },
                    { new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e54"), "LH-00074", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e54"), null, "Product 7 is a dairy product", null, "Product 7", null, 0f },
                    { new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e54"), "LH-00084", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e54"), null, "Product 8 is a dairy product", null, "Product 8", null, 0f }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "Address1", "Address2", "AxCode", "City", "ConcurrencyStamp", "DeletedAt", "Email", "EmailConfirmed", "FirstName", "InviteTime", "IsActive", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageId", "Province", "RoleId", "SecurityStamp", "SyncedAt", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "569411c1-88ef-45b6-ab57-79665fbcd9a4", 0, null, null, null, null, "6e6b65e1-772f-4587-a1af-b8eeeeae2c76", null, "superadmin@gmail.com", true, "Super", null, true, "Admin", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, null, "f4ea0102-2c6d-453e-8365-cb45c956cc44", "a620048e-d5ae-4df0-b2b9-8e8ba31686e4", null, false, "superadmin" },
                    { "0daec62b-312f-4016-9c5e-a15354259c90", 0, "LahoreLahore", null, null, "Lahore", "a74bafa4-110a-423b-a68f-be2f6208bcba", null, "order@sp.com", true, "Order", null, true, "SalesPerson", false, null, "ORDER@SP.COM", "ORDER@SP.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", "0900786012", false, null, "lahore", "c057793d-9d0d-4f1d-9fb0-2335480d82e2", "24ace1fe-78d0-402e-9864-8f222183c6d0", null, false, "order@sp.com" }
                });

            migrationBuilder.InsertData(
                table: "AssignedRoute",
                columns: new[] { "Id", "DeletedAt", "RouteId", "SalesPersonId", "TemporaryAssignedTill" },
                values: new object[] { new Guid("0daec62b-312f-4016-9c5e-a15354259c93"), null, new Guid("0daec62b-312f-4016-9c5e-a15354259c92"), "0daec62b-312f-4016-9c5e-a15354259c90", null });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address1", "Address2", "AxCode", "Balance", "City", "CreatedAt", "CreatedById", "DeletedAt", "DiscountId", "Email", "FirstName", "IsActive", "LastName", "Latitude", "Longitude", "PhoneNumber", "PictureId", "Province", "RouteId", "SyncedAt" },
                values: new object[] { new Guid("0daec62b-312f-4016-9c5e-a15354259c91"), "KarachiKarachi", null, null, 0.0, "Karachi", new DateTime(2021, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "0daec62b-312f-4016-9c5e-a15354259c90", null, null, "order@customer.com", "Order", true, "Customer", null, null, "1234567890", null, "Karachi", new Guid("0daec62b-312f-4016-9c5e-a15354259c92"), null });

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("7301eb65-53cd-45ba-9cf4-1101d8c3fcb3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 490f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("401919b7-23e9-4e52-afa2-8c2597e3f3d1"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 345f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("f7ae027c-48ce-4563-ae65-681ed5bed2d1"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 340f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("116d0215-2c7c-4d34-9b27-a083d9eeac00"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 335f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("2ff30ecf-92da-40f0-8e7c-7bab7bbef0da"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 330f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("974e04d6-644e-4a88-bb12-d2973d76fefe"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 325f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("bb12b220-ac85-4982-9eb7-7c00c06bfabd"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 320f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("f4523454-003a-4543-9899-d65760a9e6d0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 315f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("92c6a1ee-19c1-4617-83c8-fdde5eeb518f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 310f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("c4589a1d-4b28-4ddb-ab31-628b66b2bf32"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 305f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("cdc9e2ab-16f0-47ef-9493-1ea1d531305e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 300f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("0cb80fd4-8965-45e2-9600-0189b3b08654"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 295f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("9d50abd4-5532-498b-aae9-56a5f3f33b03"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 290f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("3cedc5a8-67f7-4eda-9047-7ba18db27d3f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 285f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("4e627e55-6ad5-47d4-beca-64ea3595e1b0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 280f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("9aea72d0-7f48-4bea-a496-ebcb96b5099b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 275f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("0ea3b60f-cee1-463e-87c9-c15a8281b99c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 270f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("2b31f9d7-0572-410e-90ce-8529505a15b3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 265f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("7f1f7386-39e3-4b90-aad8-8381604df538"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 260f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("501c6238-8fbd-4ec3-818a-2b1f6d0ffde8"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 255f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("219baec3-7251-4055-b3fa-a31ff4158321"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 250f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("25d2424c-8d1c-4106-a982-f20c38085590"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 245f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("a4953c00-b252-4be5-9092-b14fdf053dca"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 240f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("23b25016-afc7-4b28-a1ff-814bd1562f4b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 235f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("1040929e-af56-487f-89d3-2968e7d70820"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 350f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("de1a0418-d3f3-4b30-b5ff-be95956ad0c1"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 355f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("b4d2198c-f4af-49bc-8446-bd1e70c18e05"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 360f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("f93e8d6c-4420-41ac-bc6e-f57aff94c8b0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 230f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("899cc737-7e7c-4bd1-9552-acfdf34a00af"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 485f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("36eec0d5-0523-44a6-8bde-1433f26b39fb"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 480f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("dae7989f-5aba-4396-bd6c-8e434cf88425"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 475f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("f1ddd440-3eff-4a06-b35a-5965f6bbcc06"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 470f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("abea596e-53f9-4d9f-b44c-e49bf7467273"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 465f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("26f6f3ca-eec7-4653-b23f-76e10ed12493"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 460f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("520b5435-85dc-49e3-b368-5f44eb9a26e6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 455f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("cce1cafb-ffee-426e-9dfd-a17cde66beeb"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 450f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("a0bd439b-873d-43f2-a4df-940a0e257c1a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 445f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("0d7cbd3e-58cc-4aa8-b9c5-fe56c6300d75"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 440f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("e722a669-5e4b-41c0-a688-ac90a76f4e9a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 435f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("cca8d028-5980-48bf-8be9-b2abadc72d5f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 495f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e59") }
                });

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("04d4388c-7d77-44e3-9f5d-f7eb60081a52"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 430f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("e4336669-a018-480c-9055-2dceb4895c28"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 420f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("3b493200-bc2c-493a-9970-c820f4f60363"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 415f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("94daf8d8-2580-4de3-b812-0ca293fe057f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 410f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("3a2b2bc8-a0cf-4ae3-ad9f-43e4b154d434"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 405f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("7826761d-d704-40db-933c-fb38150a960a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 400f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("ad61e413-42e3-499a-96e6-620648a3880e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 395f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("7b3a4153-5913-4fc9-8cbe-01c8a327b9ab"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 390f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("2bc9954e-23bd-4d62-8216-db7c1cda90f1"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 385f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("f2483c34-5d26-4ba4-a438-bff5ec63d955"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 380f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("727a41b4-f99c-4299-92c9-0dc842a8ca17"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 375f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("87575d2a-a483-48f2-a7ee-1d81e184d7f6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 370f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("729a34fa-a5b0-4b7d-b58c-fce9623de8ea"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 425f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("4eb7b5cb-a487-4df1-bfa2-dbc9f0302cec"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 365f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("ebe9f66d-43b9-4208-b6c5-3d720d3ba537"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 225f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("5c971f6e-6c17-4d29-ae29-7c2e56d98b46"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 215f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("cab7cfbc-be06-4242-9dd1-120dfcc19495"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 95f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("ae15a164-70eb-4ce1-b1d4-367ffbf5fe52"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 90f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("c8919a74-b4e7-479a-949a-9db1ae0102d2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 85f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("0550a6a7-7d50-4859-ba45-fafe17cb0cd8"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 220f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("30939ce4-05da-4831-97d3-f56be3acdbe3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 75f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("95a1bb1c-772d-45b5-97e9-39df09ab8aa5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 70f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("9827efb6-2ba9-44cf-acb4-0d2725ff2619"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 65f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("a328958f-35f0-4f6a-913e-89caac5327d6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 60f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("c398ddaf-4e39-4f5c-ba6e-c1b43e5e6f31"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 55f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("db9cd30d-162c-4a3a-bbb8-2535b6a0f5b6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 50f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("52477b08-f8ef-4220-bfc5-c646f0624f5a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 45f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("aa058741-9640-422b-bdd9-1c001643c0cc"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 40f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("92e9cea7-00a9-4eee-9f37-6c94147efa75"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 35f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("c4265ec5-cd8e-4521-8ed0-4d4f9ee1ad51"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 30f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("7a9cc1db-d6d2-4ad8-bc4e-e49e8b43040e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 25f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("2a79c14e-0898-41f6-b07d-569db0cf08bd"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 20f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("b742a723-e5b0-4d4f-b7fe-4ab7dcb9796b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 15f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("10b15089-08bf-4e2e-a3dc-329f541ceb78"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 10f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("0bda1bf2-47bb-4454-9189-e08c3e158d48"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("909b141c-d440-4d7d-813c-7ba5933ec335"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 100f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("d682e674-d76c-4122-ba39-2caf75085d95"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 105f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("e11b4324-8e54-40fe-a517-541a40ad64b8"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 80f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("b4572948-0c6a-48ec-8b33-774aeec34ac5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 115f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("5c86547e-5c60-485e-b89d-b56bdbc60c4d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 210f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("c64bcfce-052a-4bbc-a52f-bedfa3e5da3b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 205f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("a8ad09e0-9c30-421a-886a-85787d57b187"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 200f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e54") }
                });

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("e55dd401-4895-4f13-89b3-827613faf007"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 195f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("1d59938f-3876-4bc9-87b8-9a919b68078a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 190f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("973ac970-5ee4-440a-a1cb-69684fcd1e67"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 185f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("2b100bc5-fba8-4418-a850-91eeb04475d3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 180f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("7f9f10a5-a3e9-49b8-87e1-3f1c548fd7dc"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 110f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("ce68ed93-bdf5-4071-8679-a59306aa5fab"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 175f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("1cc6c69a-36c8-4719-ad36-b5b9347fbd80"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 170f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("3c73e5c8-c644-49bd-806c-78b4437d819a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("e2dee9ae-c55b-4992-b204-3ca96e11b21f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 165f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("dcd36b96-c4fb-44dd-906d-5fcf1df62641"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 160f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("2d8c3427-75b9-4278-9fd7-a4831a1510a4"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 155f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("c150efc2-cf25-4712-8756-12183643ed50"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 150f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("d3fb6c91-6ff9-4f8b-9641-c13edfece3fa"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 120f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("2e68d6a4-8262-4470-b463-e0c5f904fe62"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 145f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("c9ad62de-5838-4191-8c63-1e59cdd7e705"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 140f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("69202f3e-6421-4a60-9975-2f72bc1398f9"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 125f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("dea5a5ad-16bc-4cc8-88d6-d1b445b59e0e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 135f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("8a66342d-b3ee-415b-b1c5-e22abb78aa58"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 130f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e52") }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AxCode", "CategoryId", "DeletedAt", "Description", "ImageId", "Name", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("8c74fc65-b701-4ade-9f07-7a7a744e2e59"), "LH-10000", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50"), null, "Variant of Product 0", null, "Small", new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e50"), 100f },
                    { new Guid("8c74fc65-b701-4ade-9f17-7a7a744e2e59"), "LH-10001", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50"), null, "Variant of Product 1", null, "Small", new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e50"), 100f },
                    { new Guid("8c74fc65-b701-4ade-9f27-7a7a744e2e59"), "LH-10002", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50"), null, "Variant of Product 2", null, "Small", new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e50"), 100f },
                    { new Guid("8c74fc65-b701-4ade-9f47-7a7a744e2e59"), "LH-10004", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50"), null, "Variant of Product 4", null, "Small", new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e50"), 100f },
                    { new Guid("8c74fc65-b701-4ade-9f97-7a7a744e2e59"), "LH-10009", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50"), null, "Variant of Product 9", null, "Small", new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e50"), 100f },
                    { new Guid("8c74fc65-b701-4ade-9f57-7a7a744e2e59"), "LH-10005", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50"), null, "Variant of Product 5", null, "Small", new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e50"), 100f },
                    { new Guid("8c74fc65-b701-4ade-9f67-7a7a744e2e59"), "LH-10006", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50"), null, "Variant of Product 6", null, "Small", new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e50"), 100f },
                    { new Guid("8c74fc65-b701-4ade-9f87-7a7a744e2e59"), "LH-10008", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50"), null, "Variant of Product 8", null, "Small", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50"), 100f },
                    { new Guid("8c74fc65-b701-4ade-9f37-7a7a744e2e59"), "LH-10003", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50"), null, "Variant of Product 3", null, "Small", new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e50"), 100f },
                    { new Guid("8c74fc65-b701-4ade-9f77-7a7a744e2e59"), "LH-10007", new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50"), null, "Variant of Product 7", null, "Small", new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e50"), 100f }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "BalanceUsed", "CreatedAt", "CustomerId", "DeletedAt", "Discount", "SalesPersonId", "VehicleId" },
                values: new object[] { new Guid("0daec62b-312f-4016-9c5e-a15354259c95"), 0f, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0daec62b-312f-4016-9c5e-a15354259c91"), null, 0f, "0daec62b-312f-4016-9c5e-a15354259c90", new Guid("c7be1d28-2b81-42e9-90e9-5396492a90e0") });

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("4ba5d24e-9b41-44c7-b20b-656781aeafca"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 500f, new Guid("8c74fc65-b701-4ade-9f07-7a7a744e2e59") },
                    { new Guid("4048a18d-c5c1-4e51-bcbc-8e8dfd752a94"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 505f, new Guid("8c74fc65-b701-4ade-9f17-7a7a744e2e59") },
                    { new Guid("00582daf-0c34-44a4-afd5-2e9c1e4937cb"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 510f, new Guid("8c74fc65-b701-4ade-9f27-7a7a744e2e59") },
                    { new Guid("111b1882-21be-44d9-af49-dfa8bdf9da2f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 515f, new Guid("8c74fc65-b701-4ade-9f37-7a7a744e2e59") },
                    { new Guid("d1cf4c11-d376-4067-b592-245347ccff2d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 520f, new Guid("8c74fc65-b701-4ade-9f47-7a7a744e2e59") },
                    { new Guid("2cbfa5cb-e7d6-471a-a171-a675b47572ad"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 525f, new Guid("8c74fc65-b701-4ade-9f57-7a7a744e2e59") },
                    { new Guid("1f99c041-e0af-401b-a2ff-259db8887cb9"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 530f, new Guid("8c74fc65-b701-4ade-9f67-7a7a744e2e59") },
                    { new Guid("0a8bd68b-fecb-4147-90c0-32c6381ff9a5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 535f, new Guid("8c74fc65-b701-4ade-9f77-7a7a744e2e59") },
                    { new Guid("34f2aef2-1299-4dfa-b39e-c58b2eea4d3d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 540f, new Guid("8c74fc65-b701-4ade-9f87-7a7a744e2e59") },
                    { new Guid("2277a0bc-c539-4e6f-9559-c31f0ae9fe44"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 545f, new Guid("8c74fc65-b701-4ade-9f97-7a7a744e2e59") }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "DeletedAt", "OrderId", "ProductId", "PromotionId", "Quantity" },
                values: new object[] { new Guid("0daec62b-312f-4016-9c5e-a15354259c97"), null, new Guid("0daec62b-312f-4016-9c5e-a15354259c95"), new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50"), null, 100f });

            migrationBuilder.InsertData(
                table: "ReturnOrders",
                columns: new[] { "Id", "DeletedAt", "OrderId", "ProductId", "Quantity", "ReturnReason" },
                values: new object[] { new Guid("0daec62b-312f-4016-9c5e-a15354259c96"), null, new Guid("0daec62b-312f-4016-9c5e-a15354259c95"), new Guid("8c74fc65-b701-4ade-9f07-7a7a744e2e59"), 10f, "Expired" });

            migrationBuilder.CreateIndex(
                name: "IX_AssignedRoute_RouteId",
                table: "AssignedRoute",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedRoute_SalesPersonId",
                table: "AssignedRoute",
                column: "SalesPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignStock_ProductId",
                table: "AssignStock",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignStock_TransferId",
                table: "AssignStock",
                column: "TransferId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CreatedById",
                table: "Customers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DiscountId",
                table: "Customers",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PictureId",
                table: "Customers",
                column: "PictureId",
                unique: true,
                filter: "[PictureId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_RouteId",
                table: "Customers",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_LogInformation_ChangedById",
                table: "LogInformation",
                column: "ChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CreatedByid",
                table: "Notifications",
                column: "CreatedByid");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationSettings_UserId",
                table: "NotificationSettings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_PromotionId",
                table: "OrderDetails",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPromos_OrderDetailId",
                table: "OrderPromos",
                column: "OrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPromos_PromoId",
                table: "OrderPromos",
                column: "PromoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SalesPersonId",
                table: "Orders",
                column: "SalesPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_VehicleId",
                table: "Orders",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceHistory_ProductId",
                table: "PriceHistory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ImageId",
                table: "Products",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnOrders_OrderId",
                table: "ReturnOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnOrders_ProductId",
                table: "ReturnOrders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferStocks_CreatedById",
                table: "TransferStocks",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TransferStocks_RouteId",
                table: "TransferStocks",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferStocks_SalesPersonId",
                table: "TransferStocks",
                column: "SalesPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferStocks_VehicleId",
                table: "TransferStocks",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_User_ProfileImageId",
                table: "User",
                column: "ProfileImageId",
                unique: true,
                filter: "[ProfileImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_NotificationId",
                table: "UserNotifications",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_UserId",
                table: "UserNotifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_WasteOrders_OrderId",
                table: "WasteOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_WasteOrders_ProductId",
                table: "WasteOrders",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedRoute");

            migrationBuilder.DropTable(
                name: "AssignStock");

            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "LogInformation");

            migrationBuilder.DropTable(
                name: "MailConfiguration");

            migrationBuilder.DropTable(
                name: "NotificationSettings");

            migrationBuilder.DropTable(
                name: "OrderPromos");

            migrationBuilder.DropTable(
                name: "PriceHistory");

            migrationBuilder.DropTable(
                name: "ReturnOrders");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserNotifications");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "WasteOrders");

            migrationBuilder.DropTable(
                name: "TransferStocks");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ResourceFiles");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
