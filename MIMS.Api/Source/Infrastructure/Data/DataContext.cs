using Microsoft.EntityFrameworkCore;
using MIMS.Api.Source.Domain.Entiities;

namespace MIMS.Api.Source.Infrastructure.Data;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Packaging> Packagings { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Items__727E83EB024FF4DC");

            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.ItemName).HasMaxLength(255);
            entity.Property(e => e.PackagingId).HasColumnName("PackagingID");

            entity.HasOne(d => d.Packaging).WithMany(p => p.Items)
                .HasForeignKey(d => d.PackagingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Item_Packaging");
        });

        modelBuilder.Entity<Packaging>(entity =>
        {
            entity.HasKey(e => e.PackagingId).HasName("PK__Packagin__BD507F589E7FEFB8");

            entity.ToTable("Packaging");

            entity.Property(e => e.PackagingId).HasColumnName("PackagingID");
            entity.Property(e => e.PackagingType).HasMaxLength(50);
            entity.Property(e => e.ParentPackagingId).HasColumnName("ParentPackagingID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.ParentPackaging).WithMany(p => p.InverseParentPackaging)
                .HasForeignKey(d => d.ParentPackagingId)
                .HasConstraintName("FK_Packaging_ParentPackaging");

            entity.HasOne(d => d.Product).WithMany(p => p.Packagings)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Packaging_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6ED77E062F0");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0707EC1835");

            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
