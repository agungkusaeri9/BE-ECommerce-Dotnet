using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNullableInTransactionMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Cities_city_id",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Couriers_courier_id",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Districts_district_id",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_PaymentMethods_payment_method_id",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Provinces_province_id",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Villages_village_id",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "village_id",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "province_id",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "payment_method_id",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "district_id",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "courier_id",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "city_id",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Cities_city_id",
                table: "Transactions",
                column: "city_id",
                principalTable: "Cities",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Couriers_courier_id",
                table: "Transactions",
                column: "courier_id",
                principalTable: "Couriers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Districts_district_id",
                table: "Transactions",
                column: "district_id",
                principalTable: "Districts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_PaymentMethods_payment_method_id",
                table: "Transactions",
                column: "payment_method_id",
                principalTable: "PaymentMethods",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Provinces_province_id",
                table: "Transactions",
                column: "province_id",
                principalTable: "Provinces",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Villages_village_id",
                table: "Transactions",
                column: "village_id",
                principalTable: "Villages",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Cities_city_id",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Couriers_courier_id",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Districts_district_id",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_PaymentMethods_payment_method_id",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Provinces_province_id",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Villages_village_id",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "village_id",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "province_id",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "payment_method_id",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "district_id",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "courier_id",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "city_id",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Cities_city_id",
                table: "Transactions",
                column: "city_id",
                principalTable: "Cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Couriers_courier_id",
                table: "Transactions",
                column: "courier_id",
                principalTable: "Couriers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Districts_district_id",
                table: "Transactions",
                column: "district_id",
                principalTable: "Districts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_PaymentMethods_payment_method_id",
                table: "Transactions",
                column: "payment_method_id",
                principalTable: "PaymentMethods",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Provinces_province_id",
                table: "Transactions",
                column: "province_id",
                principalTable: "Provinces",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Villages_village_id",
                table: "Transactions",
                column: "village_id",
                principalTable: "Villages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
