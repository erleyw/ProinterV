﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProinterV.Infra.Data.Context;

namespace ProinterV.Infra.Data.Migrations
{
    [DbContext(typeof(DbProinterContext))]
    [Migration("20190602182904_AddTabelaAlunoGrupo")]
    partial class AddTabelaAlunoGrupo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProinterV.Domain.Models.Aluno", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<bool?>("Ativo")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((1))");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime");

                    b.Property<string>("IdUsuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Matricula");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("ProinterV.Domain.Models.AlunoGrupo", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<bool?>("Ativo");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime");

                    b.Property<Guid>("IdAluno");

                    b.Property<Guid>("IdGrupo");

                    b.HasKey("Id");

                    b.HasIndex("IdAluno");

                    b.HasIndex("IdGrupo");

                    b.ToTable("AlunoGrupo");
                });

            modelBuilder.Entity("ProinterV.Domain.Models.ArquivoTarefa", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Arquivo");

                    b.Property<bool?>("Ativo");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<Guid?>("IdAluno");

                    b.Property<Guid?>("IdTarefa");

                    b.Property<string>("Nome")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<bool?>("Publico");

                    b.HasKey("Id");

                    b.HasIndex("IdAluno");

                    b.HasIndex("IdTarefa");

                    b.ToTable("ArquivoTarefa");
                });

            modelBuilder.Entity("ProinterV.Domain.Models.GrupoTrabalho", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<bool?>("Ativo");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime");

                    b.Property<string>("Descricao");

                    b.Property<Guid?>("IdAluno");

                    b.Property<string>("MaterialApoio");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime>("Prazo")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("IdAluno");

                    b.ToTable("GrupoTrabalho");
                });

            modelBuilder.Entity("ProinterV.Domain.Models.Tarefa", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<bool?>("Ativo");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime");

                    b.Property<string>("Descricao");

                    b.Property<Guid?>("IdAluno");

                    b.Property<Guid>("IdGrupo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("IdAluno");

                    b.HasIndex("IdGrupo");

                    b.ToTable("Tarefa");
                });

            modelBuilder.Entity("ProinterV.Domain.Models.AlunoGrupo", b =>
                {
                    b.HasOne("ProinterV.Domain.Models.Aluno", "IdAlunoNavigation")
                        .WithMany("AlunoGrupo")
                        .HasForeignKey("IdAluno")
                        .HasConstraintName("FK__AlunoGrupo__IdAluno");

                    b.HasOne("ProinterV.Domain.Models.GrupoTrabalho", "IdGrupoNavigation")
                        .WithMany("AlunoGrupo")
                        .HasForeignKey("IdGrupo")
                        .HasConstraintName("FK__AlunoGrupo__IdGrupo");
                });

            modelBuilder.Entity("ProinterV.Domain.Models.ArquivoTarefa", b =>
                {
                    b.HasOne("ProinterV.Domain.Models.Aluno", "IdAlunoNavigation")
                        .WithMany("ArquivoTarefa")
                        .HasForeignKey("IdAluno")
                        .HasConstraintName("FK__ArquivoTa__IdAlu__32E0915F");

                    b.HasOne("ProinterV.Domain.Models.Tarefa", "IdTarefaNavigation")
                        .WithMany("ArquivoTarefa")
                        .HasForeignKey("IdTarefa")
                        .HasConstraintName("FK__ArquivoTa__IdTar__33D4B598");
                });

            modelBuilder.Entity("ProinterV.Domain.Models.GrupoTrabalho", b =>
                {
                    b.HasOne("ProinterV.Domain.Models.Aluno", "IdAlunoNavigation")
                        .WithMany("GrupoTrabalho")
                        .HasForeignKey("IdAluno")
                        .HasConstraintName("FK__GrupoTrab__IdAlu__2C3393D0");
                });

            modelBuilder.Entity("ProinterV.Domain.Models.Tarefa", b =>
                {
                    b.HasOne("ProinterV.Domain.Models.Aluno", "IdAlunoNavigation")
                        .WithMany("Tarefa")
                        .HasForeignKey("IdAluno")
                        .HasConstraintName("FK__Tarefa__IdAluno__300424B4");

                    b.HasOne("ProinterV.Domain.Models.GrupoTrabalho", "IdGrupoNavigation")
                        .WithMany("Tarefa")
                        .HasForeignKey("IdGrupo")
                        .HasConstraintName("FK__Tarefa__IdGrupo__2F10007B");
                });
#pragma warning restore 612, 618
        }
    }
}
