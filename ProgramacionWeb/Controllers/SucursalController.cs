using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgramacionWeb.Models;

namespace ProgramacionWeb.Controllers
{
    public class SucursalController : Controller
    {
        // GET: Sucursal
        public ActionResult Index()
        {

            List<SucursalCLS> listaSucursal = null;

            using(var bd = new BDPasajeEntities())
            {
                listaSucursal = (from sucursal in bd.Sucursal
                                 where sucursal.BHABILITADO == 1
                                 select new SucursalCLS
                                 {
                                     iidsucusal = sucursal.IIDSUCURSAL,
                                     nombre = sucursal.NOMBRE,
                                     telefono = sucursal.TELEFONO,
                                     email = sucursal.EMAIL
                                 }).ToList();
            }


            return View(listaSucursal);
        }

        //Retorna la vista Agregar
        public ActionResult Agregar()
        {
            return View();
        }

        //Metodo para guardar los datos del formulario de Agregar
        [HttpPost]
        public ActionResult Agregar(SucursalCLS oSucusalCLS)
        {
            //Comprobar si los datos del formulario son válidos
            if (!ModelState.IsValid)
            {
                //Le pasamos el modelo con los valores que tiene ya el formulario
                return View(oSucusalCLS);
            }
           using(var bd = new BDPasajeEntities())
            {
                Sucursal oSucursal = new Sucursal();
                oSucursal.NOMBRE = oSucusalCLS.nombre;
                oSucursal.DIRECCION = oSucusalCLS.direccion;
                oSucursal.TELEFONO = oSucusalCLS.telefono;
                oSucursal.EMAIL = oSucusalCLS.email;
                oSucursal.FECHAAPERTURA = oSucusalCLS.fechaApertura;
                oSucursal.BHABILITADO = 1;
                bd.Sucursal.Add(oSucursal);
                bd.SaveChanges();
            }


            return RedirectToAction("Index");
        }


        public ActionResult Editar(int id)
        {
            SucursalCLS oSucursalCLS = new SucursalCLS();
            using(var bd = new BDPasajeEntities())
            {

                Sucursal oSucurcal = bd.Sucursal.Where(p => p.IIDSUCURSAL.Equals(id)).First();
                oSucursalCLS.iidsucusal = oSucurcal.IIDSUCURSAL;
                oSucursalCLS.nombre = oSucurcal.NOMBRE;
                oSucursalCLS.direccion = oSucurcal.DIRECCION;
                oSucursalCLS.email = oSucurcal.EMAIL;
                oSucursalCLS.telefono = oSucurcal.TELEFONO;
                oSucursalCLS.fechaApertura = (DateTime)oSucurcal.FECHAAPERTURA;




            }


            return View(oSucursalCLS);
        }


    }
}