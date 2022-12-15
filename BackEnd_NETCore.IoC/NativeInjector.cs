using Microsoft.Extensions.DependencyInjection;
using System;
using BackEnd_NETCore.Application.Interfaces;
using BackEnd_NETCore.Application.Services;

namespace Template.IoC
{
    public static class NativeInjector
    {
        //Injecao de dependencia
        public static void RegistrarServicos(IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}
