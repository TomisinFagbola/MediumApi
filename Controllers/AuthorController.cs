using AutoMapper;
using Medium.Api.Dtos;
using Medium.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Medium.Api.Controllers
{
    [ApiController]
    [Route("tag/")]
    public class AuthorController : ControllerBase
    {


        private readonly IMediumApiRepository _mediumInfoRepository;
        private readonly IMapper _mapper;
        public AuthorController(IMediumApiRepository mediumInfoRepository,
                IMapper mapper)
        {
            _mediumInfoRepository = mediumInfoRepository ??
                throw new ArgumentNullException(nameof(mediumInfoRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet("Author")]
        public async Task<IActionResult> GetAuthor()
        {
            var author = await _mediumInfoRepository.AuthorPostsAsync();

            return Ok(_mapper.Map<Authordto>(author));
        }

    }
}
       