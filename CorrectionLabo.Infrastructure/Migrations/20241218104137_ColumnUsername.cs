using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CorrectionLabo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ColumnUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Members",
                newName: "Gender");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Members",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Members",
                newName: "Genre");
        }
    }
}
