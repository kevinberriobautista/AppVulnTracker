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
                $"{vulnerabilidad.severidad}, {vulnerabilidad.estado}, '{vulnerabilidad.activoAfectado}', '{vulnerabilidad.fechaCreacion:yyyy-MM-dd HH:mm:ss}', " +
                $"'{vulnerabilidad.fechaActualizacion:yyyy-MM-dd HH:mm:ss}', {vulnerabilidad.id_reportador}, {vulnerabilidad.id_revisor});" +
                $"SELECT * FROM vulnerabilidades WHERE id_vulnerabilidad = LAST_INSERT_ID();";
        }

        // Modificar vulnerabilidad
        public string ModificarVulnerabilidad(VulnerabilidadDTO vulnerabilidad)
        {
            return $"UPDATE vulnerabilidades " +
                $"SET titulo = '{vulnerabilidad.titulo}', descripcion = '{vulnerabilidad.descripcion}', severidad = {vulnerabilidad.severidad}, " +
                $"estado = {vulnerabilidad.estado}, activoAfectado = '{vulnerabilidad.activoAfectado}', fechaActualizacion = '{vulnerabilidad.fechaActualizacion:yyyy-MM-dd HH:mm:ss}', " +
                $"id_reportador = {vulnerabilidad.id_reportador}, id_revisor = {vulnerabilidad.id_revisor} " +
                $"WHERE id_vulnerabilidad = {vulnerabilidad.id_vulnerabilidad}; " +
                $"SELECT * FROM vulnerabilidades WHERE id_vulnerabilidad = {vulnerabilidad.id_vulnerabilidad};";
        }


        // Mostrar severidad y estado por id
        public string MostrarEstadoYSeveridad(int id)
        {
            return $"SELECT ts.nombre AS severidad, te.nombre AS estado " +
                $"FROM vulnerabilidades v " +
                $"JOIN tipo_severidad ts ON v.severidad = ts.id_severidad " +
                $"JOIN tipo_estado te ON v.estado = te.id_estado " +
                $"WHERE v.id_vulnerabilidad = {id};";
        }
    }
}
