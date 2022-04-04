using Microsoft.EntityFrameworkCore.Migrations;

namespace HW4.App.DataAccess.EntityFramework.Migrations
{
    public partial class AddCompanyTableLocationColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Companies");
        }
    }
}
