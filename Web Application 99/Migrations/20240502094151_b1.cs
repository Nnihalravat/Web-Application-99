using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Application_99.Migrations
{
    public partial class b1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "homes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "homes");
        }
    }
}
