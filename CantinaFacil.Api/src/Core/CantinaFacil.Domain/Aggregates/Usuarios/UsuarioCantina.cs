using CantinaFacil.Domain.Aggregates.Estabelecimentos;
using CantinaFacil.Domain.Aggregates.Usuarios.Builders;

namespace CantinaFacil.Domain.Aggregates.Usuarios
{
    public class UsuarioCantina : Usuario
    {
        public IEnumerable<Estabelecimento> Estabelecimentos { get; private set; }

        protected UsuarioCantina()
        {
            Id = default;
            Estabelecimentos = Enumerable.Empty<Estabelecimento>();
        }

        public UsuarioCantina(UsuarioCantinaBuilder builder) : base(builder)
        {
            Estabelecimentos = Enumerable.Empty<Estabelecimento>();
        }
    }
}
