using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Configuration;
using Models;
using Services.MongoDBService;
using Microsoft.Extensions.DependencyInjection;


namespace NoteService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var mongoDBConfig = builder.Configuration.GetSection("MongoDB");

            builder.Services.Configure<MongoDBSettings>(mongoDBConfig);
            builder.Services.AddSingleton<MongoDBService>();

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