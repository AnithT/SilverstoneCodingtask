using Microsoft.EntityFrameworkCore;
using WeatherForecast.Core.Interfaces;
using WeatherForecast.Infrastructure.Data;
using WeatherForecast.Infrastructure.ExceptionMiddlewareHandler;
using WeatherForecast.Infrastructure.Repositories;
using WeatherForecast.Infrastructure.Services;

namespace WeatherForecast.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("allowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            // Add services to the container.
            //builder.Services.AddRazorPages();
            builder.Services.AddDbContext<WeatherForecastContext>(option => option.UseInMemoryDatabase(builder.Configuration.GetConnectionString("WeatherInfoDb")));
            builder.Services.AddControllers();
            builder.Services.AddScoped<IWeatherService, WeatherService>();
            builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();
            app.UseMiddleware<ExceptionMiddleware>();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("allowAll");
            //app.MapRazorPages();
            app.MapControllers();

            app.Run();
        }
    }
}