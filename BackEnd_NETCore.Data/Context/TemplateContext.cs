using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BackEnd_NETCore.Data.Extensions;
using BackEnd_NETCore.Domain.Entities;
using Template.Data.Mappings;

namespace BackEnd_NETCore.Data.Context
{
    /*
     Pacotes necessarios:
        - Entity Core
        - Entity Core Sql Server
        - Entity Core Sql Server Desing
     */
    public class TemplateContext : DbContext //Precisa herdar de DbContext
    {
        public TemplateContext(DbContextOptions<TemplateContext> options) : base(options) //Construtor padrao
        { }

        #region "DBSets"

        public DbSet<Usuario> Usuarios { get; set; }


        #endregion

        //Sobscrever o metodo OnModelCreating, para que utilize as configurações da classe UsuarioMap()
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            modelBuilder.SeeData();

            base.OnModelCreating(modelBuilder);
        }
    }
}
