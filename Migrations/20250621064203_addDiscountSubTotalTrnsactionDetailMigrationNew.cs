using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class addDiscountSubTotalTrnsactionDetailMigrationNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "discount",
                table: "transactionitems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "sub_total",
                table: "transactionitems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "discount",
                table: "transactionitems");

            migrationBuilder.DropColumn(
                name: "sub_total",
                table: "transactionitems");
        }
    }
}
