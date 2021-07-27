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
using System.IO;
namespace BreedingLogg.Pages.EjemplaresMachos
{
    public class EditModel : PageModel
    {
        private readonly BreedingLogg.Datos.ContextoBD _context;

        public EditModel(BreedingLogg.Datos.ContextoBD context)
        {
            _context = context;
        }

        [BindProperty]
        public EjemplarMacho EjemplarMacho { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EjemplarMacho = await _context.EjemplaresMachos
                .Include(e => e.Ciudad)
                .Include(e => e.Criador)
                .Include(e => e.Estado).FirstOrDefaultAsync(m => m.EjemplarMachoId == id);

            if (EjemplarMacho == null)
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
        public async Task<IActionResult> OnPostAsync(IFormFile archivo8, int? id, string a, int b, DateTime c, string d, string e, string f,  int g, int h, int i, string j, string k)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            EjemplarMacho = await _context.EjemplaresMachos
                .Include(e => e.Ciudad)
                .Include(e => e.Criador)
                .Include(e => e.Estado).FirstOrDefaultAsync(m => m.EjemplarMachoId == id);

            if (archivo8 != null)
            {
                borrarArchivo("img", EjemplarMacho.FotoEjemplarMacho);
                EjemplarMacho.FotoEjemplarMacho = subirImagen("img", archivo8);
            }

            EjemplarMacho.NombreEjemplarMacho = a;
            EjemplarMacho.CodigoPostalEjemplarMacho = b;
            EjemplarMacho.FechaNacimientoEjemplarMacho = c;
            EjemplarMacho.VariedadEjemplarMacho = d;
            EjemplarMacho.PedegreeEjemplarMacho = e;
            EjemplarMacho.DescripcionEjemplarMacho = f;
            EjemplarMacho.CriadorId = g;
            EjemplarMacho.EstadoId = h;
            EjemplarMacho.CiudadId = i;
            EjemplarMacho.RazaEjemplarMacho = j;
            EjemplarMacho.ColorEjemplarMacho = k;

            _context.Attach(EjemplarMacho).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EjemplarMachoExists(EjemplarMacho.EjemplarMachoId))
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

        private bool EjemplarMachoExists(int id)
        {
            return _context.EjemplaresMachos.Any(e => e.EjemplarMachoId == id);
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
