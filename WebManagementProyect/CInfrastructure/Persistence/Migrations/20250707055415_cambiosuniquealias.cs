using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebManagementProyect.Cinfrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class cambiosuniquealias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Usuario",
                table: "UsuariosAnonimo",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Token_TokenHash",
                table: "Token",
                column: "TokenHash",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Token_TokenHash",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "UsuariosAnonimo");
        }
    }
}
