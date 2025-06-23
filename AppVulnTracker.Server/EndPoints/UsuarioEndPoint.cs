using AppVulnTracker.Server.Controllers;
using AppVulnTracker.Server.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace AppVulnTracker.Server.EndPoints
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioEndPoint
    {
        private readonly UsuarioController usuarioController;

        public UsuarioEndPoint(UsuarioController parametroUsuarioController)
        {
            usuarioController = parametroUsuarioController;
        }

        // Listar todos los usuarios
        [HttpGet("lista")]
        public async Task<ActionResult<List<UsuarioDTO>?>> GetUsuarios()
        {
            return await usuarioController.ListarUsuarios();
        }

        // Buscar usuario
        [HttpGet("{id_usuario}")]
        public async Task<ActionResult<UsuarioDTO>?> GetUsuarioPorId(int id_usuario)
        {
            return await usuarioController.BuscarUsuarioPorId(id_usuario);
        }

        // Login clientes
        [HttpPost("loginCliente")]
        public async Task<ActionResult<string>> PostLogin(LoginDTO login)
        {
            return await usuarioController.Login(login);
        }
    }
}
