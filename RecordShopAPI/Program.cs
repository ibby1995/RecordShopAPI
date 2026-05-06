
using Microsoft.EntityFrameworkCore;
using RecordShopAPI.Data;
using RecordShopAPI.Repository;
using RecordShopAPI.Services;

namespace RecordShopAPI
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
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<RecordShopContext>(options =>
            {
                if (connectionString == "InMemoryDatabase")
                {
                    options.UseInMemoryDatabase("RecordShop");
                }
                else
                {
                    options.UseSqlServer(connectionString);
                }
            });
            builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
            builder.Services.AddScoped<IAlbumService, AlbumService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            
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
