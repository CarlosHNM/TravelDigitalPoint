using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelDigiatlPoint.Migrations
{
    public partial class UpdateVeiculosCampoNovo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodVeiculo",
                table: "Veiculos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodVeiculo",
                table: "Veiculos");
        }
    }
}
