using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            if (usuarioViewModel.Id != Guid.Empty)
                throw new Exception("Usuario Id não é valido");

            Validator.ValidateObject(usuarioViewModel, new ValidationContext(usuarioViewModel), true);

            Usuario usuario = _mapper.Map<Usuario>(usuarioViewModel);

            this._usuarioRepositorio.Create(usuario);

            return true;
        }

        public UsuarioViewModel GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid usuarioId))
                throw new Exception("Usuario Id não é válido");

            Usuario usuario = this._usuarioRepositorio.Find(x => x.Id == usuarioId && !x.IsDeleted);

            if (usuario == null)
                throw new Exception("Usuario não encontrado");

            return _mapper.Map<UsuarioViewModel>(usuario);
        }

        public bool Put(UsuarioViewModel usuarioViewModel)
        {
            if (usuarioViewModel.Id == Guid.Empty)
                throw new Exception("Usuario Id não é válido");

            Usuario usuario = this._usuarioRepositorio.Find(x => x.Id == usuarioViewModel.Id && !x.IsDeleted);

            if (usuario == null)
                throw new Exception("Usuario não encontrado");

            usuario = _mapper.Map<Usuario>(usuarioViewModel);

            this._usuarioRepositorio.Update(usuario);

            return true;
        }

        public bool Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid usuarioId))
                throw new Exception("Usuario Id não é válido");

            Usuario usuario = this._usuarioRepositorio.Find(x => x.Id == usuarioId && !x.IsDeleted);

            if (usuario == null)
                throw new Exception("Usuario não encontrado");

            return this._usuarioRepositorio.Delete(usuario);
        }

    }
}
