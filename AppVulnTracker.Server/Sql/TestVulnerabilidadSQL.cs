using AppVulnTracker.Server.Modelos;

namespace AppVulnTracker.Server.Sql
{
    public class TestVulnerabilidadSQL
    {
        // Muestra la lista de test de vulnerabilidad realizados (BÁSICO)
        public string VerTest()
        {
            return $"select * from test_vulnerabilidades;";
        }

        // Muestra la lista de test de vulnerabilidad realizados con el nombre de usuario y el tipo de test
        public string VerTestCompleto()
        {
            return $"SELECT tv.*,  u.nombre AS nombre_usuario, tt.nombre AS nombre_tipo " +
                $"FROM test_vulnerabilidades tv " +
                $"JOIN usuarios u ON tv.id_usuario = u.id_usuario " +
                $"JOIN tipo_test tt ON tv.tipo = tt.id_test " +
                $"ORDER BY tv.id_testvulnerabilidad;";
        }

        //Muestra toda la informacion del cliente seleccionado
        public string BuscarTestPorId(int id_test)
        {
            return $"select * from test_vulnerabilidades where id_testvulnerabilidad = '{id_test}';";
        }

        public string CrearTest(TestVulnerabilidadDTO test)
        {
            return $"insert into test_vulnerabilidades (id_usuario, tipo, url, resultado, fecha) values ('{test.id_usuario}', '{test.tipo}', '{test.url}', " +
                $"'{test.resultado}', '{test.fecha:yyyy-MM-dd}');SELECT * from test_vulnerabilidades where id_testvulnerabilidad = LAST_INSERT_ID();";
        }
    }
}
