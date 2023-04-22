using CantinaFacil.Domain.Aggregates.Perfis.Builders;
using CantinaFacil.Domain.Aggregates.Usuarios;
using CantinaFacil.Shared.Kernel.Domain;

namespace CantinaFacil.Domain.Aggregates.Perfis
{
    public class Perfil : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public IEnumerable<Usuario> Usuarios { get; private set; }
        public IEnumerable<PerfilPermissao> PerfilPermissoes { get; private set; }

        protected Perfil()
        {
            Nome = string.Empty;
            DataCriacao = DateTime.Now;
            Usuarios = Enumerable.Empty<Usuario>();
            PerfilPermissoes = Enumerable.Empty<PerfilPermissao>();
        }

        public Perfil(PerfilBuilder builder)
        {
            Id = builder.Id;
            Nome = builder.Nome;
            DataCriacao = builder.DataCriacao;
            Usuarios = builder.Usuarios;
            PerfilPermissoes = builder.PerfilPermissoes;
        }
    }
}
