using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class RevertInitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Shoes",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Shoes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Shoes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Shoes");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Shoes",
                newName: "id");
        }
    }
}
