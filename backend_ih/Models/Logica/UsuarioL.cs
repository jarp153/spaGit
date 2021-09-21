using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using backend_ih.AccesoDatos;
using backend_ih.Models.Objects;
using System.Data;
using System.Data.SqlClient;

namespace backend_ih.Models.Logica
{
    public class UsuarioL
    {

        ClsDB objBD = new ClsDB();
        public List<UsuarioO> ConsultarUsuarios()
        {
            UsuarioO objUsuario = new UsuarioO();
            DataTable dtUsuario;
            List<SqlParameter> args = new List<SqlParameter>();
            List<UsuarioO> usuarios = new List<UsuarioO>();

            args.Add(new SqlParameter("@opcion", 1));

            dtUsuario = objBD.QuerySPconParametros("usp_Usuario", args);

            foreach (DataRow row in dtUsuario.Rows)
            {
                objUsuario = new UsuarioO
                {
                    Cod_Usuario = Convert.ToInt32(row["cod_usuario"]),
                    Nombre = Convert.ToString(row["nombre"]),
                    Apellido = Convert.ToString(row["apellido"]),
                    Fecha_Nacimiento = Convert.ToString(row["fecha_nacimiento"]).Substring(0, 10),
                    Estado_Civil = Convert.ToInt16(row["estado_civil"]),
                    Tiene_Hermanos = Convert.ToInt16(row["tiene_hermanos"]),
                    Foto = Convert.ToString(row["foto"]),
                };

                usuarios.Add(objUsuario);
            }
            return usuarios;
        }

        public UsuarioO ConsultarUsuario(int cod_usuario)
        {
            UsuarioO objUsuario = new UsuarioO();
            DataTable dtUsuario;
            List<SqlParameter> args = new List<SqlParameter>();
            List<UsuarioO> usuarios = new List<UsuarioO>();

            args.Add(new SqlParameter("@opcion", 2));
            args.Add(new SqlParameter("@cod_usuario", cod_usuario));

            dtUsuario = objBD.QuerySPconParametros("usp_Usuario", args);

            foreach (DataRow row in dtUsuario.Rows)
            {
                objUsuario = new UsuarioO
                {
                    Cod_Usuario = Convert.ToInt32(row["cod_usuario"]),
                    Nombre = Convert.ToString(row["nombre"]),
                    Apellido = Convert.ToString(row["apellido"]),
                    Fecha_Nacimiento = Convert.ToString(row["fecha_nacimiento"]).Substring(0,10),
                    Estado_Civil = Convert.ToInt16(row["estado_civil"]),
                    Tiene_Hermanos = Convert.ToInt16(row["tiene_hermanos"]),
                    Foto = Convert.ToString(row["foto"]),
                };
            }
            return objUsuario;
        }

        public bool IngresarUusario(string nombre, string apellido, string fecha_nacimiento, string foto, int estado_civil, int tiene_hermanos)
        {
            List<SqlParameter> args = new List<SqlParameter>();

            args.Add(new SqlParameter("@opcion", 3));
            args.Add(new SqlParameter("@nombre", nombre));
            args.Add(new SqlParameter("@apellido", apellido));
            args.Add(new SqlParameter("@fecha_nacimiento", fecha_nacimiento));
            args.Add(new SqlParameter("@foto", foto));
            args.Add(new SqlParameter("@estado_civil", estado_civil));
            args.Add(new SqlParameter("@tiene_hermanos", tiene_hermanos));

            try
            {
                objBD.QuerySPconParametros("usp_Usuario", args);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public bool ActualizarUusario(int cod_usuario, string nombre, string apellido, string fecha_nacimiento, string foto, int estado_civil, int tiene_hermanos)
        {
            List<SqlParameter> args = new List<SqlParameter>();

            args.Add(new SqlParameter("@opcion  ", 4));
            args.Add(new SqlParameter("@cod_usuario", cod_usuario));
            args.Add(new SqlParameter("@nombre", nombre));
            args.Add(new SqlParameter("@apellido", apellido));
            args.Add(new SqlParameter("@fecha_nacimiento", fecha_nacimiento));
            args.Add(new SqlParameter("@foto", foto));
            args.Add(new SqlParameter("@estado_civil", estado_civil));
            args.Add(new SqlParameter("@tiene_hermanos", tiene_hermanos));

            try
            {
                objBD.QuerySPconParametros("usp_Usuario", args);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}