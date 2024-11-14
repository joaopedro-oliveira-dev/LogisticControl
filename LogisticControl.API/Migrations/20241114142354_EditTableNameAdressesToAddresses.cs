using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LogisticControl.Api.Migrations
{
    /// <inheritdoc />
    public partial class EditTableNameAdressesToAddresses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "f_k_services_adresses_adress__id",
                table: "services");

            migrationBuilder.DropTable(
                name: "adresses");

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    street = table.Column<string>(type: "text", nullable: false),
                    number = table.Column<int>(type: "integer", nullable: false),
                    complement = table.Column<string>(type: "text", nullable: true),
                    neighborhood = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    state = table.Column<string>(type: "text", nullable: false),
                    company__id = table.Column<int>(type: "integer", nullable: false),
                    company_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_addresses", x => x.id);
                    table.ForeignKey(
                        name: "f_k_addresses__companies_company__id",
                        column: x => x.company__id,
                        principalTable: "companies",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "f_k_addresses__companies_company_id",
                        column: x => x.company_id,
                        principalTable: "companies",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "i_x_addresses_company__id",
                table: "addresses",
                column: "company__id");

            migrationBuilder.CreateIndex(
                name: "i_x_addresses_company_id",
                table: "addresses",
                column: "company_id");

            migrationBuilder.AddForeignKey(
                name: "f_k_services_addresses_adress__id",
                table: "services",
                column: "adress__id",
                principalTable: "addresses",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "f_k_services_addresses_adress__id",
                table: "services");

            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.CreateTable(
                name: "adresses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company__id = table.Column<int>(type: "integer", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    complement = table.Column<string>(type: "text", nullable: true),
                    neighborhood = table.Column<string>(type: "text", nullable: false),
                    number = table.Column<int>(type: "integer", nullable: false),
                    state = table.Column<string>(type: "text", nullable: false),
                    street = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_adresses", x => x.id);
                    table.ForeignKey(
                        name: "f_k_adresses__companies_company__id",
                        column: x => x.company__id,
                        principalTable: "companies",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "f_k_adresses__companies_company_id",
                        column: x => x.company_id,
                        principalTable: "companies",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "i_x_adresses_company__id",
                table: "adresses",
                column: "company__id");

            migrationBuilder.CreateIndex(
                name: "i_x_adresses_company_id",
                table: "adresses",
                column: "company_id");

            migrationBuilder.AddForeignKey(
                name: "f_k_services_adresses_adress__id",
                table: "services",
                column: "adress__id",
                principalTable: "adresses",
                principalColumn: "id");
        }
    }
}
