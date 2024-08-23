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

    }
}