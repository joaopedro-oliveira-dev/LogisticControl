using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LogisticControl.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddLinesInTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "f_k_services_routes_route_id",
                table: "services");

            migrationBuilder.DropIndex(
                name: "i_x_services_route_id",
                table: "services");

            migrationBuilder.DropColumn(
                name: "route_id",
                table: "services");

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "id", "name", "partnership_type", "phone" },
                values: new object[,]
                {
                    { 1, "Mecbrun Industrial", "Cliente", "(31) 96523-4789" },
                    { 2, "Geosol Geologia e Sondagens", "Cliente", "(31) 99874-3642" }
                });

            migrationBuilder.InsertData(
                table: "drivers",
                columns: new[] { "id", "name", "phone" },
                values: new object[,]
                {
                    { 1, "Amaro", "(31) 95648-7854" },
                    { 2, "Higor", "(31) 94756-5467" },
                    { 3, "Samuel", "(31) 98965-4756" }
                });

            migrationBuilder.InsertData(
                table: "routes",
                columns: new[] { "id", "driver_id", "driver__id", "finalization", "observation", "opening", "realization", "status" },
                values: new object[] { 2, null, null, null, null, new DateTime(2024, 11, 14, 16, 0, 0, 0, DateTimeKind.Unspecified), null, "Pendente" });

            migrationBuilder.InsertData(
                table: "addresses",
                columns: new[] { "id", "city", "company_id", "company__id", "complement", "neighborhood", "number", "state", "street" },
                values: new object[,]
                {
                    { 1, "Pedro Leopoldo", null, 1, null, "Manoel Carlos", 560, "MG", "Av. Lincoln Diogo Viana" },
                    { 2, "Belo Horizonte", null, 2, null, "Olhos D'Água", 255, "MG", "R. São Vicente" },
                    { 3, "Lagoa Santa", null, 2, null, "Vila Asas", 333, "MG", "R. das Goiabeiras" }
                });

            migrationBuilder.InsertData(
                table: "routes",
                columns: new[] { "id", "driver_id", "driver__id", "finalization", "observation", "opening", "realization", "status" },
                values: new object[] { 1, null, 1, new DateTime(2024, 11, 13, 7, 30, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 11, 12, 14, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), "Finalizada" });

            migrationBuilder.InsertData(
                table: "services",
                columns: new[] { "id", "adress__id", "driver_observation", "observation", "priority", "responsible", "route__id", "service_type", "status", "status_item", "tracking", "tracking_type" },
                values: new object[,]
                {
                    { 1, 1, null, null, "Alta", null, 1, "Entrega", "Realizado", "Liberado", "2024/586", "NF" },
                    { 2, 2, null, "Material pesado", "Media", "Carlos", 1, "Coleta", "NaoRealizado", "Liberado", "547", "OS" },
                    { 3, 2, null, null, "Alta", null, 2, "Entrega", "EmAndamento", "Liberado", "2024/587", "NF" },
                    { 4, 3, null, null, "Baixa", null, null, "Coleta", "Pendente", "NaoLiberado", "548", "OS" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "drivers",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "drivers",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "services",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "services",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "services",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "services",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "addresses",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "addresses",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "addresses",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "routes",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "routes",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "drivers",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "route_id",
                table: "services",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "i_x_services_route_id",
                table: "services",
                column: "route_id");

            migrationBuilder.AddForeignKey(
                name: "f_k_services_routes_route_id",
                table: "services",
                column: "route_id",
                principalTable: "routes",
                principalColumn: "id");
        }
    }
}
