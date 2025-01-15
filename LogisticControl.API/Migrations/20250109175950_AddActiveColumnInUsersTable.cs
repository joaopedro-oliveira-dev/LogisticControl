using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticControl.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddActiveColumnInUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "active",
                schema: "api",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "api",
                table: "users",
                keyColumn: "user_name",
                keyValue: "JOAO PEDRO ADM",
                column: "active",
                value: true);

            migrationBuilder.UpdateData(
                schema: "api",
                table: "users",
                keyColumn: "user_name",
                keyValue: "JOAO PEDRO ANALISTA",
                columns: new[] { "active", "role" },
                values: new object[] { true, "Analista" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "active",
                schema: "api",
                table: "users");

            migrationBuilder.UpdateData(
                schema: "api",
                table: "users",
                keyColumn: "user_name",
                keyValue: "JOAO PEDRO ANALISTA",
                column: "role",
                value: "Administrador");
        }
    }
}
