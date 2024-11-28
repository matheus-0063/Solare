using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solare.Data.Migrations
{
    /// <inheritdoc />
    public partial class solare_V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Enderecos_FornecedorId",
                table: "Enderecos");

            migrationBuilder.AlterColumn<Guid>(
                name: "FornecedorId",
                table: "Enderecos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "Simulacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    TipoImovel = table.Column<int>(type: "int", nullable: false),
                    OrcamentoMaximo = table.Column<decimal>(type: "decimal(17,2)", nullable: false),
                    ConsumoMedioMensal = table.Column<decimal>(type: "decimal(17,2)", nullable: false),
                    ValorMedioContaEnergia = table.Column<decimal>(type: "decimal(17,2)", nullable: false),
                    AnosPermanencia = table.Column<int>(type: "integer", nullable: false),
                    EspacoTotalInstalacao = table.Column<decimal>(type: "decimal(17,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simulacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnderecosSimulacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SimulacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Logradouro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(100)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(100)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecosSimulacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnderecosSimulacao_Simulacao_SimulacaoId",
                        column: x => x.SimulacaoId,
                        principalTable: "Simulacao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_FornecedorId",
                table: "Enderecos",
                column: "FornecedorId",
                unique: true,
                filter: "[FornecedorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecosSimulacao_SimulacaoId",
                table: "EnderecosSimulacao",
                column: "SimulacaoId",
                unique: true,
                filter: "[SimulacaoId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnderecosSimulacao");

            migrationBuilder.DropTable(
                name: "Simulacao");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_FornecedorId",
                table: "Enderecos");

            migrationBuilder.AlterColumn<Guid>(
                name: "FornecedorId",
                table: "Enderecos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_FornecedorId",
                table: "Enderecos",
                column: "FornecedorId",
                unique: true);
        }
    }
}
