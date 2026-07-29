using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MlBl;
using MlBL.DTOs;
using MlBL.Interfaces;
using MlBL.Mappers;
using MlBL.Services;
using MlDAL;
using MlDAL.Interfaces;

namespace MLProject.Controllers
{
    [Route("api/AnalysisController")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly IAnalysisService _analysisService;

        public AnalysisController(IAnalysisService analysisService)
        {
            _analysisService = analysisService;
        }


        [HttpGet("GetAllAnalysis")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<AnalysisDto>>> GetAllAnalysis()
        {
            var analysis = await _analysisService.GetAllAsync();

            if (!analysis.Any())
                return NotFound("No Analyses Founded!");

            return Ok(analysis);

        }

        [HttpGet("{id}", Name = "GetAnalysisByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AnalysisDto>> GetAnalysisByID(int Id)
        {
            if (Id <= 0)
                return BadRequest("Not Accepted ID");

            AnalysisDto? analysis = await _analysisService.GetByIdAsync(Id);

            if (analysis == null)
                return NotFound($"Analysis With Id:{Id} is not found");

            return Ok(analysis);

        }

        
        [HttpPost( Name = "AddAnalysis")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AnalysisDto>> AddAnalysis(CreateAnalysisDto newDto) 
        {
            AnalysisDto dto = await _analysisService.AddAsync(newDto);
           

            return CreatedAtRoute("GetAnalysisByID", new { ID = dto.Id},dto);
        }


        [HttpPut("{ID}", Name = "UpdateAnalysis")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AnalysisDto>> UpdateAnalysis(int Id, UpdateAnalysisDto analysisDto)
        {
            analysisDto.Id = Id;
            var dto = analysisDto.ToDto();

            // if update failed cuz the id is wrong
            return (await _analysisService.UpdateAsync(analysisDto)) ?
                CreatedAtRoute("GetAnalysisByID", new { id = analysisDto.Id }, analysisDto) 
                : NotFound("Analysis With Id:{Id} is not found");
        }
        
        // I think it is better to make it as inactivate the analysis
        [HttpDelete("{ID}", Name = "DeleteAnalysis")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeleteAnalysis(int Id)
        {
            if (Id <= 0)
                return BadRequest("Incorrect Id");
          
            return (await _analysisService.DeleteAsync(Id)) ?
                 Ok($"Analysis With ID:{Id} deleted successfully!")
                 : NotFound($"Analysis With Id:{Id} is not found");

        }



    }
}
