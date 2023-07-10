﻿// <auto-generated />
using System;
using AuthenticationAndAuthorization.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AuthenticationAndAuthorization.Migrations
{
    [DbContext(typeof(ProductDataContext))]
    partial class ProductDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AuthenticationAndAuthorization.DBModels.TblCategory", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(18, 0)")
                        .HasColumnName("ID");

                    b.Property<string>("CategoryName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Tbl_Category", (string)null);
                });

            modelBuilder.Entity("AuthenticationAndAuthorization.DBModels.TblProduct", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(18, 0)")
                        .HasColumnName("ID");

                    b.Property<decimal?>("Categoryid")
                        .HasColumnType("numeric(18, 0)");

                    b.Property<double?>("Price")
                        .HasColumnType("double");

                    b.Property<string>("ProductCode")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ProductName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<double?>("StkQty")
                        .HasColumnType("double");

                    b.Property<decimal?>("VendorId")
                        .HasColumnType("numeric(18, 0)")
                        .HasColumnName("VendorID");

                    b.HasKey("Id");

                    b.HasIndex("Categoryid");

                    b.HasIndex("VendorId");

                    b.ToTable("Tbl_Product", (string)null);
                });

            modelBuilder.Entity("AuthenticationAndAuthorization.DBModels.TblUser", b =>
                {
                    b.Property<string>("EmailId")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Designation")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FullName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(18, 0)")
                        .HasColumnName("ID");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("EmailId");

                    b.ToTable("Tbl_User", (string)null);
                });

            modelBuilder.Entity("AuthenticationAndAuthorization.DBModels.TblVendor", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(18, 0)")
                        .HasColumnName("ID");

                    b.Property<string>("VendorCode")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("VendorEmail")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("VendorName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("VendorPhone")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Tbl_Vendor", (string)null);
                });

            modelBuilder.Entity("AuthenticationAndAuthorization.DBModels.TblProduct", b =>
                {
                    b.HasOne("AuthenticationAndAuthorization.DBModels.TblCategory", "Category")
                        .WithMany("TblProducts")
                        .HasForeignKey("Categoryid")
                        .HasConstraintName("FK_Tbl_Product_Tbl_Category");

                    b.HasOne("AuthenticationAndAuthorization.DBModels.TblVendor", "Vendor")
                        .WithMany("TblProducts")
                        .HasForeignKey("VendorId")
                        .HasConstraintName("FK_Tbl_Product_Tbl_Vendor");

                    b.Navigation("Category");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("AuthenticationAndAuthorization.DBModels.TblCategory", b =>
                {
                    b.Navigation("TblProducts");
                });

            modelBuilder.Entity("AuthenticationAndAuthorization.DBModels.TblVendor", b =>
                {
                    b.Navigation("TblProducts");
                });
#pragma warning restore 612, 618
        }
    }
}