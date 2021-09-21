using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using backend_ih.Models.Logica;
using backend_ih.Models.Objects;

namespace backend_ih.Controllers
{
    public class UsuarioController : ApiController
    {
        UsuarioL objUsuario= new UsuarioL();
        // GET: Usuario
        /// <summary>
        /// Obtiene todos los usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [System.Web.Http.ActionName("ConsultarUsuarios")]
        public List<UsuarioO> ConsultarUsuarios()
        {
            return objUsuario.ConsultarUsuarios();
        }

        /// <summary>
        /// Consulta un usuario en particular
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [System.Web.Http.ActionName("ConsultarUsuario")]
        public UsuarioO ConsultarUsuario(int id)
        {
            return objUsuario.ConsultarUsuario(id);
        }
        /// <summary>
        /// Ingresa un usuario
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [System.Web.Http.ActionName("IngresarUsuario")]
        public bool IngresarUsuario([FromBody] Models.Objects.UsuarioO request)
        {
            return objUsuario.IngresarUusario(request.Nombre, request.Apellido,request.Fecha_Nacimiento,request.Foto,request.Estado_Civil,request.Tiene_Hermanos);
        }

        /// <summary>
        /// Actualizar un usuario
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [System.Web.Http.ActionName("ActualizarUsuario")]
        public bool ActualizarUsuario([FromBody] Models.Objects.UsuarioO request)
        {
            return objUsuario.ActualizarUusario(request.Cod_Usuario, request.Nombre, request.Apellido, request.Fecha_Nacimiento, request.Foto, request.Estado_Civil, request.Tiene_Hermanos);
        }

        /// <summary>
        /// Permite ingresar una imagen
        /// </summary>
        /// <param name="archivo_subir"></param>
        [HttpPost]
        [System.Web.Http.ActionName("IngresarImagen")]
        public void IngresarImagen(Archivo archivo_subir)
        {
            var archivo_ = new Archivo
            {
                ID = archivo_subir.ID,
                Nombre = archivo_subir.Nombre,
                Imagen = archivo_subir.Imagen
            };
        }
    }
}