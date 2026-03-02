using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waternet.DAL.Migrations.OADB
{
    public partial class OA_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OA_MESSAGE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EVT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DEVICE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEVICE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LNG = table.Column<double>(type: "float", nullable: false),
                    LAT = table.Column<double>(type: "float", nullable: false),
                    ASSET_UID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMEI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEVICE_TYPE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DEVICE_TYPE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEVICE_BATCH_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DEVICE_BATCH_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EVT_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EVT_VALUE = table.Column<double>(type: "float", nullable: false),
                    EVT_UNIT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PC_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PC_VALUE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PC_UNIT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PROJECT = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OA_MESSAGE", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OA_MESSAGE");
        }
    }
}
