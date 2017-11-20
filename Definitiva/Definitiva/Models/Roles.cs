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
using System.ComponentModel.DataAnnotations;

namespace Definitiva.Models
{
    public class CrearRol
    {
        [Required]
        [Display(Name = "Nuevo Rol")]
        public string Rol { get; set; }
    }

    public class EliminarRoles
    {
        [Required]
        [Display(Name = "Rol Actual")]
        public string EliminarRol { get; set; }

    }

    public class EditarRol
    {
        [Required]
        [Display(Name = "Rol a Editar")]
        public string EditRol { get; set; }

    }

    public class AsignarRol
    {
        [Required]
        [Display(Name = "Asignacion de Rol")]
        public string RolAsignado { get; set; }

    }



}