using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProinterV.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Infra.Data.Mappings
{
    public class GrupoTrabalhoMap : IEntityTypeConfiguration<GrupoTrabalho>
    {
        public void Configure(EntityTypeBuilder<GrupoTrabalho> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.DataCadastro).HasColumnType("datetime");

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Prazo).HasColumnType("datetime");

            builder.HasOne(d => d.IdAlunoNavigation)
                .WithMany(p => p.GrupoTrabalho)
                .HasForeignKey(d => d.IdAluno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GrupoTrab__IdAlu__2C3393D0");
        }
    }
}
