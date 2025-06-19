using AppVulnTracker.Server.Controllers;
using AppVulnTracker.Server.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace AppVulnTracker.Server.EndPoints
{
    [ApiController]
    [Route("api/archivoadjunto")]
    public class ArchivoAdjuntoEndPoint
    {
        private readonly ArchivoAdjuntoController archivoAdjuntoController;
        public ArchivoAdjuntoEndPoint(ArchivoAdjuntoController parametroArchivoController)
        {
            archivoAdjuntoController = parametroArchivoController;
        }

        //Listar todos los archivos adjuntos
        [HttpGet("lista")]
        public async Task<ActionResult<List<ArchivoAdjuntoDTO>?>> GetArchivosAdjuntos()
        {
            return await archivoAdjuntoController.ListarArchivos();
        }
    }
}
