using AutoMapper;
using CantinaFacil.Application.ViewModels.Usuario;
using CantinaFacil.Domain.Aggregates.Usuarios;
using CantinaFacil.Application.ViewModels.Perfil;
using CantinaFacil.Domain.Aggregates.Perfis;

namespace CantinaFacil.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AdicionarUsuarioViewModel, Usuario> ();
            CreateMap<ObterUsuarioViewModel, Usuario>();
            CreateMap<AtualizarUsuarioViewModel, Usuario>();
            CreateMap<ObterPerfilViewModel , Perfil> ();
            CreateMap<ObterPermissaoViewModel, Permissao> ();
            CreateMap<ObterPerfilPermissaoViewModel, PerfilPermissao> ();
        }
    }
}
