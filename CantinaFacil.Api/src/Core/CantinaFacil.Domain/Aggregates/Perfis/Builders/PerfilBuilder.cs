using CantinaFacil.Domain.Aggregates.Usuarios;
using CantinaFacil.Shared.Kernel.Domain.Enums;
using CantinaFacil.Shared.Kernel.Domain;

namespace CantinaFacil.Domain.Aggregates.Perfis.Builders
{
    public class PerfilBuilder : Builder
    {
        public string Nome { get; private set; }
        public DateTime DataCriacao { get; private set; }

        public IEnumerable<Usuario> Usuarios { get; private set; }

        public IEnumerable<PerfilPermissao> PerfilPermissoes { get; private set; }

        public PerfilBuilder(PerfilEnum id)
        {
            Id = (int)id;
            Nome = string.Empty;
            DataCriacao = DateTime.Now;
            Usuarios = Enumerable.Empty<Usuario>();
            PerfilPermissoes = Enumerable.Empty<PerfilPermissao>();
        }

        public PerfilBuilder AddNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public PerfilBuilder AddUsuarios(IEnumerable<Usuario> usuarios)
        {
            Usuarios = usuarios;
            return this;
        }

        public PerfilBuilder AddPerfilPermissoes(IEnumerable<PerfilPermissao> perfilPermissoes)
        {
            PerfilPermissoes = perfilPermissoes;
            return this;
        }

        public Perfil Build()
        {
            return new Perfil(this);
        }
    }
}