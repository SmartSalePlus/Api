using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSaleApi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CountInPackage",
                table: "Products",
                newName: "InPackage");

            migrationBuilder.AlterColumn<int>(
                name: "TotalWithDiscount",
                table: "Invoices",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<int>(
                name: "Total",
                table: "Invoices",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<int>(
                name: "Discount",
                table: "Invoices",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<int>(
                name: "Total",
                table: "InvoiceDetails",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<int>(
                name: "InPackage",
                table: "InvoiceDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InPackage",
                table: "InvoiceDetails");

            migrationBuilder.RenameColumn(
                name: "InPackage",
                table: "Products",
                newName: "CountInPackage");

            migrationBuilder.AlterColumn<double>(
                name: "TotalWithDiscount",
                table: "Invoices",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<double>(
                name: "Total",
                table: "Invoices",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<double>(
                name: "Discount",
                table: "Invoices",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<double>(
                name: "Total",
                table: "InvoiceDetails",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
