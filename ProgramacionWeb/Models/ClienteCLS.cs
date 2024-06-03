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
        public string nombre { get; set; }
        [Display(Name ="Apellido Paterno")]
        public string appaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        public string apmaterno { get; set; }

        public string email { get; set; }

        public string direccion { get; set; }

        public int iidsexo { get; set; }
        [Display(Name ="Telefono Fijo")]
        public string telefonofijo { get; set; }

        public string telefonocelular { get; set; }

        public int bhabilitado { get; set; }


    }
}