using Curso.Api.Infraestruture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Curso.Api.Configurations
{
    public class DbFactoryDbContext : IDesignTimeDbContextFactory<CursoDbContext>
    {
        public CursoDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<CursoDbContext>();
            optionBuilder.UseSqlServer("Server=(local)\\sqlexpress;DataBase=CursoDio;Trusted_Connection=true;MultipleActiveResultSets=true");
            CursoDbContext contexto = new CursoDbContext(optionBuilder.Options);
            return contexto;
        }
    }
}
