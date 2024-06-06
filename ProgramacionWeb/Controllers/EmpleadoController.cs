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


        //Lenar comboBOx
        public void listarComboSexo()
        {
            //agegar
            List<SelectListItem> lista;

            using(var bd = new BDPasajeEntities())
            {
                lista = (from sexo in bd.Sexo
                            where sexo.BHABILITADO == 1
                            select new SelectListItem
                            {
                                Text = sexo.NOMBRE,
                                Value = sexo.IIDSEXO.ToString()
                            }).ToList();
            }

            lista.Insert(0, new SelectListItem { Text = "-- Seleccionar --", Value = "" });

            //PAsama la lista a la vista
            ViewBag.listaSexo = lista;
        }


        public void listarTicoContrato()
        {
            //agegar
            List<SelectListItem> lista;

            using (var bd = new BDPasajeEntities())
            {
                lista = (from item in bd.TipoContrato
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDTIPOCONTRATO.ToString()
                         }).ToList();
            }

            lista.Insert(0, new SelectListItem { Text = "-- Seleccionar --", Value = "" });

            //PAsama la lista a la vista
            ViewBag.listaTipoContrato = lista;
        }



        public void listarTipoUsuario()
        {
            //agegar
            List<SelectListItem> lista;

            using (var bd = new BDPasajeEntities())
            {
                lista = (from item in bd.TipoUsuario
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDTIPOUSUARIO.ToString()
                         }).ToList();
            }

            lista.Insert(0, new SelectListItem { Text = "-- Seleccionar --", Value = "" });

            //PAsama la lista a la vista
            ViewBag.listaTipoUsuario = lista;
        }


        //FUNCIÓN PARA LLAMAR A TODOS LOS COMBOS QUE TENEMOS EN EL LA VISTA AGREGAR
        public void listarCombos()
        {
            listarTipoUsuario();
            listarTicoContrato();
            listarComboSexo();
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(EmpleadoCLS oEmpleadoCLS) {

            if (!ModelState.IsValid)
            {
                listarCombos();
                return View(oEmpleadoCLS);
            }

            using(var bd = new BDPasajeEntities())
            {
                Empleado oEmpleado = new Empleado();

                oEmpleado.NOMBRE = oEmpleadoCLS.nombre;
                oEmpleado.APPATERNO = oEmpleadoCLS.appaterno;
                oEmpleado.APMATERNO = oEmpleadoCLS.apmaterno;
                oEmpleado.FECHACONTRATO = oEmpleadoCLS.fechaContrato;
                oEmpleado.SUELDO = oEmpleadoCLS.sueldo;
                oEmpleado.IIDTIPOCONTRATO = oEmpleadoCLS.iidttipoContrato;
                oEmpleado.IIDTIPOUSUARIO = oEmpleadoCLS.iidtipoUsuario;
                oEmpleado.IIDSEXO = oEmpleadoCLS.iidSexo;
                oEmpleado.BHABILITADO = 1;

                bd.Empleado.Add(oEmpleado);
                bd.SaveChanges();

            }

            return RedirectToAction("Index");
        }


    }
}