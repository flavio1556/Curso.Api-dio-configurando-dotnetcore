using Curso.Api.Business.Entities;
using Curso.Api.Infraestruture.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Api.Infraestruture.Data
{
    public class CursoDbContext : DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Business.Entities.Curso> Cursos { get; set; }
        public CursoDbContext(DbContextOptions<CursoDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CursoMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            base.OnModelCreating(modelBuilder);
        }

    }
}
