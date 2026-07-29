using Core.Models;
using Microsoft.AspNetCore.Mvc;
using MlBL.DTOs;
using MlBL.Interfaces;
using MlBL.Services;

namespace MLProject.Controllers
{

    [Route("api/CityController")]
    [ApiController]
    public class CityController : ControllerBase    
    {

        private readonly ICityService _cityService;

        public CityController (ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("GetAllCities")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetAllCities()
        {
            var cities = await _cityService.GetAllAsync();

            return (cities.Any()) ?
                Ok(cities)
                : NotFound("No cities founded");
        }


        [HttpGet("{Id}", Name = "GetCityById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CityDto>> GetCityById(int Id)
        {
            if (Id <= 0)
                return BadRequest("Not Accepted Id");

            var city = await _cityService.GetByIdAsync(Id);

            return (city != null) ? Ok(city) :
                NotFound($"City with this Id:{Id} is not founded");
        }

        [HttpGet("{Id}/Regions", Name = "GetCityRegions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<RegionDto>>> GetCityRegions(int Id)
        {
            if (Id <= 0)
                return BadRequest("Not Accepted Id");

            var regions = await _cityService.GetAllRegionsAsync(Id);

            return (regions != null) ? Ok(regions) :
                NotFound($"City with Id:{Id} has no regions");
        }


        [HttpPost(Name = "AddCity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CityDto>> AddCity(CityDto city)
        {
            var dto = await _cityService.AddAsync(city);

            return CreatedAtRoute("GetCityById", new { Id = dto.CityId }, dto);
        }

        [HttpPut("{Id}", Name = "UpdateCity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CityDto>> UpdateCity(int Id, CityDto dto)
        {
            if (Id <= 0)
                return BadRequest("Not Accepted Id");

            return (await _cityService.UpdateAsync(dto)) ?
                CreatedAtRoute("GetCityById", new { Id = dto.CityId }, dto) :
                NotFound($"City with Id:{Id} is not founded");
        }

        [HttpDelete("{Id}", Name = "DeleteCity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeleteCity(int Id)
        {
            if (Id <= 0)
                return BadRequest("Not Accepted Id");


            return (await _cityService.DeleteAsync(Id)) ?
                Ok($"City with Id:{Id} deleted successfully")
                : NotFound($"City with Id:{Id} is not found");
        }

    }
}
