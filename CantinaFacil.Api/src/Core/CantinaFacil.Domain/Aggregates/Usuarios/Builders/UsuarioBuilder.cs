using CantinaFacil.Domain.Aggregates.Perfis;
using CantinaFacil.Domain.Aggregates.Perfis.Builders;
using CantinaFacil.Shared.Kernel.Domain;
using CantinaFacil.Shared.Kernel.Domain.Enums;

namespace CantinaFacil.Domain.Aggregates.Usuarios.Builders
{
    public class UsuarioBuilder : Builder
    {
        public int PerfilId { get; private set; }
        public string Cpf { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Telefone { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public Perfil Perfil { get; private set; }
        
        public UsuarioBuilder(int id)
        {
            Id = id;
        }

        public UsuarioBuilder AddPerfilId(PerfilEnum idPerfil)
        {
            PerfilId = (int)idPerfil;
            return this;
        }

        public UsuarioBuilder AddCpf(string cpf)
        {
            Cpf = cpf;
            return this;
        }

        public UsuarioBuilder AddNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public UsuarioBuilder AddEmail(string email)
        {
            Email = email;
            return this;
        }

        public UsuarioBuilder AddSenha(string senha)
        {
            Senha = senha;
            return this;
        }

        public UsuarioBuilder AddTelefone(string telefone)
        {
            Telefone = telefone;
            return this;
        }

        public UsuarioBuilder AddDataCriacao(DateTime dataCriacao)
        {
            DataCriacao = dataCriacao;
            return this;
        }

        public UsuarioBuilder AddPerfil(PerfilBuilder perfilBuilder)
        {
            Perfil = perfilBuilder.Build();
            return this;
        }

        public Usuario Build()
        {
            return new Usuario(this);
        }
    }
}