using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MlBL.DTOs;
using MlBL.Interfaces;

namespace MLProject.Controllers
{
    [Route("api/LabController")]
    [ApiController]
    public class LabController : ControllerBase
    {
        private readonly ILabService _labService;

        public LabController(ILabService labService)
        {
            _labService = labService;
        }

        [HttpGet("GetAllLabs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<LabDto>>> GetAllLabs()
        {
            var labs = await _labService.GetAllAsync();

            return (labs.Any()) ?
                 Ok(labs) :
                    NotFound("No labs founded");
                
        }

        [HttpGet("{Id}", Name = "GetLabById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LabDto>> GetLabById (int Id)
        {
            if (Id <= 0)
                return BadRequest("Not Accepted Id");

            var lab = await _labService.GetByIdAsync(Id);

            return (lab != null) ?
                 Ok(lab) :
                    NotFound($"Lab with Id:{Id} is not founded");
        }


        [HttpPost(Name = "AddLab")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LabDto>> AddLab (LabDto lab)
        {
            var dto = await _labService.AddAsync(lab);

            return CreatedAtRoute("GetLabById", new { Id = dto.Id }, dto);
        }

        [HttpPut("{Id}", Name = "UpdateLab")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LabDto>> UpdateLab (int Id, LabDto dto)
        { 
            dto.Id = Id;

            return (await _labService.UpdateAsync(dto)) ?
                CreatedAtRoute("GetLabById", new { Id = dto.Id }, dto)
                : NotFound($"Lab with Id:{Id} is not found");
        }

        [HttpDelete("{Id}", Name = "DeleteLab")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeleteLab (int Id)
        {
            if (Id <= 0)
                return BadRequest("Incorrect Id");

            return (await _labService.DeleteAsync(Id)) ?
                Ok($"Lab with Id:{Id} deleted successfully")
                : NotFound($"Lab with Id:{Id} is not found");
        }

    }
}
