using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoMultiplica.Models
{
    public class Producto
    {
        public Int32 Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public Int32 Stock { get; set; }
        public Int32 Codigo_Categoria { get; set; }
        public string Name_Categoria { get; set; }

    }
}