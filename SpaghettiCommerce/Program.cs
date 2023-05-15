
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using SpaghettiCommerce.Application;
using SpaghettiCommerce.Infrastructure.Data;

namespace SpaghettiCommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            builder.Services.AddSingleton<IOrderService, OrderService>();
            builder.Services.AddSingleton<IProductService, ProductService>();
            builder.Services.AddSingleton<ICartService, CartService>();
            builder.Services.AddSingleton<ICustomersService, CustomersService>();

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