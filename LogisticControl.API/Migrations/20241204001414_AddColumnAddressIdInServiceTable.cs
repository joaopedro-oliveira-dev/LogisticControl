using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticControl.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnAddressIdInServiceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "f_k_services_addresses_adress_id",
                schema: "api",
                table: "services");

            migrationBuilder.RenameColumn(
                name: "adress_id",
                schema: "api",
                table: "services",
                newName: "address_id");

            migrationBuilder.RenameIndex(
                name: "i_x_services_adress_id",
                schema: "api",
                table: "services",
                newName: "i_x_services_address_id");

            migrationBuilder.AddForeignKey(
                name: "f_k_services_addresses_address_id",
                schema: "api",
                table: "services",
                column: "address_id",
                principalSchema: "api",
                principalTable: "addresses",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "f_k_services_addresses_address_id",
                schema: "api",
                table: "services");

            migrationBuilder.RenameColumn(
                name: "address_id",
                schema: "api",
                table: "services",
                newName: "adress_id");

            migrationBuilder.RenameIndex(
                name: "i_x_services_address_id",
                schema: "api",
                table: "services",
                newName: "i_x_services_adress_id");

            migrationBuilder.AddForeignKey(
                name: "f_k_services_addresses_adress_id",
                schema: "api",
                table: "services",
                column: "adress_id",
                principalSchema: "api",
                principalTable: "addresses",
                principalColumn: "id");
        }
    }
}
