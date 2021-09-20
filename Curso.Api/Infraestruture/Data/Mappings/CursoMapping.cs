using Microsoft.EntityFrameworkCore;
using Curso.Api.Business.Entities;
namespace Curso.Api.Infraestruture.Data.Mappings
{
    public class CursoMapping : IEntityTypeConfiguration<Business.Entities.Curso>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Business.Entities.Curso> builder)
        {
            builder.ToTable("TB_CURSO");
            builder.HasKey(p => p.Codigo);
            builder.Property(p => p.Codigo).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome);
            builder.Property(p => p.Descricao);
            builder.HasOne(p => p.Usuario)
                .WithMany().HasForeignKey(fk => fk.CodigoUsuario);
        }
    }
}
