using AutoMapper;
using Medium.Api.Dtos;
using Medium.Api.Entities;
using Medium.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Medium.Api.Controllers
{
    [ApiController]
    [Route("tag/leadership")]
    
    public class LeadershipController : ControllerBase
    {
        
        
        private readonly IMediumApiRepository _mediumInfoRepository;
        private readonly IMapper _mapper;
        public LeadershipController(IMediumApiRepository mediumInfoRepository,
                IMapper mapper)
        {
            _mediumInfoRepository = mediumInfoRepository ??
                throw new ArgumentNullException(nameof(mediumInfoRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("")]
        public async Task<IActionResult> GetTrendingPosts()
        {
            var leadershipposts = await _mediumInfoRepository.GetTag1Posts();
            if (leadershipposts == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Tagdto>(leadershipposts));
            
        }

        [HttpGet("/latest")]
        public async Task<IActionResult> GetLatestPosts()
        {
            try
            {
                var leadershiplatestposts = await _mediumInfoRepository.GetTagPosts();
                if (leadershiplatestposts == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<Tagdto>(leadershiplatestposts));
            }
            catch (Exception)
            {
                return StatusCode(500, "ServerUnableToProcessRequrest");
            }
        }

        [HttpGet("/latest/top/year")]
        public async Task<IActionResult> GetBestPostsOfTheYear()
        {
            try
            {
                var Bestpostsoftheyear =  await _mediumInfoRepository.GetHighestClapWithPost();
                if (Bestpostsoftheyear == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<Tagdto>(Bestpostsoftheyear));
            }
            catch (Exception)
            {
                return StatusCode(500, "ServerUnableToProcessRequrest");
            }

        }



    }
}
