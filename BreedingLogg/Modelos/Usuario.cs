using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BreedingLogg.Modelos
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Apellidos")]
        public string ApellidosUsuario { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Usuario")]
        public string UsuarioUsuario { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Contraseña")]
        public string ContraseñaUsuario { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Correo")]
        public string CorreoUsuario { get; set; }

        [Display(Name = "Nivel")]
        public string NivelUsuario { get; set; }
    }
}
