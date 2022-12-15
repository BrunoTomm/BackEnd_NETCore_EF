using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BackEnd_NETCore.Application.Interfaces;
using BackEnd_NETCore.Application.ViewModels;
using BackEnd_NETCore.Domain.Entities;
using BackEnd_NETCore.Domain.Interfaces;

namespace BackEnd_NETCore.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IMapper _mapper;
        public UsuarioService(IUsuarioRepositorio usuarioRepositorio, IMapper mapper)
        {
            this._usuarioRepositorio = usuarioRepositorio;
            this._mapper = mapper;
        }

        public List<UsuarioViewModel> Get()
        {
            List<UsuarioViewModel> usuarioViewModels = new List<UsuarioViewModel>();

            IEnumerable<Usuario> usuarios = this._usuarioRepositorio.ListarTodos();

            usuarioViewModels = _mapper.Map<List<UsuarioViewModel>>(usuarios); //AutoMapper de uma lista

            return usuarioViewModels;
        }

        public bool Post(UsuarioViewModel usuarioViewModel)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioViewModel);

            this._usuarioRepositorio.Create(usuario);

            return true;
        }

    }
}
