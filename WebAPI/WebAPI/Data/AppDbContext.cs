using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        
        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) 
        {
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDb"));
        }

        public DbSet<AudioModel> Audios { get; set; }
    }
}
