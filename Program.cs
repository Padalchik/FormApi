using FormApi.Abstractions;
using FormApi.Repositories;
using FormApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace FormApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DataBaseConnectionString"));
            });

            builder.Services.AddScoped<ICandidatesService, CandidatesService>();
            builder.Services.AddScoped<ICandidatesRepository, CandidatesRepository>();

            builder.Services.AddScoped<IFormService, FormService>();
            builder.Services.AddScoped<IFormRepository, FormRepository>();

            builder.Services.AddScoped<IPhoneRecordService, PhoneRecordService>();
            builder.Services.AddScoped<IPhoneRecordRepository, PhoneRecordRepository>();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.ExampleFilters();
            });
            builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();

            builder.Services.AddApiVersioning();

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
