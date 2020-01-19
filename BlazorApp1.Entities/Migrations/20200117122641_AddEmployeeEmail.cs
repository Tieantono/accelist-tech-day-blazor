using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorApp1.Entities.Migrations
{
    public partial class AddEmployeeEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "employee",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "employee");
        }
    }
}
