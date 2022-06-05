using AutoMapper;
using Medium.Api.Dtos;
using Medium.Api.Entities;
using Medium.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Medium.Api.Controllers
{
    [ApiController]
    [Route("/")]


    public class MediumController : ControllerBase
    {

            private readonly IMediumApiRepository _mediumInfoRepository;
            private readonly IMapper _mapper;

            public MediumController(IMediumApiRepository mediumInfoRepository,
                IMapper mapper)
            {
                _mediumInfoRepository = mediumInfoRepository ??
                    throw new ArgumentNullException(nameof(mediumInfoRepository));
                _mapper = mapper ??
                    throw new ArgumentNullException(nameof(mapper));
            }

            [HttpGet]
            public async Task<IActionResult> GetPosts()
            {
                var posts = await _mediumInfoRepository.GetPosts();

            return Ok(_mapper.Map<IEnumerable<Postdto>>(posts));

            foreach (var post in posts)
            {
                return Ok(_mapper.Map<Picturedto>(post.pic));
            }


                //var results = new List<CityWithoutPointsOfInterestDto>();

                //foreach (var cityEntity in cityEntities)
                //{
                //    results.Add(new CityWithoutPointsOfInterestDto
                //    {
                //        Id = cityEntity.Id,
                //        Description = cityEntity.Description,
                //        Name = cityEntity.Name
                //    });
                //}

                return Ok(_mapper.Map<IEnumerable<Postdto>>(posts));
                //return Ok(_mapper.Map<Picturedto>(posts.pic)*/
            }

        //    [HttpGet("{id}")]
        //    public IActionResult GetCity(int id)
        //    {
        //        var city = _cityInfoRepository.GetPostt(id, includePointsOfInterest);

        //        if (city == null)
        //        {
        //            return NotFound();
        //        }

        //        if (includePointsOfInterest)
        //        {
        //            return Ok(_mapper.Map<CityDto>(city));
        //        }

        //        return Ok(_mapper.Map<CityWithoutPointsOfInterestDto>(city));
        //    }

        [HttpGet("/image")]
        public ActionResult<Image> GetAllImages()
        {
            Image img = _mediumInfoRepository.LoadImage();
            return Ok(img);
        }
    }

    
}
