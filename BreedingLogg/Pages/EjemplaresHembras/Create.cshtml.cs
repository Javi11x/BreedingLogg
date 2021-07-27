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
using System.IO;

namespace BreedingLogg.Pages.EjemplaresHembras
{
    public class CreateModel : PageModel
    {
        private readonly BreedingLogg.Datos.ContextoBD _context;

        public CreateModel(BreedingLogg.Datos.ContextoBD context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                Response.Redirect("/Presentación");
            }
            var criadorvalido = HttpContext.Session.GetInt32("idcriador");

            var NuevoNombre = _context.Criadores.Select(p => new { p.CriadorId, NombreCriador = p.NombreCriador + " " + p.ApellidosCriador }).Where(p => p.CriadorId == criadorvalido);
             
        ViewData["CiudadId"] = new SelectList(_context.Ciudades, "CiudadId", "NombreCiudad");
        //ViewData["CriadorId"] = new SelectList(_context.Criadores, "CriadorId", "NombreCriador");
        ViewData["CriadorId"] = new SelectList(NuevoNombre, "CriadorId", "NombreCriador");
        ViewData["EstadoId"] = new SelectList(_context.Estados, "EstadoId", "NombreEstado");
            return Page();
        }

        [BindProperty]
        public EjemplarHembra EjemplarHembra { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(IFormFile archivo3)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            EjemplarHembra.FotoEjemplarHembra = subirImagen("img", archivo3);

            _context.EjemplarHembras.Add(EjemplarHembra);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        private string subirImagen(string rutaCarpeta, IFormFile archivoAsubir)
        {
            //Preparar la carpeta a donde se va a copiar
            string Carpeta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", rutaCarpeta);

            //Archivo unico para no repetir
            string NombreUnicoArchivo = Guid.NewGuid().ToString() + "_" + archivoAsubir.FileName;

            //Union de la carpeta con el archivo unico
            string RutaArchivoDeNombreUnico = Path.Combine(Carpeta, NombreUnicoArchivo);

            //Copiar al archivo (una vez que ya tengo la ruta y el nombre del archivo
            using (var InforArchivoACrear = new FileStream(RutaArchivoDeNombreUnico, FileMode.Create))
            {
                archivoAsubir.CopyTo(InforArchivoACrear);

            }

            return NombreUnicoArchivo;

        }
    }
}
