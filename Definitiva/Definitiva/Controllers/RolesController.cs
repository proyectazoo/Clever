using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Definitiva.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Definitiva.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        [HttpGet]
        public ActionResult CrearRoles()
        {
            
            return View();
        }


        [HttpPost]
        public ActionResult CrearRoles(CrearRol modelo)
        {
            using (ApplicationDbContext DB = new ApplicationDbContext())
            {
                var RoleManager = new RoleManager<IdentityRole>
                    (new RoleStore<IdentityRole>(DB));

                var NuevoRol = RoleManager.Create(new IdentityRole(modelo.Rol));
                
                var usermanager = new UserManager<ApplicationUser>
                    (new UserStore<ApplicationUser>(DB));
            }
            return View(modelo);
        }

        // GET: Roles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
