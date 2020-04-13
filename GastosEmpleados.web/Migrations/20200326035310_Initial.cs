using Microsoft.EntityFrameworkCore.Migrations;

namespace GastosEmpleados.web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Empleados");

            migrationBuilder.AddColumn<string>(
                name: "CellPhone",
                table: "Empleados",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Document",
                table: "Empleados",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Empleados",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Empleados",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CellPhone",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "Document",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Empleados");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Empleados",
                maxLength: 25,
                nullable: false,
                defaultValue: "");
        }
    }
}
