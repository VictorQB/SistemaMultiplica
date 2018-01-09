using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoMultiplica.Models
{
    public class DAProductos
    {
        string connString = ConfigurationManager.ConnectionStrings["CONEXSQL"].ConnectionString;
        public List<Producto> ListarProductos()
        {
            List<Producto> Productos = new List<Producto>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("Sp_CrudMultiplica", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@accion", 1);    
                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Producto pro = new Producto();

                        pro.Codigo = Convert.ToInt32(dr["Codigo"].ToString());
                        pro.Nombre =dr["Nombre"].ToString();
                        pro.Precio = Convert.ToDecimal(dr["Precio"].ToString());
                        pro.Stock = Convert.ToInt32(dr["Stock"].ToString());
                        pro.Codigo_Categoria = Convert.ToInt32(dr["Codigo_Categoria"].ToString());
                        pro.Name_Categoria = dr["Name_Categoria"].ToString();
                        Productos.Add(pro);
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return Productos;

        }

        public Producto ListarProductosxId(Int32 id)
        {
            Producto Productos = new Producto();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("Sp_CrudMultiplica", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@accion", 5);
                cmd.Parameters.AddWithValue("@Codigo", id);    
                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        Productos.Codigo = Convert.ToInt32(dr["Codigo"].ToString());
                        Productos.Nombre = dr["Nombre"].ToString();
                        Productos.Precio = Convert.ToDecimal(dr["Precio"].ToString());
                        Productos.Stock = Convert.ToInt32(dr["Stock"].ToString());
                        Productos.Codigo_Categoria = Convert.ToInt32(dr["Codigo_Categoria"].ToString());
                        Productos.Name_Categoria = dr["Name_Categoria"].ToString();
                      
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return Productos;

        }

        public List<Categoria> ListarCategoria()
        {
            List<Categoria> Productos = new List<Categoria>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("Sp_CrudMultiplica", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@accion", 3);
                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Categoria pro = new Categoria();

                        pro.Codigo = Convert.ToInt32(dr["Codigo"].ToString());
                        pro.Descripcion = dr["Descripcion"].ToString();                       
                        Productos.Add(pro);
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return Productos;

        }
        public Int32 Registrar(Producto productos)
        {
            Int32 Valid = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {

                SqlCommand cmd = new SqlCommand("Sp_CrudMultiplica", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@accion", 2);                        
                cmd.Parameters.AddWithValue("@Nombre", productos.Nombre);
                cmd.Parameters.AddWithValue("@Precio", productos.Precio);
                cmd.Parameters.AddWithValue("@Stock", productos.Stock);
                cmd.Parameters.AddWithValue("@Codigo_Categoria", productos.Codigo_Categoria);   
            
                try
                {
                    conn.Open();

                    Valid = cmd.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    Valid = -1;
                    Console.WriteLine(ex.Message);
                }

            }
            return Valid;

        }

        public Int32 Actualizar(Producto productos)
        {
            Int32 Valid = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {

                SqlCommand cmd = new SqlCommand("Sp_CrudMultiplica", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@accion", 6);
                cmd.Parameters.AddWithValue("@Codigo", productos.Codigo);
                cmd.Parameters.AddWithValue("@Nombre", productos.Nombre);
                cmd.Parameters.AddWithValue("@Precio", productos.Precio);
                cmd.Parameters.AddWithValue("@Stock", productos.Stock);
                cmd.Parameters.AddWithValue("@Codigo_Categoria", productos.Codigo_Categoria);

                try
                {
                    conn.Open();

                    Valid = cmd.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    Valid = -1;
                    Console.WriteLine(ex.Message);
                }

            }
            return Valid;

        }

        public Int32 Eliminar(Int32 id)
        {
            Int32 Valid = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {

                SqlCommand cmd = new SqlCommand("Sp_CrudMultiplica", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@accion", 4);
                cmd.Parameters.AddWithValue("@Codigo", id);              
                try
                {
                    conn.Open();

                    Valid = cmd.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    Valid = -1;
                    Console.WriteLine(ex.Message);
                }

            }
            return Valid;

        }

    }
}