using BackEnd_NETCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd_NETCore.Domain.Entities
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
