using AppVulnTracker.Server.Modelos;
using AppVulnTracker.Server.Sql;
using AppVulnTracker.Server.Utilidades;
using AppVulnTracker.Server.Utilidades.Servicios;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace AppVulnTracker.Server.Controllers
{
    public class TestVulnerabilidadController : ControllerBase
    {
        TestVulnerabilidadSQL testVulnerabilidadSQL;

        private readonly AplicationDbContext context;
        private readonly ServicioTest servicioTest;

        public TestVulnerabilidadController(AplicationDbContext context, ServicioTest servicioTest)
        {
            this.context = context;
            this.servicioTest = servicioTest;
            testVulnerabilidadSQL = new TestVulnerabilidadSQL();
        }

        // Método para obtener todos los test
        public async Task<ActionResult<List<TestVulnerabilidadDTO>?>> ListarTest()
        {
            try
            {
                using (var conexion = context._connection)
                {
                    conexion.Open();
                    List<TestVulnerabilidadDTO>? lista_test = await conexion.QueryAsync<TestVulnerabilidadDTO>(testVulnerabilidadSQL.VerTest()) as List<TestVulnerabilidadDTO>;

                    return Ok(lista_test);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // ------------------------- EJERCUTAR TEST --------------------------

        public async Task<ActionResult> EjecutarTest(TestRequestDTO test)
        {
            try
            {
                string resultado;

                if (test.tipo == 1)
                    resultado = await servicioTest.RealizarXssTest(test.url);
                else if (test.tipo == 2)
                    resultado = await servicioTest.RealizarSqliTest(test.url);
                else
                    return BadRequest("Tipo de test no válido.");

                var testvulnerabilidad = new TestVulnerabilidadDTO
                {
                    id_usuario = test.id_usuario,
                    tipo = test.tipo,
                    url = test.url,
                    resultado = resultado,
                    fecha = DateTime.Now.Date
                };

                using (var conexion = context._connection)
                {
                    conexion.Open();
                    using (var exec = conexion.BeginTransaction())
                    {
                        try
                        {
                            //var nuevoTestVulnerabilidad = await conexion.ExecuteScalarAsync<int>(testVulnerabilidadSQL.CrearTest(testvulnerabilidad), transaction: exec);
                            //exec.Commit();
                            //return Ok(nuevoTestVulnerabilidad);

                            var testFinal = await conexion.QuerySingleAsync<TestVulnerabilidadDTO>(testVulnerabilidadSQL.CrearTest(testvulnerabilidad), transaction: exec);
                            exec.Commit();
                            return Ok(testFinal);
                        }
                        catch (Exception)
                        {
                            exec.Rollback();
                            return BadRequest("Error al crear el test de vulnerabilidad.");
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
