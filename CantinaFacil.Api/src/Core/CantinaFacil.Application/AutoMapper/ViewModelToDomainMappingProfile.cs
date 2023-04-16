using AutoMapper;
using CantinaFacil.Application.ViewModels.Usuario;
using CantinaFacil.Domain.Aggregates.Usuarios;
using CantinaFacil.Application.ViewModels.Perfil;
using CantinaFacil.Domain.Aggregates.Perfis;
using CantinaFacil.Domain.Aggregates.Permissoes;

namespace CantinaFacil.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioViewModel, Usuario> ();
            CreateMap<PerfilViewModel , Perfil> ();
            CreateMap<PermissaoViewModel, Permissao> ();
            CreateMap<PerfilPermissaoViewModel, PerfilPermissao> ();
        }
    }
}
