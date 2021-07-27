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
using System.IO;
using Microsoft.AspNetCore.Http;
namespace BreedingLogg.Pages.EjemplaresHembras
{
    public class EditModel : PageModel
    {
        private readonly BreedingLogg.Datos.ContextoBD _context;

        public EditModel(BreedingLogg.Datos.ContextoBD context)
        {
            _context = context;
        }

        [BindProperty]
        public EjemplarHembra EjemplarHembra { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EjemplarHembra = await _context.EjemplarHembras
                .Include(e => e.Ciudad)
                .Include(e => e.Criador)
                .Include(e => e.Estado).FirstOrDefaultAsync(m => m.EjemplarHembraId == id);

            if (EjemplarHembra == null)
            {
                return NotFound();
            }
            var NuevoNombre = _context.Criadores.Select(p => new { p.CriadorId, NombreCriador = p.NombreCriador + " " + p.ApellidosCriador });
            ViewData["CiudadId"] = new SelectList(_context.Ciudades, "CiudadId", "NombreCiudad");
           ViewData["CriadorId"] = new SelectList(NuevoNombre, "CriadorId", "NombreCriador");
           ViewData["EstadoId"] = new SelectList(_context.Estados, "EstadoId", "NombreEstado");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(IFormFile archivo7, int? id, string a, int b, int c, int d, int e, DateTime f, string g, string h, string i, string j, string k)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            EjemplarHembra = await _context.EjemplarHembras
                .Include(e => e.Ciudad)
                .Include(e => e.Criador)
                .Include(e => e.Estado).FirstOrDefaultAsync(m => m.EjemplarHembraId == id);

            if (archivo7 != null)
            {
                borrarArchivo("img", EjemplarHembra.FotoEjemplarHembra);
                EjemplarHembra.FotoEjemplarHembra = subirImagen("img", archivo7);
            }

            EjemplarHembra.NombreEjemplarHembra = a;
            EjemplarHembra.CriadorId = b;
            EjemplarHembra.EstadoId = c;
            EjemplarHembra.CiudadId = d;
            EjemplarHembra.CodigoPostalEjemplarHembra = e;
            EjemplarHembra.FechaNacimientoEjemplarHembra = f;
            EjemplarHembra.VariedadEjemplarHembra = g;
            EjemplarHembra.PedegreeEjemplarHembra = h;
            EjemplarHembra.DescripcionEjemplarHembra = i;
            EjemplarHembra.RazaEjemplarHembra = j;
            EjemplarHembra.ColorEjemplarHembra = k;

            _context.Attach(EjemplarHembra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EjemplarHembraExists(EjemplarHembra.EjemplarHembraId))
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

        private bool EjemplarHembraExists(int id)
        {
            return _context.EjemplarHembras.Any(e => e.EjemplarHembraId == id);
        }

        public void borrarArchivo(string rutaCarpeta, string NombreArchivoBorrar)
        {
            //Preparar la carpeta a donde se va a copiar
            string Carpeta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", rutaCarpeta);

            //Union de la carpeta con el archivo unico
            string RutaArchivoDeNombreUnico = Path.Combine(Carpeta, NombreArchivoBorrar);

            FileInfo informacionArchivo = new FileInfo(RutaArchivoDeNombreUnico);

            if (informacionArchivo.Exists)
            {
                informacionArchivo.Delete();
            }
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
