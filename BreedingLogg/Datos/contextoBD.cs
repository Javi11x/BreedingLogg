using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreedingLogg.Modelos;
using Microsoft.EntityFrameworkCore;

namespace BreedingLogg.Datos
{
    public class ContextoBD : DbContext
    {
        public ContextoBD(DbContextOptions<ContextoBD> options) : base(options)
        {
        }

        public DbSet<Criador> Criadores { get; set; }
        public DbSet<EjemplarMacho> EjemplaresMachos { get; set; }
        public DbSet<EjemplarHembra> EjemplarHembras { get; set; }
        public DbSet<Cruce> Cruces { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        
    }
}
