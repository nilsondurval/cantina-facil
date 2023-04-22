using CantinaFacil.Domain.Aggregates.Perfis.Builders;
using CantinaFacil.Shared.Kernel.Domain;

namespace CantinaFacil.Domain.Aggregates.Perfis
{
    public class PerfilPermissao : Entity, IAggregateRoot
    {
        public int PerfilId { get; private set; }
        public int PermissaoId { get; private set; }
        public Perfil Perfil { get; private set; }
        public Permissao Permissao { get; private set; }

        protected PerfilPermissao()
        {
            Id = default;
            PerfilId = default;
            PermissaoId = default;
            Perfil = new PerfilBuilder(0).Build();
            Permissao = new PermissaoBuilder(0).Build();
        }

        public PerfilPermissao(PerfilPermissaoBuilder builder)
        {
            Id = builder.Id;
            PerfilId = builder.PerfilId;
            PermissaoId = builder.PermissaoId;
            Perfil = builder.Perfil;
            Permissao = builder.Permissao;
        }
    }
}
