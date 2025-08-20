
//using Dmart_web.Auth;
//using Dmart_web.Core.Interfaces;
//using Dmart_web.Data.Context;
//using Dmart_web.Data.Repository;
//using Dmart_web.Service;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.OpenApi.Models;
//using System.Text;

//namespace Dmart_web
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            // Controllers
//            builder.Services.AddControllers().AddJsonOptions(x =>
//                {
//                    x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
//                    x.JsonSerializerOptions.WriteIndented = true;
//                });

//            // Swagger setup
//            builder.Services.AddEndpointsApiExplorer();



//            /*
//            //Basic Authentication


//            builder.Services.AddSwaggerGen(c =>
//            {
//                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dmart API", Version = "v1" });

//                // Basic Authentication config
//                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
//                {
//                    Name = "Authorization",
//                    Type = SecuritySchemeType.Http,
//                    Scheme = "basic",
//                    In = ParameterLocation.Header,
//                    Description = "Enter your email and password"
//                });

//                c.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basic" }
//            },
//            new string[] {}
//        }
//    });
//            });
//            */

//            /*
//            //API Key Authentication
//            builder.Services.AddSwaggerGen(c =>

//            {

//                c.SwaggerDoc("v1", new() { Title = "Dmart API", Version = "v1" });

//                // Add API Key header support

//                c.AddSecurityDefinition("ApiKey", new Microsoft.OpenApi.Models.OpenApiSecurityScheme

//                {

//                    Description = "API Key needed to access the endpoints. XApiKey: MySecretApikey",

//                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,

//                    Name = "XApiKey",

//                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,

//                    Scheme = "ApiKeyScheme"

//                });

//                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()

//{

//    {

//        new Microsoft.OpenApi.Models.OpenApiSecurityScheme

//        {

//            Reference = new Microsoft.OpenApi.Models.OpenApiReference

//            {

//                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,

//                Id = "ApiKey"

//            },

//            In = Microsoft.OpenApi.Models.ParameterLocation.Header,

//            Name = "XApiKey",

//        },

//        new List<string>()

//    }

//});

//            });
//            */




//            builder.Services.AddScoped<ICategoryService, CategoryService>();
//            builder.Services.AddScoped<CategoryRepository>();

//            builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
//            builder.Services.AddScoped<SubCategoryRepository>();

//            builder.Services.AddScoped<IProductService, ProductService>();
//            builder.Services.AddScoped<ProductRepository>();

//            builder.Services.AddScoped<ICartService, CartService>();
//            builder.Services.AddScoped<CartRepository>();

//            builder.Services.AddScoped<IUserRepository, UserRepository>();
//            builder.Services.AddScoped<IUserService, UserService>();

//            builder.Services.AddScoped<TokenService>();



//            // DbContext
//            builder.Services.AddDbContext<DmartContext>(options =>
//                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//            /*
//            // Basic Authentication
//            builder.Services.AddAuthentication("BasicAuthentication")
//         .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
//            */


//            var configuration = builder.Configuration;
//            var jwtSettings = builder.Configuration.GetSection("Jwt");
//            var secretKey = jwtSettings["Key"];




//            builder.Services.AddAuthentication(options =>
//            {
//                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//            })
//            .AddJwtBearer(options =>
//            {
//                options.RequireHttpsMetadata = false;
//                options.SaveToken = true;
//                options.TokenValidationParameters = new TokenValidationParameters
//                {
//                    ValidateIssuer = true,
//                    ValidateAudience = true,
//                    ValidateLifetime = true,
//                    ValidateIssuerSigningKey = true,
//                    ValidIssuer = jwtSettings["Issuer"],
//                    ValidAudience = jwtSettings["Audience"],
//                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
//                };
//            });



//            //builder.Services.AddControllers();
//            builder.Services.AddSwaggerGen(c =>
//            {
//                c.SwaggerDoc("v1", new OpenApiInfo
//                {
//                    Title = "Dmart Web API",
//                    Version = "v1"
//                });

//                // JWT Bearer token setup
//                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//                {
//                    Name = "Authorization",
//                    Type = SecuritySchemeType.Http,
//                    Scheme = "Bearer",
//                    BearerFormat = "JWT",
//                    In = ParameterLocation.Header,
//                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below."
//                });

//                c.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type = ReferenceType.SecurityScheme,
//                    Id = "Bearer"
//                }
//            },
//            Array.Empty<string>()
//        }
//    });
//            });


//            builder.Services.AddAuthorization();




//            builder.Services.AddCors(options =>
//            {
//                options.AddPolicy("AllowAll", policy =>
//                {
//                    policy.AllowAnyOrigin()
//                          .AllowAnyMethod()
//                          .AllowAnyHeader();
//                });
//            });




//            //builder.WebHost.ConfigureKestrel(options =>
//            //{
//            //    options.ListenLocalhost(7000); // HTTP
//            //    options.ListenLocalhost(7001, listenOptions =>
//            //    {
//            //        listenOptions.UseHttps(); // HTTPS
//            //    });
//            //});

//            var app = builder.Build();

//            if (app.Environment.IsDevelopment())
//            {
//                app.UseSwagger();
//                app.UseSwaggerUI();
//            }

//            //Api Key Authentication
//            //app.UseMiddleware<ApiKeyHandler>();



//            app.UseCors("AllowAll");

//            app.UseHttpsRedirection();

//            app.UseAuthentication();

//            app.UseAuthorization();

//            app.MapControllers();
//            app.Run();
//        }
//    }
//}

//Basic Authentication
using Dmart_web.Auth;
using Dmart_web.Core.Interfaces;
using Dmart_web.Data.Context;
using Dmart_web.Data.Repository;
using Dmart_web.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Dmart_web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Controllers
            builder.Services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                x.JsonSerializerOptions.WriteIndented = true;
            });

            // Swagger setup
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dmart API", Version = "v1" });

                // Basic Auth
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Enter your username and password"
                });

                // JWT Auth
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' followed by your JWT token"
                });

                // Apply Security Requirements
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basic" }
                        },
                        Array.Empty<string>()
                    },
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            // Register services
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<CategoryRepository>();

            builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
            builder.Services.AddScoped<SubCategoryRepository>();

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ProductRepository>();

            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<CartRepository>();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddScoped<TokenService>();

            // DbContext
            builder.Services.AddDbContext<DmartContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Authentication
            builder.Services.AddAuthentication()
                // JWT Bearer
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    var jwtSettings = builder.Configuration.GetSection("Jwt");
                    var secretKey = jwtSettings["Key"];

                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings["Issuer"],
                        ValidAudience = jwtSettings["Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    };
                })
                // Basic Authentication
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            builder.Services.AddAuthorization();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}

/*
//Jwt authentication
using Dmart_web.Auth;
using Dmart_web.Core.Interfaces;
using Dmart_web.Data.Context;
using Dmart_web.Data.Repository;
using Dmart_web.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Dmart_web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Controllers
            builder.Services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                x.JsonSerializerOptions.WriteIndented = true;
            });

            // DbContext
            builder.Services.AddDbContext<DmartContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Services
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<CategoryRepository>();
            builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
            builder.Services.AddScoped<SubCategoryRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ProductRepository>();
            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<CartRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<TokenService>();

            // JWT Authentication Setup
            var jwtSection = builder.Configuration.GetSection("Jwt");
            //builder.Services.Configure<JwtSettings>(jwtSection); // Optional

            var secretKey = jwtSection["Key"];
            var issuer = jwtSection["Issuer"];
            var audience = jwtSection["Audience"];

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "http://localhost:7000",
            ValidAudience = "http://localhost:7000",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))

        };
    });


            builder.Services.AddAuthorization();

            // Swagger with JWT
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dmart API", Version = "v1" });

                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "Enter JWT Bearer token",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });
            });

            // CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAll");

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
*/


//OAuth Authentication

//using Dmart_web.Auth;
//using Dmart_web.Core.Interfaces;
//using Dmart_web.Data.Context;
//using Dmart_web.Data.Repository;
//using Dmart_web.Service;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication.Google;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.OpenApi.Models;
//using System.Text;

//namespace Dmart_web
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

//            // Controllers
//            builder.Services.AddControllersWithViews().AddJsonOptions(x =>
//            {
//                x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
//                x.JsonSerializerOptions.WriteIndented = true;
//            });

//            // DbContext
//            builder.Services.AddDbContext<DmartContext>(options =>
//                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//            // Services
//            builder.Services.AddScoped<ICategoryService, CategoryService>();
//            builder.Services.AddScoped<CategoryRepository>();
//            builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
//            builder.Services.AddScoped<SubCategoryRepository>();
//            builder.Services.AddScoped<IProductService, ProductService>();
//            builder.Services.AddScoped<ProductRepository>();
//            builder.Services.AddScoped<ICartService, CartService>();
//            builder.Services.AddScoped<CartRepository>();
//            builder.Services.AddScoped<IUserRepository, UserRepository>();
//            builder.Services.AddScoped<IUserService, UserService>();
//            //builder.Services.AddScoped<TokenService>();


//            /*
//            // JWT Authentication Setup
//            var jwtSection = builder.Configuration.GetSection("Jwt");


//            var secretKey = jwtSection["Key"];
//            var issuer = jwtSection["Issuer"];
//            var audience = jwtSection["Audience"];

//            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = "http://localhost:7000",
//            ValidAudience = "http://localhost:7000",
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))

//        };
//    });
//*/

//            //OAuth

//            //builder.Services.AddAuthentication(options =>
//            //{
//            //    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//            //    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
//            //})
//            //.AddCookie()
//            //.AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
//            //{
//            
//            //});
//            builder.Services.AddAuthentication(options =>
//            {
//                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
//            })
//  .AddCookie()
//  .AddGoogle(options =>
//  {
//     
//  });



//            builder.Services.AddAuthorization();

//            builder.Services.AddSwaggerGen(c =>
//            {
//                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dmart API", Version = "v1" });
//            });


//            /*
//            // Swagger with JWT
//            builder.Services.AddSwaggerGen(c =>
//            {
//                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dmart API", Version = "v1" });

//                var jwtSecurityScheme = new OpenApiSecurityScheme
//                {
//                    Scheme = "bearer",
//                    BearerFormat = "JWT",
//                    Name = "Authorization",
//                    In = ParameterLocation.Header,
//                    Type = SecuritySchemeType.Http,
//                    Description = "Enter JWT Bearer token",

//                    Reference = new OpenApiReference
//                    {
//                        Id = JwtBearerDefaults.AuthenticationScheme,
//                        Type = ReferenceType.SecurityScheme
//                    }
//                };

//                c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
//                c.AddSecurityRequirement(new OpenApiSecurityRequirement
//                {
//                    { jwtSecurityScheme, Array.Empty<string>() }
//                });
//            });
//            */

//            // CORS
//            builder.Services.AddCors(options =>
//            {
//                options.AddPolicy("AllowAll", policy =>
//                {
//                    policy.AllowAnyOrigin()
//                          .AllowAnyMethod()
//                          .AllowAnyHeader();
//                });
//            });

//            var app = builder.Build();

//            if (app.Environment.IsDevelopment())
//            {
//                app.UseSwagger();
//                app.UseSwaggerUI();
//            }

//            app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Login}/{action=Index}/{id?}");



//            app.UseCors("AllowAll");

//            app.UseHttpsRedirection();
//            app.UseRouting();
//            app.UseAuthentication();
//            app.UseAuthorization();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllerRoute(
//                    name: "default",
//                    pattern: "{controller=Login}/{action=Index}/{id?}");
//            });
//            app.MapControllers();
//            app.MapGet("/", context =>
//            {
//                context.Response.Redirect("/Login");
//                return Task.CompletedTask;
//            });


//            app.Run();
//        }
//    }
//}



