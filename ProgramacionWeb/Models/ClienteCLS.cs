using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgramacionWeb.Models
{
    public class ClienteCLS
    {
        [Display(Name = "Id Cliente")]
        public int iidcliente { get; set; }

        [Display(Name ="Nombre Cliente")]
        [Required]
        [StringLength(100,ErrorMessage = "Longitud máxima 100")]
        public string nombre { get; set; }
        [Display(Name ="Apellido Paterno")]
        [Required]
        [StringLength(150, ErrorMessage = "Longitud máxima 150")]
        public string appaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        [Required]
        [StringLength(150, ErrorMessage = "Longitud máxima 150")]
        public string apmaterno { get; set; }
        [Required]
        [Display(Name = "Email")]
        [StringLength(200, ErrorMessage = "Longitud máxima 200")]
        [EmailAddress(ErrorMessage ="Ingrese un email válido")]
        public string email { get; set; }
        [Required]
        [Display(Name = "Direccion")]
       
        [StringLength(200, ErrorMessage = "Longitud máxima 200")]
        [DataType(DataType.MultilineText)]
        public string direccion { get; set; }

        [Required]
        [Display(Name = "Sexo")]
        public int iidsexo { get; set; }
        [Display(Name ="Telefono Fijo")]
        [Required]
        [StringLength(10, ErrorMessage = "Longitud máxima 10")]

        public string telefonofijo { get; set; }
        [Display(Name = "Telefon Celular")]
        [StringLength(10, ErrorMessage = "Longitud máxima 10")]

        public string telefonocelular { get; set; }

        public int bhabilitado { get; set; }


    }
}