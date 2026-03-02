using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waternet.DAL.Migrations
{
    public partial class V100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WAT_APP_USER",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USER_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ROLE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_APP_USER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WAT_APP_CONFIG",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VALUE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IS_DELET = table.Column<bool>(type: "bit", nullable: false),
                    IS_MODIF = table.Column<bool>(type: "bit", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_APP_CONFIG", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_APP_CONFIG_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_APP_CONFIG_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WAT_ATT",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OBJECT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OBJECT_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    ATTACH_TYPE = table.Column<int>(type: "int", nullable: false),
                    SIZE = table.Column<int>(type: "int", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_ATT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_ATT_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_ATT_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WAT_BOSWACHTER",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LAT = table.Column<double>(type: "float", nullable: false),
                    LNG = table.Column<double>(type: "float", nullable: false),
                    BGRONDWATER = table.Column<bool>(type: "bit", nullable: false),
                    BWATERWINGGEBIED = table.Column<bool>(type: "bit", nullable: false),
                    ONDERBORD = table.Column<bool>(type: "bit", nullable: false),
                    DESCR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VUILNISBAKKEN = table.Column<bool>(type: "bit", nullable: false),
                    BANKEN = table.Column<bool>(type: "bit", nullable: false),
                    EGRONDWATER = table.Column<bool>(type: "bit", nullable: false),
                    EWATERWINGGEBIED = table.Column<bool>(type: "bit", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_BOSWACHTER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_BOSWACHTER_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_BOSWACHTER_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WAT_EVENT_STATE_TYPE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IS_STATE = table.Column<bool>(type: "bit", nullable: false),
                    IS_RELEASE = table.Column<bool>(type: "bit", nullable: false),
                    IS_UPDATED = table.Column<bool>(type: "bit", nullable: false),
                    DERIVED_STATE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_EVENT_STATE_TYPE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_EVENT_STATE_TYPE_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_EVENT_STATE_TYPE_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_EVENT_STATE_TYPE_WAT_EVENT_STATE_TYPE_DERIVED_STATE_ID",
                        column: x => x.DERIVED_STATE_ID,
                        principalTable: "WAT_EVENT_STATE_TYPE",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "WAT_GROUP",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TARGETDB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LAT = table.Column<double>(type: "float", nullable: false),
                    LNG = table.Column<double>(type: "float", nullable: false),
                    ISACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ISPROJECT = table.Column<bool>(type: "bit", nullable: false),
                    ACCESS_LEVEL = table.Column<int>(type: "int", nullable: false),
                    BEG_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    END_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PARENT_GROUP_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_GROUP", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_GROUP_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_GROUP_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_GROUP_WAT_GROUP_PARENT_GROUP_ID",
                        column: x => x.PARENT_GROUP_ID,
                        principalTable: "WAT_GROUP",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "WAT_NETWORK_API",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IS_LORA = table.Column<bool>(type: "bit", nullable: false),
                    IS_SIGFOX = table.Column<bool>(type: "bit", nullable: false),
                    IS_LTM = table.Column<bool>(type: "bit", nullable: false),
                    IS_NBIOT = table.Column<bool>(type: "bit", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_NETWORK_API", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_NETWORK_API_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_NETWORK_API_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WAT_PARSER",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CLASSNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_PARSER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_PARSER_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_PARSER_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WAT_SERVICE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IS_RUNNING = table.Column<bool>(type: "bit", nullable: false),
                    START_AUT_URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STOP_AUT_URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_SERVICE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_SERVICE_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_SERVICE_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WAT_SUPPLIER",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TELNUMBER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_SUPPLIER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_SUPPLIER_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_SUPPLIER_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WAT_UNIT_TYPE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LABEL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_UNIT_TYPE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_UNIT_TYPE_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_UNIT_TYPE_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WAT_USER_TASK",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TOKEN = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DES = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DEVICE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GROUP_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TASK_TYPE = table.Column<int>(type: "int", nullable: false),
                    START_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    END_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    STATE = table.Column<int>(type: "int", nullable: false),
                    PROGRESS = table.Column<int>(type: "int", nullable: false),
                    MESSAGE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HREF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_USER_TASK", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_USER_TASK_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_USER_TASK_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_USER_TASK_WAT_APP_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WAT_SUB_EVT_STATE_TYPE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EVT_STATE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IS_RELEASED = table.Column<bool>(type: "bit", nullable: false),
                    IS_UPDATED = table.Column<bool>(type: "bit", nullable: false),
                    START_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    END_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VALUE = table.Column<int>(type: "int", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_SUB_EVT_STATE_TYPE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_SUB_EVT_STATE_TYPE_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_SUB_EVT_STATE_TYPE_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_SUB_EVT_STATE_TYPE_WAT_EVENT_STATE_TYPE_EVT_STATE_ID",
                        column: x => x.EVT_STATE_ID,
                        principalTable: "WAT_EVENT_STATE_TYPE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WAT_USER2GROUP",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GROUP_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ROLE = table.Column<int>(type: "int", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_USER2GROUP", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_USER2GROUP_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_USER2GROUP_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_USER2GROUP_WAT_APP_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_USER2GROUP_WAT_GROUP_GROUP_ID",
                        column: x => x.GROUP_ID,
                        principalTable: "WAT_GROUP",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WAT_NETWORK_API_SETTING",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VAL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IS_SECRET = table.Column<bool>(type: "bit", nullable: false),
                    SECRET_VAL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IS_DEVICE_INFO = table.Column<bool>(type: "bit", nullable: false),
                    NET_API_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_NETWORK_API_SETTING", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_NETWORK_API_SETTING_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_NETWORK_API_SETTING_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_NETWORK_API_SETTING_WAT_NETWORK_API_NET_API_ID",
                        column: x => x.NET_API_ID,
                        principalTable: "WAT_NETWORK_API",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WAT_USER2SERVICE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SERVICE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_USER2SERVICE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_USER2SERVICE_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_USER2SERVICE_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_USER2SERVICE_WAT_APP_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_USER2SERVICE_WAT_SERVICE_SERVICE_ID",
                        column: x => x.SERVICE_ID,
                        principalTable: "WAT_SERVICE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WAT_DEVICETYPE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SUPPLIER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_DEVICETYPE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICETYPE_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICETYPE_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICETYPE_WAT_SUPPLIER_SUPPLIER_ID",
                        column: x => x.SUPPLIER_ID,
                        principalTable: "WAT_SUPPLIER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WAT_MEAS_TYPE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UNIT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_MEAS_TYPE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_MEAS_TYPE_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_MEAS_TYPE_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_MEAS_TYPE_WAT_UNIT_TYPE_UNIT_ID",
                        column: x => x.UNIT_ID,
                        principalTable: "WAT_UNIT_TYPE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WAT_BATCH_DEVICE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISREGISTERED = table.Column<bool>(type: "bit", nullable: false),
                    DEVICE_TYPE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GROUP_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_BATCH_DEVICE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_BATCH_DEVICE_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_BATCH_DEVICE_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_BATCH_DEVICE_WAT_DEVICETYPE_DEVICE_TYPE_ID",
                        column: x => x.DEVICE_TYPE_ID,
                        principalTable: "WAT_DEVICETYPE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_BATCH_DEVICE_WAT_GROUP_GROUP_ID",
                        column: x => x.GROUP_ID,
                        principalTable: "WAT_GROUP",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WAT_DEVICETYPE_FIRMWARE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IS_USED = table.Column<bool>(type: "bit", nullable: false),
                    PARSER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DEVICETYPE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IS_CONFIG = table.Column<bool>(type: "bit", nullable: false),
                    MEAS_FIRMWARE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    STATE_FIRMWARE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ALERT_FIRMWARE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_DEVICETYPE_FIRMWARE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICETYPE_FIRMWARE_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICETYPE_FIRMWARE_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICETYPE_FIRMWARE_WAT_DEVICETYPE_DEVICETYPE_ID",
                        column: x => x.DEVICETYPE_ID,
                        principalTable: "WAT_DEVICETYPE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICETYPE_FIRMWARE_WAT_DEVICETYPE_FIRMWARE_ALERT_FIRMWARE_ID",
                        column: x => x.ALERT_FIRMWARE_ID,
                        principalTable: "WAT_DEVICETYPE_FIRMWARE",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_WAT_DEVICETYPE_FIRMWARE_WAT_DEVICETYPE_FIRMWARE_MEAS_FIRMWARE_ID",
                        column: x => x.MEAS_FIRMWARE_ID,
                        principalTable: "WAT_DEVICETYPE_FIRMWARE",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_WAT_DEVICETYPE_FIRMWARE_WAT_DEVICETYPE_FIRMWARE_STATE_FIRMWARE_ID",
                        column: x => x.STATE_FIRMWARE_ID,
                        principalTable: "WAT_DEVICETYPE_FIRMWARE",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_WAT_DEVICETYPE_FIRMWARE_WAT_PARSER_PARSER_ID",
                        column: x => x.PARSER_ID,
                        principalTable: "WAT_PARSER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WAT_DEVTYPE2NETWORK_API",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DEVICETYPE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NETWORK_API_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_DEVTYPE2NETWORK_API", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_DEVTYPE2NETWORK_API_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVTYPE2NETWORK_API_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVTYPE2NETWORK_API_WAT_DEVICETYPE_DEVICETYPE_ID",
                        column: x => x.DEVICETYPE_ID,
                        principalTable: "WAT_DEVICETYPE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVTYPE2NETWORK_API_WAT_NETWORK_API_NETWORK_API_ID",
                        column: x => x.NETWORK_API_ID,
                        principalTable: "WAT_NETWORK_API",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WAT_DEVICE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LAST_MESSAGE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PUBLISHED_DOC_COUNTER = table.Column<int>(type: "int", nullable: false),
                    PUBLISHED_DOC_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PUBLISHED_DOC_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    INSTALL_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SERIALNR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HDW_VER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FIRMW_VER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    IS_TRACED = table.Column<bool>(type: "bit", nullable: false),
                    LNG = table.Column<double>(type: "float", nullable: false),
                    LAT = table.Column<double>(type: "float", nullable: false),
                    ALT = table.Column<double>(type: "float", nullable: false),
                    ASSET_UID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISREGISTERED = table.Column<bool>(type: "bit", nullable: false),
                    ISCHANGED = table.Column<bool>(type: "bit", nullable: false),
                    PROV_LORA = table.Column<bool>(type: "bit", nullable: false),
                    PROV_SIGFOX = table.Column<bool>(type: "bit", nullable: false),
                    PROV_NBIOT = table.Column<bool>(type: "bit", nullable: false),
                    PROV_LTM = table.Column<bool>(type: "bit", nullable: false),
                    SIGFOX_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SIGFOX_PAC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SIGFOX_APPKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LORA_DEVEUI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LORA_OTAA_APPEUI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LORA_OTAA_APPKEY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LORA_ABP_APPSKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LORA_ABP_NwkSKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LORA_ABP_devADDR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IMEI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IMEI_APPKEY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ICCID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DEVICE_TYPE_FRW_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DEVICE_TYPE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DEVICE_BATCH_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_DEVICE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICE_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICE_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICE_WAT_BATCH_DEVICE_DEVICE_BATCH_ID",
                        column: x => x.DEVICE_BATCH_ID,
                        principalTable: "WAT_BATCH_DEVICE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICE_WAT_DEVICETYPE_DEVICE_TYPE_ID",
                        column: x => x.DEVICE_TYPE_ID,
                        principalTable: "WAT_DEVICETYPE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICE_WAT_DEVICETYPE_FIRMWARE_DEVICE_TYPE_FRW_ID",
                        column: x => x.DEVICE_TYPE_FRW_ID,
                        principalTable: "WAT_DEVICETYPE_FIRMWARE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    isNew = table.Column<bool>(type: "bit", nullable: false),
                    FIRMWARE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EVT_STATE_TYPE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IS_ALERT = table.Column<bool>(type: "bit", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_DEVICETYPEFIRMWARE_STATE_TYPE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICETYPEFIRMWARE_STATE_TYPE_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICETYPEFIRMWARE_STATE_TYPE_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICETYPEFIRMWARE_STATE_TYPE_WAT_DEVICETYPE_FIRMWARE_FIRMWARE_ID",
                        column: x => x.FIRMWARE_ID,
                        principalTable: "WAT_DEVICETYPE_FIRMWARE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICETYPEFIRMWARE_STATE_TYPE_WAT_EVENT_STATE_TYPE_EVT_STATE_TYPE_ID",
                        column: x => x.EVT_STATE_TYPE_ID,
                        principalTable: "WAT_EVENT_STATE_TYPE",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SYMBOL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MIN_VAL = table.Column<double>(type: "float", nullable: true),
                    MAX_VAL = table.Column<double>(type: "float", nullable: true),
                    MIN_LENGTH = table.Column<double>(type: "float", nullable: true),
                    MAX_LENGTH = table.Column<double>(type: "float", nullable: true),
                    TYPENAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CATEGORIES = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    REGEX = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DVALUE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ROLE = table.Column<int>(type: "int", nullable: false),
                    isNew = table.Column<bool>(type: "bit", nullable: false),
                    FIRMWARE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_DEVICETYPEFIRMWARE2CONFIGURATION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICETYPEFIRMWARE2CONFIGURATION_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICETYPEFIRMWARE2CONFIGURATION_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICETYPEFIRMWARE2CONFIGURATION_WAT_DEVICETYPE_FIRMWARE_FIRMWARE_ID",
                        column: x => x.FIRMWARE_ID,
                        principalTable: "WAT_DEVICETYPE_FIRMWARE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    isNew = table.Column<bool>(type: "bit", nullable: false),
                    FIRMWARE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MEAS_TYPE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UNIT_TYPE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MIN_MEAS = table.Column<double>(type: "float", nullable: true),
                    MAX_MEAS = table.Column<double>(type: "float", nullable: true),
                    OFFSET_MEAS = table.Column<double>(type: "float", nullable: true),
                    MIN_SENSOR = table.Column<double>(type: "float", nullable: true),
                    MAX_SENSOR = table.Column<double>(type: "float", nullable: true),
                    UNIT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_DEVICETYPEFIRMWARE2MEASUREMENT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICETYPEFIRMWARE2MEASUREMENT_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICETYPEFIRMWARE2MEASUREMENT_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICETYPEFIRMWARE2MEASUREMENT_WAT_DEVICETYPE_FIRMWARE_FIRMWARE_ID",
                        column: x => x.FIRMWARE_ID,
                        principalTable: "WAT_DEVICETYPE_FIRMWARE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICETYPEFIRMWARE2MEASUREMENT_WAT_MEAS_TYPE_MEAS_TYPE_ID",
                        column: x => x.MEAS_TYPE_ID,
                        principalTable: "WAT_MEAS_TYPE",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_WAT_DEVICETYPEFIRMWARE2MEASUREMENT_WAT_UNIT_TYPE_UNIT_TYPE_ID",
                        column: x => x.UNIT_TYPE_ID,
                        principalTable: "WAT_UNIT_TYPE",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "WAT_DEVICE2GROUP",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DEVICE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GROUP_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_DEVICE2GROUP", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICE2GROUP_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICE2GROUP_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICE2GROUP_WAT_DEVICE_DEVICE_ID",
                        column: x => x.DEVICE_ID,
                        principalTable: "WAT_DEVICE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICE2GROUP_WAT_GROUP_GROUP_ID",
                        column: x => x.GROUP_ID,
                        principalTable: "WAT_GROUP",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WAT_DEVICE2NETAPISETTING",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SETTING_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DEVICE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VALUE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_DEVICE2NETAPISETTING", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICE2NETAPISETTING_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICE2NETAPISETTING_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICE2NETAPISETTING_WAT_DEVICE_DEVICE_ID",
                        column: x => x.DEVICE_ID,
                        principalTable: "WAT_DEVICE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICE2NETAPISETTING_WAT_NETWORK_API_SETTING_SETTING_ID",
                        column: x => x.SETTING_ID,
                        principalTable: "WAT_NETWORK_API_SETTING",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    isNew = table.Column<bool>(type: "bit", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EVT_STATE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IS_RELEASED = table.Column<bool>(type: "bit", nullable: false),
                    IS_UPDATED = table.Column<bool>(type: "bit", nullable: false),
                    START_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    END_DT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VALUE = table.Column<double>(type: "float", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE_WAT_DEVICETYPEFIRMWARE_STATE_TYPE_EVT_STATE_ID",
                        column: x => x.EVT_STATE_ID,
                        principalTable: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WAT_DEVICE2CONFIGURATION",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CONFIG_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DEVICE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VALUE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_DEVICE2CONFIGURATION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICE2CONFIGURATION_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICE2CONFIGURATION_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICE2CONFIGURATION_WAT_DEVICE_DEVICE_ID",
                        column: x => x.DEVICE_ID,
                        principalTable: "WAT_DEVICE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEVICE2CONFIGURATION_WAT_DEVICETYPEFIRMWARE2CONFIGURATION_CONFIG_ID",
                        column: x => x.CONFIG_ID,
                        principalTable: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WAT_DEV2CALIB",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DEVICE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DEV2TYPEMEASUREMENT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MIN_MEAS = table.Column<double>(type: "float", nullable: true),
                    MAX_MEAS = table.Column<double>(type: "float", nullable: true),
                    OFFSET_MEAS = table.Column<double>(type: "float", nullable: true),
                    MIN_SENSOR = table.Column<double>(type: "float", nullable: true),
                    MAX_SENSOR = table.Column<double>(type: "float", nullable: true),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_DEV2CALIB", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_DEV2CALIB_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEV2CALIB_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEV2CALIB_WAT_DEVICE_DEVICE_ID",
                        column: x => x.DEVICE_ID,
                        principalTable: "WAT_DEVICE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEV2CALIB_WAT_DEVICETYPEFIRMWARE2MEASUREMENT_DEV2TYPEMEASUREMENT_ID",
                        column: x => x.DEV2TYPEMEASUREMENT_ID,
                        principalTable: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "WAT_DEV2OUTPUT",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DEVICE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EVT_STATE_TYPE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EVT_MEAS_TYPE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UNIT_TYPE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IS_ALERT = table.Column<bool>(type: "bit", nullable: false),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_DEV2OUTPUT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_DEV2OUTPUT_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEV2OUTPUT_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEV2OUTPUT_WAT_DEVICE_DEVICE_ID",
                        column: x => x.DEVICE_ID,
                        principalTable: "WAT_DEVICE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WAT_DEV2OUTPUT_WAT_DEVICETYPEFIRMWARE_STATE_TYPE_EVT_STATE_TYPE_ID",
                        column: x => x.EVT_STATE_TYPE_ID,
                        principalTable: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_WAT_DEV2OUTPUT_WAT_DEVICETYPEFIRMWARE2MEASUREMENT_EVT_MEAS_TYPE_ID",
                        column: x => x.EVT_MEAS_TYPE_ID,
                        principalTable: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_WAT_DEV2OUTPUT_WAT_UNIT_TYPE_UNIT_TYPE_ID",
                        column: x => x.UNIT_TYPE_ID,
                        principalTable: "WAT_UNIT_TYPE",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WAT_APP_CONFIG_CREATED_BY",
                table: "WAT_APP_CONFIG",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_APP_CONFIG_UPDATED_BY",
                table: "WAT_APP_CONFIG",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_ATT_CREATED_BY",
                table: "WAT_ATT",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_ATT_UPDATED_BY",
                table: "WAT_ATT",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_BATCH_DEVICE_CREATED_BY",
                table: "WAT_BATCH_DEVICE",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_BATCH_DEVICE_DEVICE_TYPE_ID",
                table: "WAT_BATCH_DEVICE",
                column: "DEVICE_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_BATCH_DEVICE_GROUP_ID",
                table: "WAT_BATCH_DEVICE",
                column: "GROUP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_BATCH_DEVICE_UPDATED_BY",
                table: "WAT_BATCH_DEVICE",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_BOSWACHTER_CREATED_BY",
                table: "WAT_BOSWACHTER",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_BOSWACHTER_UPDATED_BY",
                table: "WAT_BOSWACHTER",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEV2CALIB_CREATED_BY",
                table: "WAT_DEV2CALIB",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEV2CALIB_DEV2TYPEMEASUREMENT_ID",
                table: "WAT_DEV2CALIB",
                column: "DEV2TYPEMEASUREMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEV2CALIB_DEVICE_ID",
                table: "WAT_DEV2CALIB",
                column: "DEVICE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEV2CALIB_UPDATED_BY",
                table: "WAT_DEV2CALIB",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEV2OUTPUT_CREATED_BY",
                table: "WAT_DEV2OUTPUT",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEV2OUTPUT_DEVICE_ID",
                table: "WAT_DEV2OUTPUT",
                column: "DEVICE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEV2OUTPUT_EVT_MEAS_TYPE_ID",
                table: "WAT_DEV2OUTPUT",
                column: "EVT_MEAS_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEV2OUTPUT_EVT_STATE_TYPE_ID",
                table: "WAT_DEV2OUTPUT",
                column: "EVT_STATE_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEV2OUTPUT_UNIT_TYPE_ID",
                table: "WAT_DEV2OUTPUT",
                column: "UNIT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEV2OUTPUT_UPDATED_BY",
                table: "WAT_DEV2OUTPUT",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICE_CREATED_BY",
                table: "WAT_DEVICE",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICE_DEVICE_BATCH_ID",
                table: "WAT_DEVICE",
                column: "DEVICE_BATCH_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICE_DEVICE_TYPE_FRW_ID",
                table: "WAT_DEVICE",
                column: "DEVICE_TYPE_FRW_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICE_DEVICE_TYPE_ID",
                table: "WAT_DEVICE",
                column: "DEVICE_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICE_UPDATED_BY",
                table: "WAT_DEVICE",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICE2CONFIGURATION_CONFIG_ID",
                table: "WAT_DEVICE2CONFIGURATION",
                column: "CONFIG_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICE2CONFIGURATION_CREATED_BY",
                table: "WAT_DEVICE2CONFIGURATION",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICE2CONFIGURATION_DEVICE_ID",
                table: "WAT_DEVICE2CONFIGURATION",
                column: "DEVICE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICE2CONFIGURATION_UPDATED_BY",
                table: "WAT_DEVICE2CONFIGURATION",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICE2GROUP_CREATED_BY",
                table: "WAT_DEVICE2GROUP",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICE2GROUP_DEVICE_ID",
                table: "WAT_DEVICE2GROUP",
                column: "DEVICE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICE2GROUP_GROUP_ID",
                table: "WAT_DEVICE2GROUP",
                column: "GROUP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICE2GROUP_UPDATED_BY",
                table: "WAT_DEVICE2GROUP",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICE2NETAPISETTING_CREATED_BY",
                table: "WAT_DEVICE2NETAPISETTING",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICE2NETAPISETTING_DEVICE_ID",
                table: "WAT_DEVICE2NETAPISETTING",
                column: "DEVICE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICE2NETAPISETTING_SETTING_ID",
                table: "WAT_DEVICE2NETAPISETTING",
                column: "SETTING_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICE2NETAPISETTING_UPDATED_BY",
                table: "WAT_DEVICE2NETAPISETTING",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICETYPE_CREATED_BY",
                table: "WAT_DEVICETYPE",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICETYPE_SUPPLIER_ID",
                table: "WAT_DEVICETYPE",
                column: "SUPPLIER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICETYPE_UPDATED_BY",
                table: "WAT_DEVICETYPE",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICETYPE_FIRMWARE_ALERT_FIRMWARE_ID",
                table: "WAT_DEVICETYPE_FIRMWARE",
                column: "ALERT_FIRMWARE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICETYPE_FIRMWARE_CREATED_BY",
                table: "WAT_DEVICETYPE_FIRMWARE",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICETYPE_FIRMWARE_DEVICETYPE_ID",
                table: "WAT_DEVICETYPE_FIRMWARE",
                column: "DEVICETYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICETYPE_FIRMWARE_MEAS_FIRMWARE_ID",
                table: "WAT_DEVICETYPE_FIRMWARE",
                column: "MEAS_FIRMWARE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICETYPE_FIRMWARE_PARSER_ID",
                table: "WAT_DEVICETYPE_FIRMWARE",
                column: "PARSER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICETYPE_FIRMWARE_STATE_FIRMWARE_ID",
                table: "WAT_DEVICETYPE_FIRMWARE",
                column: "STATE_FIRMWARE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICETYPE_FIRMWARE_UPDATED_BY",
                table: "WAT_DEVICETYPE_FIRMWARE",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICETYPEFIRMWARE_STATE_TYPE_CREATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICETYPEFIRMWARE_STATE_TYPE_EVT_STATE_TYPE_ID",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                column: "EVT_STATE_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICETYPEFIRMWARE_STATE_TYPE_FIRMWARE_ID",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                column: "FIRMWARE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICETYPEFIRMWARE_STATE_TYPE_UPDATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICETYPEFIRMWARE2CONFIGURATION_CREATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICETYPEFIRMWARE2CONFIGURATION_FIRMWARE_ID",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                column: "FIRMWARE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICETYPEFIRMWARE2CONFIGURATION_UPDATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICETYPEFIRMWARE2MEASUREMENT_CREATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICETYPEFIRMWARE2MEASUREMENT_FIRMWARE_ID",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT",
                column: "FIRMWARE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICETYPEFIRMWARE2MEASUREMENT_MEAS_TYPE_ID",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT",
                column: "MEAS_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICETYPEFIRMWARE2MEASUREMENT_UNIT_TYPE_ID",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT",
                column: "UNIT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICETYPEFIRMWARE2MEASUREMENT_UPDATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVTYPE2NETWORK_API_CREATED_BY",
                table: "WAT_DEVTYPE2NETWORK_API",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVTYPE2NETWORK_API_DEVICETYPE_ID",
                table: "WAT_DEVTYPE2NETWORK_API",
                column: "DEVICETYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVTYPE2NETWORK_API_NETWORK_API_ID",
                table: "WAT_DEVTYPE2NETWORK_API",
                column: "NETWORK_API_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVTYPE2NETWORK_API_UPDATED_BY",
                table: "WAT_DEVTYPE2NETWORK_API",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE_CREATED_BY",
                table: "WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE_EVT_STATE_ID",
                table: "WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE",
                column: "EVT_STATE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE_UPDATED_BY",
                table: "WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_EVENT_STATE_TYPE_CREATED_BY",
                table: "WAT_EVENT_STATE_TYPE",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_EVENT_STATE_TYPE_DERIVED_STATE_ID",
                table: "WAT_EVENT_STATE_TYPE",
                column: "DERIVED_STATE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_EVENT_STATE_TYPE_UPDATED_BY",
                table: "WAT_EVENT_STATE_TYPE",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_GROUP_CREATED_BY",
                table: "WAT_GROUP",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_GROUP_PARENT_GROUP_ID",
                table: "WAT_GROUP",
                column: "PARENT_GROUP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_GROUP_UPDATED_BY",
                table: "WAT_GROUP",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_MEAS_TYPE_CREATED_BY",
                table: "WAT_MEAS_TYPE",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_MEAS_TYPE_UNIT_ID",
                table: "WAT_MEAS_TYPE",
                column: "UNIT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_MEAS_TYPE_UPDATED_BY",
                table: "WAT_MEAS_TYPE",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_NETWORK_API_CREATED_BY",
                table: "WAT_NETWORK_API",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_NETWORK_API_UPDATED_BY",
                table: "WAT_NETWORK_API",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_NETWORK_API_SETTING_CREATED_BY",
                table: "WAT_NETWORK_API_SETTING",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_NETWORK_API_SETTING_NET_API_ID",
                table: "WAT_NETWORK_API_SETTING",
                column: "NET_API_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_NETWORK_API_SETTING_UPDATED_BY",
                table: "WAT_NETWORK_API_SETTING",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_PARSER_CREATED_BY",
                table: "WAT_PARSER",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_PARSER_UPDATED_BY",
                table: "WAT_PARSER",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_SERVICE_CREATED_BY",
                table: "WAT_SERVICE",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_SERVICE_UPDATED_BY",
                table: "WAT_SERVICE",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_SUB_EVT_STATE_TYPE_CREATED_BY",
                table: "WAT_SUB_EVT_STATE_TYPE",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_SUB_EVT_STATE_TYPE_EVT_STATE_ID",
                table: "WAT_SUB_EVT_STATE_TYPE",
                column: "EVT_STATE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_SUB_EVT_STATE_TYPE_UPDATED_BY",
                table: "WAT_SUB_EVT_STATE_TYPE",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_SUPPLIER_CREATED_BY",
                table: "WAT_SUPPLIER",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_SUPPLIER_UPDATED_BY",
                table: "WAT_SUPPLIER",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_UNIT_TYPE_CREATED_BY",
                table: "WAT_UNIT_TYPE",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_UNIT_TYPE_UPDATED_BY",
                table: "WAT_UNIT_TYPE",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_USER_TASK_CREATED_BY",
                table: "WAT_USER_TASK",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_USER_TASK_UPDATED_BY",
                table: "WAT_USER_TASK",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_USER_TASK_USER_ID",
                table: "WAT_USER_TASK",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_USER2GROUP_CREATED_BY",
                table: "WAT_USER2GROUP",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_USER2GROUP_GROUP_ID",
                table: "WAT_USER2GROUP",
                column: "GROUP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_USER2GROUP_UPDATED_BY",
                table: "WAT_USER2GROUP",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_USER2GROUP_USER_ID",
                table: "WAT_USER2GROUP",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_USER2SERVICE_CREATED_BY",
                table: "WAT_USER2SERVICE",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_USER2SERVICE_SERVICE_ID",
                table: "WAT_USER2SERVICE",
                column: "SERVICE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_USER2SERVICE_UPDATED_BY",
                table: "WAT_USER2SERVICE",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_USER2SERVICE_USER_ID",
                table: "WAT_USER2SERVICE",
                column: "USER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WAT_APP_CONFIG");

            migrationBuilder.DropTable(
                name: "WAT_ATT");

            migrationBuilder.DropTable(
                name: "WAT_BOSWACHTER");

            migrationBuilder.DropTable(
                name: "WAT_DEV2CALIB");

            migrationBuilder.DropTable(
                name: "WAT_DEV2OUTPUT");

            migrationBuilder.DropTable(
                name: "WAT_DEVICE2CONFIGURATION");

            migrationBuilder.DropTable(
                name: "WAT_DEVICE2GROUP");

            migrationBuilder.DropTable(
                name: "WAT_DEVICE2NETAPISETTING");

            migrationBuilder.DropTable(
                name: "WAT_DEVTYPE2NETWORK_API");

            migrationBuilder.DropTable(
                name: "WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE");

            migrationBuilder.DropTable(
                name: "WAT_SUB_EVT_STATE_TYPE");

            migrationBuilder.DropTable(
                name: "WAT_USER_TASK");

            migrationBuilder.DropTable(
                name: "WAT_USER2GROUP");

            migrationBuilder.DropTable(
                name: "WAT_USER2SERVICE");

            migrationBuilder.DropTable(
                name: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT");

            migrationBuilder.DropTable(
                name: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION");

            migrationBuilder.DropTable(
                name: "WAT_DEVICE");

            migrationBuilder.DropTable(
                name: "WAT_NETWORK_API_SETTING");

            migrationBuilder.DropTable(
                name: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE");

            migrationBuilder.DropTable(
                name: "WAT_SERVICE");

            migrationBuilder.DropTable(
                name: "WAT_MEAS_TYPE");

            migrationBuilder.DropTable(
                name: "WAT_BATCH_DEVICE");

            migrationBuilder.DropTable(
                name: "WAT_NETWORK_API");

            migrationBuilder.DropTable(
                name: "WAT_DEVICETYPE_FIRMWARE");

            migrationBuilder.DropTable(
                name: "WAT_EVENT_STATE_TYPE");

            migrationBuilder.DropTable(
                name: "WAT_UNIT_TYPE");

            migrationBuilder.DropTable(
                name: "WAT_GROUP");

            migrationBuilder.DropTable(
                name: "WAT_DEVICETYPE");

            migrationBuilder.DropTable(
                name: "WAT_PARSER");

            migrationBuilder.DropTable(
                name: "WAT_SUPPLIER");

            migrationBuilder.DropTable(
                name: "WAT_APP_USER");
        }
    }
}
