using CantinaFacil.Domain.Aggregates.Perfis;
using CantinaFacil.Domain.Aggregates.Usuarios.Builders;
using CantinaFacil.Shared.Kernel.Domain;

namespace CantinaFacil.Domain.Aggregates.Usuarios
{
    public partial class Usuario : Entity, IAggregateRoot
    {
        public int PerfilId { get; private set; }
        public string Cpf { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Telefone { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public Perfil Perfil { get; private set; }

        protected Usuario()
        {
            
        }

        public Usuario(UsuarioBuilder builder)
        {
            Id = builder.Id;
            PerfilId = builder.PerfilId;
            Cpf = builder.Cpf;
            Nome = builder.Nome;
            Email = builder.Email;
            Senha = builder.Senha;
            Telefone = builder.Telefone;
            Perfil = builder.Perfil;
            DataCriacao = DateTime.Now;
        }
    }
}
