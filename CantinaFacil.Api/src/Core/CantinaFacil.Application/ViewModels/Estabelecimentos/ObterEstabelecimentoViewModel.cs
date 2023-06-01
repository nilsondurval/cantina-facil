namespace CantinaFacil.Application.ViewModels.Estabelecimentos
{
    public class ObterEstabelecimentoViewModel
    {
        public int? Id { get; set; }
        public int? UsuarioId { get; set; }
        public string? Nome { get; set; }
        public string? Cnpj { get; set; }

        public IEnumerable<ObterEstabelecimentoProdutoViewModel>? Produtos { get; set; }
    }
}
