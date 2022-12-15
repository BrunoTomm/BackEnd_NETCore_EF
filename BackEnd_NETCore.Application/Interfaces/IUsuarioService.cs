using BackEnd_NETCore.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd_NETCore.Application.Interfaces
{
    public interface IUsuarioService
    {
        List<UsuarioViewModel> Get();
    }
}
