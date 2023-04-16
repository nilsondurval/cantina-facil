using CantinaFacil.Domain.Aggregates.Usuarios;
using CantinaFacil.Domain.Aggregates.Usuarios.Builders;
using CantinaFacil.Shared.Kernel.Domain.Enums;
using CantinaFacil.Shared.Kernel.Domain;

namespace CantinaFacil.Domain.Aggregates.Perfis.Builders
{
    public class PerfilBuilder : Builder
    {
        public string Nome { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public List<Usuario> Usuarios { get; private set; }

        public PerfilBuilder(PerfilEnum id)
        {
            Id = (int)id;
        }

        public PerfilBuilder AddNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public PerfilBuilder AddUsuario(UsuarioBuilder usuarioBuilder)
        {
            if (Usuarios == null)
                Usuarios = new List<Usuario>();

            var usuariosAdicionar = new List<Usuario>();
            usuariosAdicionar.Add(usuarioBuilder.Build());
            Usuarios = Usuarios.Concat(usuariosAdicionar).ToList();
            return this;
        }

        public Perfil Build()
        {
            return new Perfil(this);
        }
    }
}