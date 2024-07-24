using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadyGo.Persistence.Migrations
{
    public partial class PromoProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Promotions]", true);
            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("00582daf-0c34-44a4-afd5-2e9c1e4937cb"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("04d4388c-7d77-44e3-9f5d-f7eb60081a52"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0550a6a7-7d50-4859-ba45-fafe17cb0cd8"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0a8bd68b-fecb-4147-90c0-32c6381ff9a5"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0bda1bf2-47bb-4454-9189-e08c3e158d48"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0cb80fd4-8965-45e2-9600-0189b3b08654"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0d7cbd3e-58cc-4aa8-b9c5-fe56c6300d75"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0ea3b60f-cee1-463e-87c9-c15a8281b99c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1040929e-af56-487f-89d3-2968e7d70820"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("10b15089-08bf-4e2e-a3dc-329f541ceb78"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("111b1882-21be-44d9-af49-dfa8bdf9da2f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("116d0215-2c7c-4d34-9b27-a083d9eeac00"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1cc6c69a-36c8-4719-ad36-b5b9347fbd80"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1d59938f-3876-4bc9-87b8-9a919b68078a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1f99c041-e0af-401b-a2ff-259db8887cb9"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("219baec3-7251-4055-b3fa-a31ff4158321"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2277a0bc-c539-4e6f-9559-c31f0ae9fe44"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("23b25016-afc7-4b28-a1ff-814bd1562f4b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("25d2424c-8d1c-4106-a982-f20c38085590"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("26f6f3ca-eec7-4653-b23f-76e10ed12493"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2a79c14e-0898-41f6-b07d-569db0cf08bd"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2b100bc5-fba8-4418-a850-91eeb04475d3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2b31f9d7-0572-410e-90ce-8529505a15b3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2bc9954e-23bd-4d62-8216-db7c1cda90f1"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2cbfa5cb-e7d6-471a-a171-a675b47572ad"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2d8c3427-75b9-4278-9fd7-a4831a1510a4"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2e68d6a4-8262-4470-b463-e0c5f904fe62"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2ff30ecf-92da-40f0-8e7c-7bab7bbef0da"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("30939ce4-05da-4831-97d3-f56be3acdbe3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("34f2aef2-1299-4dfa-b39e-c58b2eea4d3d"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("36eec0d5-0523-44a6-8bde-1433f26b39fb"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3a2b2bc8-a0cf-4ae3-ad9f-43e4b154d434"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3b493200-bc2c-493a-9970-c820f4f60363"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3c73e5c8-c644-49bd-806c-78b4437d819a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3cedc5a8-67f7-4eda-9047-7ba18db27d3f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("401919b7-23e9-4e52-afa2-8c2597e3f3d1"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4048a18d-c5c1-4e51-bcbc-8e8dfd752a94"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4ba5d24e-9b41-44c7-b20b-656781aeafca"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4e627e55-6ad5-47d4-beca-64ea3595e1b0"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4eb7b5cb-a487-4df1-bfa2-dbc9f0302cec"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("501c6238-8fbd-4ec3-818a-2b1f6d0ffde8"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("520b5435-85dc-49e3-b368-5f44eb9a26e6"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("52477b08-f8ef-4220-bfc5-c646f0624f5a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("5c86547e-5c60-485e-b89d-b56bdbc60c4d"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("5c971f6e-6c17-4d29-ae29-7c2e56d98b46"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("69202f3e-6421-4a60-9975-2f72bc1398f9"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("727a41b4-f99c-4299-92c9-0dc842a8ca17"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("729a34fa-a5b0-4b7d-b58c-fce9623de8ea"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7301eb65-53cd-45ba-9cf4-1101d8c3fcb3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7826761d-d704-40db-933c-fb38150a960a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7a9cc1db-d6d2-4ad8-bc4e-e49e8b43040e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b3a4153-5913-4fc9-8cbe-01c8a327b9ab"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7f1f7386-39e3-4b90-aad8-8381604df538"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7f9f10a5-a3e9-49b8-87e1-3f1c548fd7dc"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("87575d2a-a483-48f2-a7ee-1d81e184d7f6"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("899cc737-7e7c-4bd1-9552-acfdf34a00af"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8a66342d-b3ee-415b-b1c5-e22abb78aa58"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("909b141c-d440-4d7d-813c-7ba5933ec335"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("92c6a1ee-19c1-4617-83c8-fdde5eeb518f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("92e9cea7-00a9-4eee-9f37-6c94147efa75"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("94daf8d8-2580-4de3-b812-0ca293fe057f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("95a1bb1c-772d-45b5-97e9-39df09ab8aa5"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("973ac970-5ee4-440a-a1cb-69684fcd1e67"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("974e04d6-644e-4a88-bb12-d2973d76fefe"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9827efb6-2ba9-44cf-acb4-0d2725ff2619"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9aea72d0-7f48-4bea-a496-ebcb96b5099b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9d50abd4-5532-498b-aae9-56a5f3f33b03"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a0bd439b-873d-43f2-a4df-940a0e257c1a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a328958f-35f0-4f6a-913e-89caac5327d6"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a4953c00-b252-4be5-9092-b14fdf053dca"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a8ad09e0-9c30-421a-886a-85787d57b187"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("aa058741-9640-422b-bdd9-1c001643c0cc"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("abea596e-53f9-4d9f-b44c-e49bf7467273"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ad61e413-42e3-499a-96e6-620648a3880e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ae15a164-70eb-4ce1-b1d4-367ffbf5fe52"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b4572948-0c6a-48ec-8b33-774aeec34ac5"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b4d2198c-f4af-49bc-8446-bd1e70c18e05"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b742a723-e5b0-4d4f-b7fe-4ab7dcb9796b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("bb12b220-ac85-4982-9eb7-7c00c06bfabd"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c150efc2-cf25-4712-8756-12183643ed50"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c398ddaf-4e39-4f5c-ba6e-c1b43e5e6f31"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c4265ec5-cd8e-4521-8ed0-4d4f9ee1ad51"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c4589a1d-4b28-4ddb-ab31-628b66b2bf32"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c64bcfce-052a-4bbc-a52f-bedfa3e5da3b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c8919a74-b4e7-479a-949a-9db1ae0102d2"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c9ad62de-5838-4191-8c63-1e59cdd7e705"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("cab7cfbc-be06-4242-9dd1-120dfcc19495"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("cca8d028-5980-48bf-8be9-b2abadc72d5f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("cce1cafb-ffee-426e-9dfd-a17cde66beeb"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("cdc9e2ab-16f0-47ef-9493-1ea1d531305e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ce68ed93-bdf5-4071-8679-a59306aa5fab"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d1cf4c11-d376-4067-b592-245347ccff2d"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d3fb6c91-6ff9-4f8b-9641-c13edfece3fa"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d682e674-d76c-4122-ba39-2caf75085d95"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("dae7989f-5aba-4396-bd6c-8e434cf88425"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("db9cd30d-162c-4a3a-bbb8-2535b6a0f5b6"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("dcd36b96-c4fb-44dd-906d-5fcf1df62641"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("de1a0418-d3f3-4b30-b5ff-be95956ad0c1"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("dea5a5ad-16bc-4cc8-88d6-d1b445b59e0e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e11b4324-8e54-40fe-a517-541a40ad64b8"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e2dee9ae-c55b-4992-b204-3ca96e11b21f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e4336669-a018-480c-9055-2dceb4895c28"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e55dd401-4895-4f13-89b3-827613faf007"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e722a669-5e4b-41c0-a688-ac90a76f4e9a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ebe9f66d-43b9-4208-b6c5-3d720d3ba537"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f1ddd440-3eff-4a06-b35a-5965f6bbcc06"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f2483c34-5d26-4ba4-a438-bff5ec63d955"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f4523454-003a-4543-9899-d65760a9e6d0"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f7ae027c-48ce-4563-ae65-681ed5bed2d1"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f93e8d6c-4420-41ac-bc6e-f57aff94c8b0"));

            migrationBuilder.AddColumn<Guid>(
                name: "BaseProductId",
                table: "Promotions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PromoProductId",
                table: "Promotions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RouteId",
                table: "Promotions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("08f6b60a-a01e-43cb-a8ba-c8d581022089"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("ccb15fb6-e2b6-4c5a-8d83-958910e01e81"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 405f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("48ed208e-7c5f-4d4c-9d9e-31093ea370a7"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 400f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("31b175e0-8956-4ddc-beb4-e79f259720e4"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 395f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("dedfa4be-13d0-470c-a71a-08f258129908"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 390f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("6c24881a-0c76-4659-b8ee-d9e060488c23"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 385f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("db00a6a7-026b-45a6-843d-ab2ed70d0c46"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 380f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("842efb2a-85f4-4aa9-87e0-62e01cb009a7"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 375f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("9e27e604-e998-4946-b186-a6de22d07707"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 370f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("6ca0a1ba-22f3-45a2-a261-874c4bc113ff"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 365f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("4d2c18f4-d448-4c16-98ed-d8db0f26b8a6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 360f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("750019dd-c4e1-41c7-84af-addc4dce229b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 355f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("586231fb-c006-4bc3-85bf-9f26466a3107"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 410f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("2be59936-3c7b-445a-9398-46c8c591076a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 350f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("ab83b66b-0d77-4f4a-ae3c-def71cc312d8"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 340f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("763709a5-dd54-4dab-8ba6-4bd4babc3d87"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 335f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("b0063325-e1ed-4723-897d-056d765a9c94"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 330f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("463a2f5f-2b76-4f2c-8c1f-d0ad8671643f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 325f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("039f4f56-a0dc-4946-bfd4-611f92084d0b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 320f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("5663d2ee-b941-4834-b7f3-51723e229612"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 315f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("d2e69720-a557-4305-9fbb-4eb993d62a44"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 310f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("9aaee470-dbc7-4638-bc14-713c543f1159"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 305f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("a984576c-8dbe-4665-acd9-522a1a815a67"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 300f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("b5fcf5b3-e8d5-46aa-8383-854dc07c2c84"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 295f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("9536af84-e978-446e-b6b1-5c520debae0c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 290f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("8ce42e35-74ce-4f9f-ac72-59599d80d9bb"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 345f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("63fcb1e2-a0df-4ff9-961f-e91044472351"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 280f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("f58af871-3948-4f25-9275-6c2f9ba461f0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 415f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("50ca9839-6fc1-4d57-85fe-bcf479e31fd2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 425f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("55e935e1-4fdf-4146-89af-b880e5efca72"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 545f, new Guid("8c74fc65-b701-4ade-9f97-7a7a744e2e59") },
                    { new Guid("14d0efdc-def2-48d9-9290-e7293a116e41"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 540f, new Guid("8c74fc65-b701-4ade-9f87-7a7a744e2e59") },
                    { new Guid("c55b29d7-7b99-446b-8efa-fc43aef3d8fa"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 535f, new Guid("8c74fc65-b701-4ade-9f77-7a7a744e2e59") },
                    { new Guid("3041a8c6-0b50-4ae4-9059-f63427f0fb8f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 530f, new Guid("8c74fc65-b701-4ade-9f67-7a7a744e2e59") },
                    { new Guid("e02cecab-0371-4340-bea3-f7af7b16e9ce"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 525f, new Guid("8c74fc65-b701-4ade-9f57-7a7a744e2e59") },
                    { new Guid("88821b96-179d-43fd-be35-cdce016dc4c2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 520f, new Guid("8c74fc65-b701-4ade-9f47-7a7a744e2e59") },
                    { new Guid("f5ebddbb-33c6-467e-a058-96070c601ceb"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 515f, new Guid("8c74fc65-b701-4ade-9f37-7a7a744e2e59") },
                    { new Guid("9d6025e1-6de4-4930-b473-5dd8491eb282"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 510f, new Guid("8c74fc65-b701-4ade-9f27-7a7a744e2e59") },
                    { new Guid("b9b703e2-185c-496c-b799-0842c0e686dc"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 505f, new Guid("8c74fc65-b701-4ade-9f17-7a7a744e2e59") },
                    { new Guid("017f215d-368f-48c8-b98e-5aa2987c5542"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 500f, new Guid("8c74fc65-b701-4ade-9f07-7a7a744e2e59") },
                    { new Guid("1aff46e7-2980-44ef-b2eb-00a5ce5ae4bc"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 495f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("c1f2a311-ee19-43f6-b83a-8e829a1cbadf"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 420f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("42c618f7-dacd-4215-aeb4-236e98ff659a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 490f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e59") }
                });

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("0909fa07-26df-4a48-9cfa-4a008550d59d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 480f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("7a96d0b7-918d-403c-b829-d2525bed73f8"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 475f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("68b44f79-5970-47e0-befc-26db26e9985c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 470f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("50f000a9-d71f-480a-b921-425fa91e79d5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 465f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("c57b96d3-c5f1-4c07-a1e1-fe39dae68fde"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 460f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("ca18f765-395e-4d85-bd71-abb5519f514a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 455f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("23125a17-31e8-4c30-a6c9-b05671b4aa85"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 450f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("f72377b6-a370-4c59-904d-74dca9c1894e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 445f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("a60dd1d8-2005-41cc-acd8-d4a306317705"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 440f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("faec83d1-68de-4364-8525-9acbdc5e5d93"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 435f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("12dfd118-b52f-4912-89b7-d9b23c125257"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 430f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("ad43ddbd-b506-43e2-bf59-a9e587525f27"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 485f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("7808967c-caff-4c2b-8fcb-e0168fd9ec6e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 275f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("953ba380-dc09-4d4a-a29d-d5df272890d8"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 285f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("d2211ad4-bb99-48d8-b495-5867a212ba56"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 265f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("447b218e-7621-4534-a2b8-ae7d097830fb"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 120f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("8d892c41-8ce2-4f78-af8f-fc7693ce63e3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 115f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("3544fd69-ba15-4c80-ab84-443f706e73e6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 110f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("882e1be3-fe7f-4c1b-9d7f-d6ec73789ac9"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 105f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("6814be95-85b9-4bbe-8cda-426fb1b73549"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 100f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("75df2dea-d6ca-42be-8aaa-405b67f1b806"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 95f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("4076c228-4837-473d-b683-d2f3610163b3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 90f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("9ea3e119-9b13-47aa-91dc-438ad060c53f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 85f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("6eb9831c-bd78-429e-9aff-42f8bced5624"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 80f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("499d8b22-1f93-4d19-b0ef-73174704e2bb"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 75f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("42f37b25-cccd-4c1a-9494-a8e3dbeb97d5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 70f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("cac59721-b98a-43ee-b2cf-dc97ad58ee58"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 270f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("22741a65-5677-43b9-9341-c20bc3ecf292"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 65f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("28750d12-cf0f-426c-b558-88088620b661"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 55f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("2df8a41e-ac7a-48cc-840c-1d14f41d5c56"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 50f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("0b3f89b2-50ae-4c42-b66d-8f9dad5c9e5f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 45f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("bd151b13-587e-4c0b-a55b-b4e1b58e7de1"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 40f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("6062bb1f-6668-47c8-9191-7f01ba1d13bc"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 35f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("be81e32a-afe2-47e5-8527-9372c96bb973"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 30f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("38890d5d-d314-40df-80fb-e3ed0e7f7f72"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 25f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("e4303d28-1903-494c-a48a-bb44207f0abd"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 20f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("4ebe063e-d5cd-4784-8162-996a635ee303"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 15f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("b33ab1b6-9f58-4846-98f6-df64f16a6bed"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 10f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("29f5cea0-7f78-4ea0-8278-d2ce3f41d4a5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("860a7659-ab27-44cf-8559-9282e87a44d3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 60f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("04729c1b-fc69-48e4-b246-06ae37a8b34a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 130f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("cf365db8-0457-451c-9640-e1ecb783e236"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 125f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e52") }
                });

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("9d96f18b-fd20-453d-ae12-caa0653088d8"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 140f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("d557705f-2ae6-4380-9381-cd02617c0fe6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 260f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("b5647af5-a2a7-44c5-a616-95be2ad234d7"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 255f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("2ebf04ce-10e9-4f0a-ba34-b0999493262f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 250f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("d1764f96-a75a-4b1d-be26-633a24877517"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 245f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("934857af-d07f-4e2e-a410-5460dc8a0e21"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 240f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("a75ef751-493c-4bac-8255-e338ac82edfd"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 235f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("0a32fd8c-056e-418a-80d1-d3fad52ebabf"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 230f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("d0374a99-7a56-47cd-9318-45614186024a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 225f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("65b4da06-de22-416e-9570-6787aa3b4ec5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 220f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("0e61995e-9672-4885-8442-6acebbcc5107"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 135f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("aacd8266-6f3a-4cdc-a0bd-e0b6d9472e16"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 210f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("66e929e2-2775-4002-b05e-2fcd79d0357f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 205f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("8ed5d302-b757-4181-9d9f-31804c54a099"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 215f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("c2eb0754-664f-4e32-8264-41771c9dbded"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 195f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("8514a6e4-ec13-4b33-bd71-98e3b5543713"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 145f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("08bf9ec4-3dd1-498d-ad92-a109315af4aa"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 150f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("f16a054b-1c5e-4a15-ab89-7c208d66cd7d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 200f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("bdec361b-57d4-40d7-a33b-acdd61732d62"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 160f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("1cd1f1d1-4836-40a7-920d-eafa625ebd71"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 165f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("73f0c079-6ebe-4e18-8514-a823c6edfa5e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 155f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("a5edeb08-b752-4d23-9163-e36d8d2fd696"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 175f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("38564cb8-b869-4267-a2e6-77676b254c2c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 180f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("8b565ba1-fe8f-4b49-9054-7b620d062aa4"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 185f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("e1eb7f5b-d79d-413d-858d-c1e3bd656b97"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 190f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("7d7d157d-8d3a-41ad-97dc-410b7c8709f5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 170f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e53") }
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1570902e-48bb-4b03-850c-8ebd63261e33",
                column: "ConcurrencyStamp",
                value: "f2614303-824a-447d-852a-0b478370247b");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "4ce95b9b-0760-4f11-b576-71dfaa053e74",
                column: "ConcurrencyStamp",
                value: "c64ee149-71e3-41e2-8358-50688d568dd8");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "c057793d-9d0d-4f1d-9fb0-2335480d82e2",
                column: "ConcurrencyStamp",
                value: "eadaf954-ca3e-4ff1-9060-a726d4c83e19");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "f4ea0102-2c6d-453e-8365-cb45c956cc44",
                column: "ConcurrencyStamp",
                value: "79816d2a-d41b-4bc9-8d0b-cb2f456864d5");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "0daec62b-312f-4016-9c5e-a15354259c90",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b6844c39-5c37-4966-9e84-fb125bbe47ad", "93a26710-20aa-44b5-976d-be100507aa5c" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "569411c1-88ef-45b6-ab57-79665fbcd9a4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5668ad84-e72c-4e42-a104-b013d9e7c3bb", "566e5e99-97fb-4736-8cee-4a38181b891c" });

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_BaseProductId",
                table: "Promotions",
                column: "BaseProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_PromoProductId",
                table: "Promotions",
                column: "PromoProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_RouteId",
                table: "Promotions",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Products_BaseProductId",
                table: "Promotions",
                column: "BaseProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Products_PromoProductId",
                table: "Promotions",
                column: "PromoProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Routes_RouteId",
                table: "Promotions",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Products_BaseProductId",
                table: "Promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Products_PromoProductId",
                table: "Promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Routes_RouteId",
                table: "Promotions");

            migrationBuilder.DropIndex(
                name: "IX_Promotions_BaseProductId",
                table: "Promotions");

            migrationBuilder.DropIndex(
                name: "IX_Promotions_PromoProductId",
                table: "Promotions");

            migrationBuilder.DropIndex(
                name: "IX_Promotions_RouteId",
                table: "Promotions");

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("017f215d-368f-48c8-b98e-5aa2987c5542"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("039f4f56-a0dc-4946-bfd4-611f92084d0b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("04729c1b-fc69-48e4-b246-06ae37a8b34a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("08bf9ec4-3dd1-498d-ad92-a109315af4aa"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("08f6b60a-a01e-43cb-a8ba-c8d581022089"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0909fa07-26df-4a48-9cfa-4a008550d59d"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0a32fd8c-056e-418a-80d1-d3fad52ebabf"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0b3f89b2-50ae-4c42-b66d-8f9dad5c9e5f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0e61995e-9672-4885-8442-6acebbcc5107"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("12dfd118-b52f-4912-89b7-d9b23c125257"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("14d0efdc-def2-48d9-9290-e7293a116e41"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1aff46e7-2980-44ef-b2eb-00a5ce5ae4bc"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1cd1f1d1-4836-40a7-920d-eafa625ebd71"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("22741a65-5677-43b9-9341-c20bc3ecf292"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("23125a17-31e8-4c30-a6c9-b05671b4aa85"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("28750d12-cf0f-426c-b558-88088620b661"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("29f5cea0-7f78-4ea0-8278-d2ce3f41d4a5"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2be59936-3c7b-445a-9398-46c8c591076a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2df8a41e-ac7a-48cc-840c-1d14f41d5c56"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2ebf04ce-10e9-4f0a-ba34-b0999493262f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3041a8c6-0b50-4ae4-9059-f63427f0fb8f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("31b175e0-8956-4ddc-beb4-e79f259720e4"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3544fd69-ba15-4c80-ab84-443f706e73e6"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("38564cb8-b869-4267-a2e6-77676b254c2c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("38890d5d-d314-40df-80fb-e3ed0e7f7f72"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4076c228-4837-473d-b683-d2f3610163b3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("42c618f7-dacd-4215-aeb4-236e98ff659a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("42f37b25-cccd-4c1a-9494-a8e3dbeb97d5"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("447b218e-7621-4534-a2b8-ae7d097830fb"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("463a2f5f-2b76-4f2c-8c1f-d0ad8671643f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("48ed208e-7c5f-4d4c-9d9e-31093ea370a7"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("499d8b22-1f93-4d19-b0ef-73174704e2bb"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4d2c18f4-d448-4c16-98ed-d8db0f26b8a6"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4ebe063e-d5cd-4784-8162-996a635ee303"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("50ca9839-6fc1-4d57-85fe-bcf479e31fd2"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("50f000a9-d71f-480a-b921-425fa91e79d5"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("55e935e1-4fdf-4146-89af-b880e5efca72"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("5663d2ee-b941-4834-b7f3-51723e229612"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("586231fb-c006-4bc3-85bf-9f26466a3107"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6062bb1f-6668-47c8-9191-7f01ba1d13bc"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("63fcb1e2-a0df-4ff9-961f-e91044472351"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("65b4da06-de22-416e-9570-6787aa3b4ec5"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("66e929e2-2775-4002-b05e-2fcd79d0357f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6814be95-85b9-4bbe-8cda-426fb1b73549"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("68b44f79-5970-47e0-befc-26db26e9985c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6c24881a-0c76-4659-b8ee-d9e060488c23"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6ca0a1ba-22f3-45a2-a261-874c4bc113ff"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6eb9831c-bd78-429e-9aff-42f8bced5624"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("73f0c079-6ebe-4e18-8514-a823c6edfa5e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("750019dd-c4e1-41c7-84af-addc4dce229b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("75df2dea-d6ca-42be-8aaa-405b67f1b806"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("763709a5-dd54-4dab-8ba6-4bd4babc3d87"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7808967c-caff-4c2b-8fcb-e0168fd9ec6e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7a96d0b7-918d-403c-b829-d2525bed73f8"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7d7d157d-8d3a-41ad-97dc-410b7c8709f5"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("842efb2a-85f4-4aa9-87e0-62e01cb009a7"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8514a6e4-ec13-4b33-bd71-98e3b5543713"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("860a7659-ab27-44cf-8559-9282e87a44d3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("882e1be3-fe7f-4c1b-9d7f-d6ec73789ac9"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("88821b96-179d-43fd-be35-cdce016dc4c2"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8b565ba1-fe8f-4b49-9054-7b620d062aa4"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8ce42e35-74ce-4f9f-ac72-59599d80d9bb"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8d892c41-8ce2-4f78-af8f-fc7693ce63e3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8ed5d302-b757-4181-9d9f-31804c54a099"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("934857af-d07f-4e2e-a410-5460dc8a0e21"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9536af84-e978-446e-b6b1-5c520debae0c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("953ba380-dc09-4d4a-a29d-d5df272890d8"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9aaee470-dbc7-4638-bc14-713c543f1159"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9d6025e1-6de4-4930-b473-5dd8491eb282"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9d96f18b-fd20-453d-ae12-caa0653088d8"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9e27e604-e998-4946-b186-a6de22d07707"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9ea3e119-9b13-47aa-91dc-438ad060c53f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a5edeb08-b752-4d23-9163-e36d8d2fd696"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a60dd1d8-2005-41cc-acd8-d4a306317705"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a75ef751-493c-4bac-8255-e338ac82edfd"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a984576c-8dbe-4665-acd9-522a1a815a67"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("aacd8266-6f3a-4cdc-a0bd-e0b6d9472e16"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ab83b66b-0d77-4f4a-ae3c-def71cc312d8"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ad43ddbd-b506-43e2-bf59-a9e587525f27"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b0063325-e1ed-4723-897d-056d765a9c94"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b33ab1b6-9f58-4846-98f6-df64f16a6bed"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b5647af5-a2a7-44c5-a616-95be2ad234d7"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b5fcf5b3-e8d5-46aa-8383-854dc07c2c84"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b9b703e2-185c-496c-b799-0842c0e686dc"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("bd151b13-587e-4c0b-a55b-b4e1b58e7de1"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("bdec361b-57d4-40d7-a33b-acdd61732d62"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("be81e32a-afe2-47e5-8527-9372c96bb973"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c1f2a311-ee19-43f6-b83a-8e829a1cbadf"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c2eb0754-664f-4e32-8264-41771c9dbded"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c55b29d7-7b99-446b-8efa-fc43aef3d8fa"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c57b96d3-c5f1-4c07-a1e1-fe39dae68fde"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ca18f765-395e-4d85-bd71-abb5519f514a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("cac59721-b98a-43ee-b2cf-dc97ad58ee58"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ccb15fb6-e2b6-4c5a-8d83-958910e01e81"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("cf365db8-0457-451c-9640-e1ecb783e236"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d0374a99-7a56-47cd-9318-45614186024a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d1764f96-a75a-4b1d-be26-633a24877517"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d2211ad4-bb99-48d8-b495-5867a212ba56"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d2e69720-a557-4305-9fbb-4eb993d62a44"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d557705f-2ae6-4380-9381-cd02617c0fe6"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("db00a6a7-026b-45a6-843d-ab2ed70d0c46"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("dedfa4be-13d0-470c-a71a-08f258129908"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e02cecab-0371-4340-bea3-f7af7b16e9ce"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e1eb7f5b-d79d-413d-858d-c1e3bd656b97"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e4303d28-1903-494c-a48a-bb44207f0abd"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f16a054b-1c5e-4a15-ab89-7c208d66cd7d"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f58af871-3948-4f25-9275-6c2f9ba461f0"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f5ebddbb-33c6-467e-a058-96070c601ceb"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f72377b6-a370-4c59-904d-74dca9c1894e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("faec83d1-68de-4364-8525-9acbdc5e5d93"));

            migrationBuilder.DropColumn(
                name: "BaseProductId",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "PromoProductId",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Promotions");

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("3c73e5c8-c644-49bd-806c-78b4437d819a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("3a2b2bc8-a0cf-4ae3-ad9f-43e4b154d434"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 405f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("7826761d-d704-40db-933c-fb38150a960a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 400f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("ad61e413-42e3-499a-96e6-620648a3880e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 395f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("7b3a4153-5913-4fc9-8cbe-01c8a327b9ab"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 390f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("2bc9954e-23bd-4d62-8216-db7c1cda90f1"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 385f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("f2483c34-5d26-4ba4-a438-bff5ec63d955"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 380f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("727a41b4-f99c-4299-92c9-0dc842a8ca17"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 375f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("87575d2a-a483-48f2-a7ee-1d81e184d7f6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 370f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("4eb7b5cb-a487-4df1-bfa2-dbc9f0302cec"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 365f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("b4d2198c-f4af-49bc-8446-bd1e70c18e05"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 360f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("de1a0418-d3f3-4b30-b5ff-be95956ad0c1"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 355f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("94daf8d8-2580-4de3-b812-0ca293fe057f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 410f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("1040929e-af56-487f-89d3-2968e7d70820"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 350f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("f7ae027c-48ce-4563-ae65-681ed5bed2d1"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 340f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("116d0215-2c7c-4d34-9b27-a083d9eeac00"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 335f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("2ff30ecf-92da-40f0-8e7c-7bab7bbef0da"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 330f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("974e04d6-644e-4a88-bb12-d2973d76fefe"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 325f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("bb12b220-ac85-4982-9eb7-7c00c06bfabd"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 320f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("f4523454-003a-4543-9899-d65760a9e6d0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 315f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("92c6a1ee-19c1-4617-83c8-fdde5eeb518f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 310f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("c4589a1d-4b28-4ddb-ab31-628b66b2bf32"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 305f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("cdc9e2ab-16f0-47ef-9493-1ea1d531305e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 300f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("0cb80fd4-8965-45e2-9600-0189b3b08654"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 295f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("9d50abd4-5532-498b-aae9-56a5f3f33b03"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 290f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("401919b7-23e9-4e52-afa2-8c2597e3f3d1"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 345f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("4e627e55-6ad5-47d4-beca-64ea3595e1b0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 280f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("3b493200-bc2c-493a-9970-c820f4f60363"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 415f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("729a34fa-a5b0-4b7d-b58c-fce9623de8ea"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 425f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("2277a0bc-c539-4e6f-9559-c31f0ae9fe44"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 545f, new Guid("8c74fc65-b701-4ade-9f97-7a7a744e2e59") },
                    { new Guid("34f2aef2-1299-4dfa-b39e-c58b2eea4d3d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 540f, new Guid("8c74fc65-b701-4ade-9f87-7a7a744e2e59") },
                    { new Guid("0a8bd68b-fecb-4147-90c0-32c6381ff9a5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 535f, new Guid("8c74fc65-b701-4ade-9f77-7a7a744e2e59") },
                    { new Guid("1f99c041-e0af-401b-a2ff-259db8887cb9"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 530f, new Guid("8c74fc65-b701-4ade-9f67-7a7a744e2e59") },
                    { new Guid("2cbfa5cb-e7d6-471a-a171-a675b47572ad"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 525f, new Guid("8c74fc65-b701-4ade-9f57-7a7a744e2e59") },
                    { new Guid("d1cf4c11-d376-4067-b592-245347ccff2d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 520f, new Guid("8c74fc65-b701-4ade-9f47-7a7a744e2e59") },
                    { new Guid("111b1882-21be-44d9-af49-dfa8bdf9da2f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 515f, new Guid("8c74fc65-b701-4ade-9f37-7a7a744e2e59") },
                    { new Guid("00582daf-0c34-44a4-afd5-2e9c1e4937cb"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 510f, new Guid("8c74fc65-b701-4ade-9f27-7a7a744e2e59") },
                    { new Guid("4048a18d-c5c1-4e51-bcbc-8e8dfd752a94"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 505f, new Guid("8c74fc65-b701-4ade-9f17-7a7a744e2e59") },
                    { new Guid("4ba5d24e-9b41-44c7-b20b-656781aeafca"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 500f, new Guid("8c74fc65-b701-4ade-9f07-7a7a744e2e59") },
                    { new Guid("cca8d028-5980-48bf-8be9-b2abadc72d5f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 495f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("e4336669-a018-480c-9055-2dceb4895c28"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 420f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("7301eb65-53cd-45ba-9cf4-1101d8c3fcb3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 490f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e59") }
                });

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("36eec0d5-0523-44a6-8bde-1433f26b39fb"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 480f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("dae7989f-5aba-4396-bd6c-8e434cf88425"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 475f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("f1ddd440-3eff-4a06-b35a-5965f6bbcc06"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 470f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("abea596e-53f9-4d9f-b44c-e49bf7467273"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 465f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("26f6f3ca-eec7-4653-b23f-76e10ed12493"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 460f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("520b5435-85dc-49e3-b368-5f44eb9a26e6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 455f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("cce1cafb-ffee-426e-9dfd-a17cde66beeb"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 450f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("a0bd439b-873d-43f2-a4df-940a0e257c1a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 445f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("0d7cbd3e-58cc-4aa8-b9c5-fe56c6300d75"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 440f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("e722a669-5e4b-41c0-a688-ac90a76f4e9a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 435f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("04d4388c-7d77-44e3-9f5d-f7eb60081a52"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 430f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("899cc737-7e7c-4bd1-9552-acfdf34a00af"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 485f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("9aea72d0-7f48-4bea-a496-ebcb96b5099b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 275f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("3cedc5a8-67f7-4eda-9047-7ba18db27d3f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 285f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("2b31f9d7-0572-410e-90ce-8529505a15b3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 265f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("d3fb6c91-6ff9-4f8b-9641-c13edfece3fa"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 120f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("b4572948-0c6a-48ec-8b33-774aeec34ac5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 115f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("7f9f10a5-a3e9-49b8-87e1-3f1c548fd7dc"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 110f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("d682e674-d76c-4122-ba39-2caf75085d95"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 105f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("909b141c-d440-4d7d-813c-7ba5933ec335"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 100f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("cab7cfbc-be06-4242-9dd1-120dfcc19495"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 95f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("ae15a164-70eb-4ce1-b1d4-367ffbf5fe52"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 90f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("c8919a74-b4e7-479a-949a-9db1ae0102d2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 85f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("e11b4324-8e54-40fe-a517-541a40ad64b8"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 80f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("30939ce4-05da-4831-97d3-f56be3acdbe3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 75f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("95a1bb1c-772d-45b5-97e9-39df09ab8aa5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 70f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("0ea3b60f-cee1-463e-87c9-c15a8281b99c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 270f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("9827efb6-2ba9-44cf-acb4-0d2725ff2619"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 65f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("c398ddaf-4e39-4f5c-ba6e-c1b43e5e6f31"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 55f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("db9cd30d-162c-4a3a-bbb8-2535b6a0f5b6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 50f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("52477b08-f8ef-4220-bfc5-c646f0624f5a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 45f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("aa058741-9640-422b-bdd9-1c001643c0cc"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 40f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("92e9cea7-00a9-4eee-9f37-6c94147efa75"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 35f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("c4265ec5-cd8e-4521-8ed0-4d4f9ee1ad51"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 30f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("7a9cc1db-d6d2-4ad8-bc4e-e49e8b43040e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 25f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("2a79c14e-0898-41f6-b07d-569db0cf08bd"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 20f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("b742a723-e5b0-4d4f-b7fe-4ab7dcb9796b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 15f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("10b15089-08bf-4e2e-a3dc-329f541ceb78"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 10f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("0bda1bf2-47bb-4454-9189-e08c3e158d48"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("a328958f-35f0-4f6a-913e-89caac5327d6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 60f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("8a66342d-b3ee-415b-b1c5-e22abb78aa58"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 130f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("69202f3e-6421-4a60-9975-2f72bc1398f9"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 125f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e52") }
                });

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("c9ad62de-5838-4191-8c63-1e59cdd7e705"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 140f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("7f1f7386-39e3-4b90-aad8-8381604df538"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 260f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("501c6238-8fbd-4ec3-818a-2b1f6d0ffde8"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 255f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("219baec3-7251-4055-b3fa-a31ff4158321"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 250f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("25d2424c-8d1c-4106-a982-f20c38085590"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 245f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("a4953c00-b252-4be5-9092-b14fdf053dca"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 240f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("23b25016-afc7-4b28-a1ff-814bd1562f4b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 235f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("f93e8d6c-4420-41ac-bc6e-f57aff94c8b0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 230f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("ebe9f66d-43b9-4208-b6c5-3d720d3ba537"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 225f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("0550a6a7-7d50-4859-ba45-fafe17cb0cd8"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 220f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("dea5a5ad-16bc-4cc8-88d6-d1b445b59e0e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 135f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("5c86547e-5c60-485e-b89d-b56bdbc60c4d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 210f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("c64bcfce-052a-4bbc-a52f-bedfa3e5da3b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 205f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("5c971f6e-6c17-4d29-ae29-7c2e56d98b46"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 215f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("e55dd401-4895-4f13-89b3-827613faf007"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 195f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("2e68d6a4-8262-4470-b463-e0c5f904fe62"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 145f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("c150efc2-cf25-4712-8756-12183643ed50"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 150f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("a8ad09e0-9c30-421a-886a-85787d57b187"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 200f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("dcd36b96-c4fb-44dd-906d-5fcf1df62641"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 160f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("e2dee9ae-c55b-4992-b204-3ca96e11b21f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 165f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("2d8c3427-75b9-4278-9fd7-a4831a1510a4"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 155f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("ce68ed93-bdf5-4071-8679-a59306aa5fab"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 175f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("2b100bc5-fba8-4418-a850-91eeb04475d3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 180f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("973ac970-5ee4-440a-a1cb-69684fcd1e67"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 185f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("1d59938f-3876-4bc9-87b8-9a919b68078a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 190f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("1cc6c69a-36c8-4719-ad36-b5b9347fbd80"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 170f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e53") }
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1570902e-48bb-4b03-850c-8ebd63261e33",
                column: "ConcurrencyStamp",
                value: "4e4d3390-7e79-4067-aa14-3f109247f407");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "4ce95b9b-0760-4f11-b576-71dfaa053e74",
                column: "ConcurrencyStamp",
                value: "dc728e9f-a1da-4d79-a2ac-fa1deb38c753");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "c057793d-9d0d-4f1d-9fb0-2335480d82e2",
                column: "ConcurrencyStamp",
                value: "a6393142-b295-4a2f-9f8f-547fe111aa68");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "f4ea0102-2c6d-453e-8365-cb45c956cc44",
                column: "ConcurrencyStamp",
                value: "a56c575b-6c7b-42fa-a881-93fa264452d7");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "0daec62b-312f-4016-9c5e-a15354259c90",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a74bafa4-110a-423b-a68f-be2f6208bcba", "24ace1fe-78d0-402e-9864-8f222183c6d0" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "569411c1-88ef-45b6-ab57-79665fbcd9a4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6e6b65e1-772f-4587-a1af-b8eeeeae2c76", "a620048e-d5ae-4df0-b2b9-8e8ba31686e4" });
        }
    }
}
