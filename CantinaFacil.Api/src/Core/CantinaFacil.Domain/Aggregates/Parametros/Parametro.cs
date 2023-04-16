using CantinaFacil.Shared.Kernel.Domain;

namespace CantinaFacil.Domain.Aggregates.Parametros
{
    public class Parametro : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }

        public string Valor { get; private set; }

        public string Descricao { get; private set; }

        protected Parametro() { }

        public Parametro(string valor)
        {
            Valor = valor;
        }
    }
}
