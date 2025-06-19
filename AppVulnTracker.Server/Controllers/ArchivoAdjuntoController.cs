using AppVulnTracker.Server.Modelos;
using AppVulnTracker.Server.Sql;
using AppVulnTracker.Server.Utilidades;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace AppVulnTracker.Server.Controllers
{
    public class ArchivoAdjuntoController : ControllerBase
    {
        ArchivoAdjuntoSQL archivoAdjuntoSQL;

        public readonly AplicationDbContext context;

        public ArchivoAdjuntoController(AplicationDbContext context)
        {
            this.context = context;
            archivoAdjuntoSQL = new ArchivoAdjuntoSQL();
        }

        //Metodo para listar clientes
        public async Task<ActionResult<List<ArchivoAdjuntoDTO>?>> ListarArchivos()
        {
            try
            {
                using (var conexion = context._connection)
                {
                    conexion.Open();
                    List<ArchivoAdjuntoDTO>? listaarchivos = await conexion.QueryAsync<ArchivoAdjuntoDTO>(archivoAdjuntoSQL.VerArchivo()) as List<ArchivoAdjuntoDTO>;

                    return Ok(listaarchivos);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
