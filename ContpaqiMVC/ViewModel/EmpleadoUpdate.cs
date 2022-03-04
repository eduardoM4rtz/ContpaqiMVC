using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContpaqiMVC.ViewModel
{
    public class EmpleadoUpdate
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }

        [Required]
        [MaxLength(30)]
        public string EstadoCivil { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Puesto { get; set; }
        public string RFC { get; set; }

        [Required]
        [MaxLength(500)]
        public string Direccion { get; set; }

        [Required]
        [Range(1111111111, 9999999999)]
        public Int64 Telefono { get; set; }
        public string FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
    }
}
