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

namespace BreedingLogg.Pages.Criadores
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

            return Page();
        }

        [BindProperty]
        public Criador Criador { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync( IFormFile archivo, IFormFile archivo2)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Criador.FotoCriador = subirImagen("img", archivo);

            Criador.FotoCriadero = subirImagen("img", archivo2);

            _context.Criadores.Add(Criador);
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
