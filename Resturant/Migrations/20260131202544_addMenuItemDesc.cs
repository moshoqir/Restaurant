using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant.Migrations
{
    /// <inheritdoc />
    public partial class addMenuItemDesc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterItemMenuMainDesc",
                table: "MasterItemMenus");

            migrationBuilder.AddColumn<string>(
                name: "SystemSettingItemMenuDesc",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SystemSettingItemMenuDesc",
                table: "SystemSettings");

            migrationBuilder.AddColumn<string>(
                name: "MasterItemMenuMainDesc",
                table: "MasterItemMenus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
