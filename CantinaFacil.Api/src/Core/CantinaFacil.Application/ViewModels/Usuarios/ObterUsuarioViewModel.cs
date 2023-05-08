using CantinaFacil.Application.ViewModels.Perfil;

namespace CantinaFacil.Application.ViewModels.Usuario
{
    public class ObterUsuarioViewModel
    {
        public int? Id { get; set; }
        public int? PerfilId { get; set; }
        public string? Cpf { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public DateTime? DataCriacao { get; set; }
        public ObterPerfilViewModel? Perfil { get; set; }
    }
}
