using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Book.Migrations
{
    /// <inheritdoc />
    public partial class Modify_Books : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookQty",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "DiscountedPri",
                table: "Books",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ListPrice",
                table: "Books",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ratings",
                table: "Books",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookQty",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "DiscountedPri",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ListPrice",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ratings",
                table: "Books");
        }
    }
}
