using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Entities;
using Repository.Extensions;

namespace Repository.Mapeamento
{
    public class LoginMapeamento : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Login)
                .HasMaxLength(70)
                .IsRequired();

            builder.Property(x => x.Senha)
                .HasMaxLength(150)
                .IsRequired();

            builder.HasData(
                new Usuario
                {
                    Id = 1,
                    Nome = "Francisco",
                    Login = "francisco.lucas.sens@gmail.com",
                    Senha = "123".Hash()
                },
                new Usuario
                {
                    Id = 2,
                    Nome = "Joana",
                    Login = "joana@gmail.com",
                    Senha = "1234".Hash()
                });
        }
    }
}
