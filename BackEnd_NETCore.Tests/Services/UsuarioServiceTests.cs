using AutoMapper;
using BackEnd_NETCore.Application.AutoMapper;
using BackEnd_NETCore.Application.Interfaces;
using BackEnd_NETCore.Application.Services;
using BackEnd_NETCore.Application.ViewModels;
using BackEnd_NETCore.Data.Repositories;
using BackEnd_NETCore.Domain.Entities;
using BackEnd_NETCore.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BackEnd_NETCore.Tests.Services
{
    public class UsuarioServiceTests
    {
        private UsuarioService _usuarioService;

        public UsuarioServiceTests()
        {
            _usuarioService = new UsuarioService(new Mock<IUsuarioRepositorio>().Object, new Mock<IMapper>().Object);
        }

        #region Mock Personalizado
        private UsuarioService MockParaTrazerValoresDeBanco(string request)
        {
            List<Usuario> usuarios = new List<Usuario>();

            usuarios.Add(new Usuario
            {
                Id = Guid.Parse("56f06ba6-54f6-48a0-bdfc-a5dfbac5e1d2"),
                Nome = "Victor Hugo",
                Email = "victor.hugo@gmail.com"
            });

            //Criado Mock para IUsuarioRepositorio (neste contexto) 

            if((request.Equals("Get")))
            {
                var usuarioRepositorio = new Mock<IUsuarioRepositorio>();
                usuarioRepositorio.Setup(x => x.ListarTodos()).Returns(usuarios);

                //Criado Mock para IMapper (neste contexto)
                var autoMapperProfile = new AutoMapperSetup();
                var configuration = new MapperConfiguration(x => x.AddProfile(autoMapperProfile));
                IMapper mapper = new Mapper(configuration);

                return _usuarioService = new UsuarioService(usuarioRepositorio.Object, mapper);
            }
            else 
            {

                Guid idVictorHugo = Guid.Parse("56f06ba6-54f6-48a0-bdfc-a5dfbac5e1d2");

                var usuarioRepositorio = new Mock<IUsuarioRepositorio>();
                usuarioRepositorio.Setup(x => x.Find( x => x.Id == idVictorHugo && !x.IsDeleted)).Returns(usuarios.SingleOrDefault());

                //Criado Mock para IMapper (neste contexto)
                var autoMapperProfile = new AutoMapperSetup();
                var configuration = new MapperConfiguration(x => x.AddProfile(autoMapperProfile));
                IMapper mapper = new Mapper(configuration);

                return _usuarioService = new UsuarioService(usuarioRepositorio.Object, mapper);
            }
        }
        #endregion

        #region ValidacaoDeObjetoValido


        [Fact]
        public void Post_EnviandoObjetoValido()
        {
            var result = _usuarioService.Post(new UsuarioViewModel() { Nome = "Bruno Tomm", Email = "bruno.tomm@gmail.com" });

            Assert.True(result);
        }

        [Fact]
        public void Put_EnviandoObjetoValido()
        {
            _usuarioService = MockParaTrazerValoresDeBanco("Put");

            var usuarioUpdate = new UsuarioViewModel { Nome = "Bruno Alexandre Tomm", Email = "bruno.alexandre.tomm@gmail.com", Id = Guid.Parse("56f06ba6-54f6-48a0-bdfc-a5dfbac5e1d2") };

            var result = _usuarioService.Put(usuarioUpdate);

            Assert.True(result);
        }

        [Fact]
        public void Delete_EnviandoObjetoValido()
        {
            _usuarioService = MockParaTrazerValoresDeBanco("Delete");

            var result = _usuarioService.Delete("56f06ba6-54f6-48a0-bdfc-a5dfbac5e1d2");

            Assert.True(result);
        }

        [Fact]
        public void Get_ValidacaoDeObjeto()
        {
            _usuarioService = MockParaTrazerValoresDeBanco("Get"); //Mock para trazer valores ficticios do banco

            var result = _usuarioService.Get();

            Assert.True(result.Count > 0);

        }

        [Fact]
        public void GetById_ValidacaoDeId()
        {
            _usuarioService = MockParaTrazerValoresDeBanco("GetById"); 

            var result = _usuarioService.GetById("56f06ba6-54f6-48a0-bdfc-a5dfbac5e1d2"); //Id UsuarioEspecifico

            Assert.True(result.Id != Guid.Empty);

        }

        #endregion

        #region ValidacaoDeEntrada
        [Fact]
        public void Post_EnviaIdValido()
        {
            var exception = Assert.Throws<Exception>(() =>
                                    _usuarioService.Post(new UsuarioViewModel() { Id = Guid.NewGuid() }));

            Assert.Equal("Usuario Id não é valido", exception.Message);
        }

        [Fact]
        public void GetById_EnviaIdVazio()
        {
            var exception = Assert.Throws<Exception>(() =>
                                    _usuarioService.GetById(""));

            Assert.Equal("Usuario Id não é válido", exception.Message);
        }

        [Fact]
        public void Put_EnviaObjetoVazio()
        {
            var exception = Assert.Throws<Exception>(() =>
                                    _usuarioService.Put(new UsuarioViewModel()));

            Assert.Equal("Usuario Id não é válido", exception.Message);
        }

        [Fact]
        public void Delete_EnviaIdVazio()
        {
            var exception = Assert.Throws<Exception>(() =>
                                    _usuarioService.Delete(""));

            Assert.Equal("Usuario Id não é válido", exception.Message);
        }
        #endregion

        #region ValidacaoDeObjetoInvalido

        [Fact]
        public void Post_EnviandoObjetoInvalido()
        {
            var exception = Assert.Throws<ValidationException>(() => _usuarioService.Post(new UsuarioViewModel() { Nome = "Bruno Tomm" }));

            Assert.Equal("The Email field is required.", exception.Message);
        }

        #endregion 

    }

}
