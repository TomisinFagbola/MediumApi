using AutoMapper;

namespace Medium.Api.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Entities.Post, Dtos.Postdto>();
            CreateMap<Entities.Tag, Dtos.Tagdto>();
            CreateMap<Entities.PostTag, Dtos.PostTagdto>();
            CreateMap<System.Drawing.Image, System.Drawing.Image>();



        }

    }
}
