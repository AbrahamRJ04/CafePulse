using Azure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CafePulse.BusinessClass
{
    public class Usuario
    {
        public static CafePulse.ModelClass.Result GetAuthenticationLog(string userName, string password)
        {
            var response = new CafePulse.ModelClass.Result();

            try
            {
                using (var context = new CafePulse.DataBaseClass.Models.CoffeeDevBdContext())
                {
                    // Usar parámetros para evitar SQL Injection
                    var query = context.Usuarios
                        .FromSqlRaw("EXEC USP_GetUsuarioLogin @User, @Password",
                            new SqlParameter("@User", userName),
                            new SqlParameter("@Password", password))
                        .AsEnumerable()
                        .FirstOrDefault();

                    if (query != null)
                    {
                        var user = new CafePulse.ModelClass.Usuario
                        {
                            Rol = new CafePulse.ModelClass.Rol
                            {
                                IdRol = (int)query.Idrol,
                                Nombre = query.Rol
                            },
                            Genero = new CafePulse.ModelClass.Genero
                            {
                                IdGenero = (int)query.Idgenero,
                                Nombre = query.Genero
                            },
                            IdUsuario = query.Idusuario,
                            Nombre = query.Nombre,
                            Apellido = query.Apellido,
                            FechaNacimiento = query.FechaNacimiento?.ToString("yyyy-MM-dd"),
                            Telefono = query.Telefono,
                            Email = query.Email,
                            User = query.Usuario1
                        };

                        response.Object = user;
                        response.Success = true;
                    }
                    else
                    {
                        response.Success = false;
                        response.ErrorMessage = $"Usuario o contraseña incorrectos para el usuario {userName}.";
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                response.Success = false;
                response.ErrorMessage = "Error de base de datos al intentar autenticar al usuario.";
                response.exception = sqlEx;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = "Ocurrió un error inesperado al intentar autenticar al usuario.";
                response.exception = ex;
            }

            return response;
        }

        public static CafePulse.ModelClass.Result InsertNewUser(ModelClass.Usuario requestUser)
        {
            var result = new ModelClass.Result();

            try
            {
                using (var context = new DataBaseClass.Models.CoffeeDevBdContext())
                {
                    var query = context.Database.ExecuteSqlRaw(
                        "EXEC USP_InsertNewUser @Nombre, @Apellido, @FechaNacimiento, @IdGenero, @IdRol, @Telefono, @Email, @Usuario, @Contrasena",
                        new SqlParameter("@Nombre", requestUser.Nombre),
                        new SqlParameter("@Apellido", requestUser.Apellido),
                        new SqlParameter("@FechaNacimiento", requestUser.FechaNacimiento),
                        new SqlParameter("@IdGenero", requestUser.Genero.IdGenero),
                        new SqlParameter("@IdRol", requestUser.Rol.IdRol),
                        new SqlParameter("@Telefono", requestUser.Telefono),
                        new SqlParameter("@Email", requestUser.Email),
                        new SqlParameter("@Usuario", requestUser.User),
                        new SqlParameter("@Contrasena", requestUser.Pass) 
                    );

                    result.Success = query > 0;
                }
            }
            catch (SqlException sqlEx)
            {
                result.Success = false;
                result.ErrorMessage = "Error al insertar el usuario en la base de datos.";
                result.exception = sqlEx;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = "Ocurrió un error inesperado al registrar el usuario.";
                result.exception = ex;
            }

            return result;
        }

    }
}
