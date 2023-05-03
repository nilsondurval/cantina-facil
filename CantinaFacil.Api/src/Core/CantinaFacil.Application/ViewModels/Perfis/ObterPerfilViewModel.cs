using CantinaFacil.Application.ViewModels.Usuario;

namespace CantinaFacil.Application.ViewModels.Perfil
{
    public class ObterPerfilViewModel
    {
        public string? Nome { get; private set; }
        public DateTime? DataCriacao { get; private set; }
        public IEnumerable<ObterUsuarioViewModel>? Usuarios { get; private set; }
        public IEnumerable<ObterPerfilPermissaoViewModel>? PerfilPermissoes { get; private set; }
    }
}
