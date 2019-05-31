using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProinterV.Infra.Data.Migrations
{
    public partial class AddCampoMatricula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ativo = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IdUsuario = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Nome = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Matricula = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoTrabalho",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdAluno = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Prazo = table.Column<DateTime>(type: "datetime", nullable: false),
                    MaterialApoio = table.Column<string>(nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoTrabalho", x => x.Id);
                    table.ForeignKey(
                        name: "FK__GrupoTrab__IdAlu__2C3393D0",
                        column: x => x.IdAluno,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tarefa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdGrupo = table.Column<Guid>(nullable: false),
                    IdAluno = table.Column<Guid>(nullable: true),
                    Nome = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Tarefa__IdAluno__300424B4",
                        column: x => x.IdAluno,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Tarefa__IdGrupo__2F10007B",
                        column: x => x.IdGrupo,
                        principalTable: "GrupoTrabalho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArquivoTarefa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: true),
                    IdAluno = table.Column<Guid>(nullable: true),
                    IdTarefa = table.Column<Guid>(nullable: true),
                    Nome = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Publico = table.Column<bool>(nullable: true),
                    Arquivo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArquivoTarefa", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ArquivoTa__IdAlu__32E0915F",
                        column: x => x.IdAluno,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ArquivoTa__IdTar__33D4B598",
                        column: x => x.IdTarefa,
                        principalTable: "Tarefa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArquivoTarefa_IdAluno",
                table: "ArquivoTarefa",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_ArquivoTarefa_IdTarefa",
                table: "ArquivoTarefa",
                column: "IdTarefa");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoTrabalho_IdAluno",
                table: "GrupoTrabalho",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_IdAluno",
                table: "Tarefa",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_IdGrupo",
                table: "Tarefa",
                column: "IdGrupo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArquivoTarefa");

            migrationBuilder.DropTable(
                name: "Tarefa");

            migrationBuilder.DropTable(
                name: "GrupoTrabalho");

            migrationBuilder.DropTable(
                name: "Aluno");
        }
    }
}
