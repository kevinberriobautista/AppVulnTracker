using AppVulnTracker.Server.Controllers;
using AppVulnTracker.Server.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace AppVulnTracker.Server.EndPoints
{
    [ApiController]
    [Route("api/comentario")]
    public class ComentarioEndPoint
    {
        private readonly ComentarioController comentarioController;
        public ComentarioEndPoint(ComentarioController parametroComentarioController)
        {
            comentarioController = parametroComentarioController;
        }

        //Listar todos los comentarios
        [HttpGet("lista")]
        public async Task<ActionResult<List<ComentarioDTO>?>> GetComentarios()
        {
            return await comentarioController.ListarComentarios();
        }

    }
}
