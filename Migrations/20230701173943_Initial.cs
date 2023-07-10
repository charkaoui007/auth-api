using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace AuthenticationAndAuthorization.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tbl_Category",
                columns: table => new
                {
                    ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Category", x => x.ID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tbl_User",
                columns: table => new
                {
                    EmailId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Designation = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_User", x => x.EmailId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tbl_Vendor",
                columns: table => new
                {
                    ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    VendorCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    VendorName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    VendorPhone = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    VendorEmail = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Vendor", x => x.ID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tbl_Product",
                columns: table => new
                {
                    ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProductCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ProductName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Categoryid = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Price = table.Column<double>(type: "double", nullable: true),
                    StkQty = table.Column<double>(type: "double", nullable: true),
                    VendorID = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tbl_Product_Tbl_Category",
                        column: x => x.Categoryid,
                        principalTable: "Tbl_Category",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Tbl_Product_Tbl_Vendor",
                        column: x => x.VendorID,
                        principalTable: "Tbl_Vendor",
                        principalColumn: "ID");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Product_Categoryid",
                table: "Tbl_Product",
                column: "Categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Product_VendorID",
                table: "Tbl_Product",
                column: "VendorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Product");

            migrationBuilder.DropTable(
                name: "Tbl_User");

            migrationBuilder.DropTable(
                name: "Tbl_Category");

            migrationBuilder.DropTable(
                name: "Tbl_Vendor");
        }
    }
}
