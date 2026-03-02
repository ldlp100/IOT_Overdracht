using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waternet.DAL.Migrations
{
    public partial class V101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WAT_APP_CONFIG_WAT_APP_USER_CREATED_BY",
                table: "WAT_APP_CONFIG");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_APP_CONFIG_WAT_APP_USER_UPDATED_BY",
                table: "WAT_APP_CONFIG");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_ATT_WAT_APP_USER_CREATED_BY",
                table: "WAT_ATT");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_ATT_WAT_APP_USER_UPDATED_BY",
                table: "WAT_ATT");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_BATCH_DEVICE_WAT_APP_USER_CREATED_BY",
                table: "WAT_BATCH_DEVICE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_BATCH_DEVICE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_BATCH_DEVICE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_BATCH_DEVICE_WAT_GROUP_GROUP_ID",
                table: "WAT_BATCH_DEVICE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_BOSWACHTER_WAT_APP_USER_CREATED_BY",
                table: "WAT_BOSWACHTER");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_BOSWACHTER_WAT_APP_USER_UPDATED_BY",
                table: "WAT_BOSWACHTER");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEV2CALIB_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEV2CALIB");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEV2CALIB_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEV2CALIB");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEV2OUTPUT_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEV2OUTPUT");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEV2OUTPUT_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEV2OUTPUT");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICE_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICE2CONFIGURATION_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICE2CONFIGURATION");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICE2CONFIGURATION_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICE2CONFIGURATION");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICE2GROUP_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICE2GROUP");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICE2GROUP_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICE2GROUP");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICE2GROUP_WAT_DEVICE_DEVICE_ID",
                table: "WAT_DEVICE2GROUP");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICE2GROUP_WAT_GROUP_GROUP_ID",
                table: "WAT_DEVICE2GROUP");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICE2NETAPISETTING_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICE2NETAPISETTING");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICE2NETAPISETTING_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICE2NETAPISETTING");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICETYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICETYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICETYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICETYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICETYPE_FIRMWARE_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICETYPE_FIRMWARE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICETYPE_FIRMWARE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICETYPE_FIRMWARE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICETYPE_FIRMWARE_WAT_DEVICETYPE_FIRMWARE_ALERT_FIRMWARE_ID",
                table: "WAT_DEVICETYPE_FIRMWARE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICETYPE_FIRMWARE_WAT_DEVICETYPE_FIRMWARE_MEAS_FIRMWARE_ID",
                table: "WAT_DEVICETYPE_FIRMWARE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICETYPE_FIRMWARE_WAT_DEVICETYPE_FIRMWARE_STATE_FIRMWARE_ID",
                table: "WAT_DEVICETYPE_FIRMWARE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE_STATE_TYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE_STATE_TYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE_STATE_TYPE_WAT_DEVICETYPE_FIRMWARE_FIRMWARE_ID",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE2CONFIGURATION_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE2CONFIGURATION_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE2MEASUREMENT_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE2MEASUREMENT_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVTYPE2NETWORK_API_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVTYPE2NETWORK_API");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVTYPE2NETWORK_API_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVTYPE2NETWORK_API");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_EVENT_STATE_TYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_EVENT_STATE_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_EVENT_STATE_TYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_EVENT_STATE_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_GROUP_WAT_APP_USER_CREATED_BY",
                table: "WAT_GROUP");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_GROUP_WAT_APP_USER_UPDATED_BY",
                table: "WAT_GROUP");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_GROUP_WAT_GROUP_PARENT_GROUP_ID",
                table: "WAT_GROUP");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_MEAS_TYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_MEAS_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_MEAS_TYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_MEAS_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_NETWORK_API_WAT_APP_USER_CREATED_BY",
                table: "WAT_NETWORK_API");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_NETWORK_API_WAT_APP_USER_UPDATED_BY",
                table: "WAT_NETWORK_API");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_NETWORK_API_SETTING_WAT_APP_USER_CREATED_BY",
                table: "WAT_NETWORK_API_SETTING");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_NETWORK_API_SETTING_WAT_APP_USER_UPDATED_BY",
                table: "WAT_NETWORK_API_SETTING");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_PARSER_WAT_APP_USER_CREATED_BY",
                table: "WAT_PARSER");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_PARSER_WAT_APP_USER_UPDATED_BY",
                table: "WAT_PARSER");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_SERVICE_WAT_APP_USER_CREATED_BY",
                table: "WAT_SERVICE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_SERVICE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_SERVICE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_SUB_EVT_STATE_TYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_SUB_EVT_STATE_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_SUB_EVT_STATE_TYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_SUB_EVT_STATE_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_SUPPLIER_WAT_APP_USER_CREATED_BY",
                table: "WAT_SUPPLIER");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_SUPPLIER_WAT_APP_USER_UPDATED_BY",
                table: "WAT_SUPPLIER");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_UNIT_TYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_UNIT_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_UNIT_TYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_UNIT_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_USER_TASK_WAT_APP_USER_CREATED_BY",
                table: "WAT_USER_TASK");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_USER_TASK_WAT_APP_USER_UPDATED_BY",
                table: "WAT_USER_TASK");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_USER2GROUP_WAT_APP_USER_CREATED_BY",
                table: "WAT_USER2GROUP");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_USER2GROUP_WAT_APP_USER_UPDATED_BY",
                table: "WAT_USER2GROUP");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_USER2SERVICE_WAT_APP_USER_CREATED_BY",
                table: "WAT_USER2SERVICE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_USER2SERVICE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_USER2SERVICE");

            migrationBuilder.DropIndex(
                name: "IX_WAT_GROUP_PARENT_GROUP_ID",
                table: "WAT_GROUP");

            migrationBuilder.DropIndex(
                name: "IX_WAT_DEVICETYPE_FIRMWARE_ALERT_FIRMWARE_ID",
                table: "WAT_DEVICETYPE_FIRMWARE");

            migrationBuilder.DropIndex(
                name: "IX_WAT_DEVICETYPE_FIRMWARE_MEAS_FIRMWARE_ID",
                table: "WAT_DEVICETYPE_FIRMWARE");

            migrationBuilder.DropIndex(
                name: "IX_WAT_DEVICETYPE_FIRMWARE_STATE_FIRMWARE_ID",
                table: "WAT_DEVICETYPE_FIRMWARE");

            migrationBuilder.DropColumn(
                name: "ISPROJECT",
                table: "WAT_GROUP");

            migrationBuilder.DropColumn(
                name: "PARENT_GROUP_ID",
                table: "WAT_GROUP");

            migrationBuilder.DropColumn(
                name: "isNew",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT");

            migrationBuilder.DropColumn(
                name: "isNew",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION");

            migrationBuilder.DropColumn(
                name: "isNew",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE");

            migrationBuilder.DropColumn(
                name: "ALERT_FIRMWARE_ID",
                table: "WAT_DEVICETYPE_FIRMWARE");

            migrationBuilder.DropColumn(
                name: "MEAS_FIRMWARE_ID",
                table: "WAT_DEVICETYPE_FIRMWARE");

            migrationBuilder.DropColumn(
                name: "STATE_FIRMWARE_ID",
                table: "WAT_DEVICETYPE_FIRMWARE");

            migrationBuilder.DropColumn(
                name: "FIRMW_VER",
                table: "WAT_DEVICE");

            migrationBuilder.DropColumn(
                name: "LORA_ABP_APPSKey",
                table: "WAT_DEVICE");

            migrationBuilder.DropColumn(
                name: "LORA_ABP_NwkSKey",
                table: "WAT_DEVICE");

            migrationBuilder.DropColumn(
                name: "LORA_ABP_devADDR",
                table: "WAT_DEVICE");

            migrationBuilder.DropColumn(
                name: "PROV_LORA",
                table: "WAT_DEVICE");

            migrationBuilder.DropColumn(
                name: "PROV_LTM",
                table: "WAT_DEVICE");

            migrationBuilder.DropColumn(
                name: "PROV_NBIOT",
                table: "WAT_DEVICE");

            migrationBuilder.DropColumn(
                name: "PROV_SIGFOX",
                table: "WAT_DEVICE");

            migrationBuilder.DropColumn(
                name: "PUBLISHED_DOC_COUNTER",
                table: "WAT_DEVICE");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_USER2SERVICE",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_USER2SERVICE",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_USER2SERVICE",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_USER2SERVICE",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_USER2GROUP",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_USER2GROUP",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_USER2GROUP",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_USER2GROUP",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_USER_TASK",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_USER_TASK",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_USER_TASK",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MESSAGE",
                table: "WAT_USER_TASK",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "HREF",
                table: "WAT_USER_TASK",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DES",
                table: "WAT_USER_TASK",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_USER_TASK",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_USER_TASK",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_UNIT_TYPE",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_UNIT_TYPE",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_UNIT_TYPE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LABEL",
                table: "WAT_UNIT_TYPE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_UNIT_TYPE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_UNIT_TYPE",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_UNIT_TYPE",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_SUPPLIER",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_SUPPLIER",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "TELNUMBER",
                table: "WAT_SUPPLIER",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_SUPPLIER",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_SUPPLIER",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_SUPPLIER",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_SUPPLIER",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_SUB_EVT_STATE_TYPE",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_SUB_EVT_STATE_TYPE",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_SUB_EVT_STATE_TYPE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_SUB_EVT_STATE_TYPE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_SUB_EVT_STATE_TYPE",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_SUB_EVT_STATE_TYPE",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_SERVICE",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_SERVICE",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "STOP_AUT_URL",
                table: "WAT_SERVICE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "START_AUT_URL",
                table: "WAT_SERVICE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_SERVICE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "WAT_SERVICE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_SERVICE",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_SERVICE",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_PARSER",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_PARSER",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_PARSER",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_PARSER",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_PARSER",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_PARSER",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CLASSNAME",
                table: "WAT_PARSER",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "VAL",
                table: "WAT_NETWORK_API_SETTING",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_NETWORK_API_SETTING",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_NETWORK_API_SETTING",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "SECRET_VAL",
                table: "WAT_NETWORK_API_SETTING",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_NETWORK_API_SETTING",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_NETWORK_API_SETTING",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_NETWORK_API_SETTING",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_NETWORK_API_SETTING",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_NETWORK_API",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_NETWORK_API",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_NETWORK_API",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_NETWORK_API",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_NETWORK_API",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_NETWORK_API",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_MEAS_TYPE",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_MEAS_TYPE",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_MEAS_TYPE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_MEAS_TYPE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_MEAS_TYPE",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_MEAS_TYPE",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_GROUP",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_GROUP",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "TARGETDB",
                table: "WAT_GROUP",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_GROUP",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_GROUP",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_GROUP",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_GROUP",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_EVENT_STATE_TYPE",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_EVENT_STATE_TYPE",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_EVENT_STATE_TYPE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_EVENT_STATE_TYPE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_EVENT_STATE_TYPE",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_EVENT_STATE_TYPE",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_DEVTYPE2NETWORK_API",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_DEVTYPE2NETWORK_API",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_DEVTYPE2NETWORK_API",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_DEVTYPE2NETWORK_API",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "UNIT",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "TYPENAME",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SYMBOL",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "REGEX",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DVALUE",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CATEGORIES",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "FIRMWARE_ID",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_DEVICETYPE_FIRMWARE",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_DEVICETYPE_FIRMWARE",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_DEVICETYPE_FIRMWARE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_DEVICETYPE_FIRMWARE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_DEVICETYPE_FIRMWARE",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_DEVICETYPE_FIRMWARE",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_DEVICETYPE",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_DEVICETYPE",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_DEVICETYPE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_DEVICETYPE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_DEVICETYPE",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_DEVICETYPE",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "VALUE",
                table: "WAT_DEVICE2NETAPISETTING",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_DEVICE2NETAPISETTING",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_DEVICE2NETAPISETTING",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_DEVICE2NETAPISETTING",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_DEVICE2NETAPISETTING",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_DEVICE2GROUP",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_DEVICE2GROUP",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "GROUP_ID",
                table: "WAT_DEVICE2GROUP",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "DEVICE_ID",
                table: "WAT_DEVICE2GROUP",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_DEVICE2GROUP",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_DEVICE2GROUP",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "VALUE",
                table: "WAT_DEVICE2CONFIGURATION",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_DEVICE2CONFIGURATION",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_DEVICE2CONFIGURATION",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_DEVICE2CONFIGURATION",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_DEVICE2CONFIGURATION",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_DEVICE",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_DEVICE",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "SIGFOX_PAC",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SIGFOX_ID",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SIGFOX_APPKey",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SERIALNR",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PUBLISHED_DOC_ID",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LORA_OTAA_APPKEY",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LORA_OTAA_APPEUI",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LORA_DEVEUI",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "IMEI_APPKEY",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "IMEI",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ICCID",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "HDW_VER",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_DEVICE",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_DEVICE",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "ASSET_UID",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_DEV2OUTPUT",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_DEV2OUTPUT",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "PC",
                table: "WAT_DEV2OUTPUT",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_DEV2OUTPUT",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_DEV2OUTPUT",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_DEV2CALIB",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_DEV2CALIB",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_DEV2CALIB",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_DEV2CALIB",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_BOSWACHTER",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_BOSWACHTER",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_BOSWACHTER",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_BOSWACHTER",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_BOSWACHTER",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_BATCH_DEVICE",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_BATCH_DEVICE",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_BATCH_DEVICE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "GROUP_ID",
                table: "WAT_BATCH_DEVICE",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_BATCH_DEVICE",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_BATCH_DEVICE",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "URL",
                table: "WAT_ATT",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_ATT",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_ATT",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DESC",
                table: "WAT_ATT",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_ATT",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_ATT",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "VALUE",
                table: "WAT_APP_CONFIG",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_APP_CONFIG",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_APP_CONFIG",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_APP_CONFIG",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_APP_CONFIG",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_APP_CONFIG",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "WAT_TARGETDB",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UPDATED = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UPDATED_BY = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAT_TARGETDB", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WAT_TARGETDB_WAT_APP_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_WAT_TARGETDB_WAT_APP_USER_UPDATED_BY",
                        column: x => x.UPDATED_BY,
                        principalTable: "WAT_APP_USER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WAT_TARGETDB_CREATED_BY",
                table: "WAT_TARGETDB",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_TARGETDB_UPDATED_BY",
                table: "WAT_TARGETDB",
                column: "UPDATED_BY");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_APP_CONFIG_WAT_APP_USER_CREATED_BY",
                table: "WAT_APP_CONFIG",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_APP_CONFIG_WAT_APP_USER_UPDATED_BY",
                table: "WAT_APP_CONFIG",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_ATT_WAT_APP_USER_CREATED_BY",
                table: "WAT_ATT",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_ATT_WAT_APP_USER_UPDATED_BY",
                table: "WAT_ATT",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_BATCH_DEVICE_WAT_APP_USER_CREATED_BY",
                table: "WAT_BATCH_DEVICE",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_BATCH_DEVICE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_BATCH_DEVICE",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_BATCH_DEVICE_WAT_GROUP_GROUP_ID",
                table: "WAT_BATCH_DEVICE",
                column: "GROUP_ID",
                principalTable: "WAT_GROUP",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_BOSWACHTER_WAT_APP_USER_CREATED_BY",
                table: "WAT_BOSWACHTER",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_BOSWACHTER_WAT_APP_USER_UPDATED_BY",
                table: "WAT_BOSWACHTER",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEV2CALIB_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEV2CALIB",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEV2CALIB_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEV2CALIB",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEV2OUTPUT_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEV2OUTPUT",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEV2OUTPUT_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEV2OUTPUT",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICE_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICE",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICE",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICE2CONFIGURATION_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICE2CONFIGURATION",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICE2CONFIGURATION_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICE2CONFIGURATION",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICE2GROUP_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICE2GROUP",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICE2GROUP_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICE2GROUP",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICE2GROUP_WAT_DEVICE_DEVICE_ID",
                table: "WAT_DEVICE2GROUP",
                column: "DEVICE_ID",
                principalTable: "WAT_DEVICE",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICE2GROUP_WAT_GROUP_GROUP_ID",
                table: "WAT_DEVICE2GROUP",
                column: "GROUP_ID",
                principalTable: "WAT_GROUP",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICE2NETAPISETTING_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICE2NETAPISETTING",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICE2NETAPISETTING_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICE2NETAPISETTING",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICETYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICETYPE",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICETYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICETYPE",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICETYPE_FIRMWARE_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICETYPE_FIRMWARE",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICETYPE_FIRMWARE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICETYPE_FIRMWARE",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE_STATE_TYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE_STATE_TYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE_STATE_TYPE_WAT_DEVICETYPE_FIRMWARE_FIRMWARE_ID",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                column: "FIRMWARE_ID",
                principalTable: "WAT_DEVICETYPE_FIRMWARE",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE2CONFIGURATION_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE2CONFIGURATION_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE2MEASUREMENT_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE2MEASUREMENT_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVTYPE2NETWORK_API_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVTYPE2NETWORK_API",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVTYPE2NETWORK_API_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVTYPE2NETWORK_API",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_EVENT_STATE_TYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_EVENT_STATE_TYPE",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_EVENT_STATE_TYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_EVENT_STATE_TYPE",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_GROUP_WAT_APP_USER_CREATED_BY",
                table: "WAT_GROUP",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_GROUP_WAT_APP_USER_UPDATED_BY",
                table: "WAT_GROUP",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_MEAS_TYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_MEAS_TYPE",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_MEAS_TYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_MEAS_TYPE",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_NETWORK_API_WAT_APP_USER_CREATED_BY",
                table: "WAT_NETWORK_API",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_NETWORK_API_WAT_APP_USER_UPDATED_BY",
                table: "WAT_NETWORK_API",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_NETWORK_API_SETTING_WAT_APP_USER_CREATED_BY",
                table: "WAT_NETWORK_API_SETTING",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_NETWORK_API_SETTING_WAT_APP_USER_UPDATED_BY",
                table: "WAT_NETWORK_API_SETTING",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_PARSER_WAT_APP_USER_CREATED_BY",
                table: "WAT_PARSER",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_PARSER_WAT_APP_USER_UPDATED_BY",
                table: "WAT_PARSER",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_SERVICE_WAT_APP_USER_CREATED_BY",
                table: "WAT_SERVICE",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_SERVICE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_SERVICE",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_SUB_EVT_STATE_TYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_SUB_EVT_STATE_TYPE",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_SUB_EVT_STATE_TYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_SUB_EVT_STATE_TYPE",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_SUPPLIER_WAT_APP_USER_CREATED_BY",
                table: "WAT_SUPPLIER",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_SUPPLIER_WAT_APP_USER_UPDATED_BY",
                table: "WAT_SUPPLIER",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_UNIT_TYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_UNIT_TYPE",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_UNIT_TYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_UNIT_TYPE",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_USER_TASK_WAT_APP_USER_CREATED_BY",
                table: "WAT_USER_TASK",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_USER_TASK_WAT_APP_USER_UPDATED_BY",
                table: "WAT_USER_TASK",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_USER2GROUP_WAT_APP_USER_CREATED_BY",
                table: "WAT_USER2GROUP",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_USER2GROUP_WAT_APP_USER_UPDATED_BY",
                table: "WAT_USER2GROUP",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_USER2SERVICE_WAT_APP_USER_CREATED_BY",
                table: "WAT_USER2SERVICE",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_USER2SERVICE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_USER2SERVICE",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WAT_APP_CONFIG_WAT_APP_USER_CREATED_BY",
                table: "WAT_APP_CONFIG");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_APP_CONFIG_WAT_APP_USER_UPDATED_BY",
                table: "WAT_APP_CONFIG");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_ATT_WAT_APP_USER_CREATED_BY",
                table: "WAT_ATT");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_ATT_WAT_APP_USER_UPDATED_BY",
                table: "WAT_ATT");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_BATCH_DEVICE_WAT_APP_USER_CREATED_BY",
                table: "WAT_BATCH_DEVICE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_BATCH_DEVICE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_BATCH_DEVICE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_BATCH_DEVICE_WAT_GROUP_GROUP_ID",
                table: "WAT_BATCH_DEVICE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_BOSWACHTER_WAT_APP_USER_CREATED_BY",
                table: "WAT_BOSWACHTER");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_BOSWACHTER_WAT_APP_USER_UPDATED_BY",
                table: "WAT_BOSWACHTER");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEV2CALIB_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEV2CALIB");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEV2CALIB_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEV2CALIB");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEV2OUTPUT_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEV2OUTPUT");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEV2OUTPUT_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEV2OUTPUT");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICE_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICE2CONFIGURATION_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICE2CONFIGURATION");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICE2CONFIGURATION_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICE2CONFIGURATION");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICE2GROUP_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICE2GROUP");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICE2GROUP_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICE2GROUP");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICE2GROUP_WAT_DEVICE_DEVICE_ID",
                table: "WAT_DEVICE2GROUP");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICE2GROUP_WAT_GROUP_GROUP_ID",
                table: "WAT_DEVICE2GROUP");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICE2NETAPISETTING_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICE2NETAPISETTING");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICE2NETAPISETTING_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICE2NETAPISETTING");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICETYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICETYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICETYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICETYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICETYPE_FIRMWARE_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICETYPE_FIRMWARE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICETYPE_FIRMWARE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICETYPE_FIRMWARE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE_STATE_TYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE_STATE_TYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE_STATE_TYPE_WAT_DEVICETYPE_FIRMWARE_FIRMWARE_ID",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE2CONFIGURATION_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE2CONFIGURATION_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE2MEASUREMENT_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE2MEASUREMENT_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVTYPE2NETWORK_API_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVTYPE2NETWORK_API");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVTYPE2NETWORK_API_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVTYPE2NETWORK_API");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_EVENT_STATE_TYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_EVENT_STATE_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_EVENT_STATE_TYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_EVENT_STATE_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_GROUP_WAT_APP_USER_CREATED_BY",
                table: "WAT_GROUP");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_GROUP_WAT_APP_USER_UPDATED_BY",
                table: "WAT_GROUP");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_MEAS_TYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_MEAS_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_MEAS_TYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_MEAS_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_NETWORK_API_WAT_APP_USER_CREATED_BY",
                table: "WAT_NETWORK_API");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_NETWORK_API_WAT_APP_USER_UPDATED_BY",
                table: "WAT_NETWORK_API");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_NETWORK_API_SETTING_WAT_APP_USER_CREATED_BY",
                table: "WAT_NETWORK_API_SETTING");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_NETWORK_API_SETTING_WAT_APP_USER_UPDATED_BY",
                table: "WAT_NETWORK_API_SETTING");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_PARSER_WAT_APP_USER_CREATED_BY",
                table: "WAT_PARSER");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_PARSER_WAT_APP_USER_UPDATED_BY",
                table: "WAT_PARSER");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_SERVICE_WAT_APP_USER_CREATED_BY",
                table: "WAT_SERVICE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_SERVICE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_SERVICE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_SUB_EVT_STATE_TYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_SUB_EVT_STATE_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_SUB_EVT_STATE_TYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_SUB_EVT_STATE_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_SUPPLIER_WAT_APP_USER_CREATED_BY",
                table: "WAT_SUPPLIER");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_SUPPLIER_WAT_APP_USER_UPDATED_BY",
                table: "WAT_SUPPLIER");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_UNIT_TYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_UNIT_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_UNIT_TYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_UNIT_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_USER_TASK_WAT_APP_USER_CREATED_BY",
                table: "WAT_USER_TASK");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_USER_TASK_WAT_APP_USER_UPDATED_BY",
                table: "WAT_USER_TASK");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_USER2GROUP_WAT_APP_USER_CREATED_BY",
                table: "WAT_USER2GROUP");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_USER2GROUP_WAT_APP_USER_UPDATED_BY",
                table: "WAT_USER2GROUP");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_USER2SERVICE_WAT_APP_USER_CREATED_BY",
                table: "WAT_USER2SERVICE");

            migrationBuilder.DropForeignKey(
                name: "FK_WAT_USER2SERVICE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_USER2SERVICE");

            migrationBuilder.DropTable(
                name: "WAT_TARGETDB");

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_USER2SERVICE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_USER2SERVICE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_USER2SERVICE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_USER2SERVICE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_USER2GROUP",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_USER2GROUP",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_USER2GROUP",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_USER2GROUP",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_USER_TASK",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_USER_TASK",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_USER_TASK",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MESSAGE",
                table: "WAT_USER_TASK",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HREF",
                table: "WAT_USER_TASK",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DES",
                table: "WAT_USER_TASK",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_USER_TASK",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_USER_TASK",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_UNIT_TYPE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_UNIT_TYPE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_UNIT_TYPE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LABEL",
                table: "WAT_UNIT_TYPE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_UNIT_TYPE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_UNIT_TYPE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_UNIT_TYPE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_SUPPLIER",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_SUPPLIER",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TELNUMBER",
                table: "WAT_SUPPLIER",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_SUPPLIER",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_SUPPLIER",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_SUPPLIER",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_SUPPLIER",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_SUB_EVT_STATE_TYPE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_SUB_EVT_STATE_TYPE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_SUB_EVT_STATE_TYPE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_SUB_EVT_STATE_TYPE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_SUB_EVT_STATE_TYPE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_SUB_EVT_STATE_TYPE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_SERVICE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_SERVICE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "STOP_AUT_URL",
                table: "WAT_SERVICE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "START_AUT_URL",
                table: "WAT_SERVICE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_SERVICE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "WAT_SERVICE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_SERVICE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_SERVICE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_PARSER",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_PARSER",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_PARSER",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_PARSER",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_PARSER",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_PARSER",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CLASSNAME",
                table: "WAT_PARSER",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VAL",
                table: "WAT_NETWORK_API_SETTING",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_NETWORK_API_SETTING",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_NETWORK_API_SETTING",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SECRET_VAL",
                table: "WAT_NETWORK_API_SETTING",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_NETWORK_API_SETTING",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_NETWORK_API_SETTING",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_NETWORK_API_SETTING",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_NETWORK_API_SETTING",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_NETWORK_API",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_NETWORK_API",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_NETWORK_API",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_NETWORK_API",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_NETWORK_API",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_NETWORK_API",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_MEAS_TYPE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_MEAS_TYPE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_MEAS_TYPE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_MEAS_TYPE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_MEAS_TYPE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_MEAS_TYPE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_GROUP",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_GROUP",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TARGETDB",
                table: "WAT_GROUP",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_GROUP",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_GROUP",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_GROUP",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_GROUP",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ISPROJECT",
                table: "WAT_GROUP",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "PARENT_GROUP_ID",
                table: "WAT_GROUP",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_EVENT_STATE_TYPE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_EVENT_STATE_TYPE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_EVENT_STATE_TYPE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_EVENT_STATE_TYPE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_EVENT_STATE_TYPE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_EVENT_STATE_TYPE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_DEVTYPE2NETWORK_API",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_DEVTYPE2NETWORK_API",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_DEVTYPE2NETWORK_API",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_DEVTYPE2NETWORK_API",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UNIT",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isNew",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TYPENAME",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SYMBOL",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "REGEX",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DVALUE",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CATEGORIES",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isNew",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FIRMWARE_ID",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isNew",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_DEVICETYPE_FIRMWARE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_DEVICETYPE_FIRMWARE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_DEVICETYPE_FIRMWARE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_DEVICETYPE_FIRMWARE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_DEVICETYPE_FIRMWARE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_DEVICETYPE_FIRMWARE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ALERT_FIRMWARE_ID",
                table: "WAT_DEVICETYPE_FIRMWARE",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MEAS_FIRMWARE_ID",
                table: "WAT_DEVICETYPE_FIRMWARE",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "STATE_FIRMWARE_ID",
                table: "WAT_DEVICETYPE_FIRMWARE",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_DEVICETYPE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_DEVICETYPE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_DEVICETYPE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_DEVICETYPE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_DEVICETYPE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_DEVICETYPE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VALUE",
                table: "WAT_DEVICE2NETAPISETTING",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_DEVICE2NETAPISETTING",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_DEVICE2NETAPISETTING",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_DEVICE2NETAPISETTING",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_DEVICE2NETAPISETTING",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_DEVICE2GROUP",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_DEVICE2GROUP",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GROUP_ID",
                table: "WAT_DEVICE2GROUP",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DEVICE_ID",
                table: "WAT_DEVICE2GROUP",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_DEVICE2GROUP",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_DEVICE2GROUP",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VALUE",
                table: "WAT_DEVICE2CONFIGURATION",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_DEVICE2CONFIGURATION",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_DEVICE2CONFIGURATION",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_DEVICE2CONFIGURATION",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_DEVICE2CONFIGURATION",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_DEVICE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_DEVICE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SIGFOX_PAC",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SIGFOX_ID",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SIGFOX_APPKey",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SERIALNR",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PUBLISHED_DOC_ID",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LORA_OTAA_APPKEY",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LORA_OTAA_APPEUI",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LORA_DEVEUI",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IMEI_APPKEY",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IMEI",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ICCID",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HDW_VER",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_DEVICE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_DEVICE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ASSET_UID",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FIRMW_VER",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LORA_ABP_APPSKey",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LORA_ABP_NwkSKey",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LORA_ABP_devADDR",
                table: "WAT_DEVICE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "PROV_LORA",
                table: "WAT_DEVICE",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PROV_LTM",
                table: "WAT_DEVICE",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PROV_NBIOT",
                table: "WAT_DEVICE",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PROV_SIGFOX",
                table: "WAT_DEVICE",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PUBLISHED_DOC_COUNTER",
                table: "WAT_DEVICE",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_DEV2OUTPUT",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_DEV2OUTPUT",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PC",
                table: "WAT_DEV2OUTPUT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_DEV2OUTPUT",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_DEV2OUTPUT",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_DEV2CALIB",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_DEV2CALIB",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_DEV2CALIB",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_DEV2CALIB",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_BOSWACHTER",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_BOSWACHTER",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_BOSWACHTER",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_BOSWACHTER",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_BOSWACHTER",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_BATCH_DEVICE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_BATCH_DEVICE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "WAT_BATCH_DEVICE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GROUP_ID",
                table: "WAT_BATCH_DEVICE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_BATCH_DEVICE",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_BATCH_DEVICE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "URL",
                table: "WAT_ATT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_ATT",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_ATT",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESC",
                table: "WAT_ATT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_ATT",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_ATT",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VALUE",
                table: "WAT_APP_CONFIG",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UPDATED_BY",
                table: "WAT_APP_CONFIG",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATED",
                table: "WAT_APP_CONFIG",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "WAT_APP_CONFIG",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CREATED_BY",
                table: "WAT_APP_CONFIG",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED",
                table: "WAT_APP_CONFIG",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WAT_GROUP_PARENT_GROUP_ID",
                table: "WAT_GROUP",
                column: "PARENT_GROUP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICETYPE_FIRMWARE_ALERT_FIRMWARE_ID",
                table: "WAT_DEVICETYPE_FIRMWARE",
                column: "ALERT_FIRMWARE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICETYPE_FIRMWARE_MEAS_FIRMWARE_ID",
                table: "WAT_DEVICETYPE_FIRMWARE",
                column: "MEAS_FIRMWARE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WAT_DEVICETYPE_FIRMWARE_STATE_FIRMWARE_ID",
                table: "WAT_DEVICETYPE_FIRMWARE",
                column: "STATE_FIRMWARE_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_APP_CONFIG_WAT_APP_USER_CREATED_BY",
                table: "WAT_APP_CONFIG",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_APP_CONFIG_WAT_APP_USER_UPDATED_BY",
                table: "WAT_APP_CONFIG",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_ATT_WAT_APP_USER_CREATED_BY",
                table: "WAT_ATT",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_ATT_WAT_APP_USER_UPDATED_BY",
                table: "WAT_ATT",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_BATCH_DEVICE_WAT_APP_USER_CREATED_BY",
                table: "WAT_BATCH_DEVICE",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_BATCH_DEVICE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_BATCH_DEVICE",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_BATCH_DEVICE_WAT_GROUP_GROUP_ID",
                table: "WAT_BATCH_DEVICE",
                column: "GROUP_ID",
                principalTable: "WAT_GROUP",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_BOSWACHTER_WAT_APP_USER_CREATED_BY",
                table: "WAT_BOSWACHTER",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_BOSWACHTER_WAT_APP_USER_UPDATED_BY",
                table: "WAT_BOSWACHTER",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEV2CALIB_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEV2CALIB",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEV2CALIB_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEV2CALIB",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEV2OUTPUT_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEV2OUTPUT",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEV2OUTPUT_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEV2OUTPUT",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICE_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICE",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICE",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICE2CONFIGURATION_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICE2CONFIGURATION",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICE2CONFIGURATION_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICE2CONFIGURATION",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICE2GROUP_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICE2GROUP",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICE2GROUP_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICE2GROUP",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICE2GROUP_WAT_DEVICE_DEVICE_ID",
                table: "WAT_DEVICE2GROUP",
                column: "DEVICE_ID",
                principalTable: "WAT_DEVICE",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICE2GROUP_WAT_GROUP_GROUP_ID",
                table: "WAT_DEVICE2GROUP",
                column: "GROUP_ID",
                principalTable: "WAT_GROUP",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICE2NETAPISETTING_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICE2NETAPISETTING",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICE2NETAPISETTING_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICE2NETAPISETTING",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICETYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICETYPE",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICETYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICETYPE",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICETYPE_FIRMWARE_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICETYPE_FIRMWARE",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICETYPE_FIRMWARE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICETYPE_FIRMWARE",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICETYPE_FIRMWARE_WAT_DEVICETYPE_FIRMWARE_ALERT_FIRMWARE_ID",
                table: "WAT_DEVICETYPE_FIRMWARE",
                column: "ALERT_FIRMWARE_ID",
                principalTable: "WAT_DEVICETYPE_FIRMWARE",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICETYPE_FIRMWARE_WAT_DEVICETYPE_FIRMWARE_MEAS_FIRMWARE_ID",
                table: "WAT_DEVICETYPE_FIRMWARE",
                column: "MEAS_FIRMWARE_ID",
                principalTable: "WAT_DEVICETYPE_FIRMWARE",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICETYPE_FIRMWARE_WAT_DEVICETYPE_FIRMWARE_STATE_FIRMWARE_ID",
                table: "WAT_DEVICETYPE_FIRMWARE",
                column: "STATE_FIRMWARE_ID",
                principalTable: "WAT_DEVICETYPE_FIRMWARE",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE_STATE_TYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE_STATE_TYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE_STATE_TYPE_WAT_DEVICETYPE_FIRMWARE_FIRMWARE_ID",
                table: "WAT_DEVICETYPEFIRMWARE_STATE_TYPE",
                column: "FIRMWARE_ID",
                principalTable: "WAT_DEVICETYPE_FIRMWARE",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE2CONFIGURATION_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE2CONFIGURATION_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2CONFIGURATION",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE2MEASUREMENT_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVICETYPEFIRMWARE2MEASUREMENT_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVICETYPEFIRMWARE2MEASUREMENT",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVTYPE2NETWORK_API_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVTYPE2NETWORK_API",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVTYPE2NETWORK_API_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVTYPE2NETWORK_API",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_DEVTYPEFIRMWARE_EVT_SUB_EVT_STATE_TYPE",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_EVENT_STATE_TYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_EVENT_STATE_TYPE",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_EVENT_STATE_TYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_EVENT_STATE_TYPE",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_GROUP_WAT_APP_USER_CREATED_BY",
                table: "WAT_GROUP",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_GROUP_WAT_APP_USER_UPDATED_BY",
                table: "WAT_GROUP",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_GROUP_WAT_GROUP_PARENT_GROUP_ID",
                table: "WAT_GROUP",
                column: "PARENT_GROUP_ID",
                principalTable: "WAT_GROUP",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_MEAS_TYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_MEAS_TYPE",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_MEAS_TYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_MEAS_TYPE",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_NETWORK_API_WAT_APP_USER_CREATED_BY",
                table: "WAT_NETWORK_API",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_NETWORK_API_WAT_APP_USER_UPDATED_BY",
                table: "WAT_NETWORK_API",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_NETWORK_API_SETTING_WAT_APP_USER_CREATED_BY",
                table: "WAT_NETWORK_API_SETTING",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_NETWORK_API_SETTING_WAT_APP_USER_UPDATED_BY",
                table: "WAT_NETWORK_API_SETTING",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_PARSER_WAT_APP_USER_CREATED_BY",
                table: "WAT_PARSER",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_PARSER_WAT_APP_USER_UPDATED_BY",
                table: "WAT_PARSER",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_SERVICE_WAT_APP_USER_CREATED_BY",
                table: "WAT_SERVICE",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_SERVICE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_SERVICE",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_SUB_EVT_STATE_TYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_SUB_EVT_STATE_TYPE",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_SUB_EVT_STATE_TYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_SUB_EVT_STATE_TYPE",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_SUPPLIER_WAT_APP_USER_CREATED_BY",
                table: "WAT_SUPPLIER",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_SUPPLIER_WAT_APP_USER_UPDATED_BY",
                table: "WAT_SUPPLIER",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_UNIT_TYPE_WAT_APP_USER_CREATED_BY",
                table: "WAT_UNIT_TYPE",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_UNIT_TYPE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_UNIT_TYPE",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_USER_TASK_WAT_APP_USER_CREATED_BY",
                table: "WAT_USER_TASK",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_USER_TASK_WAT_APP_USER_UPDATED_BY",
                table: "WAT_USER_TASK",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_USER2GROUP_WAT_APP_USER_CREATED_BY",
                table: "WAT_USER2GROUP",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_USER2GROUP_WAT_APP_USER_UPDATED_BY",
                table: "WAT_USER2GROUP",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_USER2SERVICE_WAT_APP_USER_CREATED_BY",
                table: "WAT_USER2SERVICE",
                column: "CREATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WAT_USER2SERVICE_WAT_APP_USER_UPDATED_BY",
                table: "WAT_USER2SERVICE",
                column: "UPDATED_BY",
                principalTable: "WAT_APP_USER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
