using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BreedingLogg.Modelos
{
    public class Criador
    {
        [Key]
        public int CriadorId { get; set; }

        [StringLength(100)]
        [Display(Name = "Nombre Del Criador")]
        public string NombreCriador { get; set; }

        [StringLength(100)]
        [Display(Name = "Apellidos")]
        public string ApellidosCriador { get; set; }

        [StringLength(100)]
        [Display(Name = "Correo")]
        public string CorreoC { get; set; }

        [StringLength(100)]
        [Display(Name = "Dirección del criadero")]
        public string DireccionCriadero { get; set; }

        [StringLength(300)]
        [Display(Name = "Especie que cría")]
        public string EspecieQC { get; set; }

        [Display(Name = "Foto del Criador")]
        public string FotoCriador { get; set; }

        [Display(Name = "Foto/logo del criadero")]
        public string FotoCriadero { get; set; }

        [StringLength(100)]
        [Display(Name = "Redes sociales")]
        public string RedSocialC { get; set; }

        [StringLength(15)]
        [Display(Name = "Usuario")]
        public string UsuarioCriador { get; set; }

        [StringLength(15)]
        [Display(Name = "Contraseña")]
        public string ContraseñaCriador { get; set; }

        [Display(Name = "Nivel")]
        public string NivelCriador { get; set; }
        
        [Display(Name = "Status")]
        public string StatusCriador { get; set; }

        public List<EjemplarMacho> EjemplarMachos { get; set; }
        public List<EjemplarHembra> EjemplarHembras { get; set; }
        public List<Cruce> Cruces { get; set; }
    }
}
