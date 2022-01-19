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
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Author)
                .WithMany(a => a.Posts)
                .HasForeignKey(e => e.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Email = "someemail@email.com",
                    Password = "da",
                    Id = 1,
                    FirstName = "Lars",
                    LastName = "Jönsson",
                    PhoneNumber = "07899321",
                    UserName = "LasseJJ"
                }
            );
            
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    Content = "<b>This post has been seeded.</b>",
                    Title = "Seeded Post",
                    Id = 1,
                    AuthorId = 1,
                }
            );
        }
    }
}