using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadyGo.Persistence.Migrations
{
    public partial class RemoveSpTransferStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransferStocks_User_SalesPersonId",
                table: "TransferStocks");

            migrationBuilder.DropIndex(
                name: "IX_TransferStocks_SalesPersonId",
                table: "TransferStocks");

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("00eb7f8c-5854-47a3-ae33-04c294abbfec"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("062730f6-bdbb-4bf0-83cb-48c268ce28d4"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0723e8f0-d335-4fea-b47e-bcb51e33b577"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("08b00e67-bee7-4f28-a445-4ab3bc7de37f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0a4a5215-4c9d-4a89-99ac-2c8fa95e925e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0ede0c05-11a9-43ee-af9f-aa7acdeee6c3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("112995fd-1161-4cc7-824e-3fba2265f971"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1361de67-50a2-4081-a151-6eaabe779686"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("154ddf5a-e1a5-4d27-86ac-351beee11d15"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1587ac25-97b7-46f9-bbef-732cea779a39"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("161077a5-44cc-4cbc-8c0b-4b3d8bdcab6e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1829022e-f64f-454b-85c7-3a97c2812eef"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1c917ef9-2444-4c0a-9160-f680fbab2fb0"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1e955201-c3f1-4e8c-aeb4-5c0b919cfcb0"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("217ee72a-d667-459a-b953-0e0b03ad4113"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("22dc2f12-a37e-483e-9a2e-2975722e1b77"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2416705d-889b-4d22-abaa-25cd415e234d"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2b2d679f-c498-494a-8425-3c311fc89fc0"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2e202bfa-4bd3-4b67-b043-295d2969d743"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("336e309d-07fa-4e55-960a-50eaacc1677f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("347c68f8-80c3-4929-a914-1c66083f517e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("354a35d6-e7b9-4cfa-88ae-b202d6ed29e9"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3a7d40e1-8916-4b72-b91b-40145868a3ef"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3a7dd631-a731-4153-bc0b-89682f013855"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3ac5cd44-3a2e-4f4d-8722-fba07671fe51"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3cfc9b19-7948-40ea-b743-45858b22734c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("40dbcd58-b88f-4c34-9897-36f12c2860e5"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("42541c36-b01f-4291-b282-c6f90d32bdf2"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("434314f9-4a43-4b99-843f-0b161fd0e131"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("45c3aa6d-9a58-49f9-9f8b-8f081e7fab4e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4666ef6b-5a29-4cc6-a89b-950a0f356529"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("530ca460-d46f-435f-b953-1dd147d7b5e7"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("54252334-3f9d-4932-bff1-31f12a892d63"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("55fa3cd6-bc0f-480a-bb4c-14b9bc060028"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("568b17b9-ef6d-4cd7-81de-a6a39f4a719d"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("57ef7ae5-3aed-4654-9a9a-0c218bdb6a3e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6220f0fc-7682-4668-a988-05eb83450a1d"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6d460fd9-be37-4841-9ded-dc556fd5d06f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6e2b37ab-3e00-42fa-ad18-6183e5efe9bd"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6fd765df-3447-4433-8625-b8b6fe4f6b27"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("74970667-0472-4fb6-8817-c8cbe2cdeb57"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7932fe87-9ecf-4bfb-bb10-505fefc7948c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("793b16a2-3b65-44d1-ab87-1c2775701499"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7ac54894-2734-43ba-9835-13d7057f6cdd"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b8d0f80-7b1f-4c9b-95c4-6902c6e969ea"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7cd6d00b-4be1-4832-947f-4986e58b8b74"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7e4016b5-e22a-4661-863b-b889a63e9f66"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7f29e49b-56fe-4931-b60a-a0d449234507"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("81993684-686d-43a8-b9c3-f921466d491a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("82117e54-c876-40a5-a106-87a492159850"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("85eb86e3-ee4b-47a7-b618-9e0a8134aa80"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8929c132-7b29-407d-92fd-74ed02d60abc"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8973f653-350d-4ec9-9efe-e890558e69cf"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8b2284ab-9652-41e3-9801-36decfeb5904"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8d30774a-2025-48f4-ba9c-3a7dce8143be"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8d5043f6-7d1b-43fb-912e-7a888777a3e9"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8e12c182-0573-4e14-9784-571b36af1cb7"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8e712a62-752f-4c30-b8c7-886947b51e7f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8eb7cc41-85cc-4ad8-a9d9-2194cccee5fe"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("91062103-a31e-4f58-ab2c-2c2729578dd8"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("91c921cb-a22b-40b5-968c-556a37033efe"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("926e9c7d-e1d1-4388-9ac2-8a42e9a24399"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("941eb151-288a-4b13-bf15-a7f43b6d0876"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9508cba2-4818-45af-a9af-d2ed76341288"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("951ec695-0b7e-487e-b6ca-bb29fe7b1422"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("986a8399-1525-4e15-9ada-818722274d2b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9abebbf8-43b6-4bcb-868c-d1d2bae2c2f7"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9b159832-648c-428b-9d6e-71fd796cada0"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9b57f42e-2410-4856-8821-f9e9fe954ebe"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9bd15c46-9f4e-4237-9a41-fc29eb4ab0f2"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9c2ca511-0d39-4e4e-b403-dad714301cdb"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a02b32dd-e905-4ee3-82a2-c1c9746e5c46"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a307e6ca-9179-4d9b-9679-95828384a563"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a529bb55-f919-4475-aab4-6fedee9e4253"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a801abb2-cd48-401a-9acf-a3c7999cdf51"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a94bdfaa-1d0c-414b-aae7-3eb20494c330"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("adbf26ed-99ac-4d74-80af-05303c43bf08"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("afadf6a4-b7e4-431c-8887-c9ae896316db"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b0e08c91-e0c9-4ad6-a4c9-96421731545c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b5a03072-138e-447b-a011-2fdc30e6a3fc"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b776f342-ed9e-49f3-b15c-58f51ee1a5f3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b8a475d7-4617-45bb-bbfc-46a6d93903c3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("be6f319d-ca6b-4bf8-9ed2-9b3d1df13153"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("beccd26f-4021-44d9-b28a-5a1e9e43bf66"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c0a787e4-4a75-402b-b6a4-014060567e33"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c49a8a23-7dff-4811-b309-b51ee3263eeb"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c8aa9826-4c27-41a5-9dfd-92dde569bd1a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("cc9ce403-4961-45a5-a2ba-4396a63b1c6d"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("cd2ee22b-4e3c-4d9a-9a1b-489fd9cfb534"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ce2830e1-a183-40ce-aa77-f60010061f7c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("cf6aaa7c-b456-4606-9e1c-19d2dbb12a90"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("cfa59692-8a4d-499c-bd01-a680619a3174"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d4b50184-82fd-444d-8d04-d442f6476fb2"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d6c17da7-ae17-413b-88d9-9ef2876504e2"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("dac85856-153d-4167-b406-5441723f0db0"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("db94a8d2-3bb5-4c19-a7bb-7e8caa18cd11"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("dbcc22a8-1636-4c22-8163-3b90a1680e7c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("dca99b90-e55e-4d71-8932-2bda18295486"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ded3cab2-78a8-4e3d-87a7-fa223964c6dc"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e43a9a46-3f75-4a82-a382-c2552ffbbae8"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e4a63713-bf22-4357-b9cb-8a00825139c4"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e801ef7a-c414-49ae-bfeb-6380e7e832bc"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ee6b22cd-54aa-4fc1-b06b-c6a241e27aad"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("efc62ea2-b75e-43b5-ae48-4f796ff0a8f1"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f3cea749-9f71-4801-8b6a-c544e198a6d8"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f5735908-1b30-4837-8661-35092d0b89d6"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f9df11c4-a8d0-4026-b2e7-c7e7c86f3926"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("fa93210b-cc16-40c7-a03a-4356250ab127"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("fb0121d7-4fde-46f4-96a6-f7d971cc270f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("fd2a69c9-1866-4616-ac61-202bfb96d076"));

            migrationBuilder.DropColumn(
                name: "SalesPersonId",
                table: "TransferStocks");

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("45fa32c6-57f8-40d3-9f8a-b24de77843b4"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("7d3e364c-af91-45b4-8011-053b907a9e1f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 405f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("cd5404b4-0786-452d-8068-1450da45786c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 400f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("1745496f-6111-4b7d-b089-d1057e6b9a03"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 395f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("1e266307-1c76-417d-bcb9-ebc0eaa55892"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 390f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("269def19-9f8a-40f3-a8f5-db9d3370fc95"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 385f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("c9f8c340-e753-4a32-b7bd-cf6b35240b10"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 380f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("b106b2fb-c619-46cd-a56c-582c1f9501b3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 375f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("db23f67a-05f1-4f18-b708-3ec8971d8191"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 370f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("c0266fc8-ecb2-4d1b-ba2a-ad6c5bcf5706"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 365f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("aadc8072-213b-44b8-a074-3b420d9e4a7e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 360f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("36b91f72-f180-4ce0-acc7-255a66bf9373"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 355f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("79ff70a6-449d-4fd2-a0f9-c29a6d21903a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 410f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("3f15eb69-919a-41a1-b194-d68d33796633"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 350f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("a7256ddb-c343-4824-8eb8-129d1c10ad76"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 340f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("40536c73-7c98-4f39-bece-f1ff1de30242"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 335f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("8e3a44f3-4b0d-427c-8039-b6128073c608"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 330f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("b87f0d43-ad02-4a2b-9a88-9e5512c7f8c6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 325f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("de1c6ebc-cb55-4037-85eb-c1b33923b4f7"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 320f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("45c0d8b6-d16e-4a5a-b7f6-596da1493d2c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 315f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("d4c5d203-a28c-4976-acbf-5d3452c2273b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 310f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("ea43c5e4-dc49-4705-b649-88188780122f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 305f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("1a7ebdee-28d1-49c5-beaf-53123a00b2d6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 300f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("8aec9d92-aa90-4344-8bb0-9eb077f9b854"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 295f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("c340ac19-6f01-4c9f-8dfb-d21214cdf0d4"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 290f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("bebb2777-b13c-4a4e-b2ed-9e8c3d74804f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 345f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("b4af13ea-0784-4277-9d8f-dbb4fb8215d1"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 280f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("a6b055f2-f291-4606-9554-cee2f387650e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 415f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("c53ce5f5-84d9-4f30-be7c-62e0add2f135"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 425f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("7b5fe619-0b8f-43d0-b62c-10404d7fdd79"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 545f, new Guid("8c74fc65-b701-4ade-9f97-7a7a744e2e59") },
                    { new Guid("e2d6c706-4df3-438d-9cf2-e0b6a4aa4b40"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 540f, new Guid("8c74fc65-b701-4ade-9f87-7a7a744e2e59") },
                    { new Guid("c8b496ad-40ea-4a6c-8495-ab5af4570ff5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 535f, new Guid("8c74fc65-b701-4ade-9f77-7a7a744e2e59") },
                    { new Guid("f4920f06-22bb-4dce-a6a0-ca4ffda5cc7d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 530f, new Guid("8c74fc65-b701-4ade-9f67-7a7a744e2e59") },
                    { new Guid("2451eba4-6c98-4539-a57e-3471fc14de03"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 525f, new Guid("8c74fc65-b701-4ade-9f57-7a7a744e2e59") },
                    { new Guid("e742cf47-0bb6-4cf7-920e-8e30c91715bb"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 520f, new Guid("8c74fc65-b701-4ade-9f47-7a7a744e2e59") },
                    { new Guid("fae7ea8e-25f7-45e3-bb42-aaf4ec5bce14"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 515f, new Guid("8c74fc65-b701-4ade-9f37-7a7a744e2e59") },
                    { new Guid("8ef62fb3-300b-4c0e-9731-1e55fd776a77"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 510f, new Guid("8c74fc65-b701-4ade-9f27-7a7a744e2e59") },
                    { new Guid("9ac8ba7b-61fb-4c61-bf84-4db4b1abbe64"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 505f, new Guid("8c74fc65-b701-4ade-9f17-7a7a744e2e59") },
                    { new Guid("b79e92db-0a7c-4a0f-84bb-c9c8911bdb48"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 500f, new Guid("8c74fc65-b701-4ade-9f07-7a7a744e2e59") },
                    { new Guid("8961292c-0087-49bf-a239-db62a7163a94"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 495f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("2bc8918f-1b2a-4b50-bb82-4b369e8693af"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 420f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("f6805100-e668-47f6-b369-b2c09edac529"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 490f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e59") }
                });

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("36fae0d5-a708-429b-8494-d0ca006c68f6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 480f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("b2b19e88-cf90-495a-a9ee-baaa32b200ce"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 475f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("ef5d97d3-45f0-46cf-9b92-ed2d7d662199"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 470f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("34c7da0d-a0a7-48a8-94b3-c224fcb4e81f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 465f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("414dc76d-9b43-4d71-b2c6-897394854bcc"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 460f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("4a604beb-1c18-4709-92d5-9e58ffd10295"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 455f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("f542b5ec-9668-45be-a7ef-c5c523c012c3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 450f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("a981b497-d0f9-4992-9a6b-b93778fd3012"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 445f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("fd7989a4-d609-48fc-b2c0-c5b565f3f69e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 440f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("a2b46dab-c01d-4f3b-9990-0db22f13ec14"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 435f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("0fa60abe-4928-4dde-98f0-ec77106a979c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 430f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("b87f0fdc-5b39-4c36-802f-171def23184b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 485f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("95a5a3a4-04c2-44b0-9972-07bfea0de4d5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 275f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("946086c5-64ab-4160-8520-04c1e8496186"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 285f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("a788d503-35e9-4933-a76d-bd21ea291ea8"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 265f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("7728b1ca-73f0-4b27-985b-6a605aee31cd"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 120f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("afcc5a18-c14f-468a-9994-0c04465bf198"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 115f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("d82b1c0b-ad5c-46bb-ac0e-6c6a35379120"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 110f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("bb17ecc3-898d-44ad-a5d4-771b6b6411e3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 105f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("0296bbf0-d017-400d-be13-cf352c5cb82a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 100f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("28e1a4fb-060c-4383-a190-60ffa88138aa"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 95f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("8726c5ba-a58a-4e05-ad4f-6240656b5256"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 90f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("edc6c3b8-46b7-448e-8b55-5e6c73e8669b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 85f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("05a4bcd9-a6d4-43b9-a8af-4a4d63417eb2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 80f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("692c1319-e580-43f6-9e9f-75eeb26692d5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 75f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("cb7c6dd7-7501-46ca-80dc-3d8fb6716af4"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 70f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("6c428269-4071-4c35-9a9b-c980c0b8f1d0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 270f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("78754eb3-11dc-4ef6-9065-5de0f8261d92"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 65f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("791a116a-6866-448f-a64c-bbf2fc0f1130"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 55f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("a8e708b8-0926-4eaa-8007-1ecfdc0f81d3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 50f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("4faddfe5-516d-4b4c-8526-0adcf1c03876"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 45f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("fef30195-8fc4-49b2-935c-07f8d6012327"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 40f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("d82a6994-2b20-452e-a1a1-d68242f4a89c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 35f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("f9fc0cd9-4295-4684-8f00-0e04eb7f042e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 30f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("bb63cad7-ff26-402c-a69a-caa05d8f7049"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 25f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("e457d967-c6f5-4c0a-9809-bd49524a8f57"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 20f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("18c41d4b-1f5b-4a2a-9095-da4c0987cfda"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 15f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("25eb2c40-ddba-49fe-8a64-23cec1876a18"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 10f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("9c1aee78-c245-4c6f-b556-08e9cf2039c9"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("4d3213c8-d140-4952-8d2c-620797099e77"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 60f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("15c4e027-4bfe-40c3-90e0-3c7994d9b538"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 130f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("bed682c1-9aaf-49cf-a791-0422648dd11f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 125f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e52") }
                });

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("934dfd41-df6e-429d-ad4b-a11af6c4a4b4"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 140f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("29e9ee74-e080-416e-bf7c-13258de77da9"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 260f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("dd055ab0-b141-4002-ba75-56a755aeaf44"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 255f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("debe514a-2b05-423d-a0fd-6279c46c02b9"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 250f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("6d7f4a95-35ff-4a91-9a4d-1728c62f92ba"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 245f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("7463de2b-46a3-4549-84f4-2b5d5bd02492"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 240f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("4204dbd1-e41e-4500-a592-be3084ef2ce1"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 235f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("703b428d-dd36-4ca9-aad5-d1bd61d5e186"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 230f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("06bff59e-4e29-4e8b-b519-d9a9f79e39ee"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 225f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("4e576441-5a4f-4e2c-9f26-fab7b3be8eae"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 220f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("d2d45fe5-82ff-48ac-a736-cf5696aae152"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 135f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("05c20a30-13b3-4ba7-955c-717d1dd7dc68"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 210f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("1bb320df-8cd4-4cfa-81bc-c9eead018e5f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 205f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("6fea2ea0-e837-4ebf-92dd-4d9b74526f03"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 215f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("c8709644-1471-4881-bb8b-806893d91231"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 195f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("ca624178-2730-4bae-ae70-62efebe06be2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 145f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("c678e8d1-6e76-4625-984f-e0654f4a35d4"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 150f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("3a2d7be6-8d1a-4f67-9102-37202f1ec175"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 200f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("d14e5f25-dae5-411a-bd7e-fe3f8b9c9565"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 160f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("e8468d57-38d5-414a-8c62-ed1f21529e21"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 165f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("18a1efb5-bfa3-4db1-8507-016cfd379de2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 155f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("c5c0ed9b-a0d3-4121-949b-d35e5a2d08ee"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 175f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("657e5fa5-98bc-49ac-841a-9c24142bcc32"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 180f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("114c8b69-4e8e-4ffc-b499-dd06dde5c215"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 185f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("bac45c07-65e1-4fcc-9365-7c94a634805b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 190f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("c9688a5a-50c3-434f-b505-d9d67717a323"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 170f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e53") }
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1570902e-48bb-4b03-850c-8ebd63261e33",
                column: "ConcurrencyStamp",
                value: "fdab1caa-da91-4a27-97c7-8c6a0d54dc04");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "4ce95b9b-0760-4f11-b576-71dfaa053e74",
                column: "ConcurrencyStamp",
                value: "80700f1f-13f1-464c-95a3-982e46913673");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "c057793d-9d0d-4f1d-9fb0-2335480d82e2",
                column: "ConcurrencyStamp",
                value: "8d1ec3db-b46e-4bde-ad71-44f0cffea7bb");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "f4ea0102-2c6d-453e-8365-cb45c956cc44",
                column: "ConcurrencyStamp",
                value: "b5cc9e0c-53f9-40ab-978a-4f737d845bec");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "0daec62b-312f-4016-9c5e-a15354259c90",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "13fb4c0a-79fe-4632-803f-1266f5deb8e4", "01f73a50-de04-4139-ae91-3902460c27fa" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "569411c1-88ef-45b6-ab57-79665fbcd9a4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cbba0108-5ad7-47d6-b305-407b7937c85e", "3d33f01c-1104-4d23-abc2-18226c3afa77" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0296bbf0-d017-400d-be13-cf352c5cb82a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("05a4bcd9-a6d4-43b9-a8af-4a4d63417eb2"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("05c20a30-13b3-4ba7-955c-717d1dd7dc68"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("06bff59e-4e29-4e8b-b519-d9a9f79e39ee"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0fa60abe-4928-4dde-98f0-ec77106a979c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("114c8b69-4e8e-4ffc-b499-dd06dde5c215"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("15c4e027-4bfe-40c3-90e0-3c7994d9b538"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1745496f-6111-4b7d-b089-d1057e6b9a03"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("18a1efb5-bfa3-4db1-8507-016cfd379de2"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("18c41d4b-1f5b-4a2a-9095-da4c0987cfda"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1a7ebdee-28d1-49c5-beaf-53123a00b2d6"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1bb320df-8cd4-4cfa-81bc-c9eead018e5f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1e266307-1c76-417d-bcb9-ebc0eaa55892"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2451eba4-6c98-4539-a57e-3471fc14de03"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("25eb2c40-ddba-49fe-8a64-23cec1876a18"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("269def19-9f8a-40f3-a8f5-db9d3370fc95"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("28e1a4fb-060c-4383-a190-60ffa88138aa"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("29e9ee74-e080-416e-bf7c-13258de77da9"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2bc8918f-1b2a-4b50-bb82-4b369e8693af"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("34c7da0d-a0a7-48a8-94b3-c224fcb4e81f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("36b91f72-f180-4ce0-acc7-255a66bf9373"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("36fae0d5-a708-429b-8494-d0ca006c68f6"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3a2d7be6-8d1a-4f67-9102-37202f1ec175"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3f15eb69-919a-41a1-b194-d68d33796633"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("40536c73-7c98-4f39-bece-f1ff1de30242"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("414dc76d-9b43-4d71-b2c6-897394854bcc"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4204dbd1-e41e-4500-a592-be3084ef2ce1"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("45c0d8b6-d16e-4a5a-b7f6-596da1493d2c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("45fa32c6-57f8-40d3-9f8a-b24de77843b4"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4a604beb-1c18-4709-92d5-9e58ffd10295"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4d3213c8-d140-4952-8d2c-620797099e77"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4e576441-5a4f-4e2c-9f26-fab7b3be8eae"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4faddfe5-516d-4b4c-8526-0adcf1c03876"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("657e5fa5-98bc-49ac-841a-9c24142bcc32"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("692c1319-e580-43f6-9e9f-75eeb26692d5"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6c428269-4071-4c35-9a9b-c980c0b8f1d0"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6d7f4a95-35ff-4a91-9a4d-1728c62f92ba"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6fea2ea0-e837-4ebf-92dd-4d9b74526f03"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("703b428d-dd36-4ca9-aad5-d1bd61d5e186"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7463de2b-46a3-4549-84f4-2b5d5bd02492"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7728b1ca-73f0-4b27-985b-6a605aee31cd"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("78754eb3-11dc-4ef6-9065-5de0f8261d92"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("791a116a-6866-448f-a64c-bbf2fc0f1130"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("79ff70a6-449d-4fd2-a0f9-c29a6d21903a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7b5fe619-0b8f-43d0-b62c-10404d7fdd79"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7d3e364c-af91-45b4-8011-053b907a9e1f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8726c5ba-a58a-4e05-ad4f-6240656b5256"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8961292c-0087-49bf-a239-db62a7163a94"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8aec9d92-aa90-4344-8bb0-9eb077f9b854"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8e3a44f3-4b0d-427c-8039-b6128073c608"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8ef62fb3-300b-4c0e-9731-1e55fd776a77"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("934dfd41-df6e-429d-ad4b-a11af6c4a4b4"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("946086c5-64ab-4160-8520-04c1e8496186"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("95a5a3a4-04c2-44b0-9972-07bfea0de4d5"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9ac8ba7b-61fb-4c61-bf84-4db4b1abbe64"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9c1aee78-c245-4c6f-b556-08e9cf2039c9"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a2b46dab-c01d-4f3b-9990-0db22f13ec14"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a6b055f2-f291-4606-9554-cee2f387650e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a7256ddb-c343-4824-8eb8-129d1c10ad76"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a788d503-35e9-4933-a76d-bd21ea291ea8"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a8e708b8-0926-4eaa-8007-1ecfdc0f81d3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a981b497-d0f9-4992-9a6b-b93778fd3012"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("aadc8072-213b-44b8-a074-3b420d9e4a7e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("afcc5a18-c14f-468a-9994-0c04465bf198"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b106b2fb-c619-46cd-a56c-582c1f9501b3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b2b19e88-cf90-495a-a9ee-baaa32b200ce"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b4af13ea-0784-4277-9d8f-dbb4fb8215d1"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b79e92db-0a7c-4a0f-84bb-c9c8911bdb48"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b87f0d43-ad02-4a2b-9a88-9e5512c7f8c6"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b87f0fdc-5b39-4c36-802f-171def23184b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("bac45c07-65e1-4fcc-9365-7c94a634805b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("bb17ecc3-898d-44ad-a5d4-771b6b6411e3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("bb63cad7-ff26-402c-a69a-caa05d8f7049"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("bebb2777-b13c-4a4e-b2ed-9e8c3d74804f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("bed682c1-9aaf-49cf-a791-0422648dd11f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c0266fc8-ecb2-4d1b-ba2a-ad6c5bcf5706"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c340ac19-6f01-4c9f-8dfb-d21214cdf0d4"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c53ce5f5-84d9-4f30-be7c-62e0add2f135"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c5c0ed9b-a0d3-4121-949b-d35e5a2d08ee"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c678e8d1-6e76-4625-984f-e0654f4a35d4"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c8709644-1471-4881-bb8b-806893d91231"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c8b496ad-40ea-4a6c-8495-ab5af4570ff5"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c9688a5a-50c3-434f-b505-d9d67717a323"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c9f8c340-e753-4a32-b7bd-cf6b35240b10"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ca624178-2730-4bae-ae70-62efebe06be2"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("cb7c6dd7-7501-46ca-80dc-3d8fb6716af4"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("cd5404b4-0786-452d-8068-1450da45786c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d14e5f25-dae5-411a-bd7e-fe3f8b9c9565"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d2d45fe5-82ff-48ac-a736-cf5696aae152"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d4c5d203-a28c-4976-acbf-5d3452c2273b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d82a6994-2b20-452e-a1a1-d68242f4a89c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d82b1c0b-ad5c-46bb-ac0e-6c6a35379120"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("db23f67a-05f1-4f18-b708-3ec8971d8191"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("dd055ab0-b141-4002-ba75-56a755aeaf44"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("de1c6ebc-cb55-4037-85eb-c1b33923b4f7"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("debe514a-2b05-423d-a0fd-6279c46c02b9"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e2d6c706-4df3-438d-9cf2-e0b6a4aa4b40"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e457d967-c6f5-4c0a-9809-bd49524a8f57"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e742cf47-0bb6-4cf7-920e-8e30c91715bb"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e8468d57-38d5-414a-8c62-ed1f21529e21"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ea43c5e4-dc49-4705-b649-88188780122f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("edc6c3b8-46b7-448e-8b55-5e6c73e8669b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ef5d97d3-45f0-46cf-9b92-ed2d7d662199"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f4920f06-22bb-4dce-a6a0-ca4ffda5cc7d"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f542b5ec-9668-45be-a7ef-c5c523c012c3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f6805100-e668-47f6-b369-b2c09edac529"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f9fc0cd9-4295-4684-8f00-0e04eb7f042e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("fae7ea8e-25f7-45e3-bb42-aaf4ec5bce14"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("fd7989a4-d609-48fc-b2c0-c5b565f3f69e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("fef30195-8fc4-49b2-935c-07f8d6012327"));

            migrationBuilder.AddColumn<string>(
                name: "SalesPersonId",
                table: "TransferStocks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("793b16a2-3b65-44d1-ab87-1c2775701499"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("ded3cab2-78a8-4e3d-87a7-fa223964c6dc"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 405f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("d6c17da7-ae17-413b-88d9-9ef2876504e2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 400f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("40dbcd58-b88f-4c34-9897-36f12c2860e5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 395f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("986a8399-1525-4e15-9ada-818722274d2b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 390f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("7e4016b5-e22a-4661-863b-b889a63e9f66"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 385f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("fb0121d7-4fde-46f4-96a6-f7d971cc270f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 380f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("a529bb55-f919-4475-aab4-6fedee9e4253"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 375f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("dbcc22a8-1636-4c22-8163-3b90a1680e7c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 370f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("8b2284ab-9652-41e3-9801-36decfeb5904"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 365f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("6fd765df-3447-4433-8625-b8b6fe4f6b27"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 360f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("6220f0fc-7682-4668-a988-05eb83450a1d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 355f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("8973f653-350d-4ec9-9efe-e890558e69cf"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 410f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("926e9c7d-e1d1-4388-9ac2-8a42e9a24399"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 350f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("336e309d-07fa-4e55-960a-50eaacc1677f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 340f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("0ede0c05-11a9-43ee-af9f-aa7acdeee6c3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 335f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("22dc2f12-a37e-483e-9a2e-2975722e1b77"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 330f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("beccd26f-4021-44d9-b28a-5a1e9e43bf66"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 325f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("e801ef7a-c414-49ae-bfeb-6380e7e832bc"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 320f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("8d5043f6-7d1b-43fb-912e-7a888777a3e9"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 315f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("6d460fd9-be37-4841-9ded-dc556fd5d06f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 310f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("cf6aaa7c-b456-4606-9e1c-19d2dbb12a90"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 305f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("00eb7f8c-5854-47a3-ae33-04c294abbfec"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 300f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("062730f6-bdbb-4bf0-83cb-48c268ce28d4"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 295f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("a94bdfaa-1d0c-414b-aae7-3eb20494c330"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 290f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("1587ac25-97b7-46f9-bbef-732cea779a39"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 345f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("9508cba2-4818-45af-a9af-d2ed76341288"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 280f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("81993684-686d-43a8-b9c3-f921466d491a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 415f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("dca99b90-e55e-4d71-8932-2bda18295486"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 425f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("1c917ef9-2444-4c0a-9160-f680fbab2fb0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 545f, new Guid("8c74fc65-b701-4ade-9f97-7a7a744e2e59") },
                    { new Guid("951ec695-0b7e-487e-b6ca-bb29fe7b1422"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 540f, new Guid("8c74fc65-b701-4ade-9f87-7a7a744e2e59") },
                    { new Guid("dac85856-153d-4167-b406-5441723f0db0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 535f, new Guid("8c74fc65-b701-4ade-9f77-7a7a744e2e59") },
                    { new Guid("7cd6d00b-4be1-4832-947f-4986e58b8b74"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 530f, new Guid("8c74fc65-b701-4ade-9f67-7a7a744e2e59") },
                    { new Guid("45c3aa6d-9a58-49f9-9f8b-8f081e7fab4e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 525f, new Guid("8c74fc65-b701-4ade-9f57-7a7a744e2e59") },
                    { new Guid("9bd15c46-9f4e-4237-9a41-fc29eb4ab0f2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 520f, new Guid("8c74fc65-b701-4ade-9f47-7a7a744e2e59") },
                    { new Guid("cfa59692-8a4d-499c-bd01-a680619a3174"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 515f, new Guid("8c74fc65-b701-4ade-9f37-7a7a744e2e59") },
                    { new Guid("b8a475d7-4617-45bb-bbfc-46a6d93903c3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 510f, new Guid("8c74fc65-b701-4ade-9f27-7a7a744e2e59") },
                    { new Guid("154ddf5a-e1a5-4d27-86ac-351beee11d15"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 505f, new Guid("8c74fc65-b701-4ade-9f17-7a7a744e2e59") },
                    { new Guid("ee6b22cd-54aa-4fc1-b06b-c6a241e27aad"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 500f, new Guid("8c74fc65-b701-4ade-9f07-7a7a744e2e59") },
                    { new Guid("8d30774a-2025-48f4-ba9c-3a7dce8143be"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 495f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("b776f342-ed9e-49f3-b15c-58f51ee1a5f3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 420f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("2b2d679f-c498-494a-8425-3c311fc89fc0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 490f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e59") }
                });

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("1361de67-50a2-4081-a151-6eaabe779686"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 480f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("3cfc9b19-7948-40ea-b743-45858b22734c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 475f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("82117e54-c876-40a5-a106-87a492159850"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 470f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("161077a5-44cc-4cbc-8c0b-4b3d8bdcab6e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 465f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("91c921cb-a22b-40b5-968c-556a37033efe"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 460f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("d4b50184-82fd-444d-8d04-d442f6476fb2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 455f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("8eb7cc41-85cc-4ad8-a9d9-2194cccee5fe"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 450f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("8e12c182-0573-4e14-9784-571b36af1cb7"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 445f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("3a7dd631-a731-4153-bc0b-89682f013855"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 440f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("efc62ea2-b75e-43b5-ae48-4f796ff0a8f1"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 435f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("fd2a69c9-1866-4616-ac61-202bfb96d076"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 430f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("8929c132-7b29-407d-92fd-74ed02d60abc"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 485f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("91062103-a31e-4f58-ab2c-2c2729578dd8"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 275f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("a02b32dd-e905-4ee3-82a2-c1c9746e5c46"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 285f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("e4a63713-bf22-4357-b9cb-8a00825139c4"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 265f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("57ef7ae5-3aed-4654-9a9a-0c218bdb6a3e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 120f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("530ca460-d46f-435f-b953-1dd147d7b5e7"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 115f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("9b159832-648c-428b-9d6e-71fd796cada0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 110f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("f5735908-1b30-4837-8661-35092d0b89d6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 105f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("f3cea749-9f71-4801-8b6a-c544e198a6d8"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 100f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("6e2b37ab-3e00-42fa-ad18-6183e5efe9bd"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 95f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("9abebbf8-43b6-4bcb-868c-d1d2bae2c2f7"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 90f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("4666ef6b-5a29-4cc6-a89b-950a0f356529"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 85f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("1e955201-c3f1-4e8c-aeb4-5c0b919cfcb0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 80f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("e43a9a46-3f75-4a82-a382-c2552ffbbae8"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 75f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("be6f319d-ca6b-4bf8-9ed2-9b3d1df13153"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 70f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("7b8d0f80-7b1f-4c9b-95c4-6902c6e969ea"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 270f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("f9df11c4-a8d0-4026-b2e7-c7e7c86f3926"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 65f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("9c2ca511-0d39-4e4e-b403-dad714301cdb"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 55f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("217ee72a-d667-459a-b953-0e0b03ad4113"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 50f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("c0a787e4-4a75-402b-b6a4-014060567e33"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 45f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("434314f9-4a43-4b99-843f-0b161fd0e131"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 40f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("cd2ee22b-4e3c-4d9a-9a1b-489fd9cfb534"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 35f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("3ac5cd44-3a2e-4f4d-8722-fba07671fe51"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 30f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("1829022e-f64f-454b-85c7-3a97c2812eef"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 25f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("c8aa9826-4c27-41a5-9dfd-92dde569bd1a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 20f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("c49a8a23-7dff-4811-b309-b51ee3263eeb"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 15f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("2416705d-889b-4d22-abaa-25cd415e234d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 10f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("db94a8d2-3bb5-4c19-a7bb-7e8caa18cd11"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("354a35d6-e7b9-4cfa-88ae-b202d6ed29e9"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 60f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("568b17b9-ef6d-4cd7-81de-a6a39f4a719d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 130f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("112995fd-1161-4cc7-824e-3fba2265f971"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 125f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e52") }
                });

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("b0e08c91-e0c9-4ad6-a4c9-96421731545c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 140f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("afadf6a4-b7e4-431c-8887-c9ae896316db"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 260f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("54252334-3f9d-4932-bff1-31f12a892d63"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 255f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("fa93210b-cc16-40c7-a03a-4356250ab127"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 250f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("08b00e67-bee7-4f28-a445-4ab3bc7de37f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 245f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("347c68f8-80c3-4929-a914-1c66083f517e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 240f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("55fa3cd6-bc0f-480a-bb4c-14b9bc060028"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 235f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("a307e6ca-9179-4d9b-9679-95828384a563"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 230f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("7932fe87-9ecf-4bfb-bb10-505fefc7948c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 225f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("42541c36-b01f-4291-b282-c6f90d32bdf2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 220f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("cc9ce403-4961-45a5-a2ba-4396a63b1c6d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 135f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("9b57f42e-2410-4856-8821-f9e9fe954ebe"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 210f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("7f29e49b-56fe-4931-b60a-a0d449234507"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 205f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("74970667-0472-4fb6-8817-c8cbe2cdeb57"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 215f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("8e712a62-752f-4c30-b8c7-886947b51e7f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 195f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("0723e8f0-d335-4fea-b47e-bcb51e33b577"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 145f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("2e202bfa-4bd3-4b67-b043-295d2969d743"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 150f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("b5a03072-138e-447b-a011-2fdc30e6a3fc"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 200f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("85eb86e3-ee4b-47a7-b618-9e0a8134aa80"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 160f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("7ac54894-2734-43ba-9835-13d7057f6cdd"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 165f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("adbf26ed-99ac-4d74-80af-05303c43bf08"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 155f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("0a4a5215-4c9d-4a89-99ac-2c8fa95e925e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 175f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("ce2830e1-a183-40ce-aa77-f60010061f7c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 180f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("3a7d40e1-8916-4b72-b91b-40145868a3ef"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 185f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("a801abb2-cd48-401a-9acf-a3c7999cdf51"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 190f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("941eb151-288a-4b13-bf15-a7f43b6d0876"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 170f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e53") }
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1570902e-48bb-4b03-850c-8ebd63261e33",
                column: "ConcurrencyStamp",
                value: "b0946a6b-3531-4c9e-bfc9-69cc477ad08d");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "4ce95b9b-0760-4f11-b576-71dfaa053e74",
                column: "ConcurrencyStamp",
                value: "2e611baa-a239-4f3e-af45-7d8a4a6e01d1");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "c057793d-9d0d-4f1d-9fb0-2335480d82e2",
                column: "ConcurrencyStamp",
                value: "7643ceae-b145-438b-90d2-d34358e4fa1c");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "f4ea0102-2c6d-453e-8365-cb45c956cc44",
                column: "ConcurrencyStamp",
                value: "f5a05120-e4c5-43c2-816a-131541cac7c2");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "0daec62b-312f-4016-9c5e-a15354259c90",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ba326b7b-7cb8-4c12-8a86-1569f7fececa", "e47093bf-1734-40fe-8120-c1ffcd316384" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "569411c1-88ef-45b6-ab57-79665fbcd9a4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4d05caf5-17db-447b-b3d8-5147299d201c", "103aa3c6-9ccd-4399-8192-f4808e2b1d78" });

            migrationBuilder.CreateIndex(
                name: "IX_TransferStocks_SalesPersonId",
                table: "TransferStocks",
                column: "SalesPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransferStocks_User_SalesPersonId",
                table: "TransferStocks",
                column: "SalesPersonId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
