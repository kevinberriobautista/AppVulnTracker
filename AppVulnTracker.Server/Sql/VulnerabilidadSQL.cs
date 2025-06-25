using AppVulnTracker.Server.Modelos;

namespace AppVulnTracker.Server.Sql
{
    public class VulnerabilidadSQL
    {
        //Muestra toda la informacion de la vulnerabilidad
        public string VerVulnerabilidad()
        {
            return $"select * from vulnerabilidades;";
        }

        //Muestra toda la informacion de la vulnerabilidad seleccionada
        public string BuscarVulnerabilidadPorId(int id_vulnerabilidad)
        {
            return $"select * from vulnerabilidades where id_vulnerabilidad = '{id_vulnerabilidad}';";
        }

        // Crear vulnerabilidad
        public string CrearVulnerabilidad(VulnerabilidadDTO vulnerabilidad)
        {
            return $"insert into vulnerabilidades (titulo, descripcion, severidad, estado, activoAfectado, fechaCreacion, " +
                $"fechaActualizacion, id_reportador, id_revisor) values ('{vulnerabilidad.titulo}', '{vulnerabilidad.descripcion}', " +
                $"{vulnerabilidad.severidad}, {vulnerabilidad.estado}, '{vulnerabilidad.activoAfectado}', '{vulnerabilidad.fechaCreacion:yyyy-MM-dd}', " +
                $"'{vulnerabilidad.fechaActualizacion:yyyy-MM-dd}', {vulnerabilidad.id_reportador}, {vulnerabilidad.id_revisor});" +
                $"SELECT * FROM vulnerabilidades WHERE id_vulnerabilidad = LAST_INSERT_ID();";
        }

        // Mostrar tipos de severidad
        public string MostrarSeveridad()
        {
            return $"SELECT ts.nombre" +
                $"FROM vulnerabilidades v" +
                $"JOIN tipo_severidad ts ON v.severidad = ts.id_severidad;";
        }

        // Mostrar tipos de estado
        public string MostrarEstados()
        {
            return $"SELECT te.nombre" +
                $"FROM vulnerabilidades v" +
                $"JOIN tipo_estado ts ON v.estado = te.id_estado;";
        }
    }
}
