using AppVulnTracker.Server.Modelos;

namespace AppVulnTracker.Server.Sql
{
    public class HistorialVulnerabilidadSQL
    {
        //Muestra todo el historial de modificaciones de una vulnerabilidad seleccionada
        public string BuscarHistorialPorId(int id_vulnerabilidad)
        {
            return $"select * from historial_vulnerabilidad where id_vulnerabilidad = '{id_vulnerabilidad}';";
        }

        // Crear entrada en historial de una vulnerabilidad
        public string CrearEntradaHistorialVulnerabilidad(VulnerabilidadDTO vulnerabilidad)
        {
            return $"insert into historial_vulnerabilidad (id_vulnerabilidad, titulo, descripcion, severidad, estado, activoAfectado, fechaCreacion, " +
                $"fechaActualizacion, id_reportador, id_revisor) values ('{vulnerabilidad.id_vulnerabilidad}', '{vulnerabilidad.titulo}', '{vulnerabilidad.descripcion}', " +
                $"{vulnerabilidad.severidad}, {vulnerabilidad.estado}, '{vulnerabilidad.activoAfectado}', '{vulnerabilidad.fechaCreacion:yyyy-MM-dd HH:mm:ss}', " +
                $"'{vulnerabilidad.fechaActualizacion:yyyy-MM-dd HH:mm:ss}', {vulnerabilidad.id_reportador}, {vulnerabilidad.id_revisor});";
        }
    }
}
