using CantinaFacil.Shared.Kernel.Domain;
using CantinaFacil.Domain.Aggregates.Perfis.Builders;

namespace CantinaFacil.Domain.Aggregates.Perfis
{
    public class Permissao : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public IEnumerable<PerfilPermissao> PerfilPermissoes { get; private set; }

        protected Permissao()
        {
            Nome = string.Empty;
            DataCriacao = DateTime.Now;
            PerfilPermissoes = Enumerable.Empty<PerfilPermissao>();
        }

        public Permissao(PermissaoBuilder builder)
        {
            Id = builder.Id;
            Nome = builder.Nome;
            DataCriacao = DateTime.Now;
            PerfilPermissoes = builder.PerfilPermissoes;
        }
    }
}
