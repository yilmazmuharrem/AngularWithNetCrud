using Microsoft.EntityFrameworkCore;
using MyCrudProject.API.Models.Domain;

namespace MyCrudProject.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
