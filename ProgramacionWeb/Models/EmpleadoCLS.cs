﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgramacionWeb.Models
{
    public class EmpleadoCLS
    {

        [Display(Name = "ID Empleado")]
     
        public int iidEmpleado { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        [StringLength(100,ErrorMessage ="Longitud máxima 100")]
        public string nombre { get; set; }

        [Display(Name = "Apellido Paterno")]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud máxima 200")]

        public string appaterno { get; set; }


        [Display(Name = "Apellido Materno")]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud máxima 200")]
        public string apmaterno { get; set; }

        [Display(Name = "Fehca de Contrato")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime fechaContrato { get; set; }

        [Display(Name = "Tipo Usuario")]
        [Required]
        public int iidttipoUsuario { get; set; }

        [Display(Name = "Sexo")]
        [Required]
        public int iidSexo { get; set; }

        public int bhabilitado{ get; set; }


        ///Propiedade adicionlaes
        [Display(Name ="Tipo Contrato")]
        public string nombreTipoContrato { get; set; }
         [Display(Name ="Tipo Usuario")]
        public string nombreTipoUsuario { get; set; }
    }
}