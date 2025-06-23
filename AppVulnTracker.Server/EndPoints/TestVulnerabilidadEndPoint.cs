using AppVulnTracker.Server.Controllers;
using AppVulnTracker.Server.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace AppVulnTracker.Server.EndPoints
{
    [ApiController]
    [Route("api/testvulnerabilidad")]
    public class TestVulnerabilidadEndPoint
    {
        private readonly TestVulnerabilidadController testVulnerabilidadController;

        public TestVulnerabilidadEndPoint(TestVulnerabilidadController parametroTestVulnerabilidad)
        {
            testVulnerabilidadController = parametroTestVulnerabilidad;
        }

        // Listar todos los test
        [HttpGet("lista")]
        public async Task<ActionResult<List<TestVulnerabilidadDTO>?>> GetTest()
        {
            return await testVulnerabilidadController.ListarTest();
        }

        // Crear test de vulnerabilidad
        [HttpPost("ejecutar")]
        public async Task<ActionResult<TestVulnerabilidadDTO>> PostTest(TestRequestDTO test)
        {
            return await testVulnerabilidadController.EjecutarTest(test);
        }
    }
}
