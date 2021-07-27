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
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string usuario { get; set; }

        [BindProperty]
        public string contrasena { get; set; }


        private readonly BreedingLogg.Datos.ContextoBD _context;
 
        public LoginModel(BreedingLogg.Datos.ContextoBD context)
        {
            _context = context;
        }

        public Criador Criador { get;set; }

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
            Criador = _context.Criadores
                .Where(p => p.UsuarioCriador == usuario && p.ContraseñaCriador == contrasena && p.StatusCriador == "Enable").FirstOrDefault<Criador>();

            if (Criador != null)
            {
                //Variable de id
                HttpContext.Session.SetInt32("idcriador", Criador.CriadorId);

                //Variable usuario
                HttpContext.Session.SetString("usuario", Criador.UsuarioCriador);

                //Variable contraseña
                HttpContext.Session.SetString("contrasena", Criador.ContraseñaCriador);

                //Variable de nivel
                HttpContext.Session.SetString("nivel", Criador.NivelCriador);


                //Variable de status
                HttpContext.Session.SetString("status", Criador.StatusCriador);

                Response.Redirect("Index");
            }  
        }
    }
}
