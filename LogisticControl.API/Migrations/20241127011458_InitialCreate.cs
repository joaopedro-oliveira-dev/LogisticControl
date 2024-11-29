using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LogisticControl.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "api");

            migrationBuilder.CreateTable(
                name: "companies",
                schema: "api",
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
                schema: "api",
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
                name: "addresses",
                schema: "api",
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
                    company_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_addresses", x => x.id);
                    table.ForeignKey(
                        name: "f_k_addresses__companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "api",
                        principalTable: "companies",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "routes",
                schema: "api",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    opening = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    realization = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    finalization = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    driver_id = table.Column<int>(type: "integer", nullable: true),
                    status = table.Column<string>(type: "text", nullable: false),
                    observation = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_routes", x => x.id);
                    table.ForeignKey(
                        name: "f_k_routes_drivers_driver_id",
                        column: x => x.driver_id,
                        principalSchema: "api",
                        principalTable: "drivers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "services",
                schema: "api",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    service_type = table.Column<string>(type: "text", nullable: false),
                    adress_id = table.Column<int>(type: "integer", nullable: true),
                    priority = table.Column<string>(type: "text", nullable: true),
                    tracking_type = table.Column<string>(type: "text", nullable: true),
                    tracking = table.Column<string>(type: "text", nullable: true),
                    observation = table.Column<string>(type: "text", nullable: true),
                    status_item = table.Column<string>(type: "text", nullable: false),
                    responsible = table.Column<string>(type: "text", nullable: true),
                    driver_observation = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: false),
                    route_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_services", x => x.id);
                    table.ForeignKey(
                        name: "f_k_services_addresses_adress_id",
                        column: x => x.adress_id,
                        principalSchema: "api",
                        principalTable: "addresses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "f_k_services_routes_route_id",
                        column: x => x.route_id,
                        principalSchema: "api",
                        principalTable: "routes",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                schema: "api",
                table: "companies",
                columns: new[] { "id", "name", "partnership_type", "phone" },
                values: new object[,]
                {
                    { 1, "Mecbrun Industrial", "Cliente", "(31) 96523-4789" },
                    { 2, "Geosol Geologia e Sondagens", "Cliente", "(31) 99874-3642" }
                });

            migrationBuilder.InsertData(
                schema: "api",
                table: "drivers",
                columns: new[] { "id", "name", "phone" },
                values: new object[,]
                {
                    { 1, "Amaro", "(31) 95648-7854" },
                    { 2, "Higor", "(31) 94756-5467" },
                    { 3, "Samuel", "(31) 98965-4756" }
                });

            migrationBuilder.InsertData(
                schema: "api",
                table: "routes",
                columns: new[] { "id", "driver_id", "finalization", "observation", "opening", "realization", "status" },
                values: new object[] { 2, null, null, null, new DateTime(2024, 11, 14, 16, 0, 0, 0, DateTimeKind.Unspecified), null, "Pendente" });

            migrationBuilder.InsertData(
                schema: "api",
                table: "addresses",
                columns: new[] { "id", "city", "company_id", "complement", "neighborhood", "number", "state", "street" },
                values: new object[,]
                {
                    { 1, "Pedro Leopoldo", 1, null, "Manoel Carlos", 560, "MG", "Av. Lincoln Diogo Viana" },
                    { 2, "Belo Horizonte", 2, null, "Olhos D'Água", 255, "MG", "R. São Vicente" },
                    { 3, "Lagoa Santa", 2, null, "Vila Asas", 333, "MG", "R. das Goiabeiras" }
                });

            migrationBuilder.InsertData(
                schema: "api",
                table: "routes",
                columns: new[] { "id", "driver_id", "finalization", "observation", "opening", "realization", "status" },
                values: new object[] { 1, 1, new DateTime(2024, 11, 13, 7, 30, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 11, 12, 14, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), "Finalizada" });

            migrationBuilder.InsertData(
                schema: "api",
                table: "services",
                columns: new[] { "id", "adress_id", "driver_observation", "observation", "priority", "responsible", "route_id", "service_type", "status", "status_item", "tracking", "tracking_type" },
                values: new object[,]
                {
                    { 1, 1, null, null, "Alta", null, 1, "Entrega", "Realizado", "Liberado", "2024/586", "NF" },
                    { 2, 2, null, "Material pesado", "Media", "Carlos", 1, "Coleta", "NaoRealizado", "Liberado", "547", "OS" },
                    { 3, 2, null, null, "Alta", null, 2, "Entrega", "EmAndamento", "Liberado", "2024/587", "NF" },
                    { 4, 3, null, null, "Baixa", null, null, "Coleta", "Pendente", "NaoLiberado", "548", "OS" }
                });

            migrationBuilder.CreateIndex(
                name: "i_x_addresses_company_id",
                schema: "api",
                table: "addresses",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "i_x_routes_driver_id",
                schema: "api",
                table: "routes",
                column: "driver_id");

            migrationBuilder.CreateIndex(
                name: "i_x_services_adress_id",
                schema: "api",
                table: "services",
                column: "adress_id");

            migrationBuilder.CreateIndex(
                name: "i_x_services_route_id",
                schema: "api",
                table: "services",
                column: "route_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "services",
                schema: "api");

            migrationBuilder.DropTable(
                name: "addresses",
                schema: "api");

            migrationBuilder.DropTable(
                name: "routes",
                schema: "api");

            migrationBuilder.DropTable(
                name: "companies",
                schema: "api");

            migrationBuilder.DropTable(
                name: "drivers",
                schema: "api");
        }
    }
}
