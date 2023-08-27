using BookStore.User.Context;
using BookStore.User.Interface;
using BookStore.User.Service;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;



namespace BookStore.User
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<UserDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreConnection"));
            });
            builder.Services.AddTransient<IUserRepo, UserRepo>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddCors();
            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "BookStore.User V1", Version = "v1" });

                var securitySchema = new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Using Authorization header with the beare schema",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer",

                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                option.AddSecurityDefinition("Bearer", securitySchema);
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securitySchema , new[] { "Bearer" } }
                });

            });


            // Add MassTransit and RabbitMQ configuration
            //builder.Services.AddMassTransit(x =>
            //{
            //    x.UsingRabbitMq((context, cfg) =>
            //    {
            //        cfg.Host(new Uri("rabbitmq://localhost"));
            //    });

            //});

            //builder.Services.AddMassTransitHostedService();

            //static void ConfigureSwagger(IServiceCollection services)
            //{
            //    services.AddSwaggerGen(c =>
            //    {
            //        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bookstore", Version = "v1" });

            //        var securitySchema = new OpenApiSecurityScheme
            //        {
            //            Description = "Using the Authroziation header with Bearer Schema",
            //            Name = "Authorization",
            //            In = ParameterLocation.Header,
            //            Type = SecuritySchemeType.Http,
            //            Scheme = "bearer",
            //            Reference = new OpenApiReference
            //            {
            //                Type = ReferenceType.SecurityScheme,
            //                Id = "Bearer"
            //            }
            //        };
            //        c.AddSecurityDefinition("Bearer", securitySchema);
            //        c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //    {
            //        { securitySchema,new[] {"Bearer"} }
            //    });
            //    });
            //}


            //JWT Token
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidAudience = builder.Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Key)
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();

            //app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}