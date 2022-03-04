using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContpaqiMVC.ViewModel
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string EstadoCivil { get; set; }
        public string Email { get; set; }
        public string Puesto { get; set; }
        public string RFC { get; set; }
        public string Direccion { get; set; }
        public Int64 Telefono { get; set; }
        public string FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }

        public string NombreCompleto
        {
            get
            {
                return Nombre + (!String.IsNullOrEmpty(ApellidoPaterno) ? " " + ApellidoPaterno : "") +  (!String.IsNullOrEmpty(ApellidoMaterno) ? " " + ApellidoMaterno : "");
            }
        }
    }
}
