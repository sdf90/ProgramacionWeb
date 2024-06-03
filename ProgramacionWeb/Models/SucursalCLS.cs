using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgramacionWeb.Models
{
    public class SucursalCLS
    {
        [Display(Name = "ID Sucursal")]
        public int iidsucusal { get; set; }
        [Display(Name = "Nombre Sucursal")]
        [Required]
        [StringLength(100, ErrorMessage = "Longitud máxima 100")]
        public string nombre { get; set; }
        [Display(Name = "Dirección")]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud máxima 200")]
        public string direccion { get; set; }
        [Display(Name = "Telefono Sucursal")]
        [Required]
        [StringLength(10, ErrorMessage = "Longitud máxima 10")]

        public string telefono { get; set; }
        [Display(Name = "Email Sucursal")]
        [Required]
        [StringLength(100, ErrorMessage = "Longitud máxima 100")]
        [EmailAddress(ErrorMessage = "Ingrese un email válido")]
        public string email { get; set; }
        [Required]
        [Display(Name = "Fecha Apertura")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaApertura { get; set; }

        public int bhabilitado { get; set; }
    }
}