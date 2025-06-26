using AppVulnTracker.Server.Modelos;
using AppVulnTracker.Server.Sql;
using AppVulnTracker.Server.Utilidades;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace AppVulnTracker.Server.Controllers
{
    public class HistorialVulnerabilidadController : ControllerBase
    {
        HistorialVulnerabilidadSQL historialVulnerabilidadSQL;

        private readonly AplicationDbContext context;
        public HistorialVulnerabilidadController(AplicationDbContext context)
        {
            this.context = context;
            historialVulnerabilidadSQL = new HistorialVulnerabilidadSQL();
        }

        //Metodo para listar vulnerabilidades
        public async Task<ActionResult<List<HistorialVulnerabilidadDTO>?>> ListarHistorialVulnerabilidad(int id_vulnerabilidad)
        {
            try
            {
                using (var conexion = context._connection)
                {
                    conexion.Open();
                    List<HistorialVulnerabilidadDTO>? historial = await conexion.QueryAsync<HistorialVulnerabilidadDTO>(historialVulnerabilidadSQL.BuscarHistorialPorId(id_vulnerabilidad)) as List<HistorialVulnerabilidadDTO>;

                    return Ok(historial);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
