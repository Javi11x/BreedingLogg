using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BreedingLogg.Datos;
using BreedingLogg.Modelos;
using Microsoft.AspNetCore.Http;
namespace BreedingLogg.Pages.Cruces
{
    public class EditModel : PageModel
    {
        private readonly BreedingLogg.Datos.ContextoBD _context;

        public EditModel(BreedingLogg.Datos.ContextoBD context)
        {
            _context = context;
        }

        [BindProperty]
        public Cruce Cruce { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                Response.Redirect("/Presentación");
            }
            if (id == null)
            {
                return NotFound();
            }

            Cruce = await _context.Cruces
                .Include(c => c.Criador)
                .Include(c => c.EjemplarHembra)
                .Include(c => c.EjemplarMacho).FirstOrDefaultAsync(m => m.CruceId == id);

            if (Cruce == null)
            {
                return NotFound();
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cruce).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CruceExists(Cruce.CruceId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CruceExists(int id)
        {
            return _context.Cruces.Any(e => e.CruceId == id);
        }
    }
}
