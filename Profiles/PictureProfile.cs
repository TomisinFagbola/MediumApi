using AutoMapper;

namespace Medium.Api.Profiles
{
    public class PictureProfile : Profile
    {
        public PictureProfile()
        {
            CreateMap<Entities.Picture, Dtos.Picturedto>();

        }
    }
}