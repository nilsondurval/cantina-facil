using CantinaFacil.Application.ViewModels.Usuario;

namespace CantinaFacil.Application.ViewModels.Perfil
{
    public class ObterPerfilPermissaoViewModel
    {
        public Guid PerfilId { get; private set; }
        public Guid PermissaoId { get; private set; }
        public ObterPerfilViewModel? Perfil { get; private set; }
        public ObterPermissaoViewModel? Permissao { get; set; }
    }
}
