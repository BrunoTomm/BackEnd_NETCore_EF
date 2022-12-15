using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BackEnd_NETCore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using BackEnd_NETCore.Domain.Models;

namespace BackEnd_NETCore.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder ApllyGlobalConfigurations(this ModelBuilder builder)
        {
            foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
            {
                foreach (IMutableProperty property in entityType.GetProperties())
                {
                    switch (property.Name)
                    {
                        case nameof(Entity.Id):
                            property.IsKey();
                            break;
                        case nameof(Entity.DateUpdate):
                            property.IsNullable = true;
                            break;
                        case nameof(Entity.DateCreated):
                            property.IsNullable = false;
                            property.SetDefaultValue(DateTime.Now);
                            break;
                        case nameof(Entity.IsDeleted):
                            property.IsNullable = false;
                            property.SetDefaultValue(false);
                            break;

                        default:
                            break;
                    }
                }
            }

            return builder;
        }

        public static ModelBuilder SeeData(this ModelBuilder builder)
        {
            builder.Entity<Usuario>()
                .HasData(
                    new Usuario
                    {
                        Id = Guid.Parse("309b7c99-ff3d-4338-859f-d1a6b5857ce4"),
                        Nome = "Usuario Default",
                        Email = "usuarioDefault@template.com",
                        DateCreated = new DateTime(2020, 2, 2),
                        IsDeleted = false,
                        DateUpdate = null
                    }
                );

            return builder;
        }
    }
}
