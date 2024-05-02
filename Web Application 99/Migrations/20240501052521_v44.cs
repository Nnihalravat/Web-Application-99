using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Application_99.Migrations
{
    public partial class v44 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "accountName",
                table: "accounts",
                newName: "key2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "key2",
                table: "accounts",
                newName: "accountName");
        }
    }
}
