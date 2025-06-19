using AppVulnTracker.Server.Modelos;

namespace AppVulnTracker.Server.Sql
{
    public class ComentarioSQL
    {
        //Muestra toda la informacion del comentario
        public string VerComentario()
        {
            return $"select * from comentarios;";
        }

        //Muestra toda la informacion del cliente seleccionado
        public string MostrarComentarioPorId(int id_comentario)
        {
            return $"select * from comentarios where id_comentario = '{id_comentario}';";
        }

        public string CrearCliente(ComentarioDTO cliente)
        {
            return $"insert into comentarios (nombre, dni, direccion, telefono, email, contrasena) values ('{cliente.nombre}', '{cliente.dni}', '{cliente.direccion}', '{cliente.telefono}', '{cliente.email}', '{hash}');SELECT LAST_INSERT_ID();";
        }
    }
}
