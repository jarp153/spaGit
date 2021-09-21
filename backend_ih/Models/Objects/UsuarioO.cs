using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend_ih.Models.Objects
{
    public class UsuarioO
    {
        public int Cod_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Fecha_Nacimiento { get; set; }
        public string Foto { get; set; }
        public int Estado_Civil { get; set; }
        public int Tiene_Hermanos { get; set; }
    }
}