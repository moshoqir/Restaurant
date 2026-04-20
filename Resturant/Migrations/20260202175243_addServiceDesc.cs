using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant.Migrations
{
    /// <inheritdoc />
    public partial class addServiceDesc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterServiceMainDesc",
                table: "MasterServices");

            migrationBuilder.AddColumn<string>(
                name: "SystemSettingServiceDesc",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "MasterServiceImage",
                table: "MasterServices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SystemSettingServiceDesc",
                table: "SystemSettings");

            migrationBuilder.AlterColumn<string>(
                name: "MasterServiceImage",
                table: "MasterServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MasterServiceMainDesc",
                table: "MasterServices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
