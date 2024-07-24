using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadyGo.Persistence.Migrations
{
    public partial class add_missing_fields_in_category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0204c50f-5085-40e6-bed3-2cf75e3cc40b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0271bca2-5d4f-4289-8a07-45c405da36a6"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("06e595bf-39ce-425e-98dd-26b4f0590fd5"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0bd7ed3e-0d97-4b96-9166-3b67df91ddf2"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0da3d8fc-b008-40f2-97ae-f661cbb5ecb9"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0ed4f1f6-9be1-4602-962f-384c75bf2a10"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("0f180b75-b216-4d57-a303-839dce796f87"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("11d5fd8f-001d-4537-9258-7ff41e29c12e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("15ef9358-5901-4e75-ad59-99bea5671741"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("24045116-0984-4d7c-af7c-be43c6869fb6"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("25b11762-7e06-4ffc-9e17-1bb0668f1781"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("283f2497-e458-4002-a620-0445a8f87df3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("2dfff231-3c97-4dbe-96a5-523d299741c4"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("32526e98-70a9-4fef-b881-390d234b2d0c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("375c1eea-56fc-4967-bd69-0229959c2cc1"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("38328d89-0ae4-458b-a020-9f6e142a2753"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("38e056ad-2e3f-4e39-b7b3-b5e0ca5ffde8"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("38e843c6-ebb7-429e-b352-8ff2483a40f8"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3e036ba3-954d-449d-9c22-565c99fa1531"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("3eb7ca17-7dd0-4c3f-9c40-c0651b10ea1a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("44c01f00-1045-4099-bcee-8d12eeaaae58"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("46c62171-2b9a-407f-bdd0-155d328e0dec"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4a94d5b7-1a4d-4db5-b46d-abe918c74148"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4bb3131a-ab33-46ed-ad3a-560b518347be"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4c0420c8-68ec-4acc-a81e-ad0ed211a5b9"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("4e7228dd-3258-4415-b907-c2b9f83a81a2"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("5242e46c-d5fd-4765-9095-edea516f61b7"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("54eadf99-b2d4-4adf-bf8c-38f83c24a8af"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("57a29580-66f8-4c69-9f19-0ccd955e66d9"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("5a39739b-2b17-44e2-a877-71694dfb104b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("5bca82a8-5d9d-4a8f-bae9-f102d14ac79e"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("5c9ebdb8-7ae5-4a0b-b0c6-9b75466098fd"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6016a6be-f774-44ca-82a5-4cb3b0859661"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("61b85613-0422-4c38-8a84-4325ed741f82"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("61cf3652-64aa-450c-8695-2777ebefce57"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("646d4809-db5d-4538-8cb7-10b8ff93dcca"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("64b3ed50-2f3f-407e-bded-3c773c5bb6f2"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6642c98e-c0fc-4bf6-9443-13620ee8d70d"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("66b7506a-d8e9-405a-9cf3-b20dfd09aea3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("6823c54c-ea01-446b-87e3-8db1ee19e0ce"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("71d2eee8-a48f-42cd-9856-8e7f8e853b78"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("74009e97-bb61-4e2b-95a0-69fbd8dc6f95"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7477197b-4de8-4c44-bbab-8faf2aa8d372"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7481886b-7c83-43a7-806b-aec9862f9bb0"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("77636758-297b-46bd-822d-41617410555f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7815c483-0fd5-4ff9-9a1e-48795ee7a889"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("78512768-6e00-4964-a126-c9053f54509b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7dc1190c-e33a-4653-82a9-b477c8e3e297"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7e27ddbd-e16a-4f22-b1aa-870a553ad099"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("7fac2787-05dc-413a-82fe-6fbe2cf57d05"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("82e6b088-8405-410d-ab17-77da9310f164"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8aa2f46c-0a1e-4237-b323-4dbdfd282c94"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8b2fe69b-123d-451a-9330-33911d6473bc"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8be661b7-4f21-4301-964b-1a96bd322868"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8e4dcdc5-9faa-46af-b470-c30020d94d20"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8faf1479-273b-4d0a-a699-2a3a1c0373f3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("8fd5da43-9a43-4615-93fb-99ea781d9984"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("91737f05-c40a-40c3-83ac-4b42a5c8dd1a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("958647c0-309b-4a23-9155-cd6b9b6fc06a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("98f72a32-6f3b-44f8-8b15-f260c3a69c60"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9ab5fbac-7db5-43bc-9f98-f1772f1b5070"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9bb3744e-3614-47cb-9dc4-cb8b8bd58aaf"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9c2c461f-2b89-4956-8489-082295dd7c35"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9d6b336e-a9d0-40ce-a054-73dcb5c62d79"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9e549d3e-ca03-44f3-aed8-8b07759da50a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("9e56729f-75e5-48ff-bd20-b3a82d12f5de"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a023b8c4-aac6-471a-a9eb-baf4d50eeb58"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a45d22c0-c5ed-4d20-98c2-71cc630d6bf4"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a646b669-a7d6-43de-9584-a722e80261da"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("a735e9c4-6bbb-4bb2-9144-770ea4c1a128"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("aa15c5d5-cdb9-4c09-a84b-cff943152580"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("aaf24ee1-ba23-4412-a18a-688a94467ae3"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("af018351-ae42-44f4-bad6-fe7bcbda582d"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b7bd320f-259a-49ce-9fe4-4099a3d16d08"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("b7ed0b97-d6f4-4d2f-9093-f372dde29ed4"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ba8fb836-bf14-463e-9c6d-351ae0bee6bb"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("bb6ab40b-30d8-469a-a778-595deca569f4"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("bc97a701-d100-4d00-a16f-5f1f788cb1ed"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("bd0918b8-6131-40b5-ae4c-70b039b4d950"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("bdebe1ed-ff38-4a68-aa72-8a44fe8e62e9"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("bea0612f-01c7-472b-86c8-69f677c25e0a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c1f87a99-7f31-4cc1-8458-34f2d7179672"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c26545be-f797-4ebf-86a4-fc28e6a10faa"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c44a9ec8-5e12-45a9-8854-7de92b69b8bf"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c58d747b-7eaa-4fd6-bb18-95a67b79682b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c64dcc26-9236-4d12-89f3-26741a635137"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c65754f5-3658-4696-aab4-f2af9edc341a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("c80d4ba8-26a5-435f-910e-2cd7ff569f67"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("cb73d0ba-9c39-4f90-864e-19fef828f206"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ccbc1bca-90dc-4b36-b345-9d360ca71340"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d12a8cf5-2ab3-43cf-9dd8-dd682075fa5c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("d2e43f12-bda1-48c1-83e4-a9b2a3bcaa85"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("dba7f904-a123-4c3a-bf3b-65b38ccaa1f1"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("de305828-d686-4d53-913f-8d18c7ba812c"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e30f0c67-0b1a-431a-aecb-59afd9b912c8"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e3274d2c-85af-41a5-94f0-346d8e55c193"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e3ae1158-89b2-4ab7-8a81-3bcddadfd288"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e46c8989-bc51-4df6-8a3e-1c62c0dfe160"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e58c255d-9eb1-46f4-8f42-6e902dbd9d08"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e74c50de-ab4c-4ca5-92cf-9fa80b83f52b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e78f5af2-e120-41a8-8907-1da40720971b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("e84a6126-9b38-4e24-9e9c-78aa24d161dc"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("eaa64350-5f2b-4cba-92a1-7e47ca91814b"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("ee631829-2b76-401c-bc0a-dc6dbd719901"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f005b0ff-bc77-46b7-8a00-f958e68782e2"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f3b354ed-8b6f-4f5c-8926-2393ee9b4040"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f6d595ea-f7e0-4bd3-8489-908b8f855237"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f75751cd-4400-4b7f-a1bb-081feb9b5c6f"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f8e1ba8b-f1e8-4de5-a7da-b4799f3d538a"));

            migrationBuilder.DeleteData(
                table: "PriceHistory",
                keyColumn: "Id",
                keyValue: new Guid("f9881e00-6eb7-4aee-8a00-2b33510d5bb0"));

            migrationBuilder.AddColumn<string>(
                name: "AxCode",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SyncedAt",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            //migrationBuilder.InsertData(
            //    table: "PriceHistory",
            //    columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
            //    values: new object[,]
            //    {
            //        { new Guid("1a9f2fb2-dd35-4d26-96a5-0a2e9957bde7"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e50") },
            //        { new Guid("a9334514-f60e-4e6c-a642-24f25b609c42"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 405f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e58") },
            //        { new Guid("06484ced-22a6-4c30-a31a-7705cd33cbf0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 400f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e58") },
            //        { new Guid("abdb08a5-afba-4d8c-acf7-62c7c6f5d616"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 395f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e57") },
            //        { new Guid("3f942749-4260-4934-9abb-69a9ecf50ace"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 390f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e57") },
            //        { new Guid("d065206a-d117-4240-904b-c6cf8d14f006"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 385f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e57") },
            //        { new Guid("bf718b7f-981e-4b4f-b270-94eb2e72b8e7"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 380f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e57") },
            //        { new Guid("312b9431-4d5e-4c6f-b2fc-a64778d5a9bf"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 375f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e57") },
            //        { new Guid("e82b597b-b1d8-4dca-bd97-6c089a7060c5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 370f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e57") },
            //        { new Guid("a0a6b294-641e-499a-bb20-691b6198fe62"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 365f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e57") },
            //        { new Guid("e1840608-bb3f-44da-b2af-51cc255bf166"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 360f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e57") },
            //        { new Guid("9dd0f111-8350-4956-b68c-8554f035dc66"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 355f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e57") },
            //        { new Guid("609a28c4-8554-488d-854d-2bdbefd7f1ec"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 410f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e58") },
            //        { new Guid("23ef211e-e5a5-4d3d-952a-15f208706f66"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 350f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e57") },
            //        { new Guid("894acd44-edc4-4396-abe5-caa1bb9a7acb"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 340f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e56") },
            //        { new Guid("5159b661-35e0-4983-94c9-4f13857f01a6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 335f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e56") },
            //        { new Guid("9adec118-1a6c-49ba-b8cc-b939835b387f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 330f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e56") },
            //        { new Guid("a63ec791-f6ed-44e7-8170-a43ed69cd8d9"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 325f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e56") },
            //        { new Guid("6b355a30-b421-4e93-bddc-eff7fdea0073"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 320f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e56") },
            //        { new Guid("819ff603-aaef-40d0-ac94-ef26bfcd8753"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 315f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e56") },
            //        { new Guid("c8e18fa3-ecbc-4c84-84e2-bd42bf92c2fa"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 310f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e56") },
            //        { new Guid("aa00f9f8-ea27-401c-a249-88c870940e73"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 305f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e56") },
            //        { new Guid("9cfb7eb6-60f3-489b-8c19-d65cc04a69a2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 300f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e56") },
            //        { new Guid("36d96c59-3ef5-4a3a-918a-adbf2e130fba"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 295f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e55") },
            //        { new Guid("c4364b8e-1e09-4b48-b58a-6b10a72438d3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 290f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e55") },
            //        { new Guid("6f3a4055-8865-4214-a9b8-c73caee47d54"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 345f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e56") },
            //        { new Guid("cfe576b9-5c54-47d7-8ad5-0a571cf6031a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 280f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e55") },
            //        { new Guid("dfcaced1-1d10-46a9-8c0e-c258a9d2bc91"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 415f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e58") },
            //        { new Guid("1e8055f0-e142-462f-a5d3-f3b488d51824"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 425f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e58") },
            //        { new Guid("dd1e76c2-2658-45f0-b228-4370e6d342be"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 545f, new Guid("8c74fc65-b701-4ade-9f97-7a7a744e2e59") },
            //        { new Guid("af1f9533-9f62-4132-9bda-41ce55adfb9d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 540f, new Guid("8c74fc65-b701-4ade-9f87-7a7a744e2e59") },
            //        { new Guid("b923e33f-7d3a-4053-8fa0-059af233502b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 535f, new Guid("8c74fc65-b701-4ade-9f77-7a7a744e2e59") },
            //        { new Guid("91262e85-e9c3-47d3-b57f-ee619e180dcf"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 530f, new Guid("8c74fc65-b701-4ade-9f67-7a7a744e2e59") },
            //        { new Guid("a6050d29-dee8-4b78-85c2-fe96666b0df3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 525f, new Guid("8c74fc65-b701-4ade-9f57-7a7a744e2e59") },
            //        { new Guid("119b6aef-03fa-456c-a57a-c020f11b20e8"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 520f, new Guid("8c74fc65-b701-4ade-9f47-7a7a744e2e59") },
            //        { new Guid("c992e92f-4580-40f3-bcfc-c5cf2bffadc4"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 515f, new Guid("8c74fc65-b701-4ade-9f37-7a7a744e2e59") },
            //        { new Guid("161b637a-6b55-4da5-a542-a6798f1f7a19"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 510f, new Guid("8c74fc65-b701-4ade-9f27-7a7a744e2e59") },
            //        { new Guid("db236970-97d5-48d5-a2bb-bd9c3d4c8fbe"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 505f, new Guid("8c74fc65-b701-4ade-9f17-7a7a744e2e59") },
            //        { new Guid("d3f901c3-c2ea-484f-acba-3e546d73eef4"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 500f, new Guid("8c74fc65-b701-4ade-9f07-7a7a744e2e59") },
            //        { new Guid("83d50fc5-b833-4bac-a0bd-d6742118e74e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 495f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e59") },
            //        { new Guid("ebd3e1b3-b38a-4b06-a9ef-abeabb1750b4"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 420f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e58") },
            //        { new Guid("5cf95f41-910f-4e53-b66b-3b1243082635"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 490f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e59") }
            //    });

            //migrationBuilder.InsertData(
            //    table: "PriceHistory",
            //    columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
            //    values: new object[,]
            //    {
            //        { new Guid("aef9612f-ae32-46fb-a76f-1d73b9d2d7e8"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 480f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e59") },
            //        { new Guid("6babd7bb-6fcc-49e6-8203-78836bc5e5ef"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 475f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e59") },
            //        { new Guid("dc453fa0-f654-452c-b77d-b46f54082226"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 470f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e59") },
            //        { new Guid("97b216b7-6795-4aad-a220-8c1012b8951f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 465f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e59") },
            //        { new Guid("a38c0c2a-edc8-4b93-b6c5-f6c7227d0cff"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 460f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e59") },
            //        { new Guid("1fe097e6-d1d5-401e-b8da-7bdf2cf16880"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 455f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e59") },
            //        { new Guid("b4f02da3-1ff5-42e5-ac20-284dcb73abea"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 450f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e59") },
            //        { new Guid("3fa5341d-bee0-4938-b13f-da5981798bea"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 445f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e58") },
            //        { new Guid("23647de4-4e1f-4fda-803d-6f70e57508ac"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 440f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e58") },
            //        { new Guid("567af289-1838-479c-9227-757e891d619a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 435f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e58") },
            //        { new Guid("116ea3ec-e36a-49ee-a7f2-4e2f669f5f56"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 430f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e58") },
            //        { new Guid("a97309ad-a084-49bc-92f7-ed0ea78542a0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 485f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e59") },
            //        { new Guid("1cb237dc-d149-49a1-9533-ece7dbe731ef"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 275f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e55") },
            //        { new Guid("7299b7ce-e1b4-46b6-8352-1bfac25122cb"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 285f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e55") },
            //        { new Guid("b0c09716-6041-45a8-8b38-3e84240dcd5e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 265f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e55") },
            //        { new Guid("103589f5-e976-475f-89cc-695bd0341041"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 120f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e52") },
            //        { new Guid("1fa71422-312f-4c77-b4f0-252099a0c9aa"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 115f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e52") },
            //        { new Guid("09897d0a-55e4-4576-9f72-4154af324808"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 110f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e52") },
            //        { new Guid("4e13ccbb-ca1a-42f9-a403-1cf128ffa247"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 105f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e52") },
            //        { new Guid("399dce18-1ea1-4a64-a4a6-06cc5803d730"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 100f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e52") },
            //        { new Guid("b894e303-1100-499e-9bb0-e3b1a439c293"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 95f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e51") },
            //        { new Guid("5945e075-434a-4c61-ba20-976b3d89380f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 90f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e51") },
            //        { new Guid("a6514028-39dd-4cf8-a0aa-ab73eac205df"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 85f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e51") },
            //        { new Guid("1631e1cc-9385-4be0-871e-877e58e1b1a2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 80f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e51") },
            //        { new Guid("5d299387-c520-42b2-af58-ef40f29c53d0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 75f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e51") },
            //        { new Guid("5f05bcb2-04fa-4adf-9801-d46e5406934a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 70f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e51") },
            //        { new Guid("519b56f3-8096-4826-9a0d-a5682868a176"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 270f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e55") },
            //        { new Guid("5d6cfbe3-a48a-42fd-accf-b055c3a6fbc5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 65f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e51") },
            //        { new Guid("4418eae8-2862-4e05-94d5-11e84e2e7da1"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 55f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e51") },
            //        { new Guid("42c41656-f8a5-4db3-b7f5-cb2a411d1ff6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 50f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e51") },
            //        { new Guid("a4428a29-1d50-4248-abaf-1c9a3998d3cf"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 45f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e50") },
            //        { new Guid("cb0ae04f-4ed7-493d-babf-ba6100f77bea"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 40f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50") },
            //        { new Guid("66be8aa8-1863-4d9c-b27a-6e4e25249ee5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 35f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e50") },
            //        { new Guid("c279ca45-a5c7-44be-ae74-11d12d485970"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 30f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e50") },
            //        { new Guid("f1518973-3075-4af2-b458-4bb56f8492e1"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 25f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e50") },
            //        { new Guid("049c4b10-17df-44d8-b6c3-7981ab510502"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 20f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e50") },
            //        { new Guid("83158649-2cc1-4d96-adcb-e15bcf079157"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 15f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e50") },
            //        { new Guid("c305942f-d9e8-47dc-be90-5fa4a66784d2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 10f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e50") },
            //        { new Guid("9f2cd9d7-8af1-475e-8735-b7707bedaa9e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e50") },
            //        { new Guid("ba450ac8-f930-4af0-ab0e-992d05bd239b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 60f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e51") },
            //        { new Guid("8ad18380-c470-45f3-a09a-d7af157d14c6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 130f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e52") },
            //        { new Guid("092cd50d-dc2f-4166-9853-22b29ce1c4a3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 125f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e52") }
            //    });

            //migrationBuilder.InsertData(
            //    table: "PriceHistory",
            //    columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
            //    values: new object[,]
            //    {
            //        { new Guid("aa856679-b167-4d97-b8e1-ea67cc1d5605"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 140f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e52") },
            //        { new Guid("4485b086-ce3d-4c4f-880c-ac574fe36e37"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 260f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e55") },
            //        { new Guid("d48e3628-6941-4619-9b83-9a4ff6795a33"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 255f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e55") },
            //        { new Guid("251791a5-88d6-45a8-a1bc-5d9888671e66"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 250f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e55") },
            //        { new Guid("d81e9208-3031-46b8-86f1-4f4f109d6a3c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 245f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e54") },
            //        { new Guid("5cf0c74e-c3d9-4fdf-a400-8b4e231349c7"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 240f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e54") },
            //        { new Guid("41ba7467-ea30-4ed9-ba1d-e83df4f86adb"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 235f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e54") },
            //        { new Guid("23df82ff-47bd-4f77-aba0-3785c9fec35a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 230f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e54") },
            //        { new Guid("3c33628d-461b-49b5-9f2d-eb1c287c9ef8"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 225f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e54") },
            //        { new Guid("4fd55ea3-81a9-4c98-9e8f-275540093000"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 220f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e54") },
            //        { new Guid("47b7f884-2083-4f8a-be58-05e65eeb1014"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 135f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e52") },
            //        { new Guid("90277726-2f5b-42ef-a338-13b66e81f4d2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 210f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e54") },
            //        { new Guid("bb08c8de-8269-491d-b0b4-5aca041905e2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 205f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e54") },
            //        { new Guid("4043d6d7-f40c-48b3-8002-307c9ec42d92"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 215f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e54") },
            //        { new Guid("56357e86-d62c-40c4-ac42-d83e630fa6c8"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 195f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e53") },
            //        { new Guid("2bc96abd-92b6-4044-90ef-54794eb7e23b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 145f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e52") },
            //        { new Guid("6db5f743-9d58-42e2-93d8-088c910d0dba"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 150f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e53") },
            //        { new Guid("a1dc874c-020a-4f36-ad93-4767bc70b1bd"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 200f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e54") },
            //        { new Guid("bb97f878-0034-4123-a7c7-a1e75e611939"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 160f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e53") },
            //        { new Guid("6b586b71-c006-49b2-9c0e-a3fd8bee9631"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 165f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e53") },
            //        { new Guid("fdc4a5ee-8e4a-429c-8fa0-fc3f2a42f80f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 155f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e53") },
            //        { new Guid("955febae-51a7-436f-9d93-b13c10a20e8e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 175f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e53") },
            //        { new Guid("e13414f0-888f-4e65-b3f9-7251f06bae11"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 180f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e53") },
            //        { new Guid("1ebeb5ff-19c9-4596-a6ae-98039a012611"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 185f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e53") },
            //        { new Guid("ea21655d-69b9-4b36-9d62-872ae69e7d33"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 190f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e53") },
            //        { new Guid("a8c8f8b3-190d-4cd7-a0f4-d6c81995ce41"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 170f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e53") }
            //    });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1570902e-48bb-4b03-850c-8ebd63261e33",
                column: "ConcurrencyStamp",
                value: "16375b24-611e-4e17-8150-fafd49938952");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "4ce95b9b-0760-4f11-b576-71dfaa053e74",
                column: "ConcurrencyStamp",
                value: "0a54794b-7cd9-46bd-b707-ada251e949cc");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "c057793d-9d0d-4f1d-9fb0-2335480d82e2",
                column: "ConcurrencyStamp",
                value: "048646b0-ca13-442e-b4b0-feee9d41ce15");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "f4ea0102-2c6d-453e-8365-cb45c956cc44",
                column: "ConcurrencyStamp",
                value: "2c5a4654-ebcd-4348-9667-c7f0aca003db");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "0daec62b-312f-4016-9c5e-a15354259c90",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "206ce9e0-9e5a-4624-97d0-1a3675cdcebd", "294a8408-fac9-4bf1-b3c0-fc65753111c3" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "569411c1-88ef-45b6-ab57-79665fbcd9a4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "78cc79af-23db-4089-a951-5c4359fb21ed", "025d7f1c-4062-4b12-85d3-e6ead84ff822" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("049c4b10-17df-44d8-b6c3-7981ab510502"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("06484ced-22a6-4c30-a31a-7705cd33cbf0"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("092cd50d-dc2f-4166-9853-22b29ce1c4a3"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("09897d0a-55e4-4576-9f72-4154af324808"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("103589f5-e976-475f-89cc-695bd0341041"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("116ea3ec-e36a-49ee-a7f2-4e2f669f5f56"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("119b6aef-03fa-456c-a57a-c020f11b20e8"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("161b637a-6b55-4da5-a542-a6798f1f7a19"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("1631e1cc-9385-4be0-871e-877e58e1b1a2"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("1a9f2fb2-dd35-4d26-96a5-0a2e9957bde7"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("1cb237dc-d149-49a1-9533-ece7dbe731ef"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("1e8055f0-e142-462f-a5d3-f3b488d51824"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("1ebeb5ff-19c9-4596-a6ae-98039a012611"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("1fa71422-312f-4c77-b4f0-252099a0c9aa"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("1fe097e6-d1d5-401e-b8da-7bdf2cf16880"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("23647de4-4e1f-4fda-803d-6f70e57508ac"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("23df82ff-47bd-4f77-aba0-3785c9fec35a"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("23ef211e-e5a5-4d3d-952a-15f208706f66"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("251791a5-88d6-45a8-a1bc-5d9888671e66"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("2bc96abd-92b6-4044-90ef-54794eb7e23b"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("312b9431-4d5e-4c6f-b2fc-a64778d5a9bf"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("36d96c59-3ef5-4a3a-918a-adbf2e130fba"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("399dce18-1ea1-4a64-a4a6-06cc5803d730"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("3c33628d-461b-49b5-9f2d-eb1c287c9ef8"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("3f942749-4260-4934-9abb-69a9ecf50ace"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("3fa5341d-bee0-4938-b13f-da5981798bea"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("4043d6d7-f40c-48b3-8002-307c9ec42d92"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("41ba7467-ea30-4ed9-ba1d-e83df4f86adb"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("42c41656-f8a5-4db3-b7f5-cb2a411d1ff6"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("4418eae8-2862-4e05-94d5-11e84e2e7da1"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("4485b086-ce3d-4c4f-880c-ac574fe36e37"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("47b7f884-2083-4f8a-be58-05e65eeb1014"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("4e13ccbb-ca1a-42f9-a403-1cf128ffa247"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("4fd55ea3-81a9-4c98-9e8f-275540093000"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("5159b661-35e0-4983-94c9-4f13857f01a6"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("519b56f3-8096-4826-9a0d-a5682868a176"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("56357e86-d62c-40c4-ac42-d83e630fa6c8"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("567af289-1838-479c-9227-757e891d619a"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("5945e075-434a-4c61-ba20-976b3d89380f"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("5cf0c74e-c3d9-4fdf-a400-8b4e231349c7"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("5cf95f41-910f-4e53-b66b-3b1243082635"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("5d299387-c520-42b2-af58-ef40f29c53d0"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("5d6cfbe3-a48a-42fd-accf-b055c3a6fbc5"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("5f05bcb2-04fa-4adf-9801-d46e5406934a"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("609a28c4-8554-488d-854d-2bdbefd7f1ec"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("66be8aa8-1863-4d9c-b27a-6e4e25249ee5"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("6b355a30-b421-4e93-bddc-eff7fdea0073"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("6b586b71-c006-49b2-9c0e-a3fd8bee9631"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("6babd7bb-6fcc-49e6-8203-78836bc5e5ef"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("6db5f743-9d58-42e2-93d8-088c910d0dba"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("6f3a4055-8865-4214-a9b8-c73caee47d54"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("7299b7ce-e1b4-46b6-8352-1bfac25122cb"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("819ff603-aaef-40d0-ac94-ef26bfcd8753"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("83158649-2cc1-4d96-adcb-e15bcf079157"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("83d50fc5-b833-4bac-a0bd-d6742118e74e"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("894acd44-edc4-4396-abe5-caa1bb9a7acb"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("8ad18380-c470-45f3-a09a-d7af157d14c6"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("90277726-2f5b-42ef-a338-13b66e81f4d2"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("91262e85-e9c3-47d3-b57f-ee619e180dcf"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("955febae-51a7-436f-9d93-b13c10a20e8e"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("97b216b7-6795-4aad-a220-8c1012b8951f"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("9adec118-1a6c-49ba-b8cc-b939835b387f"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("9cfb7eb6-60f3-489b-8c19-d65cc04a69a2"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("9dd0f111-8350-4956-b68c-8554f035dc66"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("9f2cd9d7-8af1-475e-8735-b7707bedaa9e"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("a0a6b294-641e-499a-bb20-691b6198fe62"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("a1dc874c-020a-4f36-ad93-4767bc70b1bd"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("a38c0c2a-edc8-4b93-b6c5-f6c7227d0cff"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("a4428a29-1d50-4248-abaf-1c9a3998d3cf"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("a6050d29-dee8-4b78-85c2-fe96666b0df3"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("a63ec791-f6ed-44e7-8170-a43ed69cd8d9"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("a6514028-39dd-4cf8-a0aa-ab73eac205df"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("a8c8f8b3-190d-4cd7-a0f4-d6c81995ce41"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("a9334514-f60e-4e6c-a642-24f25b609c42"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("a97309ad-a084-49bc-92f7-ed0ea78542a0"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("aa00f9f8-ea27-401c-a249-88c870940e73"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("aa856679-b167-4d97-b8e1-ea67cc1d5605"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("abdb08a5-afba-4d8c-acf7-62c7c6f5d616"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("aef9612f-ae32-46fb-a76f-1d73b9d2d7e8"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("af1f9533-9f62-4132-9bda-41ce55adfb9d"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("b0c09716-6041-45a8-8b38-3e84240dcd5e"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("b4f02da3-1ff5-42e5-ac20-284dcb73abea"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("b894e303-1100-499e-9bb0-e3b1a439c293"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("b923e33f-7d3a-4053-8fa0-059af233502b"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("ba450ac8-f930-4af0-ab0e-992d05bd239b"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("bb08c8de-8269-491d-b0b4-5aca041905e2"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("bb97f878-0034-4123-a7c7-a1e75e611939"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("bf718b7f-981e-4b4f-b270-94eb2e72b8e7"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("c279ca45-a5c7-44be-ae74-11d12d485970"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("c305942f-d9e8-47dc-be90-5fa4a66784d2"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("c4364b8e-1e09-4b48-b58a-6b10a72438d3"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("c8e18fa3-ecbc-4c84-84e2-bd42bf92c2fa"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("c992e92f-4580-40f3-bcfc-c5cf2bffadc4"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("cb0ae04f-4ed7-493d-babf-ba6100f77bea"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("cfe576b9-5c54-47d7-8ad5-0a571cf6031a"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("d065206a-d117-4240-904b-c6cf8d14f006"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("d3f901c3-c2ea-484f-acba-3e546d73eef4"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("d48e3628-6941-4619-9b83-9a4ff6795a33"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("d81e9208-3031-46b8-86f1-4f4f109d6a3c"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("db236970-97d5-48d5-a2bb-bd9c3d4c8fbe"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("dc453fa0-f654-452c-b77d-b46f54082226"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("dd1e76c2-2658-45f0-b228-4370e6d342be"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("dfcaced1-1d10-46a9-8c0e-c258a9d2bc91"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("e13414f0-888f-4e65-b3f9-7251f06bae11"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("e1840608-bb3f-44da-b2af-51cc255bf166"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("e82b597b-b1d8-4dca-bd97-6c089a7060c5"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("ea21655d-69b9-4b36-9d62-872ae69e7d33"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("ebd3e1b3-b38a-4b06-a9ef-abeabb1750b4"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("f1518973-3075-4af2-b458-4bb56f8492e1"));

            //migrationBuilder.DeleteData(
            //    table: "PriceHistory",
            //    keyColumn: "Id",
            //    keyValue: new Guid("fdc4a5ee-8e4a-429c-8fa0-fc3f2a42f80f"));

            migrationBuilder.DropColumn(
                name: "AxCode",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SyncedAt",
                table: "Categories");

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("61cf3652-64aa-450c-8695-2777ebefce57"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("e58c255d-9eb1-46f4-8f42-6e902dbd9d08"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 405f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("8e4dcdc5-9faa-46af-b470-c30020d94d20"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 400f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("2dfff231-3c97-4dbe-96a5-523d299741c4"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 395f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("64b3ed50-2f3f-407e-bded-3c773c5bb6f2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 390f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("aaf24ee1-ba23-4412-a18a-688a94467ae3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 385f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("a646b669-a7d6-43de-9584-a722e80261da"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 380f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("9d6b336e-a9d0-40ce-a054-73dcb5c62d79"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 375f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("4a94d5b7-1a4d-4db5-b46d-abe918c74148"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 370f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("f75751cd-4400-4b7f-a1bb-081feb9b5c6f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 365f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("9e56729f-75e5-48ff-bd20-b3a82d12f5de"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 360f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("8faf1479-273b-4d0a-a699-2a3a1c0373f3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 355f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("9e549d3e-ca03-44f3-aed8-8b07759da50a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 410f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("38328d89-0ae4-458b-a020-9f6e142a2753"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 350f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e57") },
                    { new Guid("e46c8989-bc51-4df6-8a3e-1c62c0dfe160"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 340f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("c80d4ba8-26a5-435f-910e-2cd7ff569f67"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 335f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("f8e1ba8b-f1e8-4de5-a7da-b4799f3d538a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 330f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("78512768-6e00-4964-a126-c9053f54509b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 325f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("646d4809-db5d-4538-8cb7-10b8ff93dcca"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 320f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("0da3d8fc-b008-40f2-97ae-f661cbb5ecb9"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 315f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("98f72a32-6f3b-44f8-8b15-f260c3a69c60"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 310f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("e30f0c67-0b1a-431a-aecb-59afd9b912c8"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 305f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("f005b0ff-bc77-46b7-8a00-f958e68782e2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 300f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("c58d747b-7eaa-4fd6-bb18-95a67b79682b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 295f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("24045116-0984-4d7c-af7c-be43c6869fb6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 290f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("f9881e00-6eb7-4aee-8a00-2b33510d5bb0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 345f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e56") },
                    { new Guid("f3b354ed-8b6f-4f5c-8926-2393ee9b4040"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 280f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("c64dcc26-9236-4d12-89f3-26741a635137"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 415f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("bb6ab40b-30d8-469a-a778-595deca569f4"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 425f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("46c62171-2b9a-407f-bdd0-155d328e0dec"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 545f, new Guid("8c74fc65-b701-4ade-9f97-7a7a744e2e59") },
                    { new Guid("c26545be-f797-4ebf-86a4-fc28e6a10faa"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 540f, new Guid("8c74fc65-b701-4ade-9f87-7a7a744e2e59") },
                    { new Guid("ee631829-2b76-401c-bc0a-dc6dbd719901"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 535f, new Guid("8c74fc65-b701-4ade-9f77-7a7a744e2e59") },
                    { new Guid("74009e97-bb61-4e2b-95a0-69fbd8dc6f95"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 530f, new Guid("8c74fc65-b701-4ade-9f67-7a7a744e2e59") },
                    { new Guid("8be661b7-4f21-4301-964b-1a96bd322868"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 525f, new Guid("8c74fc65-b701-4ade-9f57-7a7a744e2e59") },
                    { new Guid("91737f05-c40a-40c3-83ac-4b42a5c8dd1a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 520f, new Guid("8c74fc65-b701-4ade-9f47-7a7a744e2e59") },
                    { new Guid("e78f5af2-e120-41a8-8907-1da40720971b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 515f, new Guid("8c74fc65-b701-4ade-9f37-7a7a744e2e59") },
                    { new Guid("7477197b-4de8-4c44-bbab-8faf2aa8d372"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 510f, new Guid("8c74fc65-b701-4ade-9f27-7a7a744e2e59") },
                    { new Guid("bdebe1ed-ff38-4a68-aa72-8a44fe8e62e9"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 505f, new Guid("8c74fc65-b701-4ade-9f17-7a7a744e2e59") },
                    { new Guid("7e27ddbd-e16a-4f22-b1aa-870a553ad099"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 500f, new Guid("8c74fc65-b701-4ade-9f07-7a7a744e2e59") },
                    { new Guid("0f180b75-b216-4d57-a303-839dce796f87"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 495f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("f6d595ea-f7e0-4bd3-8489-908b8f855237"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 420f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("e74c50de-ab4c-4ca5-92cf-9fa80b83f52b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 490f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e59") }
                });

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("af018351-ae42-44f4-bad6-fe7bcbda582d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 480f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("77636758-297b-46bd-822d-41617410555f"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 475f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("6642c98e-c0fc-4bf6-9443-13620ee8d70d"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 470f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("a735e9c4-6bbb-4bb2-9144-770ea4c1a128"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 465f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("11d5fd8f-001d-4537-9258-7ff41e29c12e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 460f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("82e6b088-8405-410d-ab17-77da9310f164"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 455f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("25b11762-7e06-4ffc-9e17-1bb0668f1781"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 450f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("958647c0-309b-4a23-9155-cd6b9b6fc06a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 445f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("38e843c6-ebb7-429e-b352-8ff2483a40f8"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 440f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("9bb3744e-3614-47cb-9dc4-cb8b8bd58aaf"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 435f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("7dc1190c-e33a-4653-82a9-b477c8e3e297"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 430f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e58") },
                    { new Guid("7481886b-7c83-43a7-806b-aec9862f9bb0"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 485f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e59") },
                    { new Guid("57a29580-66f8-4c69-9f19-0ccd955e66d9"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 275f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("c1f87a99-7f31-4cc1-8458-34f2d7179672"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 285f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("5bca82a8-5d9d-4a8f-bae9-f102d14ac79e"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 265f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("cb73d0ba-9c39-4f90-864e-19fef828f206"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 120f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("61b85613-0422-4c38-8a84-4325ed741f82"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 115f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("7815c483-0fd5-4ff9-9a1e-48795ee7a889"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 110f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("6823c54c-ea01-446b-87e3-8db1ee19e0ce"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 105f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("44c01f00-1045-4099-bcee-8d12eeaaae58"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 100f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("5a39739b-2b17-44e2-a877-71694dfb104b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 95f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("e84a6126-9b38-4e24-9e9c-78aa24d161dc"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 90f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("ccbc1bca-90dc-4b36-b345-9d360ca71340"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 85f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("c65754f5-3658-4696-aab4-f2af9edc341a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 80f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("9c2c461f-2b89-4956-8489-082295dd7c35"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 75f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("b7ed0b97-d6f4-4d2f-9093-f372dde29ed4"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 70f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("b7bd320f-259a-49ce-9fe4-4099a3d16d08"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 270f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("d2e43f12-bda1-48c1-83e4-a9b2a3bcaa85"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 65f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("3eb7ca17-7dd0-4c3f-9c40-c0651b10ea1a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 55f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("15ef9358-5901-4e75-ad59-99bea5671741"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 50f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("375c1eea-56fc-4967-bd69-0229959c2cc1"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 45f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("d12a8cf5-2ab3-43cf-9dd8-dd682075fa5c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 40f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("71d2eee8-a48f-42cd-9856-8e7f8e853b78"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 35f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("a023b8c4-aac6-471a-a9eb-baf4d50eeb58"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 30f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("bea0612f-01c7-472b-86c8-69f677c25e0a"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 25f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("aa15c5d5-cdb9-4c09-a84b-cff943152580"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 20f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("c44a9ec8-5e12-45a9-8854-7de92b69b8bf"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 15f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("4e7228dd-3258-4415-b907-c2b9f83a81a2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 10f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("0ed4f1f6-9be1-4602-962f-384c75bf2a10"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e50") },
                    { new Guid("9ab5fbac-7db5-43bc-9f98-f1772f1b5070"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 60f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e51") },
                    { new Guid("0271bca2-5d4f-4289-8a07-45c405da36a6"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 130f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("06e595bf-39ce-425e-98dd-26b4f0590fd5"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 125f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e52") }
                });

            migrationBuilder.InsertData(
                table: "PriceHistory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "From", "Price", "ProductId" },
                values: new object[,]
                {
                    { new Guid("3e036ba3-954d-449d-9c22-565c99fa1531"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 140f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("4bb3131a-ab33-46ed-ad3a-560b518347be"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 260f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("de305828-d686-4d53-913f-8d18c7ba812c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 255f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("32526e98-70a9-4fef-b881-390d234b2d0c"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 250f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e55") },
                    { new Guid("8b2fe69b-123d-451a-9330-33911d6473bc"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 245f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("7fac2787-05dc-413a-82fe-6fbe2cf57d05"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 240f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("5242e46c-d5fd-4765-9095-edea516f61b7"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 235f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("0bd7ed3e-0d97-4b96-9166-3b67df91ddf2"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 230f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("8aa2f46c-0a1e-4237-b323-4dbdfd282c94"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 225f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("8fd5da43-9a43-4615-93fb-99ea781d9984"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 220f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("eaa64350-5f2b-4cba-92a1-7e47ca91814b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 135f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("66b7506a-d8e9-405a-9cf3-b20dfd09aea3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 210f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("ba8fb836-bf14-463e-9c6d-351ae0bee6bb"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 205f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("6016a6be-f774-44ca-82a5-4cb3b0859661"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 215f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("dba7f904-a123-4c3a-bf3b-65b38ccaa1f1"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 195f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("bc97a701-d100-4d00-a16f-5f1f788cb1ed"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 145f, new Guid("9c74fc65-b791-4ade-9f97-7a7a744e2e52") },
                    { new Guid("38e056ad-2e3f-4e39-b7b3-b5e0ca5ffde8"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 150f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("54eadf99-b2d4-4adf-bf8c-38f83c24a8af"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 200f, new Guid("0c74fc65-b791-4ade-9f97-7a7a744e2e54") },
                    { new Guid("283f2497-e458-4002-a620-0445a8f87df3"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 160f, new Guid("2c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("0204c50f-5085-40e6-bed3-2cf75e3cc40b"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 165f, new Guid("3c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("e3ae1158-89b2-4ab7-8a81-3bcddadfd288"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 155f, new Guid("1c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("bd0918b8-6131-40b5-ae4c-70b039b4d950"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 175f, new Guid("5c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("a45d22c0-c5ed-4d20-98c2-71cc630d6bf4"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 180f, new Guid("6c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("4c0420c8-68ec-4acc-a81e-ad0ed211a5b9"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 185f, new Guid("7c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("5c9ebdb8-7ae5-4a0b-b0c6-9b75466098fd"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 190f, new Guid("8c74fc65-b791-4ade-9f97-7a7a744e2e53") },
                    { new Guid("e3274d2c-85af-41a5-94f0-346d8e55c193"), new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 170f, new Guid("4c74fc65-b791-4ade-9f97-7a7a744e2e53") }
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "1570902e-48bb-4b03-850c-8ebd63261e33",
                column: "ConcurrencyStamp",
                value: "df6182d8-86e1-4932-bfd5-a0b7569bb39d");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "4ce95b9b-0760-4f11-b576-71dfaa053e74",
                column: "ConcurrencyStamp",
                value: "bea1e69a-9a72-420e-ae79-ce4b1745d519");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "c057793d-9d0d-4f1d-9fb0-2335480d82e2",
                column: "ConcurrencyStamp",
                value: "009c5b34-e4b8-4ca3-aee8-dbb31bc54c32");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "f4ea0102-2c6d-453e-8365-cb45c956cc44",
                column: "ConcurrencyStamp",
                value: "d7745f0c-964f-44d8-abd7-089dba0149f7");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "0daec62b-312f-4016-9c5e-a15354259c90",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bbc77a39-f12c-4ab0-b0f8-25d9d177df95", "3b8c2ece-4b8f-4b1b-afda-1cad821fbd95" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "569411c1-88ef-45b6-ab57-79665fbcd9a4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0ffa6fa9-0b47-432d-9169-02d2f0c944f0", "6fe149df-ade5-4b98-9768-8a3d9a0a22b0" });
        }
    }
}
