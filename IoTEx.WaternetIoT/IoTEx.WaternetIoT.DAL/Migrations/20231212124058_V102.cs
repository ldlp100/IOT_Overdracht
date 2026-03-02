using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waternet.DAL.Migrations
{
    public partial class V102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DESCR",
                table: "WAT_TARGETDB",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DESCR",
                table: "WAT_TARGETDB");
        }
    }
}
