using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OwnedFullName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullNameFirst",
                table: "Passengers",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "FullNameLast",
                table: "Passengers",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullNameFirst",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "FullNameLast",
                table: "Passengers");
        }
    }
}
