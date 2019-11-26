using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class fix_length_rows : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Valid",
                table: "CreditCards",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "CreditCardNumber",
                table: "CreditCards",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<string>(
                name: "CVV",
                table: "CreditCards",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Valid",
                table: "CreditCards",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<string>(
                name: "CreditCardNumber",
                table: "CreditCards",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "CVV",
                table: "CreditCards",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 4);
        }
    }
}
