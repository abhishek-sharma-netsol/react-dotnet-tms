using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance;

public partial class RepositoryDbContext : DbContext
{
    public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TaskItem> TaskItems { get; set; } = null!;
    public virtual DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //if (!optionsBuilder.IsConfigured)
        //{
        //    optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=TMS;Trusted_Connection=True;");
        //}
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.DueDate).HasColumnType("datetime");

            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.User)
                .WithMany(p => p.TaskItems)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_TaskItems_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Email).HasMaxLength(255);

            entity.Property(e => e.UserName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}