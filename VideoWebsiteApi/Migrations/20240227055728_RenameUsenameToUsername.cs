using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoWebsiteApi.Migrations
{
    /// <inheritdoc />
    public partial class RenameUsenameToUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Usename",
                table: "Users",
                newName: "Username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "Usename");
        }
    }
}
 