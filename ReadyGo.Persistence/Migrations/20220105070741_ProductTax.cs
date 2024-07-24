using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadyGo.Persistence.Migrations
{
    public partial class ProductTax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Tax",
                table: "PriceHistory",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.UpdateData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e97"),
                column: "ProductId",
                value: new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e97"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1570902e-48bb-4b03-850c-8ebd63261e33",
                column: "ConcurrencyStamp",
                value: "b4a94163-54dc-401a-9e96-671da99d96b4");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "4ce95b9b-0760-4f11-b576-71dfaa053e74",
                column: "ConcurrencyStamp",
                value: "4f636d10-f81e-4c50-9d2f-542be4e6ebb9");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "c057793d-9d0d-4f1d-9fb0-2335480d82e2",
                column: "ConcurrencyStamp",
                value: "678a3a8f-3b85-4569-894f-ba9449ff0d8c");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "f4ea0102-2c6d-453e-8365-cb45c956cc44",
                column: "ConcurrencyStamp",
                value: "fff6ce9c-2a4c-4d4d-86f0-a47ba6a8ba8c");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "569411c1-88ef-45b6-ab57-79665fbcd9a4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "315751dc-cbb7-499b-ad63-12911db5ae4b", "d1fff807-65ef-46a3-ac31-92635aa4fac5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tax",
                table: "PriceHistory");

            migrationBuilder.UpdateData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e97"),
                column: "ProductId",
                value: new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e99"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1570902e-48bb-4b03-850c-8ebd63261e33",
                column: "ConcurrencyStamp",
                value: "0c32307f-1537-47c6-b853-db044d55a948");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "4ce95b9b-0760-4f11-b576-71dfaa053e74",
                column: "ConcurrencyStamp",
                value: "599d2c62-f5ce-4237-a804-10c1ebc5408b");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "c057793d-9d0d-4f1d-9fb0-2335480d82e2",
                column: "ConcurrencyStamp",
                value: "d70d77cc-25ba-46bb-9e46-0f355efe0697");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "f4ea0102-2c6d-453e-8365-cb45c956cc44",
                column: "ConcurrencyStamp",
                value: "7cc769a6-693d-464b-92b2-c90f01dec18f");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "569411c1-88ef-45b6-ab57-79665fbcd9a4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "15d85dff-9afe-41b4-af18-bd2cbda96788", "df46d54d-4332-40f7-8de6-a05afc599af3" });
        }
    }
}
