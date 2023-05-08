using CantinaFacil.Domain.Aggregates.Perfis;
using CantinaFacil.Shared.Kernel.Domain;

namespace CantinaFacil.Domain.Aggregates.Perfis.Builders
{
    public class PermissaoBuilder : Builder
    {
        public string Nome { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public IEnumerable<PerfilPermissao> PerfilPermissoes { get; private set; }

        public PermissaoBuilder(int id)
        {
            Id = id;
            Nome = string.Empty;
            PerfilPermissoes = Enumerable.Empty<PerfilPermissao>();
        }

        public PermissaoBuilder AddNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public PermissaoBuilder AddPerfilPermissoes(IEnumerable<PerfilPermissao> perfilPermissoes)
        {
            PerfilPermissoes = perfilPermissoes;
            return this;
        }

        public Permissao Build()
        {
            return new Permissao(this);
        }
    }
}
