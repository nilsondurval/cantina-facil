using CantinaFacil.Shared.Kernel.Domain;

namespace CantinaFacil.Domain.Aggregates.Parametros.Builders
{
    public class ParametroBuilder : Builder
    {
        public string Nome { get; private set; }
        public string Valor { get; private set; }
        public string Descricao { get; private set; }

        public ParametroBuilder(int id)
        {
            Id = id;
            Nome = string.Empty;
            Valor = string.Empty;
            Descricao = string.Empty;
        }

        public ParametroBuilder AddNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public ParametroBuilder AddValor(string valor)
        {
            Valor = valor;
            return this;
        }

        public ParametroBuilder AddDescricao(string descricao)
        {
            Descricao = descricao;
            return this;
        }

        public Parametro Build()
        {
            return new Parametro(this);
        }
    }
}
