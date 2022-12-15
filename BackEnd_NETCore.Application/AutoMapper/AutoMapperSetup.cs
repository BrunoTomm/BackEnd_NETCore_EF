using AutoMapper;
using BackEnd_NETCore.Application.ViewModels;
using BackEnd_NETCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd_NETCore.Application.AutoMapper
{
    public class AutoMapperSetup : Profile //Herda de profile
    {
        public AutoMapperSetup()
        {
            #region ViewModelParaDomain

            CreateMap<UsuarioViewModel, Usuario>();

            #endregion

            #region DomainParaViewModel

            CreateMap<Usuario, UsuarioViewModel>();

            #endregion
        }
    }
}
