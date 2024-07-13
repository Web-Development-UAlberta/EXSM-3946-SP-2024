using DotNetAPIDemo.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Post> People { get; set; }
    public virtual DbSet<Comment> Jobs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*
        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasData(new[]
            {
                new Job() { ID = -1, Name = "Bus Driver" },
                new Job() { ID = -2, Name = "Software Developer" },
                new Job() { ID = -3, Name = "Teacher" },
                new Job() { ID = -4, Name = "Nurse" },
                new Job() { ID = -5, Name = "Doctor" },
                new Job() { ID = -6, Name = "Police Officer" },
                new Job() { ID = -7, Name = "Firefighter" },
                new Job() { ID = -8, Name = "Engineer" },
                new Job() { ID = -9, Name = "Chef" },
                new Job() { ID = -10, Name = "Lawyer" }
            });
        });
        */

        modelBuilder.Entity<Comment>(entity => // A Person
        {
            entity.HasOne(child => child.Post) // Has One Job
                .WithMany(parent => parent.Comments) // With Many People
                .HasForeignKey(child => child.PostID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName($"FK_{nameof(Comment)}_{nameof(Post)}");

            entity.HasIndex(entity => entity.PostID)
                .HasDatabaseName($"FK_{nameof(Comment)}_{nameof(Post)}");
            /*
                        entity.HasData(
                            new[]
                            {
                                new Person() { ID = -1, FirstName = "John", LastName = "Doe", JobID = -1 },
                                new Person() { ID = -2, FirstName = "Jane", LastName = "Doe", JobID = -1 },
                                new Person() { ID = -3, FirstName = "James", LastName = "Smith", JobID = -2 },
                                new Person() { ID = -4, FirstName = "Mary", LastName = "Johnson", JobID = -3 },
                                new Person() { ID = -5, FirstName = "Robert", LastName = "Williams", JobID = -4 },
                                new Person() { ID = -6, FirstName = "Patricia", LastName = "Brown", JobID = -5 },
                                new Person() { ID = -7, FirstName = "Michael", LastName = "Jones", JobID = -6 },
                                new Person() { ID = -8, FirstName = "Linda", LastName = "Miller", JobID = -7 },
                                new Person() { ID = -9, FirstName = "William", LastName = "Davis", JobID = -8 },
                                new Person() { ID = -10, FirstName = "Elizabeth", LastName = "Garcia", JobID = -9 },
                                new Person() { ID = -11, FirstName = "David", LastName = "Rodriguez", JobID = -10 },
                                new Person() { ID = -12, FirstName = "Barbara", LastName = "Wilson", JobID = -1 },
                                new Person() { ID = -13, FirstName = "Richard", LastName = "Martinez", JobID = -2 },
                                new Person() { ID = -14, FirstName = "Susan", LastName = "Anderson", JobID = -3 },
                                new Person() { ID = -15, FirstName = "Joseph", LastName = "Taylor", JobID = -4 },
                                new Person() { ID = -16, FirstName = "Jessica", LastName = "Thomas", JobID = -5 },
                                new Person() { ID = -17, FirstName = "Thomas", LastName = "Jackson", JobID = -6 },
                                new Person() { ID = -18, FirstName = "Sarah", LastName = "White", JobID = -7 },
                                new Person() { ID = -19, FirstName = "Charles", LastName = "Harris", JobID = -8 },
                                new Person() { ID = -20, FirstName = "Karen", LastName = "Martin", JobID = -9 },
                                new Person() { ID = -21, FirstName = "Christopher", LastName = "Thompson", JobID = -10 },
                                new Person() { ID = -22, FirstName = "Nancy", LastName = "Garcia", JobID = -1 },
                                new Person() { ID = -23, FirstName = "Daniel", LastName = "Martinez", JobID = -2 },
                                new Person() { ID = -24, FirstName = "Lisa", LastName = "Robinson", JobID = -3 },
                                new Person() { ID = -25, FirstName = "Matthew", LastName = "Clark", JobID = -4 },
                                new Person() { ID = -26, FirstName = "Betty", LastName = "Rodriguez", JobID = -5 },
                                new Person() { ID = -27, FirstName = "Anthony", LastName = "Lewis", JobID = -6 },
                                new Person() { ID = -28, FirstName = "Dorothy", LastName = "Lee", JobID = -7 },
                                new Person() { ID = -29, FirstName = "Andrew", LastName = "Walker", JobID = -8 },
                                new Person() { ID = -30, FirstName = "Margaret", LastName = "Hall", JobID = -9 }
                            }
                        );
                        */
        });

        base.OnModelCreating(modelBuilder);
    }
}
