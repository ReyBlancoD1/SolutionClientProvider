using Microsoft.EntityFrameworkCore.Migrations;

namespace Customer.Persistence.Database.Migrations
{
    public partial class InitializeCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Customer");

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "Customer",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.InsertData(
                schema: "Customer",
                table: "Clients",
                columns: new[] { "ClientId", "Name" },
                values: new object[,]
                {
                    { 1, "Reynaldo blanco" },
                    { 17, "Carlos Rodriguez" },
                    { 16, "Juan Villanueva" },
                    { 15, "Marisol Romero" },
                    { 14, "Moises Moreno" },
                    { 13, "Viviana Salcedo" },
                    { 12, "Felipe Montaño" },
                    { 11, "Adriana Bravo" },
                    { 18, "Alejandro Castaño" },
                    { 10, "Juan David Sarmiento" },
                    { 8, "Carolina Vargas" },
                    { 7, "Liliana Rojas" },
                    { 6, "German Puentes" },
                    { 5, "Andres Cortes" },
                    { 4, "Jacobo Prado" },
                    { 3, "Elias Ruiz" },
                    { 2, "Jorge Estupiñan" },
                    { 9, "Nicolas Mora" },
                    { 19, "Claudia Lopez" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientId",
                schema: "Customer",
                table: "Clients",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients",
                schema: "Customer");
        }
    }
}
