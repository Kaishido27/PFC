using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMasterKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MasterKey",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "MasterKey",
                value: "0000");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasterKey",
                table: "SystemSettings");
        }
    }
}
