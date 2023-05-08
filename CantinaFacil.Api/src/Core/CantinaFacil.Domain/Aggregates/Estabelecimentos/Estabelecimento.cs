using CantinaFacil.Domain.Aggregates.Estabelecimentos.Builders;
using CantinaFacil.Domain.Aggregates.Usuarios;
using CantinaFacil.Domain.Aggregates.Usuarios.Builders;
using CantinaFacil.Shared.Kernel.Domain;

namespace CantinaFacil.Domain.Aggregates.Estabelecimentos
{
    public class Estabelecimento : Entity, IAggregateRoot
    {
        public int UsuarioId { get; private set; }
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }

        public UsuarioCantina Usuario { get; private set; }

        public IEnumerable<Produto> Produtos { get; private set; }

        protected Estabelecimento()
        {
            Id = default;
            UsuarioId = default;
            Nome = string.Empty;
            Cnpj = string.Empty;
            Usuario = new UsuarioCantinaBuilder(0).Build();
            Produtos = Enumerable.Empty<Produto>();
        }

        public Estabelecimento(EstabelecimentoBuilder builder)
        {
            Id = builder.Id;
            UsuarioId = builder.UsuarioId;
            Nome = builder.Nome;
            Cnpj = builder.Cnpj;
            Usuario = builder.Usuario;
            Produtos = builder.Produtos;
        }
    }
}
