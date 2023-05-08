using CantinaFacil.Application.ViewModels.Perfil;
using System;
using System.Collections.Generic;

namespace CantinaFacil.Application.ViewModels.Usuario
{
    public class ObterPermissaoViewModel
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public DateTime? DataCriacao { get; set; }
        public IEnumerable<ObterPerfilPermissaoViewModel>? PerfilPermissoes { get; set; }
    }
}
