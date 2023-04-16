using CantinaFacil.Shared.Kernel.Domain;
using CantinaFacil.Domain.Aggregates.Perfis;

namespace CantinaFacil.Domain.Aggregates.Permissoes
{
    public class Permissao : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public IEnumerable<PerfilPermissao> PerfilPermissoes { get; private set; }

        protected Permissao()
        {

        }

        public Permissao(int id, string nome)
        {
            Id = id;
            Nome = nome;
            DataCriacao = DateTime.Now;
        }
    }
}
