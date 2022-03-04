using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContpaqiMVC.ViewModel
{
    public class EmpleadoListaViewModel 
    {

        public int EmpleadoId { get; set; }

        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string Email { get; set; }

        public string Puesto { get; set; }

        public string RFC { get; set; }
        public string FechaAlta { get; set; }
    }
}
