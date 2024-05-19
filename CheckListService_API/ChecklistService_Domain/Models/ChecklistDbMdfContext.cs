namespace ChecklistService_Domain.Models;

using Microsoft.EntityFrameworkCore;

public partial class ChecklistDbMdfContext : DbContext
{
    public ChecklistDbMdfContext()
    {
    }

    public ChecklistDbMdfContext(DbContextOptions<ChecklistDbMdfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Work> Works { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\julio\\source\\repos\\ChecklistService\\CheckListService_API\\ChecklistService_Domain\\Database\\ChecklistDB.mdf;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Work>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Works__3214EC075A5261C6");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Description).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
