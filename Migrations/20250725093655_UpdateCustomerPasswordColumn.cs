using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dmart_web.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCustomerPasswordColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Customers",
                newName: "Password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Customers",
                newName: "PasswordHash");
        }
    }
}
