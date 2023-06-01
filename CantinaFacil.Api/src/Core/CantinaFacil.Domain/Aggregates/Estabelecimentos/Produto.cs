using CantinaFacil.Domain.Aggregates.Estabelecimentos.Builders;
using CantinaFacil.Shared.Kernel.Domain;

namespace CantinaFacil.Domain.Aggregates.Estabelecimentos
{
    public class Produto : Entity, IAggregateRoot
    {
        public int EstabelecimentoId { get; private set; }
        public string Nome { get; private set; }
        public decimal Valor { get; private set; }

        public Estabelecimento? Estabelecimento { get; private set; }

        protected Produto()
        {
            Id = default;
            EstabelecimentoId = default;
            Nome = string.Empty;
            Valor = default;
        }

        public Produto(ProdutoBuilder builder)
        {
            Id = builder.Id;
            EstabelecimentoId = builder.EstabelecimentoId;
            Nome = builder.Nome;
            Valor = builder.Valor;
            Estabelecimento = builder.Estabelecimento;
        }

        public void AtribuirEstabelecimento(int estabelecimentoId)
        {
            EstabelecimentoId = estabelecimentoId;
        }

        public void AtribuirId(int produtoId)
        {
            Id = produtoId;
        }
    }
}
