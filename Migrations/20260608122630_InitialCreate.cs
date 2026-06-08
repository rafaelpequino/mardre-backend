using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mardre.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CodCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CodCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Materia_Prima",
                columns: table => new
                {
                    CodMateria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CodigoBarras = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CodCategoria = table.Column<int>(type: "int", nullable: true),
                    EstoqueMin = table.Column<int>(type: "int", nullable: true),
                    EstoqueMax = table.Column<int>(type: "int", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Descarte = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FatorCo2 = table.Column<decimal>(type: "decimal(10,6)", nullable: true),
                    EmissaoCo2 = table.Column<decimal>(type: "decimal(12,6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia_Prima", x => x.CodMateria);
                    table.ForeignKey(
                        name: "FK_Materia_Prima_Categorias_CodCategoria",
                        column: x => x.CodCategoria,
                        principalTable: "Categorias",
                        principalColumn: "CodCategoria");
                });

            migrationBuilder.CreateTable(
                name: "Processamento",
                columns: table => new
                {
                    CodProcessamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataEntrada = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataSaida = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CodMateria = table.Column<int>(type: "int", nullable: true),
                    Peso = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    TempoLeitura = table.Column<int>(type: "int", nullable: true),
                    TempoPesagem = table.Column<int>(type: "int", nullable: true),
                    TempoClassificacao = table.Column<int>(type: "int", nullable: true),
                    TempoRedirecionamento = table.Column<int>(type: "int", nullable: true),
                    TempoTotalProcessamento = table.Column<int>(type: "int", nullable: true),
                    RegistroFotografico = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processamento", x => x.CodProcessamento);
                    table.ForeignKey(
                        name: "FK_Processamento_Materia_Prima_CodMateria",
                        column: x => x.CodMateria,
                        principalTable: "Materia_Prima",
                        principalColumn: "CodMateria");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materia_Prima_CodCategoria",
                table: "Materia_Prima",
                column: "CodCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Processamento_CodMateria",
                table: "Processamento",
                column: "CodMateria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Processamento");

            migrationBuilder.DropTable(
                name: "Materia_Prima");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
