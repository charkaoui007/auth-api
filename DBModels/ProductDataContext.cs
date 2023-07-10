using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAndAuthorization.DBModels
{
    public partial class ProductDataContext : DbContext
    {
        public ProductDataContext(DbContextOptions<ProductDataContext> options) : base(options)
        {
        }

        public virtual DbSet<TblCategory> TblCategories { get; set; }
        public virtual DbSet<TblProduct> TblProducts { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }
        public virtual DbSet<TblVendor> TblVendors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Entity configurations

            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.ToTable("Tbl_Category");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ID");
                entity.Property(e => e.CategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.ToTable("Tbl_Product");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ID");
                entity.Property(e => e.Categoryid).HasColumnType("numeric(18, 0)");
                entity.Property(e => e.ProductCode).HasMaxLength(50);
                entity.Property(e => e.ProductName).HasMaxLength(100);
                entity.Property(e => e.VendorId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("VendorID");

                entity.HasOne(d => d.Category).WithMany(p => p.TblProducts)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("FK_Tbl_Product_Tbl_Category");

                entity.HasOne(d => d.Vendor).WithMany(p => p.TblProducts)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("FK_Tbl_Product_Tbl_Vendor");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.EmailId);

                entity.ToTable("Tbl_User");

                entity.Property(e => e.EmailId).HasMaxLength(50);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.Designation).HasMaxLength(50);
                entity.Property(e => e.FullName).HasMaxLength(50);
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ID");
                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<TblVendor>(entity =>
            {
                entity.ToTable("Tbl_Vendor");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ID");
                entity.Property(e => e.VendorCode).HasMaxLength(50);
                entity.Property(e => e.VendorEmail).HasMaxLength(100);
                entity.Property(e => e.VendorName).HasMaxLength(100);
                entity.Property(e => e.VendorPhone).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
