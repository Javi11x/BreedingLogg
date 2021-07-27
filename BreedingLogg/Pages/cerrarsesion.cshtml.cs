using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BreedingLogg.Pages
{
    public class cerrarsesionModel : PageModel
    {
        public void OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                Response.Redirect("Presentación");
            }
        }
        public void OnPostCerrar()
        {
            HttpContext.Session.Clear();

            Response.Redirect("Presentación");
        }

        public void OnPostCancelar()
        {
            Response.Redirect("Index");
        }

    }
}

