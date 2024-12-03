using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solare.Data.Migrations
{
    /// <inheritdoc />
    public partial class solare_V4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnderecosSimulacao_Simulacao_SimulacaoId",
                table: "EnderecosSimulacao");

            migrationBuilder.DropIndex(
                name: "IX_EnderecosSimulacao_SimulacaoId",
                table: "EnderecosSimulacao");

            migrationBuilder.RenameColumn(
                name: "SimulacaoId",
                table: "EnderecosSimulacao",
                newName: "ClienteId");

            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId",
                table: "Simulacao",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Documento = table.Column<string>(type: "varchar(100)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Simulacao_ClienteId",
                table: "Simulacao",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecosSimulacao_ClienteId",
                table: "EnderecosSimulacao",
                column: "ClienteId",
                unique: true,
                filter: "[ClienteId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecosSimulacao_Cliente_ClienteId",
                table: "EnderecosSimulacao",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Simulacao_Cliente_ClienteId",
                table: "Simulacao",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnderecosSimulacao_Cliente_ClienteId",
                table: "EnderecosSimulacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Simulacao_Cliente_ClienteId",
                table: "Simulacao");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Simulacao_ClienteId",
                table: "Simulacao");

            migrationBuilder.DropIndex(
                name: "IX_EnderecosSimulacao_ClienteId",
                table: "EnderecosSimulacao");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Simulacao");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "EnderecosSimulacao",
                newName: "SimulacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecosSimulacao_SimulacaoId",
                table: "EnderecosSimulacao",
                column: "SimulacaoId",
                unique: true,
                filter: "[SimulacaoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecosSimulacao_Simulacao_SimulacaoId",
                table: "EnderecosSimulacao",
                column: "SimulacaoId",
                principalTable: "Simulacao",
                principalColumn: "Id");
        }
    }
}
