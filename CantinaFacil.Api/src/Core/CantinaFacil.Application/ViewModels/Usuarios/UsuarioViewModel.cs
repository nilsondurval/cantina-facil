using CantinaFacil.Application.ViewModels.Perfil;
using System;
using System.Collections.Generic;

namespace CantinaFacil.Application.ViewModels.Usuario
{
    public class UsuarioViewModel
    {
        public int PerfilId { get; set; }
        public string? Cpf { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public DateTime? DataCriacao { get; set; }
        public PerfilViewModel? Perfil { get; set; }
    }
}
