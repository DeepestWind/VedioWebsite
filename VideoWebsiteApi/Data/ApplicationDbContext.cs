using Microsoft.EntityFrameworkCore;
using VideoWebsiteApi.Models;

namespace VideoWebsiteApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Video> Videos { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Video>()
           .Property(v => v.VideoId)
           .ValueGeneratedOnAdd(); // 确保ID值由数据库自动生成
        }
            //还可以在此设置额外的数据库关系
    }
}
