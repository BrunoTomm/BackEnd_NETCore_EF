using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackEnd_NETCore.Application.Interfaces;
using BackEnd_NETCore.Application.ViewModels;

namespace Template.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.usuarioService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(this.usuarioService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(this.usuarioService.Post(usuarioViewModel));
        }

        [HttpPut]
        public IActionResult Put(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(this.usuarioService.Put(usuarioViewModel));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(this.usuarioService.Delete(id));
        }

    }
}
