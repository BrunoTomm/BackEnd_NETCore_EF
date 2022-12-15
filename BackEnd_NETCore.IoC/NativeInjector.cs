using Microsoft.Extensions.DependencyInjection;
using System;
using BackEnd_NETCore.Application.Interfaces;
using BackEnd_NETCore.Application.Services;
using BackEnd_NETCore.Data.Repositories;
using BackEnd_NETCore.Domain.Interfaces;

namespace Template.IoC
{
    public static class NativeInjector
    {
        //Injecao de dependencia
        public static void RegistrarServicos(IServiceCollection services)
        {
            #region Services

            services.AddScoped<IUsuarioService, UsuarioService>();

            #endregion

            #region Repositorios

            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            #endregion
        }
    }
}
