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

        //Listar todos los usuarios
        [HttpGet("lista")]
        public async Task<ActionResult<List<UsuarioDTO>?>> GetUsuarios()
        {
            return await usuarioController.ListarUsuarios();
        }
    }
}
