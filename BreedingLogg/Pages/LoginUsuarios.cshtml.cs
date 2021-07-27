using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using BreedingLogg.Modelos;

namespace BreedingLogg.Pages
{
    public class LoginUsuariosModel : PageModel
    {
        [BindProperty]
        public string usuario { get; set; }

        [BindProperty]
        public string contrasena { get; set; }

        private readonly BreedingLogg.Datos.ContextoBD _context;
        
        public LoginUsuariosModel(BreedingLogg.Datos.ContextoBD context)
        {
            _context = context;
        }
        public Usuario Usuario { get; set; }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {

            }
            else
            {
                HttpContext.Session.Clear();
            }
        }

        public void OnPost()
        {
            Usuario = _context.Usuarios
                .Where(p => p.UsuarioUsuario == usuario && p.ContraseñaUsuario == contrasena).FirstOrDefault<Usuario>();

            if (Usuario != null)
            {
                //Variable de usuario en usuarios
                HttpContext.Session.SetString("usuario", Usuario.UsuarioUsuario);

                //Variable de contraseña de usuarios
                HttpContext.Session.SetString("contrasena", Usuario.ContraseñaUsuario);

                //Variable de nivel en usuarios
                HttpContext.Session.SetString("nivel", Usuario.NivelUsuario);

                Response.Redirect("Index");
            }
        }
    }
}
