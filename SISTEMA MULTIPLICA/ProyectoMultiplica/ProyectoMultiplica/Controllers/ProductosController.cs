using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProyectoMultiplica.Models;

namespace ProyectoMultiplica.Controllers
{
    public class ProductosController : ApiController
    {
      
        List<Producto> Product = new List<Producto>();
        DAProductos DAp = new DAProductos();
            

        // GET: api/Productos      
        public List<Producto> GetProductos()
        {
            var Lista = DAp.ListarProductos();          
            return Lista;
        }
      

        // GET: api/Productos/5
        //[ResponseType(typeof(Productos))]
        public IHttpActionResult GetProductos(int id)
        {
            var Lista = DAp.ListarProductosxId(id);
            return Ok(Lista);

        }

        //// PUT: api/Productos/5
        //[ResponseType(typeof(void))]
        public IHttpActionResult PutProductos(Producto productos)
        {
            Int32 Validar = DAp.Actualizar(productos);
            return Ok(Validar);
        }

        // POST: api/Productos     
        [HttpPost]
        public IHttpActionResult PostProductos(Producto productos)
        {
            Int32 Validar = DAp.Registrar(productos);
            return Ok(Validar);
        }

        // DELETE: api/Productos/5
        //[ResponseType(typeof(Productos))]
        public IHttpActionResult DeleteProductos(int id)
        {
            Int32 Validar = DAp.Eliminar(id);
            return Ok(Validar);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool ProductosExists(int id)
        //{
        //    return db.Productos.Count(e => e.Codigo == id) > 0;
        //}
    }
}