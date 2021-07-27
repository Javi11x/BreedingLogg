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
    public class PresentaciónModel : PageModel
    {
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

        public void OnPostUsuarios()
        {
            Response.Redirect("LoginUsuarios");
        }

        public void OnPostCriadores()
        {
            Response.Redirect("LoginCriadores");
        }
    }
}
