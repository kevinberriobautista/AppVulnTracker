using AppVulnTracker.Server.Modelos;
using AppVulnTracker.Server.Sql;
using AppVulnTracker.Server.Utilidades;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace AppVulnTracker.Server.Controllers
{
    public class VulnerabilidadController : ControllerBase
    {
        VulnerabilidadSQL vulnerabilidadSQL;

        private readonly AplicationDbContext context;
        public VulnerabilidadController(AplicationDbContext context)
        {
            this.context = context;
            vulnerabilidadSQL = new VulnerabilidadSQL();
        }

        //Metodo para listar vulnerabilidades
        public async Task<ActionResult<List<VulnerabilidadDTO>?>> ListarVulnerabilidades()
        {
            try
            {
                using (var conexion = context._connection)
                {
                    conexion.Open();
                    List<VulnerabilidadDTO>? listavulnerabilidades = await conexion.QueryAsync<VulnerabilidadDTO>(vulnerabilidadSQL.VerVulnerabilidad()) as List<VulnerabilidadDTO>;

                    return Ok(listavulnerabilidades);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
