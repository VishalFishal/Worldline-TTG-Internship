using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDWeb.Migrations
{
    /// <inheritdoc />
    public partial class RemoveConfirmPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Accounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Accounts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
