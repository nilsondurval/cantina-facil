using CantinaFacil.Domain.Aggregates.Perfis.Builders;
using CantinaFacil.Domain.Aggregates.Usuarios;
using CantinaFacil.Shared.Kernel.Domain;
using CantinaFacil.Domain.Aggregates.Permissoes;

namespace CantinaFacil.Domain.Aggregates.Perfis
{
    public class PerfilPermissao : Entity, IAggregateRoot
    {
        public int PerfilId { get; private set; }
        public int PermissaoId { get; private set; }
        public Perfil Perfil { get; private set; }
        public Permissao Permissao { get; set; }

        protected PerfilPermissao()
        {

        }

        public PerfilPermissao(PerfilPermissaoBuilder builder)
        {
            Id = builder.Id;
            PerfilId = builder.PerfilId;
            PermissaoId = builder.PermissaoId;
        }
    }
}
