using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BreedingLogg.Modelos
{
    public class Ciudad
    {
        [Key]
        public int CiudadId { get; set; }

        [Required]
        public string NombreCiudad { get; set; }

        public int EstadoId { get; set; }
        public Estado Estado { get; set; }

        public List<EjemplarMacho> EjemplarMachos { get; set; }
        public List<EjemplarHembra> EjemplarHembras { get; set; }
    }
}
