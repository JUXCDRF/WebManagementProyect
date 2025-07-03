using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebManagementProyect.Cinfrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proyecto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    NombreProyecto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false),
                    FechaEliminado = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    MotivoEliminado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Proyecto__3214EC070B5017C5", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    TokenHash = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Anulado = table.Column<bool>(type: "bit", nullable: false),
                    FechaAnulado = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    MotivoAnulado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Token__3214EC07AAB7B48D", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IdProyecto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    DescEstado = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    FechaLimite = table.Column<DateTime>(type: "datetime", nullable: true),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false),
                    FechaEliminado = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    MotivoEliminado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tareas__3214EC07BE7A3AA6", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Tareas__IdProyec__656C112C",
                        column: x => x.IdProyecto,
                        principalTable: "Proyecto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsuariosAnonimo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IdToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Deshabilitado = table.Column<bool>(type: "bit", nullable: false),
                    FechaDeshabilitado = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    MotivoDeshabilitado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__3214EC07FC2D0871", x => x.Id);
                    table.ForeignKey(
                        name: "FK__UsuariosA__IdTok__5070F446",
                        column: x => x.IdToken,
                        principalTable: "Token",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TokenAccesoProyecto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IdToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProyecto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoToken = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    IdCreador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdColaborador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Lectura = table.Column<bool>(type: "bit", nullable: false),
                    Editar = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TokenAcc__3214EC0757911D84", x => x.Id);
                    table.ForeignKey(
                        name: "FK__TokenAcce__IdCol__5FB337D6",
                        column: x => x.IdColaborador,
                        principalTable: "UsuariosAnonimo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__TokenAcce__IdCre__5EBF139D",
                        column: x => x.IdCreador,
                        principalTable: "UsuariosAnonimo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__TokenAcce__IdPro__5DCAEF64",
                        column: x => x.IdProyecto,
                        principalTable: "Proyecto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__TokenAcce__IdTok__5CD6CB2B",
                        column: x => x.IdToken,
                        principalTable: "Token",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_IdProyecto",
                table: "Tareas",
                column: "IdProyecto");

            migrationBuilder.CreateIndex(
                name: "IX_TokenAccesoProyecto_IdColaborador",
                table: "TokenAccesoProyecto",
                column: "IdColaborador");

            migrationBuilder.CreateIndex(
                name: "IX_TokenAccesoProyecto_IdCreador",
                table: "TokenAccesoProyecto",
                column: "IdCreador");

            migrationBuilder.CreateIndex(
                name: "IX_TokenAccesoProyecto_IdProyecto",
                table: "TokenAccesoProyecto",
                column: "IdProyecto");

            migrationBuilder.CreateIndex(
                name: "IX_TokenAccesoProyecto_IdToken",
                table: "TokenAccesoProyecto",
                column: "IdToken");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosAnonimo_IdToken",
                table: "UsuariosAnonimo",
                column: "IdToken");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tareas");

            migrationBuilder.DropTable(
                name: "TokenAccesoProyecto");

            migrationBuilder.DropTable(
                name: "UsuariosAnonimo");

            migrationBuilder.DropTable(
                name: "Proyecto");

            migrationBuilder.DropTable(
                name: "Token");
        }
    }
}
