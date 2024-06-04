using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgramacionWeb.Models;

namespace ProgramacionWeb.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            List<EmpleadoCLS> listaEmpleado = null;
            using (var bd = new BDPasajeEntities())
            {

                listaEmpleado = (from empleado in bd.Empleado
                                 join tipousuario in bd.TipoUsuario
                                 on empleado.IIDTIPOUSUARIO equals tipousuario.IIDTIPOUSUARIO
                                 join tipocontrado in bd.TipoContrato
                                 on empleado.IIDTIPOCONTRATO equals tipocontrado.IIDTIPOCONTRATO
                                 where empleado.BHABILITADO == 1
                                 select new EmpleadoCLS
                                 {
                                     iidEmpleado = empleado.IIDEMPLEADO,
                                     nombre = empleado.NOMBRE,
                                     appaterno = empleado.APPATERNO,
                                     apmaterno = empleado.APMATERNO,
                                     nombreTipoUsuario = tipousuario.NOMBRE,
                                     nombreTipoContrato = tipocontrado.NOMBRE
                                 }).ToList();



            }



                return View(listaEmpleado);
        }
    }
}