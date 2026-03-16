using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dgii_api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contribuyentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RncCedula = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contribuyentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComprobantesFiscales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RncCedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NCF = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Itbis18 = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ContribuyenteId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprobantesFiscales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComprobantesFiscales_Contribuyentes_ContribuyenteId",
                        column: x => x.ContribuyenteId,
                        principalTable: "Contribuyentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComprobantesFiscales_ContribuyenteId",
                table: "ComprobantesFiscales",
                column: "ContribuyenteId");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobantesFiscales_NCF",
                table: "ComprobantesFiscales",
                column: "NCF",
                unique: true,
                filter: "[NCF] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contribuyentes_RncCedula",
                table: "Contribuyentes",
                column: "RncCedula",
                unique: true,
                filter: "[RncCedula] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComprobantesFiscales");

            migrationBuilder.DropTable(
                name: "Contribuyentes");
        }
    }
}
