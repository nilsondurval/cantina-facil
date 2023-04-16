using CantinaFacil.Application.ViewModels.Usuario;

namespace CantinaFacil.Application.ViewModels.Perfil
{
    public class PerfilViewModel
    {
        public string? Nome { get; private set; }
        public DateTime? DataCriacao { get; private set; }
        public IEnumerable<UsuarioViewModel>? Usuarios { get; private set; }
        public IEnumerable<PerfilPermissaoViewModel>? PerfilPermissoes { get; private set; }
    }
}
