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

        //Metodo para devolver estado y severidad de vulnerabilidades
        public async Task<ActionResult<SeveridadyEstadoVulnerabilidadDTO>?> MostrarEstadoySeveridad(int id_vulnerabilidad)
        {
            try
            {
                using (var conexion = context._connection)
                {
                    conexion.Open();
                    SeveridadyEstadoVulnerabilidadDTO? resultado = await conexion.QuerySingleOrDefaultAsync<SeveridadyEstadoVulnerabilidadDTO>(vulnerabilidadSQL.MostrarEstadoYSeveridad(id_vulnerabilidad)) as SeveridadyEstadoVulnerabilidadDTO;

                    return Ok(resultado);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // Método para crear un vulnerabilidad
        public async Task<ActionResult<VulnerabilidadDTO>> CrearVulnerabilidad(VulnerabilidadDTO vulnerabilidad)
        {
            try
            {
                //var testvulnerabilidad = new VulnerabilidadDTO
                //{
                //    titulo = vulnerabilidad.titulo,
                //    descripcion = vulnerabilidad.descripcion,
                //    severidad = vulnerabilidad.severidad,
                //    estado = vulnerabilidad.url,
                //    activoAfectado = vulnerabilidad,
                //    fechaCreacion = vulnerabilidad,
                //    fechaActualizacion = vulnerabilidad,
                //    id_reportador = vulnerabilidad,
                //    id_revisor = vulnerabilidad,
                //};

                using (var conexion = context._connection)
                {
                    conexion.Open();
                    using (var exec = conexion.BeginTransaction())
                    {
                        try
                        { 
                            var nuevaVulnerabilidad = await conexion.QuerySingleAsync<VulnerabilidadDTO>(vulnerabilidadSQL.CrearVulnerabilidad(vulnerabilidad), transaction: exec);
                            exec.Commit();
                            return Ok(nuevaVulnerabilidad);
                        }
                        catch (Exception)
                        {
                            exec.Rollback();
                            return BadRequest("Error al crear la vulnerabilidad.");
                        }
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
