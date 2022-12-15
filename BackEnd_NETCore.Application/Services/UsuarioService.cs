using System;
using System.Collections.Generic;
using System.Text;
using BackEnd_NETCore.Application.Interfaces;
using BackEnd_NETCore.Application.ViewModels;
using BackEnd_NETCore.Domain.Entities;
using BackEnd_NETCore.Domain.Interfaces;

namespace BackEnd_NETCore.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepositorio usuarioRepositorio;
        public UsuarioService(IUsuarioRepositorio usuarioRepositorio)
        {
            this.usuarioRepositorio = usuarioRepositorio;
        }

        public List<UsuarioViewModel> Get()
        {
            List<UsuarioViewModel> usuarioViewModels = new List<UsuarioViewModel>();

            IEnumerable<Usuario> usuarios = this.usuarioRepositorio.ListarTodos();

            foreach (var usuario in usuarios)
            {
                usuarioViewModels.Add(new UsuarioViewModel()
                {
                    Id = usuario.Id,
                    Email = usuario.Email,
                    Nome = usuario.Nome
                });
            }

            return usuarioViewModels;
        }
    }
}
