using AppVulnTracker.Server.Controllers;
using AppVulnTracker.Server.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace AppVulnTracker.Server.EndPoints
{
    [ApiController]
    [Route("api/historial")]
    public class HistorialVulnerabilidadEndPoint
    {
        private readonly HistorialVulnerabilidadController historialVulnerabilidadController;
        public HistorialVulnerabilidadEndPoint(HistorialVulnerabilidadController parametroHistorialVulnerabilidadController)
        {
            historialVulnerabilidadController = parametroHistorialVulnerabilidadController;
        }

        // Devulve el historial filtrando por id
        [HttpGet("{id_vulnerabilidad}")]
        public async Task<ActionResult<List<HistorialVulnerabilidadDTO>?>> GetHistorial(int id_vulnerabilidad)
        {
            return await historialVulnerabilidadController.ListarHistorialVulnerabilidad(id_vulnerabilidad);
        }
    }
}
