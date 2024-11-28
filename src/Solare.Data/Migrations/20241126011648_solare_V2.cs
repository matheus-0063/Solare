using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solare.Data.Migrations
{
    /// <inheritdoc />
    public partial class solare_V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Corrente",
                table: "Produtos",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DimensaoEmMtQuadrado",
                table: "Produtos",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Eficiencia",
                table: "Produtos",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Potencia",
                table: "Produtos",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Saida",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Tensao",
                table: "Produtos",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoProduto",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Corrente",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "DimensaoEmMtQuadrado",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Eficiencia",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Potencia",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Saida",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Tensao",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "TipoProduto",
                table: "Produtos");
        }
    }
}
