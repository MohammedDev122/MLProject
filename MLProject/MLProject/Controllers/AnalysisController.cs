using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MlBl;
using MlBL.DTOs;
using MlBL.Interfaces;
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
            List<AnalysisDto> analysis = await _analysisService.GetAllAsync();

            if (analysis.Count == 0)
                return NotFound("No Analysis not Found!");

            return Ok(analysis);

        }

        [HttpGet("{id}", Name = "GetAnalysisByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AnalysisDto>> GetAnalysisByID(int id)
        {
            if (id < 0)
                return BadRequest("Not Accepted ID");

            AnalysisDto? analysis = await _analysisService.GetByIdAsync(id);

            if (analysis == null)
                return NotFound($"Analysis With ID:{id} is not found");

            return Ok(analysis);

        }

        /*
        [HttpPost( Name = "AddAnalysis")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AnalysisDto>> AddAnalysis(CreateAnalysisDTO newDto)
        {
            if (newDto == null || string.IsNullOrEmpty(newDto.AnalysisName) || newDto.AnalysisCost < 0)
                return BadRequest("Data is Incomplete!");

            AnalysisDto dto = await _analysisService.AddAsync(newDto);
           
            // analysis.SaveAnalysis();

            return CreatedAtRoute("GetAnalysisByID", dto);

        }*/

        /*
        [HttpPut("{ID}",Name = "UpdateAnalysis")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AnalysisDto>> UpdateAnalysis(int ID,AnalysisDto analysisDto)
        {
            if (analysisDto == null||ID<=0 || string.IsNullOrEmpty(analysisDto.AnalysisName) || analysisDto.AnalysisCost < 0)
                return BadRequest("Data is Incomplete!");

            // if update failed cuz the id is wrong
            if (await _analysisService.UpdateAsync(analysisDto))
                return CreatedAtRoute("GetAnalysisByID", new { id = analysisDto.AnalysisID }, analysisDto);

            else
                return NotFound("There Is No Analysis With Such ID!");
        }
        */
        // I think it is better to make it as inactivate the analysis
       /* [HttpDelete("{ID}", Name = "DeleteAnalysis")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeleteAnalysis(int ID)
        {
            if (ID < 0)
                return BadRequest("Incorrect ID");
          
            if(await _analysisService.DeleteAsync(ID))
                return Ok($"Analysis With ID:{ID} Deleted Successfully!");

            else
                return NotFound($"No Analysis With Such ID:{ID},no rows were Deleted!");

        }*/



    }
}
