using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LogisticControl.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                schema: "api",
                columns: table => new
                {
                    email = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    role = table.Column<string>(type: "text", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_users", x => x.email);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users",
                schema: "api");
        }
    }
}
