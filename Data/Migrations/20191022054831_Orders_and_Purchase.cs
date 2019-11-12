using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Orders_and_Purchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCard_AspNetUsers_UserId",
                table: "CreditCard");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CreditCard_CreditCardId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreditCard",
                table: "CreditCard");

            migrationBuilder.RenameTable(
                name: "CreditCard",
                newName: "CreditCards");

            migrationBuilder.RenameIndex(
                name: "IX_CreditCard_UserId",
                table: "CreditCards",
                newName: "IX_CreditCards_UserId");

            migrationBuilder.AddColumn<long>(
                name: "SubscriptionPlanId",
                table: "Orders",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "Valid",
                table: "CreditCards",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreditCardNumber",
                table: "CreditCards",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreditCards",
                table: "CreditCards",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SubscriptionPlanId",
                table: "Orders",
                column: "SubscriptionPlanId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCards_AspNetUsers_UserId",
                table: "CreditCards",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CreditCards_CreditCardId",
                table: "Orders",
                column: "CreditCardId",
                principalTable: "CreditCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_SubscriptionsPlans_SubscriptionPlanId",
                table: "Orders",
                column: "SubscriptionPlanId",
                principalTable: "SubscriptionsPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCards_AspNetUsers_UserId",
                table: "CreditCards");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CreditCards_CreditCardId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_SubscriptionsPlans_SubscriptionPlanId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SubscriptionPlanId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreditCards",
                table: "CreditCards");

            migrationBuilder.DropColumn(
                name: "SubscriptionPlanId",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "CreditCards",
                newName: "CreditCard");

            migrationBuilder.RenameIndex(
                name: "IX_CreditCards_UserId",
                table: "CreditCard",
                newName: "IX_CreditCard_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Valid",
                table: "CreditCard",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreditCardNumber",
                table: "CreditCard",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 16);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreditCard",
                table: "CreditCard",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCard_AspNetUsers_UserId",
                table: "CreditCard",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CreditCard_CreditCardId",
                table: "Orders",
                column: "CreditCardId",
                principalTable: "CreditCard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
