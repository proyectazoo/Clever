using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaProyecto.Models;

namespace PruebaProyecto.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            return View(new List<Productos>());
        }

        //Metodo que lee el archvivo csv y lo almacena en una lista de tipo Productos
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            List<Productos> customers = new List<Productos>();
            string filePath = string.Empty;
            if (postedFile != null)
            {
                string path = Server.MapPath("~/Uploads/");         //En caso de no tener una carpeta que almacene el archivo la crea
                if (!Directory.Exists(path))                           
                {
                    Directory.CreateDirectory(path);
                }
                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);

                string csvData = System.IO.File.ReadAllText(filePath);
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        customers.Add(new Productos
                        {
                            //Id=Convert.ToInt32(row.Split(',')[0]),
                            Nombre_Producto = row.Split(',')[0],
                            Precio_Producto = Convert.ToInt32(row.Split(',')[1]),
                            ID_Marca = Convert.ToInt32(row.Split(',')[2]),
                            Color_Producto = row.Split(',')[3],
                            Descripcion_Producto = row.Split(',')[4],
                            Stock_Producto = Convert.ToInt32(row.Split(',')[5]),
                            ID_Categoria = Convert.ToInt32(row.Split(',')[6]),
                            PrecioOriginal_Producto = Convert.ToInt32(row.Split(',')[7])
                        });
                    }
                }

                PruebaProyecto.Models.Productos llenarbase = new PruebaProyecto.Models.Productos();
                llenarbase.llenarbase(customers);
            }
           
            return View(customers);
        }
        
        public List<Productos> Mostrarinventario()
        {
            List<Productos> inventario = new List<Productos>();

            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-4LVFM2D\SQLEXPRESS;Initial Catalog=Prueba;Integrated Security=True"))
            {              
                string q = "Select * from Productos";

                SqlCommand cmd = new SqlCommand(q, conn);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Productos productos = new Productos
                    {
                        Id_Producto = Convert.ToInt32(reader["Codigo_Producto"]),
                        Nombre_Producto = Convert.ToString(reader["Nombre_Producto"]),
                        Precio_Producto = Convert.ToInt32(reader["Precio_Producto"]),
                        ID_Marca = Convert.ToInt32(reader["ID_Marca"]),
                        Color_Producto = Convert.ToString(reader["Color_Producto"]),
                        Descripcion_Producto = Convert.ToString(reader["Descripcion_Producto"]),
                        Stock_Producto = Convert.ToInt32(reader["Stock_Producto"]),
                        ID_Categoria = Convert.ToInt32(reader["ID_Categoria"]),
                        PrecioOriginal_Producto = Convert.ToInt32(reader["PrecioOriginal_Producto"])
                    };

                    inventario.Add(productos);
                }               
            }
            return inventario;
        }
      




    }
}