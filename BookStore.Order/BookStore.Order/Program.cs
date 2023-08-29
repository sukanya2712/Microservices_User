using BookStore.Order.Context;
using BookStore.Order.Interface;
using BookStore.Order.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace BookStore.Order
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<OrderDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreOrderConnection"));
            });
            builder.Services.AddTransient<IBookServic, BookServic>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IOrderService, OrderService>();

            //Adding authorization 
            builder.Services.AddSwaggerGen(option => { option.SwaggerDoc("v1", new OpenApiInfo { Title = "BookStore.Orders V1", Version = "v1" }); var securitySchema = new OpenApiSecurityScheme { In = ParameterLocation.Header, Description = "Using Authorization header with the beare schema", Name = "Authorization", Type = SecuritySchemeType.Http, BearerFormat = "JWT", Scheme = "Bearer", Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } }; option.AddSecurityDefinition("Bearer", securitySchema); option.AddSecurityRequirement(new OpenApiSecurityRequirement { { securitySchema, new[] { "Bearer" } } }); });
            //add url 
            //builder.Services.AddHttpClient("bookservice", option =>
            //{
            //    option.BaseAddress = new Uri(builder.Configuration["BaseURL:Book"]);
            //});
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}