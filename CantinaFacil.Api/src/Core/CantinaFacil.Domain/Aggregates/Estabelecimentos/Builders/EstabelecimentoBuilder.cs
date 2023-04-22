using CantinaFacil.Domain.Aggregates.Usuarios;
using CantinaFacil.Domain.Aggregates.Usuarios.Builders;
using CantinaFacil.Shared.Kernel.Domain;

namespace CantinaFacil.Domain.Aggregates.Estabelecimentos.Builders
{
    public class EstabelecimentoBuilder : Builder
    {
        public int UsuarioId { get; private set; }
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }

        public UsuarioCantina Usuario { get; private set; }

        public IEnumerable<Produto> Produtos { get; private set; }

        public EstabelecimentoBuilder(int id)
        {
            Id = id;
            UsuarioId = default;
            Nome = string.Empty;
            Cnpj = string.Empty;
            Usuario = new UsuarioCantinaBuilder(0).Build();
            Produtos = Enumerable.Empty<Produto>();
        }

        public EstabelecimentoBuilder AddUsuarioId(int usuarioId)
        {
            UsuarioId = usuarioId;
            return this;
        }

        public EstabelecimentoBuilder AddNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public EstabelecimentoBuilder AddCnpj(string cnpj)
        {
            Cnpj = cnpj;
            return this;
        }

        public EstabelecimentoBuilder AddUsuario(UsuarioCantina usuario)
        {
            Usuario = usuario;
            return this;
        }

        public EstabelecimentoBuilder AddProdutos(IEnumerable<Produto> produtos)
        {
            Produtos = produtos;
            return this;
        }

        public Estabelecimento Build()
        {
            return new Estabelecimento(this);
        }
    }
}
