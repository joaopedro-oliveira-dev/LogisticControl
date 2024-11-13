using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LogisticControl.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    partnership_type = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_companies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "drivers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_drivers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "adresses",
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

            migrationBuilder.CreateTable(
                name: "routes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    opening = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    realization = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    finalization = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    driver__id = table.Column<int>(type: "integer", nullable: true),
                    status = table.Column<string>(type: "text", nullable: false),
                    observation = table.Column<string>(type: "text", nullable: true),
                    driver_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_routes", x => x.id);
                    table.ForeignKey(
                        name: "f_k_routes_drivers_driver__id",
                        column: x => x.driver__id,
                        principalTable: "drivers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "f_k_routes_drivers_driver_id",
                        column: x => x.driver_id,
                        principalTable: "drivers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    service_type = table.Column<string>(type: "text", nullable: false),
                    adress__id = table.Column<int>(type: "integer", nullable: true),
                    priority = table.Column<string>(type: "text", nullable: true),
                    tracking_type = table.Column<string>(type: "text", nullable: true),
                    tracking = table.Column<string>(type: "text", nullable: true),
                    observation = table.Column<string>(type: "text", nullable: true),
                    status_item = table.Column<string>(type: "text", nullable: false),
                    responsible = table.Column<string>(type: "text", nullable: true),
                    driver_observation = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: false),
                    route__id = table.Column<int>(type: "integer", nullable: true),
                    route_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_services", x => x.id);
                    table.ForeignKey(
                        name: "f_k_services_adresses_adress__id",
                        column: x => x.adress__id,
                        principalTable: "adresses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "f_k_services_routes_route__id",
                        column: x => x.route__id,
                        principalTable: "routes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "f_k_services_routes_route_id",
                        column: x => x.route_id,
                        principalTable: "routes",
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

            migrationBuilder.CreateIndex(
                name: "i_x_routes_driver__id",
                table: "routes",
                column: "driver__id");

            migrationBuilder.CreateIndex(
                name: "i_x_routes_driver_id",
                table: "routes",
                column: "driver_id");

            migrationBuilder.CreateIndex(
                name: "i_x_services_adress__id",
                table: "services",
                column: "adress__id");

            migrationBuilder.CreateIndex(
                name: "i_x_services_route__id",
                table: "services",
                column: "route__id");

            migrationBuilder.CreateIndex(
                name: "i_x_services_route_id",
                table: "services",
                column: "route_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "services");

            migrationBuilder.DropTable(
                name: "adresses");

            migrationBuilder.DropTable(
                name: "routes");

            migrationBuilder.DropTable(
                name: "companies");

            migrationBuilder.DropTable(
                name: "drivers");
        }
    }
}
