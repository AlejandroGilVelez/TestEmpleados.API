using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestEmpleados.API.Migrations
{
    public partial class SeAgregaTablaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    NroIdentificacion = table.Column<long>(nullable: false),
                    Nombres = table.Column<string>(maxLength: 150, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 150, nullable: false),
                    Correo = table.Column<string>(maxLength: 200, nullable: false),
                    Telefono = table.Column<string>(maxLength: 100, nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: false),
                    PasswordSalt = table.Column<byte[]>(nullable: false),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
