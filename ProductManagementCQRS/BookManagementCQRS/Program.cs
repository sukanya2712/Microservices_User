using BookManagementCQRS.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookManagementCQRS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ProductDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreCQRSConnection"));
            });
           // builder.Services.AddTransient<IBookServic, BookServic>();

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}