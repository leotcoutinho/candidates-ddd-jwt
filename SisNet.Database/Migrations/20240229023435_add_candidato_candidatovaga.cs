using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisNet.Database.Migrations
{
    /// <inheritdoc />
    public partial class add_candidato_candidatovaga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidato",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidatoVaga",
                columns: table => new
                {
                    VagaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidatoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatoVaga", x => new { x.CandidatoId, x.VagaId });
                    table.ForeignKey(
                        name: "FK_CandidatoVaga_Candidato_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatoVaga_Vaga_VagaId",
                        column: x => x.VagaId,
                        principalTable: "Vaga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidato_Cpf",
                table: "Candidato",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidatoVaga_CandidatoId",
                table: "CandidatoVaga",
                column: "CandidatoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidatoVaga_VagaId",
                table: "CandidatoVaga",
                column: "VagaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatoVaga");

            migrationBuilder.DropTable(
                name: "Candidato");
        }
    }
}
