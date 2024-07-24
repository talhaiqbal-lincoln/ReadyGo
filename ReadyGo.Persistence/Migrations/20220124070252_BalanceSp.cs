using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadyGo.Persistence.Migrations
{
    public partial class BalanceSp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1570902e-48bb-4b03-850c-8ebd63261e33",
                column: "ConcurrencyStamp",
                value: "fe27cc76-c73c-4d74-b496-61a4011d47ea");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "4ce95b9b-0760-4f11-b576-71dfaa053e74",
                column: "ConcurrencyStamp",
                value: "8b1ec08f-0c24-4914-af09-28199d4f1f4a");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "c057793d-9d0d-4f1d-9fb0-2335480d82e2",
                column: "ConcurrencyStamp",
                value: "056d0deb-356c-4204-a572-ab1dacb2d634");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "f4ea0102-2c6d-453e-8365-cb45c956cc44",
                column: "ConcurrencyStamp",
                value: "17003a97-654d-497d-ba05-8193229c9193");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "569411c1-88ef-45b6-ab57-79665fbcd9a4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2b98aa07-aa3a-47e0-a603-924d261a5e95", "21f9fd77-5407-47a8-9022-5479061dd01b" });


            var createProcSql = @"CREATE PROCEDURE [dbo].[update_balance]  
    @id uniqueidentifier
AS
BEGIN

  UPDATE Customers SET Balance = ((SELECT COALESCE(sum(Total),0)
                        FROM Orders 
                        WHERE CustomerId = @id AND
                              DeletedAt is null and IsMarked = 0
                       ) - (SELECT COALESCE(sum(PaymentReceived),0)
                        FROM Payments 
                        WHERE CustomerId = @id AND
                              DeletedAt is null and IsMarked = 0
                       ))
					   where Id = @id; 

END";
            migrationBuilder.Sql(createProcSql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
            var dropProcSql = "DROP PROC update_balance";
            migrationBuilder.Sql(dropProcSql);
        }
    }
}
