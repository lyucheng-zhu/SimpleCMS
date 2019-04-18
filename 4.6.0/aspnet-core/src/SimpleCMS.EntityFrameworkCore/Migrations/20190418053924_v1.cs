using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleCMS.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AppCMSContents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "AppCMSContents",
                nullable: false,
                defaultValue: 0);
        }
    }
}
