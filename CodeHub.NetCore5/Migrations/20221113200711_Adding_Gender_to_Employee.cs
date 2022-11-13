using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeHub.NetCore5.Migrations
{
    public partial class Adding_Gender_to_Employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Employees");
        }
    }
}
