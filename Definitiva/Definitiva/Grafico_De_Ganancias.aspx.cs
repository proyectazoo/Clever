using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pruebaGrafico1
{
    public partial class Grafica4Yo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected string SumaDeGanancias()
        {
            SqlConnection conexionSql = new SqlConnection(@"Data Source=DESKTOP-H96G089\SQLEXPRESS;Initial Catalog=Prueba;Integrated Security=True");

            SqlCommand cmd = new SqlCommand
            { //Productos vendidos
                CommandText = "select Fecha_Venta, SUM(Precio_Producto-PrecioOriginal_Producto) from Productos p  inner join Ventas v on (v.Codigo_Producto=p.Codigo_Producto)   GROUP BY (Fecha_Venta) Order BY (Fecha_Venta) Desc;",
                CommandType = CommandType.Text,
                Connection = conexionSql
            };
            conexionSql.Open();
            DataTable Datos = new DataTable();
            Datos.Load(cmd.ExecuteReader());
            conexionSql.Close();



            //DataTable Datos = new DataTable();
            //Datos.Columns.Add(new DataColumn("Fecha", typeof(string)));
            //Datos.Columns.Add(new DataColumn("Ganancia", typeof(string)));

            //Datos.Rows.Add(new Object[] { "23/08", 20 });
            //Datos.Rows.Add(new Object[] { "24/08", 30 });
            //Datos.Rows.Add(new Object[] { "25/08", 2 });
            //Datos.Rows.Add(new Object[] { "26/08", 1 });
            //Datos.Rows.Add(new Object[] { "27/08", 30 });

            string strDatos;

            strDatos = "[['Fecha','Ganancia'],";

            foreach (DataRow dr in Datos.Rows)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + dr[0] + "'" + "," + dr[1];
                strDatos = strDatos + "], ";
            }
            strDatos = strDatos + "]";
            return strDatos;

        }
    }
}