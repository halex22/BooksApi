using BooksApi.Service;
using BooksApi.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;

namespace BooksApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BooksContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

            builder.Services.AddSwaggerGen(options =>
                options.SwaggerDoc("v3", new OpenApiInfo
                {
                    Title = "Identity API",
                    Version = "v3",
                    Description = "API for managing Users."
                })
            );

            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IBookService, BookService>();

            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();
            app.UseSwagger(c =>
                c.OpenApiVersion = OpenApiSpecVersion.OpenApi3_0
            );
            app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("v3/swagger.json", "Identity API V1")
            );

            // Configure the HTTP request pipeline.

            //builder.Services.AddCors(options =>
            //    options.AddPolicy("AllowAllOrigins",
            //        builder => builder.AllowAnyOrigin()
            //                          .AllowAnyMethod()
            //                          .AllowAnyHeader())
            //);

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
