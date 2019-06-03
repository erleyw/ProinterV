using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProinterV.Infra.Data.Migrations
{
    public partial class AddTabelaAlunoGrupo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Tarefa",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<Guid>(
                name: "IdAluno",
                table: "GrupoTrabalho",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "GrupoTrabalho",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.CreateTable(
                name: "AlunoGrupo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ativo = table.Column<bool>(nullable: true),
                    IdGrupo = table.Column<Guid>(nullable: false),
                    IdAluno = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoGrupo", x => x.Id);
                    table.ForeignKey(
                        name: "FK__AlunoGrupo__IdAluno",
                        column: x => x.IdAluno,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__AlunoGrupo__IdGrupo",
                        column: x => x.IdGrupo,
                        principalTable: "GrupoTrabalho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoGrupo_IdAluno",
                table: "AlunoGrupo",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoGrupo_IdGrupo",
                table: "AlunoGrupo",
                column: "IdGrupo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoGrupo");

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Tarefa",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdAluno",
                table: "GrupoTrabalho",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "GrupoTrabalho",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
