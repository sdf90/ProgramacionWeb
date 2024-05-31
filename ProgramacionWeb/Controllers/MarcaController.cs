using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgramacionWeb.Models;

namespace ProgramacionWeb.Controllers
{
    public class MarcaController : Controller
    {
        // GET: Marca
        public ActionResult Index()
        {
            //Variable de lista para asignar valores
            List<MarcaCLS> listaMarca = null;
            //abrir la conexión a BBDD
            using (var bd = new BDPasajeEntities())
            {
                //Obtener todo lo que tenemos en la tabla MARCA
                listaMarca = (from marca in bd.Marca
                              where marca.BHABILITADO == 1
                                             select new MarcaCLS
                                             {
                                                 iidmarca = marca.IIDMARCA,
                                                 nombre = marca.NOMBRE,
                                                 descripcion = marca.DESCRIPCION
                                             }).ToList();


            }



            return View(listaMarca);
        }
    }
}