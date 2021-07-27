using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BreedingLogg.Modelos
{
    public class EjemplarMacho
    {
        [Key]
        public int EjemplarMachoId { get; set; }

        [Display(Name = "Foto del ejemplar")]
        public string FotoEjemplarMacho { get; set; }

        [StringLength(100)]
        [Display(Name = "Nombre del Ejemplar")]
        public string NombreEjemplarMacho { get; set; }

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
        public int CodigoPostalEjemplarMacho { get; set; }

        [Display(Name = "Raza")]
        public string RazaEjemplarMacho { get; set; }

        [Display(Name = "Color")]
        public string ColorEjemplarMacho { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime FechaNacimientoEjemplarMacho { get; set; }

        [StringLength(100)]
        [Display(Name = "Variedad")]
        public string VariedadEjemplarMacho { get; set; }

        [StringLength(50)]
        [Display(Name = "Pedegree")]
        public string PedegreeEjemplarMacho { get; set; }

        [Display(Name = "Género")]
        public string GeneroEjemplarMacho { get; set; }
        
        [StringLength(500)]
        [Display(Name = "Descripción")]
        public string DescripcionEjemplarMacho { get; set; }

        [Display(Name = "Status")]
        public string StatusEjemplarMacho { get; set; }

        public List<Cruce> Cruces { get; set; }
    }
}
