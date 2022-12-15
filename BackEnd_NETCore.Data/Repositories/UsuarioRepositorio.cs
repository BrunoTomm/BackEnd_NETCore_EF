using BackEnd_NETCore.Data.Context;
using BackEnd_NETCore.Domain.Entities;
using BackEnd_NETCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd_NETCore.Data.Repositories
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(TemplateContext context) : base(context) { }

        public IEnumerable<Usuario> ListarTodos()
        {
            return Query( x => !x.IsDeleted ).ToList();
        }
    }
}
