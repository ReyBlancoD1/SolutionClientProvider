using Microsoft.EntityFrameworkCore.Migrations;

namespace Provider.Persistence.Database.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Provider");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Provider",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "Provider",
                columns: table => new
                {
                    ProductInStockId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.ProductInStockId);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Provider",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });           

            migrationBuilder.InsertData(
               schema: "Provider",
               table: "Products",
               columns: new[] { "ProductId", "Description", "Name", "Price" },
               values: new object[,]
               {
                    { 1, "Description for product 1", "Product 1", 539m },
                    { 73, "Description for product 73", "Product 73", 410m },
                    { 72, "Description for product 72", "Product 72", 276m },
                    { 71, "Description for product 71", "Product 71", 351m },
                    { 70, "Description for product 70", "Product 70", 781m },
                    { 69, "Description for product 69", "Product 69", 320m },
                    { 68, "Description for product 68", "Product 68", 267m },
                    { 67, "Description for product 67", "Product 67", 148m },
                    { 66, "Description for product 66", "Product 66", 703m },
                    { 65, "Description for product 65", "Product 65", 565m },
                    { 64, "Description for product 64", "Product 64", 933m },
                    { 63, "Description for product 63", "Product 63", 598m },
                    { 62, "Description for product 62", "Product 62", 666m },
                    { 61, "Description for product 61", "Product 61", 906m },
                    { 60, "Description for product 60", "Product 60", 588m },
                    { 59, "Description for product 59", "Product 59", 988m },
                    { 58, "Description for product 58", "Product 58", 324m },
                    { 57, "Description for product 57", "Product 57", 519m },
                    { 56, "Description for product 56", "Product 56", 462m },
                    { 55, "Description for product 55", "Product 55", 983m },
                    { 54, "Description for product 54", "Product 54", 793m },
                    { 53, "Description for product 53", "Product 53", 844m },
                    { 74, "Description for product 74", "Product 74", 524m },
                    { 52, "Description for product 52", "Product 52", 394m },
                    { 75, "Description for product 75", "Product 75", 198m },
                    { 77, "Description for product 77", "Product 77", 426m },
                    { 98, "Description for product 98", "Product 98", 816m },
                    { 97, "Description for product 97", "Product 97", 831m },
                    { 96, "Description for product 96", "Product 96", 581m },
                    { 95, "Description for product 95", "Product 95", 277m },
                    { 94, "Description for product 94", "Product 94", 955m },
                    { 93, "Description for product 93", "Product 93", 423m },
                    { 92, "Description for product 92", "Product 92", 683m },
                    { 91, "Description for product 91", "Product 91", 456m },
                    { 90, "Description for product 90", "Product 90", 800m },
                    { 89, "Description for product 89", "Product 89", 477m },
                    { 88, "Description for product 88", "Product 88", 150m },
                    { 87, "Description for product 87", "Product 87", 227m },
                    { 86, "Description for product 86", "Product 86", 425m },
                    { 85, "Description for product 85", "Product 85", 687m },
                    { 84, "Description for product 84", "Product 84", 436m },
                    { 83, "Description for product 83", "Product 83", 609m },
                    { 82, "Description for product 82", "Product 82", 186m },
                    { 81, "Description for product 81", "Product 81", 734m },
                    { 80, "Description for product 80", "Product 80", 963m },
                    { 79, "Description for product 79", "Product 79", 178m },
                    { 78, "Description for product 78", "Product 78", 153m },
                    { 76, "Description for product 76", "Product 76", 610m },
                    { 51, "Description for product 51", "Product 51", 538m },
                    { 50, "Description for product 50", "Product 50", 815m },
                    { 49, "Description for product 49", "Product 49", 366m },
                    { 22, "Description for product 22", "Product 22", 176m },
                    { 21, "Description for product 21", "Product 21", 940m },
                    { 20, "Description for product 20", "Product 20", 347m },
                    { 19, "Description for product 19", "Product 19", 609m },
                    { 18, "Description for product 18", "Product 18", 854m },
                    { 17, "Description for product 17", "Product 17", 589m },
                    { 16, "Description for product 16", "Product 16", 260m },
                    { 15, "Description for product 15", "Product 15", 657m },
                    { 14, "Description for product 14", "Product 14", 482m },
                    { 13, "Description for product 13", "Product 13", 628m },
                    { 12, "Description for product 12", "Product 12", 891m },
                    { 11, "Description for product 11", "Product 11", 674m },
                    { 10, "Description for product 10", "Product 10", 285m },
                    { 9, "Description for product 9", "Product 9", 159m },
                    { 8, "Description for product 8", "Product 8", 750m },
                    { 7, "Description for product 7", "Product 7", 542m },
                    { 6, "Description for product 6", "Product 6", 694m },
                    { 5, "Description for product 5", "Product 5", 337m },
                    { 4, "Description for product 4", "Product 4", 732m },
                    { 3, "Description for product 3", "Product 3", 590m },
                    { 2, "Description for product 2", "Product 2", 946m },
                    { 23, "Description for product 23", "Product 23", 527m },
                    { 24, "Description for product 24", "Product 24", 365m },
                    { 25, "Description for product 25", "Product 25", 743m },
                    { 26, "Description for product 26", "Product 26", 749m },
                    { 48, "Description for product 48", "Product 48", 701m },
                    { 47, "Description for product 47", "Product 47", 114m },
                    { 46, "Description for product 46", "Product 46", 779m },
                    { 45, "Description for product 45", "Product 45", 287m },
                    { 44, "Description for product 44", "Product 44", 474m },
                    { 43, "Description for product 43", "Product 43", 750m },
                    { 42, "Description for product 42", "Product 42", 429m },
                    { 41, "Description for product 41", "Product 41", 248m },
                    { 40, "Description for product 40", "Product 40", 184m },
                    { 39, "Description for product 39", "Product 39", 543m },
                    { 99, "Description for product 99", "Product 99", 908m },
                    { 38, "Description for product 38", "Product 38", 412m },
                    { 36, "Description for product 36", "Product 36", 875m },
                    { 35, "Description for product 35", "Product 35", 262m },
                    { 34, "Description for product 34", "Product 34", 460m },
                    { 33, "Description for product 33", "Product 33", 843m },
                    { 32, "Description for product 32", "Product 32", 971m },
                    { 31, "Description for product 31", "Product 31", 720m },
                    { 30, "Description for product 30", "Product 30", 225m },
                    { 29, "Description for product 29", "Product 29", 252m },
                    { 28, "Description for product 28", "Product 28", 875m },
                    { 27, "Description for product 27", "Product 27", 787m },
                    { 37, "Description for product 37", "Product 37", 908m },
                    { 100, "Description for product 100", "Product 100", 584m }
               });


            migrationBuilder.InsertData(
                schema: "Provider",
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 11 },
                    { 72, 72, 4 },
                    { 71, 71, 12 },
                    { 70, 70, 18 },
                    { 69, 69, 19 },
                    { 68, 68, 1 },
                    { 67, 67, 9 },
                    { 66, 66, 4 },
                    { 65, 65, 15 },
                    { 64, 64, 2 },
                    { 63, 63, 5 },
                    { 62, 62, 15 },
                    { 61, 61, 0 },
                    { 60, 60, 7 },
                    { 59, 59, 8 },
                    { 58, 58, 15 },
                    { 57, 57, 5 },
                    { 56, 56, 18 },
                    { 55, 55, 17 },
                    { 54, 54, 11 },
                    { 53, 53, 11 },
                    { 52, 52, 2 },
                    { 73, 73, 7 },
                    { 51, 51, 5 },
                    { 74, 74, 5 },
                    { 76, 76, 13 },
                    { 97, 97, 16 },
                    { 96, 96, 8 },
                    { 95, 95, 16 },
                    { 94, 94, 0 },
                    { 93, 93, 5 },
                    { 92, 92, 9 },
                    { 91, 91, 16 },
                    { 90, 90, 10 },
                    { 89, 89, 3 },
                    { 88, 88, 3 },
                    { 87, 87, 13 },
                    { 86, 86, 6 },
                    { 85, 85, 0 },
                    { 84, 84, 0 },
                    { 83, 83, 10 },
                    { 82, 82, 5 },
                    { 81, 81, 11 },
                    { 80, 80, 14 },
                    { 79, 79, 1 },
                    { 78, 78, 10 },
                    { 77, 77, 1 },
                    { 75, 75, 12 },
                    { 98, 98, 9 },
                    { 50, 50, 9 },
                    { 48, 48, 18 },
                    { 22, 22, 13 },
                    { 21, 21, 15 },
                    { 20, 20, 16 },
                    { 19, 19, 2 },
                    { 18, 18, 14 },
                    { 17, 17, 18 },
                    { 16, 16, 17 },
                    { 15, 15, 19 },
                    { 14, 14, 8 },
                    { 13, 13, 2 },
                    { 12, 12, 4 },
                    { 11, 11, 9 },
                    { 10, 10, 4 },
                    { 9, 9, 8 },
                    { 8, 8, 15 },
                    { 7, 7, 11 },
                    { 6, 6, 4 },
                    { 5, 5, 10 },
                    { 4, 4, 13 },
                    { 3, 3, 5 },
                    { 2, 2, 16 },
                    { 23, 23, 11 },
                    { 49, 49, 5 },
                    { 24, 24, 9 },
                    { 26, 26, 2 },
                    { 47, 47, 11 },
                    { 46, 46, 10 },
                    { 45, 45, 8 },
                    { 44, 44, 1 },
                    { 43, 43, 12 },
                    { 42, 42, 2 },
                    { 41, 41, 3 },
                    { 40, 40, 16 },
                    { 39, 39, 7 },
                    { 38, 38, 14 },
                    { 37, 37, 5 },
                    { 36, 36, 1 },
                    { 35, 35, 8 },
                    { 34, 34, 0 },
                    { 33, 33, 15 },
                    { 32, 32, 5 },
                    { 31, 31, 9 },
                    { 30, 30, 6 },
                    { 29, 29, 9 },
                    { 28, 28, 15 },
                    { 27, 27, 4 },
                    { 25, 25, 4 },
                    { 99, 99, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                schema: "Provider",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                schema: "Provider",
                table: "Stocks",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "Provider");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Provider");
        }
    }
}
