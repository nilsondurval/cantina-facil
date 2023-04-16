using CantinaFacil.Shared.Kernel.Domain;

namespace CantinaFacil.Domain.Aggregates.Perfis.Builders
{
    public class PerfilPermissaoBuilder : Builder
    {
        public int PerfilId { get; private set; }
        public int PermissaoId { get; private set; }

        public PerfilPermissaoBuilder(int id)
        {
            Id = id;
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

        public PerfilPermissao Build()
        {
            return new PerfilPermissao(this);
        }
    }
}