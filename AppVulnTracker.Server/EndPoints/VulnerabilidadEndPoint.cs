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

        // Devulve severidad y estado
        [HttpGet("estado-severidad/{id}")]
        public async Task<ActionResult<SeveridadyEstadoVulnerabilidadDTO>?> GetEstadoYSeveridad(int id)
        {
            return await vulnerabilidadController.MostrarEstadoySeveridad(id);
        }

        // Crear vulnerabilidad
        [HttpPost("crearVulnerabilidad")]
        public async Task<ActionResult<VulnerabilidadDTO>> PostVulnerabilidad(VulnerabilidadDTO vulnerabilidad)
        {
            return await vulnerabilidadController.CrearVulnerabilidad(vulnerabilidad);
        }

        // Modificar vulnerabilidad
        [HttpPut("modificarVulnerabilidad")]
        public async Task<ActionResult<VulnerabilidadDTO>> UpdateVulnerabilidad(VulnerabilidadDTO vulnerabilidad)
        {
            return await vulnerabilidadController.ModificarVulnerabilidad(vulnerabilidad);
        }

    }
}
