using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BackEnd_NETCore.Domain.Entities;

namespace BackEnd_NETCore.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder SeeData(this ModelBuilder builder)
        {
            builder.Entity<Usuario>()
                .HasData(
                    new Usuario
                    {
                        Id = Guid.Parse("309b7c99-ff3d-4338-859f-d1a6b5857ce4"),
                        Nome = "Usuario Default",
                        Email = "usuarioDefault@template.com"
                    }
                );

            return builder;
        }
    }
}
