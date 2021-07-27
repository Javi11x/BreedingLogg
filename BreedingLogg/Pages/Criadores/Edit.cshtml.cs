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
namespace BreedingLogg.Pages.Criadores
{
    public class EditModel : PageModel
    {
        private readonly BreedingLogg.Datos.ContextoBD _context;

        public EditModel(BreedingLogg.Datos.ContextoBD context)
        {
            _context = context;
        }

        [BindProperty]
        public Criador Criador { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Criador = await _context.Criadores.FirstOrDefaultAsync(m => m.CriadorId == id);
            if (Criador == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(IFormFile archivo5, IFormFile archivo6, int? id, string a, string b, string c, string d, string e, string f, string g, string h, string i)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Criador = await _context.Criadores.FirstOrDefaultAsync(m => m.CriadorId == id);

            

            if (archivo5 != null && archivo6 != null)
            {
                borrarArchivo("img", Criador.FotoCriador);
                borrarArchivo("img", Criador.FotoCriadero);
                Criador.FotoCriador = subirImagen("img", archivo5);
                Criador.FotoCriadero = subirImagen("img", archivo6);
            }

            Criador.NombreCriador = a;
            Criador.ApellidosCriador = b;
            Criador.CorreoC = c;
            Criador.DireccionCriadero = d;
            Criador.EspecieQC = e;
            Criador.RedSocialC = f;
            Criador.UsuarioCriador = g;
            Criador.ContraseñaCriador = h;
            Criador.StatusCriador = i;

            _context.Attach(Criador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CriadorExists(Criador.CriadorId))
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

        private bool CriadorExists(int id)
        {
            return _context.Criadores.Any(e => e.CriadorId == id);
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
