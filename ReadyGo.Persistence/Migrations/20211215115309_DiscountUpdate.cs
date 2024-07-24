using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadyGo.Persistence.Migrations
{
    public partial class DiscountUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Discounts_DiscountId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "OrderPromos");

            migrationBuilder.DropIndex(
                name: "IX_Customers_DiscountId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("04e82db9-9bf7-4dc6-8dfd-8d8eae2bf2fe"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("06db265e-39e5-41b1-bb10-4bd0ec429eea"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0b2dc907-0c4e-4a21-bbaa-ecfe6e77f6d1"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0cb97355-8010-4d46-b1ae-43db57577718"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0cca895e-b5ba-4db2-8fe6-548ed3092b88"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("101507ed-2373-4ba9-aa49-7da07f7a7996"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("19cd0d13-dd37-46de-a0ff-e1d4d4a45403"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1ae3ff92-db51-4f51-8302-8bc5c233f4c3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1c7df391-4750-46ed-a25c-3993e4b88a06"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1d71020c-fb38-4f4a-9b7f-d0bbc406c83d"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1eb7b948-23bd-46d7-992e-5c57e0510e58"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1ecf21d1-250d-480c-b698-441594358968"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2303fed4-8bb4-48be-badd-566cdbdf1564"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("280b86a6-994e-42e4-8629-48dc9f28f842"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2acefec1-8230-4bd4-bf08-c3332620cb99"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2ce1fbdd-6db6-4af2-bd39-54ee566a97da"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2fe887af-e1ef-4bc8-a014-5db2674fbbec"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3097af7e-6031-4966-83bb-4754a58e79e7"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("363f5d22-3c69-4f97-a51a-ba509ceb523e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("38e86ecb-e0cc-40d2-954c-efd3ebd0ecb2"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3c01f4f3-748a-4374-8e1d-97141830e96f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3c3293e1-e8f9-4708-8f2b-207d9b58c9b5"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("40b45517-40d6-430e-bfff-41943abef311"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("425e4c7f-4f3b-41d3-ba9e-85125903ebf0"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("437dc4c0-6cd8-4e99-86dc-6322b0fb67d1"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("43971afa-99fa-4f86-9fcb-3f66618cb96e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4811197c-5e66-46f2-ba85-08c95a9a7bac"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4a098063-7801-48ca-9079-cdbd1d5f1e04"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4a236811-dfa1-415d-a71d-8343e99b64dc"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4a4a3d96-7b01-4db9-a852-0706d5640b1f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4c51ab6d-0209-4302-99b9-95c437355bd9"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4ec34060-4f69-48d2-9d2b-b6a6348929a3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("5de27521-dc02-45bf-b462-15579a7a8360"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("606e847c-5cb6-4ddb-9904-7384f3f5e013"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6272d441-4c08-4f0c-a7fe-342662d12542"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6639152e-c034-49ef-95ef-71faf713bd29"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("67cf8ed1-068f-4330-9798-a5bd0e297947"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("68990970-5715-44ea-8e1a-68116192804a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6afbb50b-af18-4526-a368-682834c57fb9"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6d3de5e3-f824-4ae0-82e7-2266edb11d15"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("70a49c38-0cd7-4f4a-b45e-c8a4f50ec6d5"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("719dbb6f-19e4-4686-b359-8fe7001e9221"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("71a08500-061c-4242-950d-d668b0df1a8e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("71d6e7cd-7e9d-4f5b-b0c5-f62b910cb563"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("754280cf-41d8-4c46-a877-7cd116a0ead3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("78967e8e-a410-47cd-a278-0078134a9513"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("78eb1f0e-0fa1-407d-8912-722bb28b259e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("79ebae1f-d00b-42bf-b92f-a583761529b9"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7ad1f4cb-c229-4e14-aa61-3a25d8a1073e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7ae814ac-c9fd-4a91-b86c-d5cb649c5f31"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7f8490d9-fc8f-43c1-b7d4-7bc85b0ed59b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("834b0632-7f9b-4440-9708-9fc5103c4554"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("85ce79d4-5adb-418c-9758-1a9719e59985"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("87a78d25-6113-48ac-bdcc-0dbd36aa3245"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8814fdd4-009f-4288-914a-07d187a1f877"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("887068bb-99dc-469b-9d43-249d6cb48b33"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("88a09b06-0eae-4642-b8af-e95f0eb14861"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8bc90413-077f-481a-9c19-09ed45248967"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8c11dafa-8b33-4bef-9b29-0f4cedd1adc5"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8d22eefc-2c92-4223-a51d-41a493081f41"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8e644ea2-ca07-4669-ba81-cb4aab10ae9b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("91363e1c-c007-4d39-bdaa-e14c3781fbfb"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("93311db2-dd3e-44fe-9420-cea69c12db33"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("95dc9d16-dc62-419f-9884-c23e3087b191"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9633dc43-6802-41d4-b463-5c756b6bc436"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9ad71411-d76d-4628-8922-5548a57e3de4"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9bd0b490-bd7a-49f9-b968-83912dc52cc3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9e19523d-6173-4e9f-8276-e41b8c637c4e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a3c2e366-637f-403b-a278-3b1d3fbd286f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a4b75e48-7273-4f7a-a255-0c590477ab96"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a59ac4b9-f25c-4e24-8ee4-c4c393b4805e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a61d2d5c-fe42-4424-8a03-b0a34ec8d33f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a763402b-2139-45d8-b71f-9f995d67b78f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a861ba5b-eb03-4dae-a308-29a7dcd8d5fa"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ab285080-2303-4400-875e-e8450bbd0e6b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ad673ac6-383f-4feb-9d8f-63b553e744e3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("aec88588-6f27-4d55-9343-335253288aad"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("af8f05d9-fb99-4d1c-b95f-75a89fedc986"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b1b88bae-465c-45ff-b529-ea3867e399ee"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b4e4a641-a60b-411e-9029-1c15fd9eed1e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b4e4c7e6-90ec-42f0-b1d2-ad897f9f4599"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b82515f4-874a-4893-bb15-c222fa96187b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("bc5df416-ce44-43b2-a5c9-7e89b4967a73"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c4e29a28-c0a9-4ff4-949f-ded2b8b300b0"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c5258f22-9651-49c1-98ba-b64299626dad"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c5b14282-321b-4b2e-bcf1-947b6f604806"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c679cdff-b940-4b9a-80db-e64790b07646"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c8d9b9ee-ba45-4466-b957-86d2e8a784ee"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ca218a1f-4d8d-427c-bd53-3e1cf5e15783"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("cb387d34-a3e9-468b-acbc-ccad0ab0aa54"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("cba3f5a5-e339-4cea-a8f9-d06b44cc9a21"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("cbd43eec-2fc3-42de-9e35-20e135bf649c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("cd600e54-6753-452f-b850-48b8e2ae110f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ce7939c9-7842-4d08-b1ef-84fe2eae87ec"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d3c8877e-132e-4b9e-973f-ab66f18d3ae2"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d552e395-e85a-41a2-b929-e6ea2f194b66"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d57c43e6-2263-4d8d-8484-4a016dd465d9"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e05a1f45-2927-46dc-b177-5665335a69f2"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e2f9acf3-2878-4840-a354-e020dc00a9e9"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e41246ab-d149-4423-9703-13ff0e9b0b63"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e51f73d8-6f44-4032-8394-1f389be9c48a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e9739d88-6864-4126-b921-6c8c7d597d61"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ef4c17c5-c9f5-4e5a-bc64-e6a448aea64e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ef9b69f4-67d4-400d-bead-821f976286f7"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f03e0b04-8bac-4572-aa52-cee6d45d81f2"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f620da8f-4150-4856-b743-d7e2068161f6"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f6ac7933-4aa4-4c09-aafb-e7d30a1298e5"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f796943d-e1e4-4fc4-a846-d3fd2522bba6"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f98dabb5-e0fd-451f-8101-56f4a3fc093a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("fd1339f3-cb8f-4045-aab8-09dc80014ff2"));

            migrationBuilder.DropColumn(
                name: "DiscountId",
                table: "Customers");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Discounts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("01bc87ab-42b6-49c6-90e8-3ac066ed18a0"),
                column: "ReceivedAt",
                value: new DateTime(2021, 12, 15, 16, 53, 7, 746, DateTimeKind.Local).AddTicks(2677));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("01bc87ab-42b6-49c6-90e8-3ac066ed18a1"),
                column: "ReceivedAt",
                value: new DateTime(2021, 12, 15, 16, 53, 7, 746, DateTimeKind.Local).AddTicks(2975));

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("93eeea8c-5e54-4ff9-8e20-160b72c4bb59"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 405f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("6a7c7299-1804-4c6c-9087-8a4f02f2f180"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 400f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("3b929f56-8b11-433a-871d-d57a70cce2eb"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 395f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("e9f550c4-7251-4134-9b50-d988dccf7ae0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 390f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("75ce0b85-784d-4c13-b8b6-6874cb28163b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 385f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("21c62522-cc86-4f56-8d5e-8b280f3c65fe"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 380f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("eedbdd52-ae08-4006-a7fa-abbe755706aa"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 375f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("51826a46-defb-42ab-930c-ddff34fb5e90"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 370f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("a1ceb369-c434-4e20-b55a-796abd42148f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 365f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("9875b541-e40b-465b-b4e1-36accbdb715a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 360f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("99d5120f-bb0d-4920-b450-8cf9133a0760"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 355f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("6d2743b7-631d-4d52-a59e-756ff7322116"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 350f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("4b84bcd7-a834-4028-8b81-e73d844e2c25"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 345f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("98935d95-1ffe-41b5-9c1e-b0ab29ac47ba"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 340f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("a7e83eae-aa1e-40f8-9d21-7f7ae5efc492"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 335f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("2cca1bd4-32bf-4b27-8f34-00cea1f0eca9"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 330f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("7df3259f-3092-48fe-9bfd-ae91ecb0966c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 325f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("9fd9b136-d94e-4bf2-a6e7-fe89081ff027"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 320f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("1e109cd1-9f61-4669-893d-9c8afb0c8e7c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 315f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("12824b18-113c-4dd0-8af4-9c087fca66cc"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 310f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("b3061bca-06e4-472a-be14-6fef8f5aae5d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 305f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("0bdc6e4c-2519-4ead-92b6-bd92411263b4"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 300f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("c43be17c-f85d-4c0c-940e-20b97e95eb0e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 295f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("0cfa8c9d-b2eb-4b5a-a6b5-7ae8a5cd8701"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 410f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("48a542b9-aee3-4315-8f7c-565fc4ea5745"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 285f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("63b3437b-a41f-44a0-9e79-06f838fdaaf9"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 415f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("09889d0d-2a43-42fe-867b-050819e46871"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 425f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("5e5ebfd9-854a-43f6-bfe1-9947b400d376"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 545f, new Guid("8c74fc65-b701-4ade-9f97-7a7a744e2e59") },
                    { new Guid("93a04f0f-eb31-46c1-b00b-3250de19e01b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 540f, new Guid("8c74fc65-b701-4ade-9f87-7a7a744e2e59") },
                    { new Guid("a6539119-9034-49c9-ba59-34c02dbe5450"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 535f, new Guid("8c74fc65-b701-4ade-9f77-7a7a744e2e59") },
                    { new Guid("1330c3f0-a0c9-4da8-8694-c9f29caf40f0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 530f, new Guid("8c74fc65-b701-4ade-9f67-7a7a744e2e59") },
                    { new Guid("2546470a-89bb-4e16-90c9-31c9167460cc"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 525f, new Guid("8c74fc65-b701-4ade-9f57-7a7a744e2e59") },
                    { new Guid("15f60015-1eb9-492f-868d-2dfb9f2a1bd0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 520f, new Guid("8c74fc65-b701-4ade-9f47-7a7a744e2e59") },
                    { new Guid("118af6f8-05aa-447a-8565-366cd8151e3d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 515f, new Guid("8c74fc65-b701-4ade-9f37-7a7a744e2e59") },
                    { new Guid("1764590b-f939-424e-b7a6-36638f2933c7"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 510f, new Guid("8c74fc65-b701-4ade-9f27-7a7a744e2e59") },
                    { new Guid("b7f83827-bc8e-41db-8608-ad558a17f275"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 505f, new Guid("8c74fc65-b701-4ade-9f17-7a7a744e2e59") },
                    { new Guid("f6011038-6389-45e0-b3af-3b985b3e2dfa"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 500f, new Guid("8c74fc65-b701-4ade-9f07-7a7a744e2e59") },
                    { new Guid("837df533-98f0-4bba-86fa-316d63fc9605"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 495f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("3e051056-1170-4797-9347-5ff0b6091924"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 420f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("564fbc08-3a65-4b19-97fe-e2caf81135fb"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 490f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e59") }
                });

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("dd39c6a6-5cad-4dd3-837b-5bc7737acb3a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 480f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("b20a44da-f370-43aa-a401-d172ec541203"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 475f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("896b86d2-6964-4f1e-a351-1dc99783732f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 470f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("5afdb033-9654-43bc-8191-2c25d66fd77f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 465f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("7a1fefe2-b9fc-4e31-9b29-93fb054d4163"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 460f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("7dd6fbb8-f090-4a1c-ad34-d73522b3236d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 455f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("e8adee71-287c-426b-b3b3-5d214e5dc5d0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 450f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("70277c3b-0c30-4e16-926c-2ff255bd01c2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 445f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("563f2e64-bb35-431e-b9fc-9238250da85d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 440f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("b4208b1f-04dd-4823-95e0-9b2973d16702"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 435f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("1e6b6de1-dbf2-4dec-ac04-386a0b2d0c5c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 430f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("83e08320-daab-47ae-9115-e0c0a884d7dd"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 485f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("9137bb9f-1520-4e47-bb5f-7bcaee1974c2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 280f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("bdf233bb-ab5c-4fd2-af22-6b2442b733e4"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 290f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("b921b090-682b-4556-a228-46fe4a98209c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 270f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("db4c13e1-c7fe-4dd5-91dd-1a4173519d42"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 275f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("4fa2ea90-e659-4d72-bb90-f6b48e2049f9"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 115f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("3f368591-7688-4481-bb12-96ad0e97ad6f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 110f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("e379d4fe-b77e-4bfa-8277-69068be58dba"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 105f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("9c4e07ed-8ebe-401b-92bc-4465b09189f6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 100f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("cb5747fd-74c4-438d-bb29-be26bda0a3ac"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 95f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("9d2e3c99-c8e6-4c39-b184-2be1941a106c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 90f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("e92ae7c6-c294-4676-9956-1ade979859f6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 85f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("b856fe98-2173-4396-86e5-bbc7e93db850"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 80f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("e9044fdb-d81a-497f-bacd-a66ee2878824"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 75f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("3ee80354-22fc-4c59-aa1e-f8cb0114d7ca"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 70f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("a60c64a7-9cd2-46fc-b603-3d238abb51e4"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 125f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("ecfb7dc0-def2-45fc-b6fa-73ca2b250ce2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 65f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("84381719-2d82-4b36-85b4-45e0e25604cc"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 55f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("ef3affb6-56f5-4ee7-afa1-d2ad9a44d297"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 50f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("e1a431bb-33f0-4d1e-9487-a5f09fcebf05"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 45f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("c8f9f453-7e82-4575-a9ab-386af2378b98"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 40f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("643dedec-ed90-4e85-b328-0fbfb745e0a5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 35f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("40dc3cf5-4006-48a6-bca1-9edd24da34a2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 30f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("5555d17b-5e73-40e9-823c-e5cff180f084"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 25f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("c42eeee5-846a-45ba-93a2-c8987cfa98bd"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 20f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("0a030e5e-86a9-411c-8845-c3ee4944a504"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 15f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("8fe9f7a8-902f-4292-aacd-db6c2767cd28"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 10f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("79c85747-ffa0-4ad9-892b-65bcdf1231ee"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("59eb5a29-8782-42f7-abb0-47b25578b260"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 60f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("209a38e6-dd6d-4617-862f-4bf0c1ef909d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 130f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("dc24ff32-1b6c-4873-9692-6c8b625bd8cd"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 120f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e52") }
                });

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("ce40a73c-15b2-4995-a5cd-8bb69ab5c0d3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 140f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("c86455a3-eae4-4293-aa6b-b13334635d2c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 265f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("3b73f43e-938a-4bf1-9837-52f09e1e5402"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 260f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("e2327a0b-a7b8-4e16-9b72-7b5e93555724"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 255f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("2be933c3-a53a-4e2e-9d39-62487f99cb70"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 250f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("2d43dfea-2c59-4679-a3a3-0f13df1f48d3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 245f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("b2d04dc4-54f5-41c4-8e12-76490f2d21bb"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 240f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("d804a8e0-0b2c-4eef-9e19-1e8c3823a803"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 235f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("b7a6ca31-a6ea-4264-a94d-c54c9bd8038f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 230f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("4d1edac1-a748-4376-aaed-fa0e12b98d2c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 225f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("735820fc-cad0-4499-b69a-78aa141a07f8"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 135f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("b54992e1-d622-464a-a45a-81571d935f24"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 215f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("59a47493-e58a-494a-a2ab-d262c261500e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 210f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("02f82ad3-f4b1-4ec2-bff9-99acc65899fe"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 220f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("db227e5e-1a31-43a0-b180-7c388cbbadf6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 200f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("63055ec4-fe7c-4889-8eb6-ca6654b23125"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 145f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("c4b1bf03-e316-4548-9755-0058c692e7b1"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 150f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("6763b584-c0a0-40c1-8803-f5f42325a31a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 205f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("f839c346-1d78-47c3-a5f9-120ea3b7afcf"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 160f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("4c5691f1-7f3a-4a97-bf36-ef2018dd45ba"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 165f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("d759b057-5b3f-4245-8e00-175768e746eb"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 155f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("709897c0-651d-48c6-b2b7-8ca81bc89e2c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 175f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("eb754382-c331-4dc2-a1c1-1f0762fc8def"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 180f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("06f7ab90-12fb-4cc6-93c3-9e105c370929"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 185f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("f17fd569-c72b-473d-b9ad-f8ee408e024c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 190f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("a9c66670-28ac-4ed0-9512-8bc121f65a27"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 195f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("841ff6e8-b39d-4252-80cc-1183db4e65bd"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 170f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("ded011f8-4c18-47ab-9cd6-7f64e50d7018"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e50") }
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1570902e-48bb-4b03-850c-8ebd63261e33",
                column: "ConcurrencyStamp",
                value: "cbd0bab0-1088-4f3f-a147-1674e3f46a5d");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "4ce95b9b-0760-4f11-b576-71dfaa053e74",
                column: "ConcurrencyStamp",
                value: "c6c7508f-ef60-4dce-9cea-8cdb3fae6032");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "c057793d-9d0d-4f1d-9fb0-2335480d82e2",
                column: "ConcurrencyStamp",
                value: "9f82a0c3-4cb6-48c4-a219-cc4a0f4d655c");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "f4ea0102-2c6d-453e-8365-cb45c956cc44",
                column: "ConcurrencyStamp",
                value: "44e50cf1-110c-4748-b175-ef687e355170");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "0daec62b-312f-4016-9c5e-a15354259c90",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "083907af-bb54-48bc-931b-df461e580ed7", "0b33678a-4092-4b1f-980d-c9e090646a73" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "569411c1-88ef-45b6-ab57-79665fbcd9a4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "63447042-4f9b-4728-a744-6e29f3722041", "707b918f-1864-43be-967b-ec8e419d3344" });

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_CustomerId",
                table: "Discounts",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Customers_CustomerId",
                table: "Discounts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Customers_CustomerId",
                table: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_CustomerId",
                table: "Discounts");

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("02f82ad3-f4b1-4ec2-bff9-99acc65899fe"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("06f7ab90-12fb-4cc6-93c3-9e105c370929"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("09889d0d-2a43-42fe-867b-050819e46871"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0a030e5e-86a9-411c-8845-c3ee4944a504"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0bdc6e4c-2519-4ead-92b6-bd92411263b4"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0cfa8c9d-b2eb-4b5a-a6b5-7ae8a5cd8701"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("118af6f8-05aa-447a-8565-366cd8151e3d"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("12824b18-113c-4dd0-8af4-9c087fca66cc"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1330c3f0-a0c9-4da8-8694-c9f29caf40f0"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("15f60015-1eb9-492f-868d-2dfb9f2a1bd0"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1764590b-f939-424e-b7a6-36638f2933c7"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1e109cd1-9f61-4669-893d-9c8afb0c8e7c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("1e6b6de1-dbf2-4dec-ac04-386a0b2d0c5c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("209a38e6-dd6d-4617-862f-4bf0c1ef909d"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("21c62522-cc86-4f56-8d5e-8b280f3c65fe"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2546470a-89bb-4e16-90c9-31c9167460cc"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2be933c3-a53a-4e2e-9d39-62487f99cb70"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2cca1bd4-32bf-4b27-8f34-00cea1f0eca9"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2d43dfea-2c59-4679-a3a3-0f13df1f48d3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3b73f43e-938a-4bf1-9837-52f09e1e5402"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3b929f56-8b11-433a-871d-d57a70cce2eb"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3e051056-1170-4797-9347-5ff0b6091924"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3ee80354-22fc-4c59-aa1e-f8cb0114d7ca"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3f368591-7688-4481-bb12-96ad0e97ad6f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("40dc3cf5-4006-48a6-bca1-9edd24da34a2"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("48a542b9-aee3-4315-8f7c-565fc4ea5745"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4b84bcd7-a834-4028-8b81-e73d844e2c25"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4c5691f1-7f3a-4a97-bf36-ef2018dd45ba"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4d1edac1-a748-4376-aaed-fa0e12b98d2c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4fa2ea90-e659-4d72-bb90-f6b48e2049f9"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("51826a46-defb-42ab-930c-ddff34fb5e90"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("5555d17b-5e73-40e9-823c-e5cff180f084"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("563f2e64-bb35-431e-b9fc-9238250da85d"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("564fbc08-3a65-4b19-97fe-e2caf81135fb"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("59a47493-e58a-494a-a2ab-d262c261500e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("59eb5a29-8782-42f7-abb0-47b25578b260"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("5afdb033-9654-43bc-8191-2c25d66fd77f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("5e5ebfd9-854a-43f6-bfe1-9947b400d376"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("63055ec4-fe7c-4889-8eb6-ca6654b23125"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("63b3437b-a41f-44a0-9e79-06f838fdaaf9"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("643dedec-ed90-4e85-b328-0fbfb745e0a5"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6763b584-c0a0-40c1-8803-f5f42325a31a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6a7c7299-1804-4c6c-9087-8a4f02f2f180"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6d2743b7-631d-4d52-a59e-756ff7322116"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("70277c3b-0c30-4e16-926c-2ff255bd01c2"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("709897c0-651d-48c6-b2b7-8ca81bc89e2c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("735820fc-cad0-4499-b69a-78aa141a07f8"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("75ce0b85-784d-4c13-b8b6-6874cb28163b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("79c85747-ffa0-4ad9-892b-65bcdf1231ee"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7a1fefe2-b9fc-4e31-9b29-93fb054d4163"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7dd6fbb8-f090-4a1c-ad34-d73522b3236d"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7df3259f-3092-48fe-9bfd-ae91ecb0966c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("837df533-98f0-4bba-86fa-316d63fc9605"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("83e08320-daab-47ae-9115-e0c0a884d7dd"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("841ff6e8-b39d-4252-80cc-1183db4e65bd"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("84381719-2d82-4b36-85b4-45e0e25604cc"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("896b86d2-6964-4f1e-a351-1dc99783732f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8fe9f7a8-902f-4292-aacd-db6c2767cd28"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9137bb9f-1520-4e47-bb5f-7bcaee1974c2"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("93a04f0f-eb31-46c1-b00b-3250de19e01b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("93eeea8c-5e54-4ff9-8e20-160b72c4bb59"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9875b541-e40b-465b-b4e1-36accbdb715a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("98935d95-1ffe-41b5-9c1e-b0ab29ac47ba"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("99d5120f-bb0d-4920-b450-8cf9133a0760"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9c4e07ed-8ebe-401b-92bc-4465b09189f6"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9d2e3c99-c8e6-4c39-b184-2be1941a106c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9fd9b136-d94e-4bf2-a6e7-fe89081ff027"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a1ceb369-c434-4e20-b55a-796abd42148f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a60c64a7-9cd2-46fc-b603-3d238abb51e4"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a6539119-9034-49c9-ba59-34c02dbe5450"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a7e83eae-aa1e-40f8-9d21-7f7ae5efc492"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a9c66670-28ac-4ed0-9512-8bc121f65a27"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b20a44da-f370-43aa-a401-d172ec541203"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b2d04dc4-54f5-41c4-8e12-76490f2d21bb"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b3061bca-06e4-472a-be14-6fef8f5aae5d"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b4208b1f-04dd-4823-95e0-9b2973d16702"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b54992e1-d622-464a-a45a-81571d935f24"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b7a6ca31-a6ea-4264-a94d-c54c9bd8038f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b7f83827-bc8e-41db-8608-ad558a17f275"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b856fe98-2173-4396-86e5-bbc7e93db850"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b921b090-682b-4556-a228-46fe4a98209c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("bdf233bb-ab5c-4fd2-af22-6b2442b733e4"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c42eeee5-846a-45ba-93a2-c8987cfa98bd"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c43be17c-f85d-4c0c-940e-20b97e95eb0e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c4b1bf03-e316-4548-9755-0058c692e7b1"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c86455a3-eae4-4293-aa6b-b13334635d2c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c8f9f453-7e82-4575-a9ab-386af2378b98"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("cb5747fd-74c4-438d-bb29-be26bda0a3ac"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ce40a73c-15b2-4995-a5cd-8bb69ab5c0d3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d759b057-5b3f-4245-8e00-175768e746eb"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d804a8e0-0b2c-4eef-9e19-1e8c3823a803"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("db227e5e-1a31-43a0-b180-7c388cbbadf6"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("db4c13e1-c7fe-4dd5-91dd-1a4173519d42"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("dc24ff32-1b6c-4873-9692-6c8b625bd8cd"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("dd39c6a6-5cad-4dd3-837b-5bc7737acb3a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ded011f8-4c18-47ab-9cd6-7f64e50d7018"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e1a431bb-33f0-4d1e-9487-a5f09fcebf05"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e2327a0b-a7b8-4e16-9b72-7b5e93555724"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e379d4fe-b77e-4bfa-8277-69068be58dba"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e8adee71-287c-426b-b3b3-5d214e5dc5d0"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e9044fdb-d81a-497f-bacd-a66ee2878824"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e92ae7c6-c294-4676-9956-1ade979859f6"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e9f550c4-7251-4134-9b50-d988dccf7ae0"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("eb754382-c331-4dc2-a1c1-1f0762fc8def"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ecfb7dc0-def2-45fc-b6fa-73ca2b250ce2"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("eedbdd52-ae08-4006-a7fa-abbe755706aa"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ef3affb6-56f5-4ee7-afa1-d2ad9a44d297"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f17fd569-c72b-473d-b9ad-f8ee408e024c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f6011038-6389-45e0-b3af-3b985b3e2dfa"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f839c346-1d78-47c3-a5f9-120ea3b7afcf"));

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Discounts");

            migrationBuilder.AddColumn<Guid>(
                name: "DiscountId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderPromos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PromoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPromos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderPromos_OrderDetails_OrderDetailId",
                        column: x => x.OrderDetailId,
                        principalTable: "OrderDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderPromos_Promotions_PromoId",
                        column: x => x.PromoId,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("01bc87ab-42b6-49c6-90e8-3ac066ed18a0"),
                column: "ReceivedAt",
                value: new DateTime(2021, 12, 15, 15, 16, 7, 983, DateTimeKind.Local).AddTicks(3009));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("01bc87ab-42b6-49c6-90e8-3ac066ed18a1"),
                column: "ReceivedAt",
                value: new DateTime(2021, 12, 15, 15, 16, 7, 983, DateTimeKind.Local).AddTicks(3326));

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("06db265e-39e5-41b1-bb10-4bd0ec429eea"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 405f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("c5b14282-321b-4b2e-bcf1-947b6f604806"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 400f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("04e82db9-9bf7-4dc6-8dfd-8d8eae2bf2fe"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 395f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("93311db2-dd3e-44fe-9420-cea69c12db33"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 390f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("8d22eefc-2c92-4223-a51d-41a493081f41"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 385f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("4c51ab6d-0209-4302-99b9-95c437355bd9"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 380f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("7ae814ac-c9fd-4a91-b86c-d5cb649c5f31"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 375f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("71d6e7cd-7e9d-4f5b-b0c5-f62b910cb563"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 370f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("af8f05d9-fb99-4d1c-b95f-75a89fedc986"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 365f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("38e86ecb-e0cc-40d2-954c-efd3ebd0ecb2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 360f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("4ec34060-4f69-48d2-9d2b-b6a6348929a3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 355f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("87a78d25-6113-48ac-bdcc-0dbd36aa3245"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 350f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("1ecf21d1-250d-480c-b698-441594358968"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 345f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("68990970-5715-44ea-8e1a-68116192804a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 340f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("8814fdd4-009f-4288-914a-07d187a1f877"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 335f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("437dc4c0-6cd8-4e99-86dc-6322b0fb67d1"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 330f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("3c3293e1-e8f9-4708-8f2b-207d9b58c9b5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 325f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("85ce79d4-5adb-418c-9758-1a9719e59985"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 320f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("ad673ac6-383f-4feb-9d8f-63b553e744e3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 315f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("a61d2d5c-fe42-4424-8a03-b0a34ec8d33f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 310f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("7f8490d9-fc8f-43c1-b7d4-7bc85b0ed59b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 305f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("3097af7e-6031-4966-83bb-4754a58e79e7"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 300f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("4811197c-5e66-46f2-ba85-08c95a9a7bac"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 295f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("f98dabb5-e0fd-451f-8101-56f4a3fc093a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 410f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("e51f73d8-6f44-4032-8394-1f389be9c48a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 285f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("ce7939c9-7842-4d08-b1ef-84fe2eae87ec"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 415f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("9ad71411-d76d-4628-8922-5548a57e3de4"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 425f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("cd600e54-6753-452f-b850-48b8e2ae110f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 545f, new Guid("8c74fc65-b701-4ade-9f97-7a7a744e2e59") },
                    { new Guid("f796943d-e1e4-4fc4-a846-d3fd2522bba6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 540f, new Guid("8c74fc65-b701-4ade-9f87-7a7a744e2e59") },
                    { new Guid("5de27521-dc02-45bf-b462-15579a7a8360"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 535f, new Guid("8c74fc65-b701-4ade-9f77-7a7a744e2e59") },
                    { new Guid("8bc90413-077f-481a-9c19-09ed45248967"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 530f, new Guid("8c74fc65-b701-4ade-9f67-7a7a744e2e59") },
                    { new Guid("0cca895e-b5ba-4db2-8fe6-548ed3092b88"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 525f, new Guid("8c74fc65-b701-4ade-9f57-7a7a744e2e59") },
                    { new Guid("8c11dafa-8b33-4bef-9b29-0f4cedd1adc5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 520f, new Guid("8c74fc65-b701-4ade-9f47-7a7a744e2e59") },
                    { new Guid("cbd43eec-2fc3-42de-9e35-20e135bf649c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 515f, new Guid("8c74fc65-b701-4ade-9f37-7a7a744e2e59") },
                    { new Guid("8e644ea2-ca07-4669-ba81-cb4aab10ae9b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 510f, new Guid("8c74fc65-b701-4ade-9f27-7a7a744e2e59") },
                    { new Guid("e2f9acf3-2878-4840-a354-e020dc00a9e9"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 505f, new Guid("8c74fc65-b701-4ade-9f17-7a7a744e2e59") },
                    { new Guid("7ad1f4cb-c229-4e14-aa61-3a25d8a1073e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 500f, new Guid("8c74fc65-b701-4ade-9f07-7a7a744e2e59") },
                    { new Guid("cba3f5a5-e339-4cea-a8f9-d06b44cc9a21"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 495f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("1c7df391-4750-46ed-a25c-3993e4b88a06"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 420f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("280b86a6-994e-42e4-8629-48dc9f28f842"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 490f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e59") }
                });

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("ab285080-2303-4400-875e-e8450bbd0e6b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 480f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("834b0632-7f9b-4440-9708-9fc5103c4554"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 475f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("2acefec1-8230-4bd4-bf08-c3332620cb99"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 470f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("2fe887af-e1ef-4bc8-a014-5db2674fbbec"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 465f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("6d3de5e3-f824-4ae0-82e7-2266edb11d15"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 460f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("a763402b-2139-45d8-b71f-9f995d67b78f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 455f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("887068bb-99dc-469b-9d43-249d6cb48b33"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 450f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("a3c2e366-637f-403b-a278-3b1d3fbd286f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 445f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("c679cdff-b940-4b9a-80db-e64790b07646"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 440f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("67cf8ed1-068f-4330-9798-a5bd0e297947"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 435f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("40b45517-40d6-430e-bfff-41943abef311"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 430f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("ef9b69f4-67d4-400d-bead-821f976286f7"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 485f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("bc5df416-ce44-43b2-a5c9-7e89b4967a73"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 280f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("4a236811-dfa1-415d-a71d-8343e99b64dc"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 290f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("101507ed-2373-4ba9-aa49-7da07f7a7996"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 270f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("c5258f22-9651-49c1-98ba-b64299626dad"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 275f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("e41246ab-d149-4423-9703-13ff0e9b0b63"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 115f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("f03e0b04-8bac-4572-aa52-cee6d45d81f2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 110f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("9e19523d-6173-4e9f-8276-e41b8c637c4e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 105f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("3c01f4f3-748a-4374-8e1d-97141830e96f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 100f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("1eb7b948-23bd-46d7-992e-5c57e0510e58"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 95f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("b4e4c7e6-90ec-42f0-b1d2-ad897f9f4599"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 90f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("78eb1f0e-0fa1-407d-8912-722bb28b259e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 85f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("1ae3ff92-db51-4f51-8302-8bc5c233f4c3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 80f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("6afbb50b-af18-4526-a368-682834c57fb9"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 75f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("78967e8e-a410-47cd-a278-0078134a9513"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 70f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("b82515f4-874a-4893-bb15-c222fa96187b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 125f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("6272d441-4c08-4f0c-a7fe-342662d12542"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 65f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("1d71020c-fb38-4f4a-9b7f-d0bbc406c83d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 55f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("c8d9b9ee-ba45-4466-b957-86d2e8a784ee"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 50f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("a861ba5b-eb03-4dae-a308-29a7dcd8d5fa"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 45f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("4a098063-7801-48ca-9079-cdbd1d5f1e04"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 40f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("91363e1c-c007-4d39-bdaa-e14c3781fbfb"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 35f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("b4e4a641-a60b-411e-9029-1c15fd9eed1e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 30f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("70a49c38-0cd7-4f4a-b45e-c8a4f50ec6d5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 25f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("0b2dc907-0c4e-4a21-bbaa-ecfe6e77f6d1"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 20f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("f620da8f-4150-4856-b743-d7e2068161f6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 15f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("d57c43e6-2263-4d8d-8484-4a016dd465d9"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 10f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("4a4a3d96-7b01-4db9-a852-0706d5640b1f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("9633dc43-6802-41d4-b463-5c756b6bc436"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 60f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("606e847c-5cb6-4ddb-9904-7384f3f5e013"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 130f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("79ebae1f-d00b-42bf-b92f-a583761529b9"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 120f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e52") }
                });

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("fd1339f3-cb8f-4045-aab8-09dc80014ff2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 140f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("b1b88bae-465c-45ff-b529-ea3867e399ee"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 265f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("43971afa-99fa-4f86-9fcb-3f66618cb96e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 260f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("19cd0d13-dd37-46de-a0ff-e1d4d4a45403"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 255f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("a59ac4b9-f25c-4e24-8ee4-c4c393b4805e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 250f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("9bd0b490-bd7a-49f9-b968-83912dc52cc3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 245f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("a4b75e48-7273-4f7a-a255-0c590477ab96"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 240f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("754280cf-41d8-4c46-a877-7cd116a0ead3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 235f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("719dbb6f-19e4-4686-b359-8fe7001e9221"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 230f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("d552e395-e85a-41a2-b929-e6ea2f194b66"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 225f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("ef4c17c5-c9f5-4e5a-bc64-e6a448aea64e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 135f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("6639152e-c034-49ef-95ef-71faf713bd29"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 215f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("0cb97355-8010-4d46-b1ae-43db57577718"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 210f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("2ce1fbdd-6db6-4af2-bd39-54ee566a97da"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 220f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("2303fed4-8bb4-48be-badd-566cdbdf1564"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 200f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("88a09b06-0eae-4642-b8af-e95f0eb14861"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 145f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("71a08500-061c-4242-950d-d668b0df1a8e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 150f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("e9739d88-6864-4126-b921-6c8c7d597d61"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 205f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("425e4c7f-4f3b-41d3-ba9e-85125903ebf0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 160f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("363f5d22-3c69-4f97-a51a-ba509ceb523e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 165f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("d3c8877e-132e-4b9e-973f-ab66f18d3ae2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 155f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("95dc9d16-dc62-419f-9884-c23e3087b191"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 175f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("f6ac7933-4aa4-4c09-aafb-e7d30a1298e5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 180f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("cb387d34-a3e9-468b-acbc-ccad0ab0aa54"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 185f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("c4e29a28-c0a9-4ff4-949f-ded2b8b300b0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 190f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("aec88588-6f27-4d55-9343-335253288aad"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 195f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("e05a1f45-2927-46dc-b177-5665335a69f2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 170f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("ca218a1f-4d8d-427c-bd53-3e1cf5e15783"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e50") }
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1570902e-48bb-4b03-850c-8ebd63261e33",
                column: "ConcurrencyStamp",
                value: "df4e5bea-743c-40fb-bafb-e078d5d83c6a");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "4ce95b9b-0760-4f11-b576-71dfaa053e74",
                column: "ConcurrencyStamp",
                value: "1729f4b0-c3a1-47a8-96b5-96248250379d");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "c057793d-9d0d-4f1d-9fb0-2335480d82e2",
                column: "ConcurrencyStamp",
                value: "299ad646-3f85-41db-9148-a509a36cc849");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "f4ea0102-2c6d-453e-8365-cb45c956cc44",
                column: "ConcurrencyStamp",
                value: "a90a01a9-2d02-48a7-bbe3-a819d4d46407");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "0daec62b-312f-4016-9c5e-a15354259c90",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bb0d1c03-2b8b-494f-b6ac-57bb4bf14cb0", "0b0d4efb-3017-45c3-bb14-18935ecea364" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "569411c1-88ef-45b6-ab57-79665fbcd9a4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4207b328-72af-40fa-89b2-edf70b123234", "083aa12c-b2e1-4108-8af2-669c191e09b1" });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DiscountId",
                table: "Customers",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPromos_OrderDetailId",
                table: "OrderPromos",
                column: "OrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPromos_PromoId",
                table: "OrderPromos",
                column: "PromoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Discounts_DiscountId",
                table: "Customers",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
