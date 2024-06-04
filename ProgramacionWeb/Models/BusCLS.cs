using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgramacionWeb.Models
{
    public class BusCLS
    {
        [Display(Name ="ID Bus")]
        public int iidBus { get; set; }
        [Display(Name = "Nombre Sucursarl")]
        [Required]
        public int iidSucursal { get; set; }
        [Display(Name = "Tipo Bus")]
        [Required]
        public int iidTipoBus { get; set; }
        [Display(Name = "Fecha Compra")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime fechaCompra { get; set; }
        [Display(Name = "Nombre Modelo")]
        [Required]
        public int iidMoelo { get; set; }
        [Display(Name = "Numero Fila")]
        [Required]
        public int numeroFilas { get; set; }
        [Display(Name = "Numero Columna")]
        [Required]
        public int numeroColumnas { get; set; }

        public int bhabilitado { get; set; }
        [Display(Name = "Descripcion")]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud máxima 200")]

        public string descripcion { get; set; }
        [Display(Name = "Observacion")]
        [StringLength(200,ErrorMessage ="Longitud máxima 200")]
        public string observacion { get; set; }
        [Display(Name = "Nombre Marca")]
        [Required]
        public int iidMarca { get; set; }

        [Display(Name ="Placa")]
        [Required]
        public string placa { get; set; }

        //Propiedade adicionales
        [Display(Name = "Nombre Sucursal")]
      
        public string nombreSucursal { get; set; }
        [Display(Name = "Nombre Tipo Bus")]

        public string nombreTipoBus { get; set; }

        [Display(Name = "Nombre Modelo")]

        public string nombreModelo { get; set; }

    }
}