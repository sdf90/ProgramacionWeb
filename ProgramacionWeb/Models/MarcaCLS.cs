using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProgramacionWeb.Models
{
    public class MarcaCLS
    {
        [Display(Name = "Id Marca")]
        public int iidmarca { get; set; }

        [Display(Name = "Nombre Marca")]
        public string nombre { get; set; }
        [Display(Name = "Descripción Marca")]

        public string descripcion { get; set; }

    

        public int bhabilitado { get; set; }



    }
}