using AutoMapper;

namespace Medium.Api.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Entities.Author, Dtos.Authordto>();

        }
    }
}
