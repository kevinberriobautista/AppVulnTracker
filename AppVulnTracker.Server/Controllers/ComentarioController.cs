using AppVulnTracker.Server.Modelos;
using AppVulnTracker.Server.Sql;
using AppVulnTracker.Server.Utilidades;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace AppVulnTracker.Server.Controllers
{
    public class ComentarioController : ControllerBase
    {
        ComentarioSQL comentarioSQL;

        private readonly AplicationDbContext context;
        public ComentarioController(AplicationDbContext context)
        {
            this.context = context;
            comentarioSQL = new ComentarioSQL();
        }

        //Metodo para listar comentarios
        public async Task<ActionResult<List<ComentarioDTO>?>> ListarComentarios()
        {
            try
            {
                using (var conexion = context._connection)
                {
                    conexion.Open();
                    List<ComentarioDTO>? listacomentarios = await conexion.QueryAsync<ComentarioDTO>(comentarioSQL.VerComentario()) as List<ComentarioDTO>;

                    return Ok(listacomentarios);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
