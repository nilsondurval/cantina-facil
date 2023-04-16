﻿using CantinaFacil.Application.ViewModels.Perfil;
using System;
using System.Collections.Generic;

namespace CantinaFacil.Application.ViewModels.Usuario
{
    public class PermissaoViewModel
    {
        public string? Nome { get; private set; }
        public DateTime? DataCriacao { get; private set; }
        public IEnumerable<PerfilPermissaoViewModel>? PerfilPermissoes { get; private set; }
    }
}
