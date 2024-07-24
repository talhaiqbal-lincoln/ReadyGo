using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadyGo.Persistence.Migrations
{
    public partial class ProductsAxRemoval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AxCode",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e01"),
                columns: new[] { "AxCode", "ImageId" },
                values: new object[] { "LH-10204", new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e33") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e02"),
                columns: new[] { "AxCode", "ImageId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e04"),
                columns: new[] { "AxCode", "ImageId" },
                values: new object[] { "LH-10206", new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e35") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e05"),
                columns: new[] { "AxCode", "ImageId" },
                values: new object[] { "LH-10207", new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e36") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e11"),
                columns: new[] { "AxCode", "ImageId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e14"),
                columns: new[] { "AxCode", "ImageId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e17"),
                columns: new[] { "AxCode", "ImageId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e20"),
                column: "AxCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e60"),
                column: "AxCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e66"),
                column: "AxCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e72"),
                column: "AxCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e74"),
                column: "AxCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e77"),
                column: "AxCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e79"),
                column: "AxCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e82"),
                column: "AxCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e85"),
                column: "AxCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e87"),
                column: "AxCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e89"),
                columns: new[] { "AxCode", "ImageId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e95"),
                columns: new[] { "AxCode", "ImageId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e98"),
                columns: new[] { "AxCode", "ImageId" },
                values: new object[] { null, null });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AxCode",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e01"),
                columns: new[] { "AxCode", "ImageId" },
                values: new object[] { "LH-10204   ", null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e02"),
                columns: new[] { "AxCode", "ImageId" },
                values: new object[] { "LH-10203", new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e32") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e04"),
                columns: new[] { "AxCode", "ImageId" },
                values: new object[] { "LH-10206   ", null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e05"),
                columns: new[] { "AxCode", "ImageId" },
                values: new object[] { "LH-10207   ", null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e11"),
                columns: new[] { "AxCode", "ImageId" },
                values: new object[] { "LH-10501", new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e43") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e14"),
                columns: new[] { "AxCode", "ImageId" },
                values: new object[] { "LH-10501", new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e43") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e17"),
                columns: new[] { "AxCode", "ImageId" },
                values: new object[] { "LH-10504", new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e46") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e20"),
                column: "AxCode",
                value: "LH-10507");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e60"),
                column: "AxCode",
                value: "LH-10000");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e66"),
                column: "AxCode",
                value: "LH-10010");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e72"),
                column: "AxCode",
                value: "LH-10020");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e74"),
                column: "AxCode",
                value: "LH-10019");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e77"),
                column: "AxCode",
                value: "LH-10420");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e79"),
                column: "AxCode",
                value: "LH-10100");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e82"),
                column: "AxCode",
                value: "LH-10109");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e85"),
                column: "AxCode",
                value: "LH-10102");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e87"),
                column: "AxCode",
                value: "LH-10114");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e89"),
                columns: new[] { "AxCode", "ImageId" },
                values: new object[] { "LH-10105", new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e24") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e95"),
                columns: new[] { "AxCode", "ImageId" },
                values: new object[] { "LH-10202", new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e31") });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e98"),
                columns: new[] { "AxCode", "ImageId" },
                values: new object[] { "LH-10203", new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e32") });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1570902e-48bb-4b03-850c-8ebd63261e33",
                column: "ConcurrencyStamp",
                value: "f5c14523-60c9-4e28-b377-a94b46753f10");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "4ce95b9b-0760-4f11-b576-71dfaa053e74",
                column: "ConcurrencyStamp",
                value: "572cc2c3-e3df-4873-ba09-6818d6587ce1");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "c057793d-9d0d-4f1d-9fb0-2335480d82e2",
                column: "ConcurrencyStamp",
                value: "82c477ea-032e-4681-b4d7-b759da0b9b57");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "f4ea0102-2c6d-453e-8365-cb45c956cc44",
                column: "ConcurrencyStamp",
                value: "706f794b-a181-4323-b567-9b17e6442414");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "569411c1-88ef-45b6-ab57-79665fbcd9a4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7afd8fb6-15d0-4a98-a9db-2778423ef35e", "885e935c-3e07-47e3-b638-90ffb6110d30" });
        }
    }
}
