using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ReadyGo.Domain.Entities.Identity;
using ReadyGo.Persistence;
using ReadyGo.Service.Services;
using ReadyGo.Service.Interfaces;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ReadyGo.Infrastructure.Mapping;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;
using ReadyGo.Service.Repositories.Interfaces;
using ReadyGo.Service.Repositories;
using ReadyGo.Service.Stored_Procedures.Interface;
using ReadyGo.Service.Stored_Procedures;

namespace ReadyGo.Infrastructure.Extension
{
    public static class ConfigureServiceContainer
    {
        public static void AddIdentityService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddIdentity<ApplicationUser, ApplicationRole>((options) => {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
             .AddDefaultTokenProviders();

        }
        public static void AddJwtAuthenticationService(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {

                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };


            });
        }
        public static void AddAutoMapper(this IServiceCollection serviceCollection)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);
        }

        public static void AddScopedServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<UserManager<ApplicationUser>>();
            serviceCollection.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
        }

        public static void AddTransientServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            serviceCollection.AddTransient<IProcedures, Procedures>();
            serviceCollection.AddTransient<IEmailService, EmailService>();
            serviceCollection.AddTransient<IFileService, ImageService>();
            serviceCollection.AddTransient<IPrincipal>(provider => provider.GetService<IHttpContextAccessor>().HttpContext.User);
            serviceCollection.AddTransient<IValidationHelper, ValidationHelper>();
            serviceCollection.AddTransient<IConfigurationService, ConfigurationService>();
            serviceCollection.AddTransient<INotificationService, NotificationService>();
            serviceCollection.AddTransient<IInvoiceService, InvoiceService>();
        }

        public static void AddSingletonServices(this IServiceCollection serviceCollection)
        {
        }

        public static void AddSwaggerOpenAPI(this IServiceCollection serviceCollection)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            serviceCollection.AddSwaggerGen(setupAction =>
            {

                #region Swagger Documents
                var contact = new OpenApiContact()
                {
                    Email = "lighthouse@gmail.com",
                    Name = "Light House",
                    Url = new Uri("https://lighthouse.com/")
                };
                var license = new OpenApiLicense()
                {
                    Name = "MIT License",
                    Url = new Uri("https://opensource.org/licenses/MIT")
                };

                //Add Swagger Document related setting 
                setupAction.SwaggerDoc("mobile", new OpenApiInfo
                {
                    Title = "LightHouse Mobile API",
                    Version = "mobile",
                    Description = "Mobile APIs can only be used by sales person.",
                    Contact = contact,
                    License = license
                });
                setupAction.SwaggerDoc("client", new OpenApiInfo
                {
                    Title = "LightHouse Client API",
                    Version = "client",
                    Description = "Use Client APIs to sync the data from Microsoft Dynamic AX to LightHouse. API key authorization will be used to validate the client APIs.",
                    Contact = contact,
                    License = license
                });

                setupAction.EnableAnnotations();
                #endregion

                #region Bearer Authentication Scheme
                setupAction.AddSecurityDefinition("JWT", new OpenApiSecurityScheme
                {
                    Description = @"Using the Authorization header with the Bearer scheme.",
                    Name = "Mobile APIs Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Name = "JWT",
                            Type = SecuritySchemeType.Http,
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "JWT"
                            }
                        },
                        new string[] { }
                    }
                });
                #endregion

                #region API Authentication Scheme

                setupAction.AddSecurityDefinition("X-API-KEY", new OpenApiSecurityScheme
                {
                    Description = @"Client Api's Authorization header using the Bearer scheme. <br> Enter 'Bearer' [space] and then your API key in the text input below. <br> Example: 'Bearer 12345abcdef'",
                    Name = "X-API-KEY",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Name = "X-API-KEY",
                            Type = SecuritySchemeType.ApiKey,
                            In = ParameterLocation.Header,
                            Scheme = "Bearer",
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "X-API-KEY"
                            }
                        },
                        new string[] { }
                    }
                });
                #endregion

                setupAction.DocInclusionPredicate((docName, apiDesc) => apiDesc.GroupName == docName);
            });
        }

        public static void AddMailSetting(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            //serviceCollection.Configure<MailSettings>(configuration.GetSection("MailSettings"));
        }
    }
}
