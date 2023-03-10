using BackEnd_NETCore.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd_NETCore.Application.Interfaces
{
    public interface IUsuarioService
    {
        List<UsuarioViewModel> Get();
        bool Post(UsuarioViewModel usuarioViewModel);
        UsuarioViewModel GetById(string id);
        bool Put(UsuarioViewModel usuarioViewModel);
        bool Delete(string id);
    }
}
