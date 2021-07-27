using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BreedingLogg.Modelos
{
    public class EjemplarHembra
    {
        [Key]
        public int EjemplarHembraId { get; set; }

        [Display(Name = "Foto del ejemplar")]
        public string FotoEjemplarHembra { get; set; }

        [StringLength(100)]
        [Display(Name = "Nombre del Ejemplar")]
        public string NombreEjemplarHembra { get; set; }

        //INICIO DE RELACIONES
        //RELACION QUE SERA EL ID DEL CRIADOR
        [Display(Name = "Nombre del criador")]
        public int CriadorId { get; set; }
        public Criador Criador { get; set; }

        //RELACIONAMOS EL ESTADO
        [Display(Name = "Estado")]
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }

        //RELACIONAMOS LA CIUDAD
        [Display(Name = "Ciudad")]
        public int CiudadId { get; set; }
        public Ciudad Ciudad { get; set; }
        //FIN DE LAS RELACIONES

        [Display(Name = "Código Postal")]
        public int CodigoPostalEjemplarHembra { get; set; }

        [Display(Name = "Raza")]
        public string RazaEjemplarHembra { get; set; }

        [Display(Name = "Color")]
        public string ColorEjemplarHembra { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime FechaNacimientoEjemplarHembra { get; set; }

        [StringLength(100)]
        [Display(Name = "Variedad")]
        public string VariedadEjemplarHembra { get; set; }

        [StringLength(50)]
        [Display(Name = "Pedegree")]
        public string PedegreeEjemplarHembra { get; set; }

        [Display(Name = "Género")]
        public string GeneroEjemplarHembra { get; set; }

        [StringLength(500)]
        [Display(Name = "Descripción")]
        public string DescripcionEjemplarHembra { get; set; }

        [Display(Name = "Status")]
        public string StatusEjemplarHembra { get; set; }
        public List<Cruce> Cruces { get; set; }
    }
}
