using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProinterV.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProinterV.Infra.Data.Mappings
{
    public class AlunoGrupoMap : IEntityTypeConfiguration<AlunoGrupo>
    {
        public void Configure(EntityTypeBuilder<AlunoGrupo> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.DataCadastro).HasColumnType("datetime");

            builder.HasOne(d => d.IdAlunoNavigation)
                .WithMany(p => p.AlunoGrupo)
                .HasForeignKey(d => d.IdAluno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AlunoGrupo__IdAluno");

            builder.HasOne(d => d.IdGrupoNavigation)
                .WithMany(p => p.AlunoGrupo)
                .HasForeignKey(d => d.IdGrupo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AlunoGrupo__IdGrupo");
        }
    }
}
