using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartPoultry.Migrations
{
    public partial class PurchaseModelChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "PurchaseLineItems");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "PurchaseLineItems");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Purchases",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "PaidAmount",
                table: "Purchases",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "DueAmount",
                table: "Purchases",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<decimal>(
                name: "Average",
                table: "PurchaseLineItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "PurchaseLineItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "PurchaseLineItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "PurchaseLineItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Average",
                table: "PurchaseLineItems");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "PurchaseLineItems");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "PurchaseLineItems");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "PurchaseLineItems");

            migrationBuilder.AlterColumn<double>(
                name: "TotalAmount",
                table: "Purchases",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "PaidAmount",
                table: "Purchases",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "DueAmount",
                table: "Purchases",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "PurchaseLineItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "UnitPrice",
                table: "PurchaseLineItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
