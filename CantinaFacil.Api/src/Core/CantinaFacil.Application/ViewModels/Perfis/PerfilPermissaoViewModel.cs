using CantinaFacil.Application.ViewModels.Usuario;

namespace CantinaFacil.Application.ViewModels.Perfil
{
    public class PerfilPermissaoViewModel
    {
        public Guid PerfilId { get; private set; }
        public Guid PermissaoId { get; private set; }
        public PerfilViewModel? Perfil { get; private set; }
        public PermissaoViewModel? Permissao { get; set; }
    }
}
