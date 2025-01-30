using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LogisticControl.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnIdInUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "p_k_users",
                schema: "api",
                table: "users");

            migrationBuilder.DeleteData(
                schema: "api",
                table: "users",
                keyColumn: "email",
                keyValue: "joao.adm@gmail.com");

            migrationBuilder.DeleteData(
                schema: "api",
                table: "users",
                keyColumn: "email",
                keyValue: "joao.analista@gmail.com");

            migrationBuilder.AddColumn<string>(
                name: "id",
                schema: "api",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "p_k_users",
                schema: "api",
                table: "users",
                column: "id");

            migrationBuilder.InsertData(
                schema: "api",
                table: "users",
                columns: new[] { "id", "active", "email", "name", "password", "role" },
                values: new object[,]
                {
                    { "3af3a70d-fc0c-458a-ae8b-4e077c7890b4", true, "joao.analista@gmail.com", "JOAO PEDRO ANALISTA", "Analista123#", "Analista" },
                    { "ef30a1f4-9bbd-4f2c-be1e-5290b695892f", true, "joao.adm@gmail.com", "JOAO PEDRO ADM", "Administrador123#", "Administrador" }
                });

            migrationBuilder.CreateIndex(
                name: "i_x_users_email",
                schema: "api",
                table: "users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "p_k_users",
                schema: "api",
                table: "users");

            migrationBuilder.DropIndex(
                name: "i_x_users_email",
                schema: "api",
                table: "users");

            migrationBuilder.DeleteData(
                schema: "api",
                table: "users",
                keyColumn: "id",
                keyColumnType: "text",
                keyValue: "3af3a70d-fc0c-458a-ae8b-4e077c7890b4");

            migrationBuilder.DeleteData(
                schema: "api",
                table: "users",
                keyColumn: "id",
                keyColumnType: "text",
                keyValue: "ef30a1f4-9bbd-4f2c-be1e-5290b695892f");

            migrationBuilder.DropColumn(
                name: "id",
                schema: "api",
                table: "users");

            migrationBuilder.AddPrimaryKey(
                name: "p_k_users",
                schema: "api",
                table: "users",
                column: "email");

            migrationBuilder.InsertData(
                schema: "api",
                table: "users",
                columns: new[] { "email", "active", "name", "password", "role" },
                values: new object[,]
                {
                    { "joao.adm@gmail.com", true, "JOAO PEDRO ADM", "Administrador123#", "Administrador" },
                    { "joao.analista@gmail.com", true, "JOAO PEDRO ANALISTA", "Analista123#", "Analista" }
                });
        }
    }
}
