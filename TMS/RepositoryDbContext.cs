namespace Infrastructure;

public partial class RepositoryDbContext : DbContext
{
    public RepositoryDbContext()
    {
    }

    public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TaskItem> TaskItems { get; set; } = null!;
    public virtual DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //        if (!optionsBuilder.IsConfigured)
        //        {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=TMS;Trusted_Connection=True;");
        //        }
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
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.Email).HasMaxLength(255);

            entity.Property(e => e.UserName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}