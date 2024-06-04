using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgramacionWeb.Models;


namespace ProgramacionWeb.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            List<ClienteCLS> listaCliente = null;

            using (var bd = new BDPasajeEntities())
            {
                listaCliente = (from cliente in bd.Cliente
                                where cliente.BHABILITADO == 1
                                select new ClienteCLS
                                {
                                    iidcliente = cliente.IIDCLIENTE,
                                    nombre = cliente.NOMBRE,
                                    appaterno = cliente.APPATERNO,
                                    apmaterno = cliente.APMATERNO,
                                    telefonofijo = cliente.TELEFONOFIJO
                                }).ToList();
            }

                return View(listaCliente);
        }


        
        //Obtener una lista según el tipo de sexo
        List<SelectListItem> listaSexo;
        private void llenarSexo()
        {
            using(var bd = new BDPasajeEntities())
            {
                listaSexo = (from sexo in bd.Sexo
                             where sexo.BHABILITADO == 1
                             select new SelectListItem
                             {
                                 Text = sexo.NOMBRE,
                                 Value = sexo.IIDSEXO.ToString()
                             }).ToList();
            }

            listaSexo.Insert(0, new SelectListItem{ Text = "--Seleccionar--",Value=""});
        }

        //Meotodo para visuali view Agregar
        public ActionResult Agregar()
        {
            //Lamamanos al método donde se obtendrá el sexo
            llenarSexo();
            //ViewBag permite pasar información del controller a la vista
            ViewBag.lista = listaSexo;

            return View();
        }

        [HttpPost]
        public ActionResult Agregar(ClienteCLS oClienteCLS)
        {

            if (!ModelState.IsValid)
            {
                //Lamamanos al método donde se obtendrá el sexo para la vista otra vez
                llenarSexo();
                //ViewBag permite pasar información del controller a la vista
                ViewBag.lista = listaSexo;

                return View(oClienteCLS);
            }
            else {
           
                using(var bd = new BDPasajeEntities())
                {
                    Cliente oCliente = new Cliente();

                    oCliente.NOMBRE = oClienteCLS.nombre;
                    oCliente.APPATERNO = oClienteCLS.appaterno;
                    oCliente.APMATERNO = oClienteCLS.apmaterno;
                    oCliente.DIRECCION = oClienteCLS.direccion;
                    oCliente.EMAIL = oClienteCLS.email;
                    oCliente.BHABILITADO = 1;
                    oCliente.IIDSEXO = oClienteCLS.iidsexo;
                    oCliente.TELEFONOCELULAR = oClienteCLS.telefonocelular;
                    oCliente.TELEFONOFIJO = oClienteCLS.telefonofijo;

                    bd.Cliente.Add(oCliente);
                    bd.SaveChanges();
                }

                return RedirectToAction("Index");

            }
        }

    }
}