using AppVulnTracker.Server.Modelos;
using AppVulnTracker.Server.Sql;
using AppVulnTracker.Server.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Dapper; //Necesario para el uso de las funciones de conexion. en los metodos

namespace AppVulnTracker.Server.Controllers
{
    public class UsuarioController : ControllerBase
    {
        UsuarioSQL usuarioSQL;

        private readonly AplicationDbContext context;

        // Creación de la conexión a la base de datos
        public UsuarioController(AplicationDbContext context)
        {
            this.context = context;
            usuarioSQL = new UsuarioSQL();
        }

        // Método para obtener todos los usuarios
        public async Task<ActionResult<List<UsuarioDTO>?>> ListarUsuarios()
        {
            try
            {
                using (var conexion = context._connection)
                {
                    conexion.Open();
                    List<UsuarioDTO>? listausuarios = await conexion.QueryAsync<UsuarioDTO>(usuarioSQL.VerUsuario()) as List<UsuarioDTO>;

                    return Ok(listausuarios);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
