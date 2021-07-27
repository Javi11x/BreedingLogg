using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BreedingLogg.Modelos
{
    public class Estado
    {
        [Key]
        public int EstadoId { get; set; }

        [Required]
        public string NombreEstado { get; set; }

        public List<Ciudad> Ciudades { get; set; }
        public List<EjemplarMacho> EjemplarMachos { get; set; }
        public List<EjemplarHembra> EjemplarHembras { get; set; }
    }
}
