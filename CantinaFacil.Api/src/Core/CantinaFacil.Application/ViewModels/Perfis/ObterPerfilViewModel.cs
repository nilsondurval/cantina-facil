using CantinaFacil.Application.ViewModels.Usuario;

namespace CantinaFacil.Application.ViewModels.Perfil
{
    public class ObterPerfilViewModel
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public DateTime? DataCriacao { get; set; }
        public IEnumerable<ObterUsuarioViewModel>? Usuarios { get; set; }
        public IEnumerable<ObterPerfilPermissaoViewModel>? PerfilPermissoes { get; set; }
    }
}
