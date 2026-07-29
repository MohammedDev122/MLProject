using Microsoft.AspNetCore.Mvc;
using MlBL.DTOs;
using MlBL.Interfaces;
using MlBL.Services;

namespace MLProject.Controllers
{
    [Route("api/RegionController")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpGet("GetAllRegions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<RegionDto>>> GetAllRegions()
        {
            var regions = await _regionService.GetAllAsync();

            return (regions.Any()) ?
                Ok(regions)
                : NotFound("No regions founded");
        }


        [HttpGet("{Id}", Name = "GetRegionById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RegionDto>> GetRegionById(int Id)
        {
            if (Id <= 0)
                return BadRequest("Not Accepted Id");

            var region = await _regionService.GetByIdAsync(Id);


            return (region != null) ? Ok(region) :
                NotFound($"Region with Id:{Id} is not founded");
        }

        [HttpGet("{Id}/Lab", Name = "GetRegionLabs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<LabDto>>> GetRegionLabs (int Id)
        {
            if (Id <= 0)
                return BadRequest("Not Accepted Id");

            var labs = await _regionService.GetAllLabsAsync(Id);

            return (labs.Any()) ? Ok(labs) :
                NotFound($"Region with this Id:{Id} has no labs");
        }


        [HttpPost(Name = "AddRegion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RegionDto>> AddRegion (RegionDto region)
        {
            var dto = await _regionService.AddAsync(region);

            return CreatedAtRoute("GetRegionById", new { Id = dto.RegionID }, dto);
        }

        [HttpPut("{Id}", Name = "UpdateRegion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RegionDto>> UpdateRegion(int Id, RegionDto dto)
        {
            dto.RegionID = Id;

            return (await _regionService.UpdateAsync(dto)) ?
                CreatedAtRoute("GetRegionById", new { Id = dto.RegionID }, dto) :
                NotFound($"Region with Id:{Id} is not founded");
        }

        [HttpDelete("{Id}", Name = "DeleteRegion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeleteRegion (int Id)
        {
            if (Id <= 0)
                return BadRequest("Not Accepted Id");

            return (await _regionService.DeleteAsync(Id)) ?
                Ok($"Region with Id:{Id} deleted successfully")
                : NotFound($"Region with Id:{Id} is not found");
        }

    }
}
