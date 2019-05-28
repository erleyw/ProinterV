using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProinterV.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Infra.Data.Mappings
{
    public class ArquivoTarefaMap : IEntityTypeConfiguration<ArquivoTarefa>
    {
        public void Configure (EntityTypeBuilder<ArquivoTarefa> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasOne(d => d.IdAlunoNavigation)
                .WithMany(p => p.ArquivoTarefa)
                .HasForeignKey(d => d.IdAluno)
                .HasConstraintName("FK__ArquivoTa__IdAlu__32E0915F");

            builder.HasOne(d => d.IdTarefaNavigation)
                .WithMany(p => p.ArquivoTarefa)
                .HasForeignKey(d => d.IdTarefa)
                .HasConstraintName("FK__ArquivoTa__IdTar__33D4B598");
        }
    }
}
