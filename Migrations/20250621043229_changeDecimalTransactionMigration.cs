using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class changeDecimalTransactionMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionItems_Products_product_id",
                table: "TransactionItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionItems_Transactions_transaction_id",
                table: "TransactionItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionItems",
                table: "TransactionItems");

            migrationBuilder.RenameTable(
                name: "TransactionItems",
                newName: "transactionitems");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionItems_transaction_id",
                table: "transactionitems",
                newName: "IX_transactionitems_transaction_id");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionItems_product_id",
                table: "transactionitems",
                newName: "IX_transactionitems_product_id");

            migrationBuilder.AlterColumn<decimal>(
                name: "total",
                table: "Transactions",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<decimal>(
                name: "sub_total",
                table: "Transactions",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<decimal>(
                name: "shipping_cost",
                table: "Transactions",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<decimal>(
                name: "discount_total",
                table: "Transactions",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transactionitems",
                table: "transactionitems",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_transactionitems_Products_product_id",
                table: "transactionitems",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transactionitems_Transactions_transaction_id",
                table: "transactionitems",
                column: "transaction_id",
                principalTable: "Transactions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactionitems_Products_product_id",
                table: "transactionitems");

            migrationBuilder.DropForeignKey(
                name: "FK_transactionitems_Transactions_transaction_id",
                table: "transactionitems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transactionitems",
                table: "transactionitems");

            migrationBuilder.RenameTable(
                name: "transactionitems",
                newName: "TransactionItems");

            migrationBuilder.RenameIndex(
                name: "IX_transactionitems_transaction_id",
                table: "TransactionItems",
                newName: "IX_TransactionItems_transaction_id");

            migrationBuilder.RenameIndex(
                name: "IX_transactionitems_product_id",
                table: "TransactionItems",
                newName: "IX_TransactionItems_product_id");

            migrationBuilder.AlterColumn<decimal>(
                name: "total",
                table: "Transactions",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "sub_total",
                table: "Transactions",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "shipping_cost",
                table: "Transactions",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<decimal>(
                name: "discount_total",
                table: "Transactions",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionItems",
                table: "TransactionItems",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionItems_Products_product_id",
                table: "TransactionItems",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionItems_Transactions_transaction_id",
                table: "TransactionItems",
                column: "transaction_id",
                principalTable: "Transactions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
