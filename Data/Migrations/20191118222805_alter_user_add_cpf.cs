using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class alter_user_add_cpf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "AspNetUsers",
                maxLength: 8,
                nullable: false,
                defaultValue:00000000);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "AspNetUsers");
        }
    }
}
