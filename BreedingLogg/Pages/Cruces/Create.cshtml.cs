using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BreedingLogg.Datos;
using BreedingLogg.Modelos;
using Microsoft.AspNetCore.Http;
namespace BreedingLogg.Pages.Cruces
{
    public class CreateModel : PageModel
    {
        private readonly BreedingLogg.Datos.ContextoBD _context;

        public CreateModel(BreedingLogg.Datos.ContextoBD context)
        {
            _context = context;
        }
         public EjemplarMacho EjemplarMacho { get; set; }
        public IActionResult OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                Response.Redirect("/Presentación");
            }

            var criadorvalido = HttpContext.Session.GetInt32("idcriador");

            var NuevoNombre = _context.Criadores.Select(p => new { p.CriadorId, NombreCriador = p.NombreCriador + " " + p.ApellidosCriador })
                .Where(p => p.CriadorId == criadorvalido);

            var MachoValido = _context.EjemplaresMachos.Select(p => new { p.EjemplarMachoId, p.CriadorId, NombreEjemplarMacho = p.NombreEjemplarMacho })
                .Where(p => p.CriadorId == criadorvalido);

            var HembraValida = _context.EjemplarHembras.Select(p => new { p.EjemplarHembraId, p.CriadorId, NombreEjemplarHembra = p.NombreEjemplarHembra })
                .Where(p => p.CriadorId == criadorvalido);

            ViewData["CriadorId"] = new SelectList(NuevoNombre, "CriadorId", "NombreCriador");
        ViewData["EjemplarHembraId"] = new SelectList(HembraValida, "EjemplarHembraId", "NombreEjemplarHembra");
        ViewData["EjemplarMachoId"] = new SelectList(MachoValido, "EjemplarMachoId", "NombreEjemplarMacho");
            return Page();
        }

        [BindProperty]
        public Cruce Cruce { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cruces.Add(Cruce);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
