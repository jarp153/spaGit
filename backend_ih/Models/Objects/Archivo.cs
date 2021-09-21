using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend_ih.Models.Objects
{
    public class Archivo
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }

        public byte Prueba { get; set; }
    }
}