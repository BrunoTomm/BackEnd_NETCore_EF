using System;
using System.Collections.Generic;
using System.Text;
using BackEnd_NETCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BackEnd_NETCore.Domain.Entities;

namespace Template.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario> // Herda IEntityTypeConfiguration
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
        }
    }
}
