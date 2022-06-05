//using AutoMapper;
//using Medium.Api.Dtos;
//using Medium.Api.Entities;
//using Medium.Api.Services;
//using Microsoft.AspNetCore.Mvc;

//namespace Medium.Api.Controllers
//{
//    [ApiController]
//    [Route("tag/{programming}")]

//    public class ProgrammingController : ControllerBase
//    {
//        private readonly IMediumApiRepository _mediumInfoRepository;
//        private readonly IMapper _mapper;
//        public ProgrammingController(IMediumApiRepository mediumInfoRepository,
//                IMapper mapper)
//        {
//            _mediumInfoRepository = mediumInfoRepository ??
//                throw new ArgumentNullException(nameof(mediumInfoRepository));
//            _mapper = mapper ??
//                throw new ArgumentNullException(nameof(mapper));
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetTrendingPosts(string programming)
//        {
//            var programmingposts = await _mediumInfoRepository.GetTagPosts(programming);
//            if (programmingposts == null)
//            {
//                return NotFound();
//            }

//            return Ok(_mapper.Map<Postdto>(programmingposts));

//        }

//        [HttpGet("/latest")]
//        public async Task<IActionResult> GetLatestPosts(string programming)
//        {
//            try
//            {
//                var programminglatestposts = await _mediumInfoRepository.GetTagPosts(programming);
//                if (programminglatestposts == null)
//                {
//                    return NotFound();
//                }

//                return Ok(_mapper.Map<Postdto>(programminglatestposts));
//            }

//            catch (Exception)
//            {
//                return StatusCode(500, "ServerUnableToProcessRequrest");
//            }
        
//        }

//        [HttpGet("/latest/top/year")]
//        public async Task<IActionResult> GetBestPostsOfTheYear(string controller)
//        {
//            try
//            {
//                var Bestpostsoftheyear = await _mediumInfoRepository.GetHighestClapWithPost(controller);
//                if (Bestpostsoftheyear == null)
//                {
//                    return NotFound();
//                }

//                return Ok(_mapper.Map<Postdto>(Bestpostsoftheyear));
//            }
//            catch (Exception)
//            {
//                return StatusCode(500, "ServerUnableToProcessRequrest");
//            }

//        }



//    }
//}

