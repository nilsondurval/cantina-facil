using CantinaFacil.Domain.Aggregates.Perfis.Builders;
using CantinaFacil.Shared.Kernel.Domain;

namespace CantinaFacil.Domain.Aggregates.Perfis.Builders
{
    public class PerfilPermissaoBuilder : Builder
    {
        public int PerfilId { get; private set; }
        public int PermissaoId { get; private set; }
        public Perfil Perfil { get; private set; }
        public Permissao Permissao { get; private set; }

        public PerfilPermissaoBuilder(int id)
        {
            Id = id;
            PerfilId = default;
            PermissaoId = default;
            Perfil = new PerfilBuilder(0).Build();
            Permissao = new PermissaoBuilder(0).Build();
        }

        public PerfilPermissaoBuilder AddPerfilId(int idPerfil)
        {
            PerfilId = idPerfil;
            return this;
        }

        public PerfilPermissaoBuilder AddPermissaoId(int idPermissao)
        {
            PermissaoId = idPermissao;
            return this;
        }

        public PerfilPermissaoBuilder AddPerfil(Perfil perfil)
        {
            Perfil = perfil;
            return this;
        }

        public PerfilPermissaoBuilder AddPermissao(Permissao permissao)
        {
            Permissao = permissao;
            return this;
        }

        public PerfilPermissao Build()
        {
            return new PerfilPermissao(this);
        }
    }
}