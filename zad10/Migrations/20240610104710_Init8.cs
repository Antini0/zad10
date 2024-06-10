using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace zad10.Migrations
{
    /// <inheritdoc />
    public partial class Init8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "email", "firstName", "lastName" },
                values: new object[,]
                {
                    { 1, "asd@gmail.com", "jan", "kowalski" },
                    { 2, "zxc@gmail.com", "stefan", "nowak" }
                });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "mocna", "alpra", "benzo" },
                    { 2, "bardzo mocna", "oksy", "opio" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "BirthDate", "firstName", "lastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 3, 1, 13, 25, 13, 0, DateTimeKind.Unspecified), "jan", "kowalski" },
                    { 2, new DateTime(1995, 4, 12, 13, 25, 13, 0, DateTimeKind.Unspecified), "stefan", "nowak" }
                });

            migrationBuilder.InsertData(
                table: "Perscriptions",
                columns: new[] { "IdPerscription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 1, new DateTime(2024, 4, 12, 13, 25, 13, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 12, 16, 25, 13, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "Perscription_Medicaments",
                columns: new[] { "IdMedicament", "IdPerscription", "Details", "dose" },
                values: new object[] { 2, 1, "zaza", 12 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Perscription_Medicaments",
                keyColumns: new[] { "IdMedicament", "IdPerscription" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Perscriptions",
                keyColumn: "IdPerscription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1);
        }
    }
}
