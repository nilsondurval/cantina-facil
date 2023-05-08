using CantinaFacil.Domain.Aggregates.Parametros.Builders;
using CantinaFacil.Shared.Kernel.Domain;

namespace CantinaFacil.Domain.Aggregates.Parametros
{
    public class Parametro : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Valor { get; private set; }
        public string Descricao { get; private set; }

        protected Parametro()
        {
            Id = default;
            Nome = string.Empty;
            Valor = string.Empty;
            Descricao = string.Empty;
        }

        public Parametro(ParametroBuilder builder)
        {
            Id = builder.Id;
            Nome = builder.Nome;
            Valor = builder.Valor;
            Descricao = builder.Descricao;
        }
    }
}
