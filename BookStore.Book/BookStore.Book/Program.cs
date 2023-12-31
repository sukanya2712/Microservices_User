using BookStore.Book.Context;
using BookStore.Book.Interface;
using BookStore.Book.Service;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Book
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BookDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreBookConnection"));
            });
            builder.Services.AddTransient<IBookRepo, BookRepo>();
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