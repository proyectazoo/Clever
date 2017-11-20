using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Helpers;
using System.Data.SqlClient;
using System.Configuration;
using Definitiva.Models;

namespace Definitiva.Controllers
{   //[Authorize]
    public class HomeController : Controller
    {

        RangoFechasModel RangoFecha = new RangoFechasModel();
        static List<ReporteModel> Lventa = new List<ReporteModel>();
        static string Fecha1;
        static string Fecha2;
        //public IEnumerable Model { get; private set; }


        public ActionResult GraficoDeGanancia()
        {


            return View();
        }
        //public ActionResult Index()
        //{


        //    return View();
        //}
        public ActionResult CharterHelp()
        {


            new Chart(width: 500, height: 500, theme: ChartTheme.Yellow)
           .AddTitle("USA City Distribution")
           .AddSeries("Default", chartType: "column",
                xValue: Lventa, xField: "Fecha",
                yValues: Lventa, yFields: "Ganancia")
            .Write();
            return null;
        }

        public ActionResult Index()
        {
            //List<ReporteModel> Lventa = new List<ReporteModel>();
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "select Fecha_Venta, SUM(Precio_Producto-PrecioOriginal_Producto) as Ganancia from Productos p  inner join Ventas v on (v.Codigo_Producto=p.Codigo_Producto)   WHERE Fecha_Venta  BETWEEN '" + Fecha1 + "' AND '" + Fecha2 + "' GROUP BY (Fecha_Venta)  Order BY (Fecha_Venta) Desc;";

                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            var Venta = new ReporteModel
                            {
                                Fecha = dr["Fecha_Venta"].ToString(),
                                Ganancia = Convert.ToInt32(dr["Ganancia"]),
                            };
                            Lventa.Add(Venta);
                        }
                    }
                    con.Close();
                }
            }

            return View();
        }
        [HttpGet]
        public ActionResult Graficos()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Graficos(RangoFechasModel RangoFecha)
        {
            Fecha1 = RangoFecha.Fecha1;
            Fecha2 = RangoFecha.Fecha2;

            return this.RedirectToAction("Index", "Home");
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}