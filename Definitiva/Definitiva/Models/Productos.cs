using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PruebaProyecto.Models
{
    public class Productos
    {
        public int Id_Producto { get; set; }

        public string Nombre_Producto { get; set; }

        public int Precio_Producto { get; set; }

        public int ID_Marca { get; set; }

        public string Color_Producto { get; set; }

        public string Descripcion_Producto { get; set; }

        public int Stock_Producto { get; set; }

        public int ID_Categoria { get; set; }

        public int PrecioOriginal_Producto { get; set; }

        public Productos ( string nombrep, int precio, int idmarca, string color, string descripcion, int stock, int idcategoria, int preciooriginal)
        {
            
            Nombre_Producto = nombrep;
            Precio_Producto = precio;
            ID_Marca = idmarca;
            Color_Producto = color;
            Descripcion_Producto = descripcion;
            Stock_Producto = stock;
            ID_Categoria = idcategoria;
            PrecioOriginal_Producto = preciooriginal;
        }

        public Productos()
        {
            Nombre_Producto = "";
            Precio_Producto = 0;
            ID_Marca = 0;
            Color_Producto = "";
            Descripcion_Producto = "";
            Stock_Producto = 0;
            ID_Categoria = 0;
            PrecioOriginal_Producto = 0;
        }


        public void llenarbase(List<Productos> x)
        {
            //List<CustomerModel> customers = new List<CustomerModel>();
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-4LVFM2D\SQLEXPRESS;Initial Catalog=Prueba;Integrated Security=True"))
            {
                foreach (Productos elemento in x)
                {
                    string q = "Insert Into Productos(Nombre_Producto, Precio_Producto, ID_Marca,Color_Producto, Descripcion_Producto, Stock_Producto,ID_Categoria, PrecioOriginal_Producto) Values(@Nombre_Producto, @Precio_Producto, @ID_Marca, @Color_Producto, @Descripcion_Producto, @Stock_Producto, @ID_Categoria, @PrecioOriginal_Producto)";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(q, conn);
                    //cmd.Parameters.AddWithValue("Id", customer.Id);
                    cmd.Parameters.AddWithValue("Nombre_Producto", elemento.Nombre_Producto);
                    cmd.Parameters.AddWithValue("Precio_Producto", elemento.Precio_Producto);
                    cmd.Parameters.AddWithValue("ID_Marca", elemento.ID_Marca);
                    cmd.Parameters.AddWithValue("Color_Producto", elemento.Color_Producto);
                    cmd.Parameters.AddWithValue("Descripcion_Producto", elemento.Descripcion_Producto);
                    cmd.Parameters.AddWithValue("Stock_Producto", elemento.Stock_Producto);
                    cmd.Parameters.AddWithValue("ID_Categoria", elemento.ID_Categoria);
                    cmd.Parameters.AddWithValue("PrecioOriginal_Producto", elemento.PrecioOriginal_Producto);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        //public List<string[]> mostrarinventario()
        //{
            

        //    using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-4LVFM2D\SQLEXPRESS;Initial Catalog=Prueba;Integrated Security=True"))
        //    {
        //        List<string[]> inventario = new List<string[]>();

        //        string q = "Select * from Productos";

        //        SqlCommand cmd = new SqlCommand(q, conn);

        //        conn.Open();

        //        SqlDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            string[] respuesta = new string[8];
        //            for (int i =0;i<respuesta.Length; i++)
        //            {
        //                respuesta[i] = reader[i].ToString();
        //            }

        //            inventario.Add(respuesta);

        //        }

        //        return inventario;
        //    }
          
        //}

        //public Productos convertirempleado(SqlDataReader reader)
        //{
        //    Productos productos = new Productos
        //    {

        //        //productos.Id_Producto = Convert.ToInt32(reader["Codigo_Prodcuto"]);
        //        Nombre_Producto = Convert.ToString(reader["Nombre_Producto"]),
        //        Precio_Producto = Convert.ToInt32(reader["Precio_Pruducto"]),
        //        ID_Marca = Convert.ToInt32(reader["ID_Marca"]),
        //        Color_Producto = Convert.ToString(reader["Color_Producto"]),
        //        Descripcion_Producto = Convert.ToString(reader["Descripcion_Producto"]),
        //        Stock_Producto = Convert.ToInt32(reader["Stock_Producto"]),
        //        ID_Categoria = Convert.ToInt32(reader["ID_Categoria"]),
        //        PrecioOriginal_Producto = Convert.ToInt32(reader["PrecioOriginarl_Producto"])
        //    };

        //    return productos;

        //}


    }


}