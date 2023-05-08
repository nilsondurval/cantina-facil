using AutoMapper;
using CantinaFacil.Application.ViewModels.Perfil;
using CantinaFacil.Application.ViewModels.Usuario;
using CantinaFacil.Domain.Aggregates.Perfis;
using CantinaFacil.Domain.Aggregates.Usuarios;

namespace CantinaFacil.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, AdicionarUsuarioViewModel>();
            CreateMap<Usuario, ObterUsuarioViewModel>();
            CreateMap<Usuario, AtualizarUsuarioViewModel>();
            CreateMap<Perfil, ObterPerfilViewModel>();
            CreateMap<Permissao, ObterPermissaoViewModel>();
            CreateMap<PerfilPermissao, ObterPerfilPermissaoViewModel>();
        }
    }
}
