using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waternet.DAL.Migrations
{
    public partial class V104 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TARGETDB_ID",
                table: "WAT_GROUP",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WAT_GROUP_TARGETDB_ID",
                table: "WAT_GROUP",
                column: "TARGETDB_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_GROUP_WAT_TARGETDB_TARGETDB_ID",
                table: "WAT_GROUP",
                column: "TARGETDB_ID",
                principalTable: "WAT_TARGETDB",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WAT_GROUP_WAT_TARGETDB_TARGETDB_ID",
                table: "WAT_GROUP");

            migrationBuilder.DropIndex(
                name: "IX_WAT_GROUP_TARGETDB_ID",
                table: "WAT_GROUP");

            migrationBuilder.DropColumn(
                name: "TARGETDB_ID",
                table: "WAT_GROUP");
        }
    }
}
