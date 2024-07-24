using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadyGo.Persistence.Migrations
{
    public partial class AddCNICField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CNIC",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1570902e-48bb-4b03-850c-8ebd63261e33",
                column: "ConcurrencyStamp",
                value: "ca835112-058e-4ff5-a509-e15be836f674");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "4ce95b9b-0760-4f11-b576-71dfaa053e74",
                column: "ConcurrencyStamp",
                value: "30ad503d-4fb6-419d-8ac2-98aabb65dc1f");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "c057793d-9d0d-4f1d-9fb0-2335480d82e2",
                column: "ConcurrencyStamp",
                value: "517cb66b-0655-406a-8fd7-90f6cbda865c");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "f4ea0102-2c6d-453e-8365-cb45c956cc44",
                column: "ConcurrencyStamp",
                value: "44c8ea79-75ef-4cab-8566-451eeba9f8ed");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "569411c1-88ef-45b6-ab57-79665fbcd9a4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8eb4e7df-eed3-4acb-9706-eb9ba884ffb9", "a9e2776a-1c80-4936-a92f-e93d0382c0b2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNIC",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1570902e-48bb-4b03-850c-8ebd63261e33",
                column: "ConcurrencyStamp",
                value: "21985940-746d-41e1-84ce-19940f2649af");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "4ce95b9b-0760-4f11-b576-71dfaa053e74",
                column: "ConcurrencyStamp",
                value: "25d9ab56-fbee-4031-9f68-3e4374a913ff");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "c057793d-9d0d-4f1d-9fb0-2335480d82e2",
                column: "ConcurrencyStamp",
                value: "c53dcdf4-acbc-4679-8dc5-bf186dd4c30d");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "f4ea0102-2c6d-453e-8365-cb45c956cc44",
                column: "ConcurrencyStamp",
                value: "2da1fbc0-7ff7-44d8-a22e-c9e231129e5f");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "569411c1-88ef-45b6-ab57-79665fbcd9a4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ad471af2-35d6-4d56-9bd2-ac8c3d12b188", "e04934c3-39bf-4473-b2cf-c2918c33b0b1" });
        }
    }
}
