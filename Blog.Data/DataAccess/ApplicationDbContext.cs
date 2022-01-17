using System.Collections.Generic;
using Blog.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(new List<Post>
            {
                new Post{Content = "Some post text" , Id = 1 , Title = "Test Post"},
                new Post{Content = "Some post text 2" , Id = 2 , Title = "Test Post 2"}
            });
        }
    }
}