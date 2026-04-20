using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant.Migrations
{
    /// <inheritdoc />
    public partial class addFeedbackDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterFeedbackDesc",
                table: "MasterFeedbacks");

            migrationBuilder.RenameColumn(
                name: "MasterFeedbackDesc",
                table: "SystemSettings",
                newName: "SystemSettingFeedbackDesc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SystemSettingFeedbackDesc",
                table: "SystemSettings",
                newName: "MasterFeedbackDesc");

            migrationBuilder.AddColumn<string>(
                name: "MasterFeedbackDesc",
                table: "MasterFeedbacks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
