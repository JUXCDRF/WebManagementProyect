using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebManagementProyect.Cinfrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TareaCambios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Estado",
                table: "Tareas",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaTarea",
                table: "Tareas",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "HoraFin",
                table: "Tareas",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "HoraInicio",
                table: "Tareas",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaTarea",
                table: "Tareas");

            migrationBuilder.DropColumn(
                name: "HoraFin",
                table: "Tareas");

            migrationBuilder.DropColumn(
                name: "HoraInicio",
                table: "Tareas");

            migrationBuilder.AlterColumn<bool>(
                name: "Estado",
                table: "Tareas",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
