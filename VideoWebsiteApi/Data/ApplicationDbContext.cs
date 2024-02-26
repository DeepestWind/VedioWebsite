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

        //还可以在此设置额外的数据库关系
    }
}
