using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProinterV.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Infra.Data.Mappings
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.DataCadastro).HasColumnType("datetime");

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasOne(d => d.IdAlunoNavigation)
                .WithMany(p => p.Tarefa)
                .HasForeignKey(d => d.IdAluno)
                .HasConstraintName("FK__Tarefa__IdAluno__300424B4");

            builder.HasOne(d => d.IdGrupoNavigation)
                .WithMany(p => p.Tarefa)
                .HasForeignKey(d => d.IdGrupo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tarefa__IdGrupo__2F10007B");
        }
    }
}
