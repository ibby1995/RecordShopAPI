using Microsoft.EntityFrameworkCore;
using RecordShopAPI.Models;

namespace RecordShopAPI.Data
{
    public class RecordShopContext : DbContext
    {
        public RecordShopContext(DbContextOptions<RecordShopContext> options) : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
    }
}