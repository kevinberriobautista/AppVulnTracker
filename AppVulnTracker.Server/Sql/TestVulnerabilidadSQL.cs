using AppVulnTracker.Server.Modelos;

namespace AppVulnTracker.Server.Sql
{
    public class TestVulnerabilidadSQL
    {
        public string VerTest()
        {
            return $"select * from test_vulnerabilidades;";
        }

        //Muestra toda la informacion del cliente seleccionado
        public string BuscarTestPorId(int id_test)
        {
            return $"select * from test_vulnerabilidades where id_testvulnerabilidad = '{id_test}';";
        }

        public string CrearTest(TestVulnerabilidadDTO test)
        {
            return $"insert into test_vulnerabilidades (id_usuario, tipo, url, resultado, fecha) values ('{test.id_usuario}', '{test.tipo}', '{test.url}', " +
                $"{test.resultado}, '{test.fecha:yyyy-MM-dd}');SELECT LAST_INSERT_ID();";
        }
    }
}
