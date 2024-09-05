using Microsoft.AspNetCore.Mvc;
using Sistemas.Models;
using Sistemas.Repository.Interface; 

namespace Sistemas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> GetAllUsers()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.GetAllUsers();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> GetUserById(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.GetById(id);
            if (usuario == null)
            {
                return NotFound($"Usuário com ID {id} não encontrado.");
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> CreateUser([FromBody] UsuarioModel usuario)
        {
            UsuarioModel usuarioCriado = await _usuarioRepositorio.AddUser(usuario);
            return CreatedAtAction(nameof(GetUserById), new { id = usuarioCriado.Id }, usuarioCriado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> UpdateUser([FromBody] UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioAtualizado = await _usuarioRepositorio.UpdateUser(usuario, id);
            if (usuarioAtualizado == null)
            {
                return NotFound($"Usuário com ID {id} não encontrado.");
            }
            return Ok(usuarioAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            bool usuarioDeletado = await _usuarioRepositorio.DeleteUser(id);
            if (!usuarioDeletado)
            {
                return NotFound($"Usuário com ID {id} não encontrado.");
            }
            return NoContent();  
        }
    }
}
