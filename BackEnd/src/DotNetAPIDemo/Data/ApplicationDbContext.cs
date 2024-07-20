using DotNetAPIDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetAPIDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>().HasData(
                new Post { ID = -1, Title = "A Cool Post", Content = "This is a cool post." },
                new Post { ID = -2, Title = "A Hot Post", Content = "This is a hot post." },
                new Post { ID = -3, Title = "A Cold Post", Content = "This is a cold post." },
                new Post { ID = -4, Title = "A Warm Post", Content = "This is a warm post." },
                new Post { ID = -5, Title = "A Dry Post", Content = "This is a dry post." }
            );

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasOne(c => c.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(c => c.PostID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName($"FK_{nameof(Comment)}_{nameof(Post)}");

                entity.HasIndex(e => e.PostID)
                    .HasDatabaseName($"IX_{nameof(Comment)}_{nameof(Post)}");

                entity.HasData(
                    new Comment { ID = -1, PostID = -1, Author = "John Doe", Text = "Wow I didn't think a post could be so cool." },
                    new Comment { ID = -2, PostID = -1, Author = "Jane Doe", Text = "I agree with John, this post is cool." },
                    new Comment { ID = -3, PostID = -2, Author = "John Doe", Text = "Wow I didn't think a post could be so hot." },
                    new Comment { ID = -4, PostID = -2, Author = "Jane Doe", Text = "I agree with John, this post is hot." },
                    new Comment { ID = -5, PostID = -3, Author = "John Doe", Text = "Wow I didn't think a post could be so cold." },
                    new Comment { ID = -6, PostID = -3, Author = "Jane Doe", Text = "I agree with John, this post is cold." },
                    new Comment { ID = -7, PostID = -4, Author = "John Doe", Text = "Wow I didn't think a post could be so warm." },
                    new Comment { ID = -8, PostID = -4, Author = "Jane Doe", Text = "I agree with John, this post is warm." },
                    new Comment { ID = -9, PostID = -5, Author = "John Doe", Text = "Wow I didn't think a post could be so dry." },
                    new Comment { ID = -10, PostID = -5, Author = "Jane Doe", Text = "I agree with John, this post is dry." }
                );
            });
        }
    }
}