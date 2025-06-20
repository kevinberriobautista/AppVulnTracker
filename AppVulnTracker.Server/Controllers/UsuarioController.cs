using AppVulnTracker.Server.Modelos;
using AppVulnTracker.Server.Sql;
using AppVulnTracker.Server.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Dapper; //Necesario para el uso de las funciones de conexion. en los metodos
using Org.BouncyCastle.Crypto.Generators; 
using BCrypt.Net;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System;

namespace AppVulnTracker.Server.Controllers
{
    public class UsuarioController : ControllerBase
    {
        UsuarioSQL usuarioSQL;

        private readonly AplicationDbContext context;

        // Creación de la conexión a la base de datos
        public UsuarioController(AplicationDbContext context)
        {
            this.context = context;
            usuarioSQL = new UsuarioSQL();
        }

        // Método para obtener todos los usuarios
        public async Task<ActionResult<List<UsuarioDTO>?>> ListarUsuarios()
        {
            try
            {
                using (var conexion = context._connection)
                {
                    conexion.Open();
                    List<UsuarioDTO>? listausuarios = await conexion.QueryAsync<UsuarioDTO>(usuarioSQL.VerUsuario()) as List<UsuarioDTO>;

                    return Ok(listausuarios);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //Login Clientes
        public async Task<ActionResult<string>> Login(LoginDTO login)
        {
            try
            {
                using (var conexion = context._connection)
                {
                    conexion.Open();
                    // Buscar al cliente por correo
                    LoginDTO? correoCliente = await conexion.QueryFirstOrDefaultAsync<LoginDTO>(usuarioSQL.BuscarUsuario(login.correo)) as LoginDTO;
                    // Verifico si existe el usuario y si la contraseña es correcta
                    // if (correoCliente == null || !BCrypt.Net.BCrypt.Verify(login.contrasena, correoCliente.contrasena))
                    if (correoCliente == null || login.contrasena != correoCliente.contrasena)
                    {
                        return Unauthorized("Credenciales incorrectas");
                    }
                    else
                    {
                        var token = GenerarToken(correoCliente);  // Método que genera el JWT
                        return Ok(new { token = token });
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        private string GenerarToken(LoginDTO login)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("clave-super-segura-con-32-o-mas-caracteres");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.NameIdentifier, login.id_usuario.ToString()),
                new Claim(ClaimTypes.Email, login.correo)
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
