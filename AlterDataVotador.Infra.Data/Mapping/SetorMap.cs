using AlterDataVotador.Domain.ViewModel.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlterDataVotador.Infra.Data.Mapping
{
    public class SetorMap : IEntityTypeConfiguration<Setor>
    {
        public void Configure(EntityTypeBuilder<Setor> builder)
        {
            builder.ToTable("Tb_Setor");

            builder.HasKey(setor => setor.IdSetor);

            builder.Property(setor => setor.NomeGerente)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
