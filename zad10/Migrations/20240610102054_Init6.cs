﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zad10.Migrations
{
    /// <inheritdoc />
    public partial class Init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdStudent",
                table: "Doctors",
                newName: "IdDoctor");

            migrationBuilder.CreateTable(
                name: "Perscriptions",
                columns: table => new
                {
                    IdPerscription = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPatient = table.Column<int>(type: "int", nullable: false),
                    IdDoctor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perscriptions", x => x.IdPerscription);
                    table.ForeignKey(
                        name: "FK_Perscriptions_Doctors_IdDoctor",
                        column: x => x.IdDoctor,
                        principalTable: "Doctors",
                        principalColumn: "IdDoctor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Perscriptions_Patients_IdPatient",
                        column: x => x.IdPatient,
                        principalTable: "Patients",
                        principalColumn: "IdPatient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Perscriptions_IdDoctor",
                table: "Perscriptions",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Perscriptions_IdPatient",
                table: "Perscriptions",
                column: "IdPatient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Perscriptions");

            migrationBuilder.RenameColumn(
                name: "IdDoctor",
                table: "Doctors",
                newName: "IdStudent");
        }
    }
}
