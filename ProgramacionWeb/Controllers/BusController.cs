using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgramacionWeb.Models;

namespace ProgramacionWeb.Controllers
{
    public class BusController : Controller
    {
        // GET: Bus
        public ActionResult Index()
        {
            List<BusCLS> listaBus = null;

            using(var bd = new BDPasajeEntities())
            {


                listaBus = (from bus in bd.Bus
                            join sucursal in bd.Sucursal
                            on bus.IIDSUCURSAL equals sucursal.IIDSUCURSAL
                            join tipoBus in bd.TipoBus
                            on bus.IIDTIPOBUS equals tipoBus.IIDTIPOBUS
                            join tipoModelo in bd.Modelo
                            on bus.IIDMODELO equals tipoModelo.IIDMODELO
                            where bus.BHABILITADO == 1
                            select new BusCLS
                            {
                                iidBus = bus.IIDBUS,
                                nombreModelo = tipoModelo.NOMBRE,
                                nombreSucursal = sucursal.NOMBRE,
                                nombreTipoBus = tipoBus.NOMBRE,
                                placa = bus.PLACA
                            }).ToList();


            }



            return View(listaBus);
        }

        //Metodo para  mostrar la vista agregar
        public ActionResult Agregar()
        {
            listarCombos();
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(BusCLS oBusCls)
        {

            if (!ModelState.IsValid)
            {
                return View(oBusCls);
            }


            using(var bd = new BDPasajeEntities())
            {

                Bus oBus = new Bus();

                oBus.BHABILITADO = 1;
                oBus.IIDSUCURSAL = oBusCls.iidSucursal;
                oBus.IIDTIPOBUS = oBusCls.iidTipoBus;
                oBus.PLACA = oBusCls.placa;
                oBus.FECHACOMPRA = oBusCls.fechaCompra;
                oBus.IIDMODELO = oBusCls.iidMoelo;
                oBus.NUMEROFILAS = oBusCls.numeroFilas;
                oBus.NUMEROCOLUMNAS = oBusCls.numeroColumnas;
                oBus.DESCRIPCION = oBusCls.descripcion;
                oBus.OBSERVACION = oBusCls.observacion;
                oBus.IIDMARCA = oBusCls.iidMarca;

                bd.Bus.Add(oBus);
                bd.SaveChanges();
            }


            return RedirectToAction("Index");
        }

        //Metodos para listar datos en los ComboBox
        public void listarTicoBus()
        {
            //agegar
            List<SelectListItem> lista;

            using (var bd = new BDPasajeEntities())
            {
                lista = (from item in bd.TipoBus
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDTIPOBUS.ToString()
                         }).ToList();
            }

            lista.Insert(0, new SelectListItem { Text = "-- Seleccionar --", Value = "" });

            //PAsama la lista a la vista
            ViewBag.listaTipoBus = lista;
        }


        public void listarTicoMarca()
        {
            //agegar
            List<SelectListItem> lista;

            using (var bd = new BDPasajeEntities())
            {
                lista = (from item in bd.Marca
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDMARCA.ToString()
                         }).ToList();
            }

            lista.Insert(0, new SelectListItem { Text = "-- Seleccionar --", Value = "" });

            //PAsama la lista a la vista
            ViewBag.listaMarca = lista;
        }

        public void listarTicoModelo()
        {
            //agegar
            List<SelectListItem> lista;

            using (var bd = new BDPasajeEntities())
            {
                lista = (from item in bd.Modelo
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDMODELO.ToString()
                         }).ToList();
            }

            lista.Insert(0, new SelectListItem { Text = "-- Seleccionar --", Value = "" });

            //PAsama la lista a la vista
            ViewBag.listaModelo = lista;
        }



        public void listarSucursal()
        {
            //agegar
            List<SelectListItem> lista;

            using (var bd = new BDPasajeEntities())
            {
                lista = (from item in bd.Sucursal
                         where item.BHABILITADO == 1
                         select new SelectListItem
                         {
                             Text = item.NOMBRE,
                             Value = item.IIDSUCURSAL.ToString()
                         }).ToList();
            }

            lista.Insert(0, new SelectListItem { Text = "-- Seleccionar --", Value = "" });

            //PAsama la lista a la vista
            ViewBag.listaSucursal = lista;
        }

        //metodo para llamar a todos los comboBox
        public void listarCombos()
        {
            listarSucursal();
            listarTicoBus();
            listarTicoMarca();
            listarTicoModelo();
        }


        //Editar

        public ActionResult Editar(int id)
        {
            BusCLS oBucCls = new BusCLS();

            listarCombos();


            using(var bd = new BDPasajeEntities())
            {
                Bus obus = bd.Bus.Where(p => p.IIDBUS.Equals(id)).First();

                oBucCls.iidBus = obus.IIDBUS;
                oBucCls.iidMarca = (int)obus.IIDMARCA;
                oBucCls.iidSucursal = (int)obus.IIDSUCURSAL;
                oBucCls.iidTipoBus = (int)obus.IIDTIPOBUS;
                oBucCls.placa = obus.PLACA;

                oBucCls.fechaCompra = (DateTime)obus.FECHACOMPRA;
                oBucCls.iidMoelo = (int) obus.IIDMODELO;
                oBucCls.numeroColumnas = (int)obus.NUMEROCOLUMNAS;
                oBucCls.numeroFilas =(int) obus.NUMEROFILAS;

                oBucCls.descripcion = obus.DESCRIPCION;
                oBucCls.observacion = obus.OBSERVACION;


            }


            return View(oBucCls);
        }

    }
}