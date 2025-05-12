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


        //Método que nos lleva a la vista Agregar
        public ActionResult Agregar()
        {
            return View();
        }

        //Método que recibirá el formulario de la vista y que será de tipo POST
        [HttpPost]
        public ActionResult Agregar(MarcaCLS oMarcaCLS)
        {
            //Comprobar si no hay errores en el formulario
            if (!ModelState.IsValid)
            {
                //Si hay error volvemos  a la página
                return View(oMarcaCLS);
            }
            else{
                //Inserta datos
                using(var bd = new BDPasajeEntities())
                {

                    Marca oMarca = new Marca();

                    oMarca.NOMBRE = oMarcaCLS.nombre;
                    oMarca.DESCRIPCION = oMarcaCLS.descripcion;
                    oMarca.BHABILITADO = 1;
                    bd.Marca.Add(oMarca);
                    bd.SaveChanges();
                } 
            }


            return RedirectToAction("Index");
        }


        //Metodo para la vista Editar
        public ActionResult Editar(int id)
        {
            MarcaCLS oMarcaCLS = new MarcaCLS();
            
            using(var bd = new BDPasajeEntities())
            {
                Marca oMarca = bd.Marca.Where(p => p.IIDMARCA.Equals(id)).First();

                oMarcaCLS.iidmarca = oMarca.IIDMARCA;
                oMarcaCLS.nombre = oMarca.NOMBRE;
                oMarcaCLS.descripcion = oMarca.DESCRIPCION;    

            }

            return View(oMarcaCLS);
        }


        [HttpPost]
        public ActionResult Editar(MarcaCLS oMarcaCls)
        {

            if (!ModelState.IsValid)
            {
                return View(oMarcaCls);
            }
            int idMarca = oMarcaCls.iidmarca;
            using(var bd = new BDPasajeEntities())
            {
                Marca oMarca = bd.Marca.Where(p => p.IIDMARCA.Equals(idMarca)).First();

                oMarca.NOMBRE = oMarcaCls.nombre;

                oMarca.DESCRIPCION = oMarcaCls.descripcion;

               bd.SaveChanges();
            }

                return RedirectToAction("Index");


        }

    }
}