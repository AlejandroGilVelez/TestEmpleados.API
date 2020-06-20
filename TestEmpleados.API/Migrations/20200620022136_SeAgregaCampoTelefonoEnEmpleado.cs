using Microsoft.EntityFrameworkCore.Migrations;

namespace TestEmpleados.API.Migrations
{
    public partial class SeAgregaCampoTelefonoEnEmpleado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Empleados",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Empleados");
        }
    }
}
