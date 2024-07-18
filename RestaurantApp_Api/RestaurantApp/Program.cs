using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestaurantApp.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder => builder.WithOrigins("http://localhost:8080")
                                  .AllowAnyHeader()
                                  .AllowAnyMethod());
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var provider = builder.Services.BuildServiceProvider();
        var config = provider.GetService<IConfiguration>();
        builder.Services.AddDbContext<TestDbContext>(item => item.UseSqlServer(config.GetConnectionString("dbcs")));

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors("AllowSpecificOrigin");

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
