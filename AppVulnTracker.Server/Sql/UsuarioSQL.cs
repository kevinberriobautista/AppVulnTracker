using AppVulnTracker.Server.Modelos;

namespace AppVulnTracker.Server.Sql
{
    public class UsuarioSQL
    {
        //Muestra toda la informacion del usuario
        public string VerUsuario()
        {
            return $"select * from usuarios;";
        }

        //Muestra toda la informacion del cliente seleccionado
        public string BuscarUsuarioPorId(int id_usuario)
        {
            return $"select * from usuarios where id_usuario = '{id_usuario}';";
        }

        public string CrearUsuario(UsuarioDTO usuario, string hash)
        {
            return $"insert into usuarios (nombre, correo, contrasena, rol, fechaCreacion) values ('{usuario.nombre}', '{usuario.correo}', '{hash}', " +
                $"'{usuario.rol}', '{usuario.fechaCreacion:yyyy-MM-dd}');SELECT LAST_INSERT_ID();";
        }
    }
}
