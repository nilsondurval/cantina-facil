using CantinaFacil.Domain.Aggregates.Usuarios;
using CantinaFacil.Domain.Aggregates.Usuarios.Builders;
using CantinaFacil.Shared.Kernel.Domain;

namespace CantinaFacil.Domain.Aggregates.Estabelecimentos.Builders
{
    public class ProdutoBuilder : Builder
    {
        public int EstabelecimentoId { get; private set; }
        public string Nome { get; private set; }
        public decimal Valor { get; private set; }

        public Estabelecimento Estabelecimento { get; private set; }

        public ProdutoBuilder(int id)
        {
            Id = id;
            EstabelecimentoId = default;
            Nome = string.Empty;
            Valor = default;
            Estabelecimento = new EstabelecimentoBuilder(0).Build();
        }

        public ProdutoBuilder AddEstabelecimentoId(int estabelecimentoId)
        {
            EstabelecimentoId = estabelecimentoId;
            return this;
        }

        public ProdutoBuilder AddNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public ProdutoBuilder AddValor(decimal valor)
        {
            Valor = valor;
            return this;
        }

        public ProdutoBuilder AddEstabelecimento(Estabelecimento estabelecimento)
        {
            Estabelecimento = estabelecimento;
            return this;
        }

        public Produto Build()
        {
            return new Produto(this);
        }
    }
}
