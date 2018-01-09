using ProyectoMultiplica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoMultiplica.Controllers
{
    public class CategoriaController : ApiController
    {
        DAProductos DAp = new DAProductos();
        public List<Categoria> GetCategoria()
        {
            var Lista = DAp.ListarCategoria();
            return Lista;
        }
    }
}
