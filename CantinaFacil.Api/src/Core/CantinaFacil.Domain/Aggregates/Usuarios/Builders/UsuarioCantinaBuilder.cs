namespace CantinaFacil.Domain.Aggregates.Usuarios.Builders
{
    public class UsuarioCantinaBuilder : UsuarioBuilder
    {
        public UsuarioCantinaBuilder(int id) : base(id)
        {

        }

        public UsuarioCantina Build()
        {
            return new UsuarioCantina(this);
        }
    }
}