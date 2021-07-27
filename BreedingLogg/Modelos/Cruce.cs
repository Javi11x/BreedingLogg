using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BreedingLogg.Modelos
{
    public class Cruce
    {
        [Key]
        public int CruceId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre de la cría")]
        public string NombreCria { get; set; }

        //INICIO DE RELACIONES
        //RELACION QUE SERA EL NOMBRE DEL PADRE
        [Display(Name = "Nombre del padre")]
        public int EjemplarMachoId { get; set; }
        public EjemplarMacho EjemplarMacho { get; set; }

        //RELACION QUE SERA EL NOMBRE DE LA MADRE
        [Display(Name = "Nombre de la madre")]
        public int EjemplarHembraId { get; set; }
        public EjemplarHembra EjemplarHembra { get; set; }
        //FIN DE RELACIONES

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de emparejamiento")]
        public DateTime FechaEmparejamientoCria { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimientoCria { get; set; }

        [Required]
        [Display(Name = "Ejemplares nacidos")]
        public int CriasNacidas { get; set; }

        [Required]
        [Display(Name = "Cantidad de machos")]
        public int CriasMachos { get; set; }

        [Required]
        [Display(Name = "Cantidad de hembras")]
        public int CriasHembras { get; set; }

        [Required]
        [Display(Name = "Número de bajas")]
        public int CriasFallecidas { get; set; }

        [Display(Name = "Nombre del criador")]
        public int CriadorId { get; set; }
        public Criador Criador { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string StatusCruce { get; set; }
    }
}
