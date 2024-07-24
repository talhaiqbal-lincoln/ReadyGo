using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadyGo.Persistence.Migrations
{
    public partial class AddingDeviceNameField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("01ea8240-823d-40ec-b96c-8e1d81c7875d"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0842f7e2-06cf-453e-b76d-8c00e902220c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0aa39766-f5ab-4fb2-a6f3-503d0c42df06"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0ae909b2-dfc9-4e31-816e-492a4cf99043"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0b1258f2-b141-4252-a438-4e3cb8a0c99b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0ce5ee3e-7049-4aed-99aa-5b5df95b33f4"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0dcc9db2-6076-4def-920b-dafaff67fb09"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0f823e31-fcc2-42c5-a402-007d0e1d03be"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("166fe51a-70a1-41ed-82c5-e62cb124fc47"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("16d7ad7b-b85f-4338-ae6f-77a900ae3e06"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("17335af2-ff5e-485b-b5d4-018dfdafecf2"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1a10b2c4-f1b3-4674-9143-23876c2ff4aa"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1a1c4b31-6d22-4585-b746-8d449265235a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("20e07c20-aa66-46cf-80d7-7778a68ac09f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("21149f41-5a5c-4533-b4ee-0ad095a92ccc"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2325a352-7d84-49c2-a026-7fe46f4b9b3c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("235a4603-ad82-48a9-a3ec-576021527951"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2545c8fe-9226-48b9-8ac2-d7db9b198545"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("25972c93-93ae-4256-9d62-83cba454aad1"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("27d626ac-d19d-4d52-ba0d-6668369f93b4"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("28458240-af3d-453d-bdd2-92e978ceae2f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("286d7786-5f83-4157-b457-b37493e80883"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("298ed412-6ebf-44ae-9daa-05ab0f0a4d97"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2ae0cfc2-ee89-4ff5-819a-d7735f83872d"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2c26804c-2ef9-4c1f-8300-086a0b99ad2b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2c91a9a1-1f8c-435f-b1b9-6ce6534612f0"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2e069c1f-6466-4bb4-8927-be18fea98257"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2e93b250-0d7b-4db9-931c-2d064245d36f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2fb3963e-1292-4169-9d0f-839012be0756"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2fd2b0f2-7c17-4eb6-9e7c-8328133b837a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("30f6edf6-78f5-452d-af18-f848a2297d1b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("31072199-14ff-4ffb-be6d-cc7f5bc5d22f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("324d2a8e-140f-496b-9a8d-c94e160fa548"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("35f61905-0ff0-4176-b772-70e9e28e8b3a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("37ed544e-90dd-4662-93d5-e32de3e25cec"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3c3245cf-9e56-4031-9529-8b9919f0f6d0"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3c82b780-c989-4ec4-8fe6-96b020185c5a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3ff0fc70-583e-4059-b994-bd6f0735f7ae"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("432c9192-ef4f-4d93-9748-a00f51bece7d"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4b50a19d-f1c6-4826-afb1-fb7f2796cb9c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4dcf8199-2930-464e-941f-99e81258cb83"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("58bee42d-c8bb-40f6-83e1-ef95964bcb64"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("5d095cfc-3a32-469e-94de-4abf6b356650"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("5dc7657a-1cb0-4b25-b4ed-4b67feba3914"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6139dda6-06c5-4a1b-8505-56e472d56015"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("62120faa-8500-4787-83c3-dfc23fdbf024"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6291eb14-cc33-4b3c-b38b-0239244fe084"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("62b847de-4b70-4bfc-b938-b36127864963"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("62cca137-93d9-4e39-8237-29aec5b09636"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("63c51963-a072-4e79-9546-acbd089d94c3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6597e043-aa90-415c-aad7-d12d8daffd19"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6710b046-052a-4d67-abe7-f268fb414446"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6846748f-6a96-425e-b2bc-33c379178d51"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6ad5b759-b26d-4c59-8ddb-207dd4b5d09b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6e4ef299-9ab5-4942-990b-97f13a7c117b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("711ee2b9-4af5-4b46-aaa6-d5d4289e53b0"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("718ca06d-ca3b-4273-9b6d-2bf82f9d178c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7358de90-e1fb-46fc-8e14-b8ed29996cfe"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7362b48a-ca59-4128-b783-ec73e56d9e50"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("80cd5c43-df09-4623-a70e-57dbe9d93d88"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("886eec80-4e74-46f7-a404-dd222ebe74b7"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("894d0350-6689-4e67-9a1b-f98e0a52168b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8b38351d-2c80-46af-aa04-b5e3ba60484b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8bef8ba6-60af-4271-8fbe-565cfc4514c5"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8fc65b3b-8c6b-481a-8cda-ce4a95fea010"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9329d3c7-de4a-44f3-924f-979d937c6e8a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9405c462-103b-4b0b-b020-3804b686b4b8"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("943e5a71-35c6-4702-8ab2-f99107f88bc9"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("95b4c545-cd4d-47f8-a44e-cc28ebbd499b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("96db3d59-bbae-4486-b555-b58551f1d227"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9bf6ce66-a284-43d2-a1e2-7d031e5a4749"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9d2b0a5b-d70d-4a38-ae76-3a6d382a0a6a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9ddd3d43-3974-40a6-ae42-818a6889c281"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a77fb565-75a2-4a4d-95d0-30e544a06410"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ae23c0d9-aef7-4468-b068-e5484d3082f2"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b2dc09c1-7a50-4304-9967-b13812361164"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b953dbe1-58a0-4a96-b555-d1a680ea04ad"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b99ba1bc-92f1-40ae-9647-bcbbf8bdbd1f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("bc067e12-5497-4282-b7bd-cb5cca23fdcc"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("bcf8ea08-1dc3-49bb-b260-2c92fd59c25a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("bdd1b709-a1b6-4ad6-87b7-033a68973148"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("bffae3ec-21a5-4e40-8063-072b605bf2f9"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c782f89e-24da-42a1-b0a1-824537db0d75"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c98a35f9-9963-4912-8b1a-c834d0b9cf7f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c9ae0371-fc7e-41c9-b1ee-6e69e08eac47"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ca1ede44-d3e6-4012-b98c-08132371c923"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ca6e503d-d307-4013-9550-c13d75a6c061"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("cbe5e270-e516-4818-9ccd-2325cb6744d2"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("cccc13ec-f23f-4794-b146-eca6e864e80c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("cdc06f0d-3934-4b66-973d-91aadb1876fe"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d03f65db-4b80-45f3-ba98-426e84350b83"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d0937e11-f0a1-4e9d-ad7a-bb9cd25c9dbf"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d322c1d0-23c4-44ae-a605-0aa793ae0a3f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d328e981-4554-42a6-8169-b1a05167464a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d5670fce-21cf-4971-9c4d-72bf5d919a06"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("dbeab3d6-2662-4992-bf23-9a60b7a55ca1"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("dbf01cda-cc86-49d7-9d8c-32c57d7d992b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("dfb7e4e0-5238-400e-99e0-820ecdb0ea2a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e2e620a2-6ba4-44a7-8b7a-dd1ce75e7b00"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e48b75e3-7038-4ea2-834e-67ad387ab679"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e756a978-c3d4-4024-98bf-f197836d3cae"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ebeb2f2e-e820-43a6-8091-d045d87894f0"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ec67597e-b487-4018-85ef-d67faa0cc4db"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ed470af2-5e4b-4afc-8d1c-643aca2875b4"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f10ae38e-4eef-4fa1-858b-83c42c3bc665"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f2678a62-00d3-43d7-bc7d-59c5aa242cd5"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f444870e-248b-4ddd-bf27-828c3dbc4b06"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f61f8de4-6d4b-4914-8c9f-2dd058d595a3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f82ddbdf-1fb7-416b-926c-76c8038cf215"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("fb0972c7-a37a-4db7-b2b1-3d7dc74ca3a1"));

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("01bc87ab-42b6-49c6-90e8-3ac066ed18a0"),
                column: "ReceivedAt",
                value: new DateTime(2021, 12, 16, 14, 8, 11, 69, DateTimeKind.Local).AddTicks(9337));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("01bc87ab-42b6-49c6-90e8-3ac066ed18a1"),
                column: "ReceivedAt",
                value: new DateTime(2021, 12, 16, 14, 8, 11, 69, DateTimeKind.Local).AddTicks(9645));

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("fdb69342-932b-427e-b515-4a0b75597633"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 405f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("dec8503f-41e3-4714-826a-a5c7f9a05362"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 400f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("f7255529-8dbe-4442-bad7-1c9f072ee9da"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 395f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("8e62fdca-8ea1-44e7-9003-840db02e6daa"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 390f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("cfbd0c87-3c1c-4fdd-9ead-c28f4612e305"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 385f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("69ae9bda-27d8-4545-942d-f3c1cfc1bf0d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 380f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("5e923f41-5468-465f-a566-8052a0cf5e5c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 375f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("1190271a-2bdc-4e66-b3f0-c86183c26f76"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 370f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("92ce3949-8f22-45ad-a6ca-7854e8eb74c3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 365f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("2c48f2df-3350-4185-bb1f-98beeaca0754"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 360f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("652ac3a7-57dd-464a-b03c-9bea973d036f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 355f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("1a7f2158-8c90-41e6-928e-6088e59e29df"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 350f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("a7c80fff-616b-4c08-b9d9-079160ac5015"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 345f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("1445ed5b-83fa-444b-8bb2-ef7f62ee8b62"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 340f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("d0b971fc-74e3-4466-a668-919b2d814c5c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 335f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("2e71d8aa-c2d2-4fc4-ac51-d849ac123164"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 330f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("47f8d619-adc9-4c9f-85bf-0d0e97c8407a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 325f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("ba76ed35-aa10-4ede-953e-b88635c38b1a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 320f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("e6d6f52d-bdb2-417f-ba79-1fe42fcc4ab6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 315f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("716c4d66-ff8b-4440-a5a3-7912f7f2e464"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 310f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("859d8e4f-16cc-4c3a-8568-1465684ccff1"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 305f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("fad01caa-24f8-49ce-b30f-cfc782325473"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 300f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("c0468f7d-49cb-4429-88ba-2cc9171fa342"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 295f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("33c26c5c-54d3-4801-860a-673cfecefcd5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 410f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("00fe3347-77a2-4acd-aaa5-28626e6a3c5a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 285f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("cd53e000-5c0b-4c1e-9b33-015b5da90415"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 415f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("42493785-589c-4434-a836-a26572160385"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 425f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("4a5c2109-2888-4f39-b97b-1cdaed9b6ded"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 545f, new Guid("8c74fc65-b701-4ade-9f97-7a7a744e2e59") },
                    { new Guid("aec76955-6d2e-463c-8b05-647d90e97e54"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 540f, new Guid("8c74fc65-b701-4ade-9f87-7a7a744e2e59") },
                    { new Guid("ba501926-7291-4f06-8d6d-50b452f80bc4"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 535f, new Guid("8c74fc65-b701-4ade-9f77-7a7a744e2e59") },
                    { new Guid("3502437f-b70a-4149-8c71-e11451208886"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 530f, new Guid("8c74fc65-b701-4ade-9f67-7a7a744e2e59") },
                    { new Guid("678892c6-b877-4463-884c-9f7cb123c492"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 525f, new Guid("8c74fc65-b701-4ade-9f57-7a7a744e2e59") },
                    { new Guid("ba0eaf95-68d7-4df3-a597-de41063087e5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 520f, new Guid("8c74fc65-b701-4ade-9f47-7a7a744e2e59") },
                    { new Guid("ac8da977-f273-47ae-8a1e-fc3dab68be7b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 515f, new Guid("8c74fc65-b701-4ade-9f37-7a7a744e2e59") },
                    { new Guid("f53081fe-d2c0-4942-b5fb-23283f2b1c82"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 510f, new Guid("8c74fc65-b701-4ade-9f27-7a7a744e2e59") },
                    { new Guid("68d397a1-3876-499b-924b-2f97cd44ebe3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 505f, new Guid("8c74fc65-b701-4ade-9f17-7a7a744e2e59") },
                    { new Guid("5fb5ed8e-6eff-4b0b-99be-2f726f87f697"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 500f, new Guid("8c74fc65-b701-4ade-9f07-7a7a744e2e59") },
                    { new Guid("68314c8c-5c46-44f3-9a0f-62a4303fd668"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 495f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("6d390220-e0bd-4152-bcd0-b30a6a8fbe52"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 420f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("65bcc07d-a7e6-415a-b5f3-4d41f9553337"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 490f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e59") }
                });

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("3b705796-e9ba-4e4d-aaf6-deeb2d9496fd"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 480f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("f30bb211-10b6-4d7f-8b41-24b71e59a609"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 475f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("3454dbf9-9774-4981-9ac7-9425e51296bd"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 470f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("5d56eb62-fcdc-40f1-803c-9aa8e7a580b6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 465f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("d192668a-c52e-4ba6-a96a-ee3257137e92"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 460f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("f1a76a6e-c775-4f10-b9ac-987ea47125d9"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 455f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("9cf74cea-acfd-4f3a-9d99-4a7f8fa246b5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 450f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("d6dfa93b-1a0a-4717-a035-ba9f23b37666"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 445f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("5e1e66dc-f120-493c-b102-977d4b91c14f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 440f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("0de06087-6af8-40e8-a665-d0798841ccfc"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 435f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("24d35be3-e890-4eae-b5f2-b7fdf001708b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 430f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("14d3517d-bd8e-4fb5-8f4b-cbe8fb221357"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 485f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("bb3063d4-3380-4ea0-8809-9c1b2e4b6f46"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 280f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("50329ec6-29fa-4611-b5ed-0d48b45ce94f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 290f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("0e8bff4c-03bc-49b6-afec-2b5a14cc4d5c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 270f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("c977e384-8a1b-47fd-83a0-a3f336345111"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 275f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("42b2e71f-0365-41a3-8558-93b0aaaea7bc"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 115f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("b422a302-3668-408f-99d3-345e45620014"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 110f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("1b35f30b-7317-4b6b-a4d3-0627a8e7de34"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 105f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("ef2b9f3d-9e72-46b3-9dda-eebd775f3efc"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 100f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("b5899ef1-f045-4b62-8954-bb92c5f138ec"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 95f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("f6c55463-f9e0-4932-94bc-6546ec0adc11"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 90f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("bfeb14c6-cf56-4c18-8499-68fb228e7de5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 85f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("c992faa2-bf26-4fcb-a6c2-a03772462694"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 80f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("53d5c2a5-397b-46af-be0d-a81991075d9f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 75f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("4675cc90-2d81-4a1c-b35c-77ab7bfa55b8"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 70f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("eaa003a3-2b93-4844-a60a-cf7c72b867a6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 125f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("0fb1d4ce-c97c-4997-8fee-4935be3c17d7"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 65f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("d4448678-2d7d-48a8-ada7-64819d05caff"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 55f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("5e326b36-b9cf-4530-a467-dd845a4f4f7d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 50f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("019d40d7-3a64-4897-84d3-53977a8c2830"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 45f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("b39499dc-bb12-4c09-91bf-a3e99a13ef9b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 40f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("0b518903-9991-48e6-8edd-04e2e1adf249"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 35f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("c9a38da4-bd8c-43ab-adde-9abb1d59d1a8"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 30f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("93097554-7599-4668-be2c-add12f7dddac"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 25f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("0b9a4e04-3376-40d2-ab19-ddcbce3e54a1"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 20f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("95ff8be0-9349-41eb-b588-92484fe10e1d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 15f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("275d9975-6de1-4042-87b7-a7187e601878"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 10f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("d5e7444f-21b9-466b-aaf7-036a3bec1203"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("177ee07e-40eb-4c53-8d59-01e8a3742f17"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 60f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("79f0d57b-d419-4167-8520-8725ccb46362"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 130f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("a1041d5c-9d43-41c4-8641-e93501419634"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 120f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e52") }
                });

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("617e040b-ada2-4999-ac29-ae80ed36e068"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 140f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("997f1a01-4e48-49b7-a52e-4acbe26794b6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 265f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("e8fee688-8076-45af-bf20-90cadd0b683a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 260f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("03e25489-1bc6-4b86-b7d5-0057042b3fd1"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 255f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("eaacface-9530-44e3-b801-7059a96670fb"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 250f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("1591fa4d-c0dc-4dc1-87c2-70ec672d6eac"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 245f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("2a9e12ed-576e-48cb-b63b-b1e5325b3db4"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 240f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("db616da1-2990-4d5c-9ccf-f9711acd4962"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 235f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("14ed3849-4cf4-4c32-853d-bf398316d84e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 230f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("581bd65c-d0a5-4339-9ab8-b681fdc1eb27"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 225f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("ef39a96a-7e5f-451d-86e7-f0ac2aeb06a1"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 135f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("b81a8125-d1ba-4289-b079-7eae9aa3459c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 215f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("c06bb87a-994e-4740-8781-58c3df780d26"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 210f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("63dd034f-f770-41e9-9d45-26186e15d6fe"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 220f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("c8c5d51a-b9ea-41b9-bded-8c000e5b268f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 200f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("beb4536c-3175-4532-a55c-55a957d0e87c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 145f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("253ac6e3-f66c-4dec-940a-0122b97f519f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 150f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("f1ad523d-f979-4a75-9d24-156996dd76f5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 205f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("d85a1279-452a-4dda-aadc-7d3ba40b7f56"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 160f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("832a8f25-23c1-434c-816c-328d3c5e11af"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 165f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("0e896d8a-a8ef-4a7a-a3ce-8451120a4674"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 155f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("138f3d4e-9346-4f0a-abb3-8e680801a448"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 175f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("3106afc2-b9ec-4d8d-8007-70d0109d9631"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 180f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("09e05182-fe14-4cf6-ae5d-f841564d0a95"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 185f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("d686ba26-2dbc-48ae-a96a-e3768d6015c7"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 190f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("f356fb51-a14a-4071-8621-67a9356989a6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 195f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("0270ba2d-8f23-4e1c-8853-69a88f6a38a2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 170f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("12e4adf1-7e41-43c6-9221-42d11324a67c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e50") }
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1570902e-48bb-4b03-850c-8ebd63261e33",
                column: "ConcurrencyStamp",
                value: "a11a6d08-3e9d-4b82-97b8-cffa3ff0905e");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "4ce95b9b-0760-4f11-b576-71dfaa053e74",
                column: "ConcurrencyStamp",
                value: "3fa7bb29-0891-456c-a89c-7290e4038acc");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "c057793d-9d0d-4f1d-9fb0-2335480d82e2",
                column: "ConcurrencyStamp",
                value: "45fe3c09-c438-4d2a-a5fc-fa495f77171c");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "f4ea0102-2c6d-453e-8365-cb45c956cc44",
                column: "ConcurrencyStamp",
                value: "5980b3ec-0e54-4533-afca-dd978c64c775");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "0daec62b-312f-4016-9c5e-a15354259c90",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9826421c-373a-4503-b30f-7ee60f18cff4", "8825d13a-3bfe-4ea3-a4d7-a9235c5789f2" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "569411c1-88ef-45b6-ab57-79665fbcd9a4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "68f35246-e94c-400c-b240-3a02ec5b9223", "b1f29d88-93e1-461c-92c6-d62033f050e1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("00fe3347-77a2-4acd-aaa5-28626e6a3c5a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("019d40d7-3a64-4897-84d3-53977a8c2830"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0270ba2d-8f23-4e1c-8853-69a88f6a38a2"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("03e25489-1bc6-4b86-b7d5-0057042b3fd1"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("09e05182-fe14-4cf6-ae5d-f841564d0a95"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0b518903-9991-48e6-8edd-04e2e1adf249"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0b9a4e04-3376-40d2-ab19-ddcbce3e54a1"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0de06087-6af8-40e8-a665-d0798841ccfc"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0e896d8a-a8ef-4a7a-a3ce-8451120a4674"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0e8bff4c-03bc-49b6-afec-2b5a14cc4d5c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0fb1d4ce-c97c-4997-8fee-4935be3c17d7"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1190271a-2bdc-4e66-b3f0-c86183c26f76"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("12e4adf1-7e41-43c6-9221-42d11324a67c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("138f3d4e-9346-4f0a-abb3-8e680801a448"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1445ed5b-83fa-444b-8bb2-ef7f62ee8b62"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("14d3517d-bd8e-4fb5-8f4b-cbe8fb221357"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("14ed3849-4cf4-4c32-853d-bf398316d84e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1591fa4d-c0dc-4dc1-87c2-70ec672d6eac"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("177ee07e-40eb-4c53-8d59-01e8a3742f17"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1a7f2158-8c90-41e6-928e-6088e59e29df"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1b35f30b-7317-4b6b-a4d3-0627a8e7de34"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("24d35be3-e890-4eae-b5f2-b7fdf001708b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("253ac6e3-f66c-4dec-940a-0122b97f519f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("275d9975-6de1-4042-87b7-a7187e601878"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2a9e12ed-576e-48cb-b63b-b1e5325b3db4"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2c48f2df-3350-4185-bb1f-98beeaca0754"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2e71d8aa-c2d2-4fc4-ac51-d849ac123164"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3106afc2-b9ec-4d8d-8007-70d0109d9631"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("33c26c5c-54d3-4801-860a-673cfecefcd5"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3454dbf9-9774-4981-9ac7-9425e51296bd"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3502437f-b70a-4149-8c71-e11451208886"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3b705796-e9ba-4e4d-aaf6-deeb2d9496fd"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("42493785-589c-4434-a836-a26572160385"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("42b2e71f-0365-41a3-8558-93b0aaaea7bc"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4675cc90-2d81-4a1c-b35c-77ab7bfa55b8"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("47f8d619-adc9-4c9f-85bf-0d0e97c8407a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4a5c2109-2888-4f39-b97b-1cdaed9b6ded"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("50329ec6-29fa-4611-b5ed-0d48b45ce94f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("53d5c2a5-397b-46af-be0d-a81991075d9f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("581bd65c-d0a5-4339-9ab8-b681fdc1eb27"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("5d56eb62-fcdc-40f1-803c-9aa8e7a580b6"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("5e1e66dc-f120-493c-b102-977d4b91c14f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("5e326b36-b9cf-4530-a467-dd845a4f4f7d"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("5e923f41-5468-465f-a566-8052a0cf5e5c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("5fb5ed8e-6eff-4b0b-99be-2f726f87f697"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("617e040b-ada2-4999-ac29-ae80ed36e068"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("63dd034f-f770-41e9-9d45-26186e15d6fe"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("652ac3a7-57dd-464a-b03c-9bea973d036f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("65bcc07d-a7e6-415a-b5f3-4d41f9553337"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("678892c6-b877-4463-884c-9f7cb123c492"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("68314c8c-5c46-44f3-9a0f-62a4303fd668"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("68d397a1-3876-499b-924b-2f97cd44ebe3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("69ae9bda-27d8-4545-942d-f3c1cfc1bf0d"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6d390220-e0bd-4152-bcd0-b30a6a8fbe52"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("716c4d66-ff8b-4440-a5a3-7912f7f2e464"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("79f0d57b-d419-4167-8520-8725ccb46362"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("832a8f25-23c1-434c-816c-328d3c5e11af"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("859d8e4f-16cc-4c3a-8568-1465684ccff1"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8e62fdca-8ea1-44e7-9003-840db02e6daa"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("92ce3949-8f22-45ad-a6ca-7854e8eb74c3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("93097554-7599-4668-be2c-add12f7dddac"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("95ff8be0-9349-41eb-b588-92484fe10e1d"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("997f1a01-4e48-49b7-a52e-4acbe26794b6"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9cf74cea-acfd-4f3a-9d99-4a7f8fa246b5"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a1041d5c-9d43-41c4-8641-e93501419634"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a7c80fff-616b-4c08-b9d9-079160ac5015"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ac8da977-f273-47ae-8a1e-fc3dab68be7b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("aec76955-6d2e-463c-8b05-647d90e97e54"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b39499dc-bb12-4c09-91bf-a3e99a13ef9b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b422a302-3668-408f-99d3-345e45620014"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b5899ef1-f045-4b62-8954-bb92c5f138ec"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b81a8125-d1ba-4289-b079-7eae9aa3459c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ba0eaf95-68d7-4df3-a597-de41063087e5"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ba501926-7291-4f06-8d6d-50b452f80bc4"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ba76ed35-aa10-4ede-953e-b88635c38b1a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("bb3063d4-3380-4ea0-8809-9c1b2e4b6f46"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("beb4536c-3175-4532-a55c-55a957d0e87c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("bfeb14c6-cf56-4c18-8499-68fb228e7de5"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c0468f7d-49cb-4429-88ba-2cc9171fa342"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c06bb87a-994e-4740-8781-58c3df780d26"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c8c5d51a-b9ea-41b9-bded-8c000e5b268f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c977e384-8a1b-47fd-83a0-a3f336345111"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c992faa2-bf26-4fcb-a6c2-a03772462694"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c9a38da4-bd8c-43ab-adde-9abb1d59d1a8"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("cd53e000-5c0b-4c1e-9b33-015b5da90415"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("cfbd0c87-3c1c-4fdd-9ead-c28f4612e305"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d0b971fc-74e3-4466-a668-919b2d814c5c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d192668a-c52e-4ba6-a96a-ee3257137e92"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d4448678-2d7d-48a8-ada7-64819d05caff"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d5e7444f-21b9-466b-aaf7-036a3bec1203"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d686ba26-2dbc-48ae-a96a-e3768d6015c7"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d6dfa93b-1a0a-4717-a035-ba9f23b37666"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d85a1279-452a-4dda-aadc-7d3ba40b7f56"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("db616da1-2990-4d5c-9ccf-f9711acd4962"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("dec8503f-41e3-4714-826a-a5c7f9a05362"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e6d6f52d-bdb2-417f-ba79-1fe42fcc4ab6"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e8fee688-8076-45af-bf20-90cadd0b683a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("eaa003a3-2b93-4844-a60a-cf7c72b867a6"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("eaacface-9530-44e3-b801-7059a96670fb"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ef2b9f3d-9e72-46b3-9dda-eebd775f3efc"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ef39a96a-7e5f-451d-86e7-f0ac2aeb06a1"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f1a76a6e-c775-4f10-b9ac-987ea47125d9"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f1ad523d-f979-4a75-9d24-156996dd76f5"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f30bb211-10b6-4d7f-8b41-24b71e59a609"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f356fb51-a14a-4071-8621-67a9356989a6"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f53081fe-d2c0-4942-b5fb-23283f2b1c82"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f6c55463-f9e0-4932-94bc-6546ec0adc11"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f7255529-8dbe-4442-bad7-1c9f072ee9da"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("fad01caa-24f8-49ce-b30f-cfc782325473"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("fdb69342-932b-427e-b515-4a0b75597633"));

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "DeviceName",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("01bc87ab-42b6-49c6-90e8-3ac066ed18a0"),
                column: "ReceivedAt",
                value: new DateTime(2021, 12, 16, 10, 29, 12, 524, DateTimeKind.Local).AddTicks(9615));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("01bc87ab-42b6-49c6-90e8-3ac066ed18a1"),
                column: "ReceivedAt",
                value: new DateTime(2021, 12, 16, 10, 29, 12, 524, DateTimeKind.Local).AddTicks(9929));

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("7358de90-e1fb-46fc-8e14-b8ed29996cfe"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 405f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("8fc65b3b-8c6b-481a-8cda-ce4a95fea010"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 400f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("bffae3ec-21a5-4e40-8063-072b605bf2f9"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 395f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("0dcc9db2-6076-4def-920b-dafaff67fb09"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 390f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("bc067e12-5497-4282-b7bd-cb5cca23fdcc"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 385f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("6710b046-052a-4d67-abe7-f268fb414446"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 380f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("0ce5ee3e-7049-4aed-99aa-5b5df95b33f4"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 375f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("9ddd3d43-3974-40a6-ae42-818a6889c281"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 370f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("01ea8240-823d-40ec-b96c-8e1d81c7875d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 365f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("37ed544e-90dd-4662-93d5-e32de3e25cec"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 360f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("2e93b250-0d7b-4db9-931c-2d064245d36f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 355f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("0842f7e2-06cf-453e-b76d-8c00e902220c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 350f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("298ed412-6ebf-44ae-9daa-05ab0f0a4d97"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 345f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("3c3245cf-9e56-4031-9529-8b9919f0f6d0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 340f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("63c51963-a072-4e79-9546-acbd089d94c3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 335f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("6846748f-6a96-425e-b2bc-33c379178d51"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 330f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("9329d3c7-de4a-44f3-924f-979d937c6e8a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 325f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("25972c93-93ae-4256-9d62-83cba454aad1"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 320f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("886eec80-4e74-46f7-a404-dd222ebe74b7"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 315f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("c9ae0371-fc7e-41c9-b1ee-6e69e08eac47"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 310f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("ca6e503d-d307-4013-9550-c13d75a6c061"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 305f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("b99ba1bc-92f1-40ae-9647-bcbbf8bdbd1f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 300f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("2fb3963e-1292-4169-9d0f-839012be0756"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 295f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("58bee42d-c8bb-40f6-83e1-ef95964bcb64"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 410f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("16d7ad7b-b85f-4338-ae6f-77a900ae3e06"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 285f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("e2e620a2-6ba4-44a7-8b7a-dd1ce75e7b00"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 415f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("711ee2b9-4af5-4b46-aaa6-d5d4289e53b0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 425f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("d03f65db-4b80-45f3-ba98-426e84350b83"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 545f, new Guid("8c74fc65-b701-4ade-9f97-7a7a744e2e59") },
                    { new Guid("0aa39766-f5ab-4fb2-a6f3-503d0c42df06"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 540f, new Guid("8c74fc65-b701-4ade-9f87-7a7a744e2e59") },
                    { new Guid("d0937e11-f0a1-4e9d-ad7a-bb9cd25c9dbf"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 535f, new Guid("8c74fc65-b701-4ade-9f77-7a7a744e2e59") },
                    { new Guid("2ae0cfc2-ee89-4ff5-819a-d7735f83872d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 530f, new Guid("8c74fc65-b701-4ade-9f67-7a7a744e2e59") },
                    { new Guid("4dcf8199-2930-464e-941f-99e81258cb83"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 525f, new Guid("8c74fc65-b701-4ade-9f57-7a7a744e2e59") },
                    { new Guid("b953dbe1-58a0-4a96-b555-d1a680ea04ad"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 520f, new Guid("8c74fc65-b701-4ade-9f47-7a7a744e2e59") },
                    { new Guid("9bf6ce66-a284-43d2-a1e2-7d031e5a4749"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 515f, new Guid("8c74fc65-b701-4ade-9f37-7a7a744e2e59") },
                    { new Guid("30f6edf6-78f5-452d-af18-f848a2297d1b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 510f, new Guid("8c74fc65-b701-4ade-9f27-7a7a744e2e59") },
                    { new Guid("dfb7e4e0-5238-400e-99e0-820ecdb0ea2a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 505f, new Guid("8c74fc65-b701-4ade-9f17-7a7a744e2e59") },
                    { new Guid("62120faa-8500-4787-83c3-dfc23fdbf024"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 500f, new Guid("8c74fc65-b701-4ade-9f07-7a7a744e2e59") },
                    { new Guid("6597e043-aa90-415c-aad7-d12d8daffd19"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 495f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("b2dc09c1-7a50-4304-9967-b13812361164"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 420f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("96db3d59-bbae-4486-b555-b58551f1d227"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 490f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e59") }
                });

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("235a4603-ad82-48a9-a3ec-576021527951"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 480f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("2e069c1f-6466-4bb4-8927-be18fea98257"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 475f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("432c9192-ef4f-4d93-9748-a00f51bece7d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 470f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("ed470af2-5e4b-4afc-8d1c-643aca2875b4"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 465f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("dbf01cda-cc86-49d7-9d8c-32c57d7d992b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 460f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("8b38351d-2c80-46af-aa04-b5e3ba60484b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 455f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("7362b48a-ca59-4128-b783-ec73e56d9e50"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 450f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("166fe51a-70a1-41ed-82c5-e62cb124fc47"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 445f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("bdd1b709-a1b6-4ad6-87b7-033a68973148"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 440f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("3ff0fc70-583e-4059-b994-bd6f0735f7ae"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 435f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("6139dda6-06c5-4a1b-8505-56e472d56015"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 430f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("2c91a9a1-1f8c-435f-b1b9-6ce6534612f0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 485f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("e756a978-c3d4-4024-98bf-f197836d3cae"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 280f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("62cca137-93d9-4e39-8237-29aec5b09636"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 290f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("dbeab3d6-2662-4992-bf23-9a60b7a55ca1"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 270f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("80cd5c43-df09-4623-a70e-57dbe9d93d88"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 275f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("20e07c20-aa66-46cf-80d7-7778a68ac09f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 115f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("2545c8fe-9226-48b9-8ac2-d7db9b198545"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 110f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("5d095cfc-3a32-469e-94de-4abf6b356650"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 105f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("d328e981-4554-42a6-8169-b1a05167464a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 100f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("d322c1d0-23c4-44ae-a605-0aa793ae0a3f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 95f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("3c82b780-c989-4ec4-8fe6-96b020185c5a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 90f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("95b4c545-cd4d-47f8-a44e-cc28ebbd499b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 85f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("f61f8de4-6d4b-4914-8c9f-2dd058d595a3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 80f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("cbe5e270-e516-4818-9ccd-2325cb6744d2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 75f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("718ca06d-ca3b-4273-9b6d-2bf82f9d178c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 70f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("1a10b2c4-f1b3-4674-9143-23876c2ff4aa"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 125f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("f2678a62-00d3-43d7-bc7d-59c5aa242cd5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 65f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("6ad5b759-b26d-4c59-8ddb-207dd4b5d09b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 55f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("2fd2b0f2-7c17-4eb6-9e7c-8328133b837a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 50f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("fb0972c7-a37a-4db7-b2b1-3d7dc74ca3a1"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 45f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("ec67597e-b487-4018-85ef-d67faa0cc4db"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 40f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("ebeb2f2e-e820-43a6-8091-d045d87894f0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 35f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("21149f41-5a5c-4533-b4ee-0ad095a92ccc"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 30f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("2325a352-7d84-49c2-a026-7fe46f4b9b3c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 25f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("943e5a71-35c6-4702-8ab2-f99107f88bc9"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 20f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("9405c462-103b-4b0b-b020-3804b686b4b8"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 15f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("ca1ede44-d3e6-4012-b98c-08132371c923"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 10f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("4b50a19d-f1c6-4826-afb1-fb7f2796cb9c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("28458240-af3d-453d-bdd2-92e978ceae2f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 60f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("c98a35f9-9963-4912-8b1a-c834d0b9cf7f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 130f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("f10ae38e-4eef-4fa1-858b-83c42c3bc665"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 120f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e52") }
                });

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("62b847de-4b70-4bfc-b938-b36127864963"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 140f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("6e4ef299-9ab5-4942-990b-97f13a7c117b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 265f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("cccc13ec-f23f-4794-b146-eca6e864e80c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 260f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("d5670fce-21cf-4971-9c4d-72bf5d919a06"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 255f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("5dc7657a-1cb0-4b25-b4ed-4b67feba3914"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 250f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("f444870e-248b-4ddd-bf27-828c3dbc4b06"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 245f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("9d2b0a5b-d70d-4a38-ae76-3a6d382a0a6a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 240f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("bcf8ea08-1dc3-49bb-b260-2c92fd59c25a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 235f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("286d7786-5f83-4157-b457-b37493e80883"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 230f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("31072199-14ff-4ffb-be6d-cc7f5bc5d22f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 225f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("ae23c0d9-aef7-4468-b068-e5484d3082f2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 135f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("f82ddbdf-1fb7-416b-926c-76c8038cf215"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 215f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("c782f89e-24da-42a1-b0a1-824537db0d75"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 210f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("e48b75e3-7038-4ea2-834e-67ad387ab679"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 220f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("6291eb14-cc33-4b3c-b38b-0239244fe084"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 200f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("0ae909b2-dfc9-4e31-816e-492a4cf99043"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 145f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("cdc06f0d-3934-4b66-973d-91aadb1876fe"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 150f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("27d626ac-d19d-4d52-ba0d-6668369f93b4"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 205f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("17335af2-ff5e-485b-b5d4-018dfdafecf2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 160f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("1a1c4b31-6d22-4585-b746-8d449265235a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 165f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("8bef8ba6-60af-4271-8fbe-565cfc4514c5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 155f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("324d2a8e-140f-496b-9a8d-c94e160fa548"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 175f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("0b1258f2-b141-4252-a438-4e3cb8a0c99b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 180f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("0f823e31-fcc2-42c5-a402-007d0e1d03be"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 185f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("894d0350-6689-4e67-9a1b-f98e0a52168b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 190f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("a77fb565-75a2-4a4d-95d0-30e544a06410"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 195f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("35f61905-0ff0-4176-b772-70e9e28e8b3a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 170f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("2c26804c-2ef9-4c1f-8300-086a0b99ad2b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e50") }
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1570902e-48bb-4b03-850c-8ebd63261e33",
                column: "ConcurrencyStamp",
                value: "a388ed5c-faa2-47f1-901d-eed3f95c75c2");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "4ce95b9b-0760-4f11-b576-71dfaa053e74",
                column: "ConcurrencyStamp",
                value: "2deb8137-0e70-4793-b665-507876cf7e45");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "c057793d-9d0d-4f1d-9fb0-2335480d82e2",
                column: "ConcurrencyStamp",
                value: "64173d2b-599f-4206-87bd-c67855fc68c6");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "f4ea0102-2c6d-453e-8365-cb45c956cc44",
                column: "ConcurrencyStamp",
                value: "6d2a2f05-d82a-4662-ad29-a55d37b85570");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "0daec62b-312f-4016-9c5e-a15354259c90",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "13399bc7-b9c6-4bfb-bf0f-d3da6aa6ea5d", "cf708e2d-c01b-40b5-bd70-ea635c4ee0a0" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "569411c1-88ef-45b6-ab57-79665fbcd9a4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6afccb66-fcb8-4571-9674-e213854582f5", "f6e4f6b5-6834-4976-8896-9c7e46bc7a01" });
        }
    }
}
