using AutoMapper;
using backmaree.Models;
using backmaree.Modelsdtos.Commons;
using backmaree.Modelsdtos.Stock;
using backmaree.Modelsdtos.Users;

namespace backmaree.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<AddUser, User>().ReverseMap();
            CreateMap<EditUser, User>().ReverseMap();
            CreateMap<UserPerfil, PerfilModel>().ReverseMap();
            CreateMap<LoggModel, UserLog>().ReverseMap();

            //stock
           
            CreateMap<Producto, ProductoBaseDto>().ReverseMap();
            CreateMap<ProductoBase, ProductoBaseDto>().ReverseMap();
            CreateMap<ProductoDetalle, ProductoBaseDto>().ReverseMap();

        }
    }
}