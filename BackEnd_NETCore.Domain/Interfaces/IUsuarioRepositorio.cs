using BackEnd_NETCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd_NETCore.Domain.Interfaces
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        IEnumerable<Usuario> ListarTodos();

    }
}
