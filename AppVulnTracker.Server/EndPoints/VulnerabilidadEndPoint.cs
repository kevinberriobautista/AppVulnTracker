using AppVulnTracker.Server.Controllers;
using AppVulnTracker.Server.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace AppVulnTracker.Server.EndPoints
{
    [ApiController]
    [Route("api/vulnerabilidad")]
    public class VulnerabilidadEndPoint
    {
        private readonly VulnerabilidadController vulnerabilidadController;
        public VulnerabilidadEndPoint(VulnerabilidadController parametroVulnerabilidadController)
        {
            vulnerabilidadController = parametroVulnerabilidadController;
        }

        //Listar todas las vulnerabilidades
        [HttpGet("lista")]
        public async Task<ActionResult<List<VulnerabilidadDTO>?>> GetVulnerabilidades()
        {
            return await vulnerabilidadController.ListarVulnerabilidades();
        }

    }
}
