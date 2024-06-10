using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zad10.Migrations
{
    /// <inheritdoc />
    public partial class Init7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Perscription_Medicaments",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(type: "int", nullable: false),
                    IdPerscription = table.Column<int>(type: "int", nullable: false),
                    dose = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perscription_Medicaments", x => new { x.IdMedicament, x.IdPerscription });
                    table.ForeignKey(
                        name: "FK_Perscription_Medicaments_Medicaments_IdMedicament",
                        column: x => x.IdMedicament,
                        principalTable: "Medicaments",
                        principalColumn: "IdMedicament",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Perscription_Medicaments_Perscriptions_IdPerscription",
                        column: x => x.IdPerscription,
                        principalTable: "Perscriptions",
                        principalColumn: "IdPerscription",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Perscription_Medicaments_IdPerscription",
                table: "Perscription_Medicaments",
                column: "IdPerscription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Perscription_Medicaments");
        }
    }
}
