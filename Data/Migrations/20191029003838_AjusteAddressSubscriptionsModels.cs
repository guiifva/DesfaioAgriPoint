using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AjusteAddressSubscriptionsModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_SubscriptionPlanId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "PlanMonths",
                table: "SubscriptionsPlans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PlanRenewalDate",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Addresses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SubscriptionPlanId",
                table: "Orders",
                column: "SubscriptionPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_SubscriptionPlanId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PlanMonths",
                table: "SubscriptionsPlans");

            migrationBuilder.DropColumn(
                name: "PlanRenewalDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Addresses");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SubscriptionPlanId",
                table: "Orders",
                column: "SubscriptionPlanId",
                unique: true);
        }
    }
}
