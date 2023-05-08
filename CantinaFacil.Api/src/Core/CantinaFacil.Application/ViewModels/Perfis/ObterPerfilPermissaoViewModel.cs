using CantinaFacil.Application.ViewModels.Usuario;

namespace CantinaFacil.Application.ViewModels.Perfil
{
    public class ObterPerfilPermissaoViewModel
    {
        public int? Id { get; set; }
        public Guid? PerfilId { get; set; }
        public Guid? PermissaoId { get; set; }
        public ObterPerfilViewModel? Perfil { get; set; }
        public ObterPermissaoViewModel? Permissao { get; set; }
    }
}
