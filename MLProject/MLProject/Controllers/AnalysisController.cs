using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MlBl;
using MlDAL;

namespace MLProject.Controllers
{
    [Route("api/AnalysisController")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {

        [HttpGet("GetAllAnalysis")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<IEnumerable<AnalysisDto>> GetAllAnalysis()
        {
            List<AnalysisDto> analysis = Analysis.GetAll();

            if (analysis.Count == 0)
            {
                return NotFound("No Analysis not Found!");
            }
            return Ok(analysis);



        }

        [HttpGet("{id}", Name = "GetAnalysisByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AnalysisDto> GetAnalysisByID(int id)
        {
            if (id < 0)
            {
                return BadRequest("Not Accepted ID");
            }
            Analysis analysis = Analysis.FindByID(id);
            if (analysis == null)
            {
                return NotFound($"Analysis With ID:{id} is not found");
            }
            AnalysisDto ADTO = analysis.ADTO;
            return Ok(ADTO);


        }
        [HttpPost( Name = "AddAnalysis")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AnalysisDto> AddAnalysis(AnalysisDto ADTO)
        {
            if (ADTO == null || string.IsNullOrEmpty(ADTO.AnalysisName) || ADTO.AnalysisCost < 0)
            {

                return BadRequest("Data is Incomplete!");


            }
            Analysis analysis = new Analysis(ADTO);
            analysis.SaveAnalysis();
            ADTO.AnalysisID = analysis.AnalysisID;
            return CreatedAtRoute("GetAnalysisByID", new { id = ADTO.AnalysisID }, ADTO);


        }

        [HttpPut("{ID}",Name = "UpdateAnalysis")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AnalysisDto> UpdateAnalysis(int ID,AnalysisDto ADTO)
        {
            if (ADTO == null||ID<=0 || string.IsNullOrEmpty(ADTO.AnalysisName) || ADTO.AnalysisCost < 0)
            {

                return BadRequest("Data is Incomplete!");


            }
            Analysis analysis = Analysis.FindByID(ID);
            if (analysis == null)
                return NotFound("There Is No Analysis With Such ID!");
           analysis.AnalysisName = ADTO.AnalysisName;
            analysis.Cost=ADTO.AnalysisCost;
            analysis.SaveAnalysis();
            ADTO = analysis.ADTO;
            return CreatedAtRoute("GetAnalysisByID", new { id = ADTO.AnalysisID }, ADTO);


        }
        [HttpDelete("{ID}", Name = "DeleteAnalysis")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool>DeleteAnalysis(int ID)
        {
            if (ID < 0)
            {
                return BadRequest("Incorrect ID");
            }
          
            if(Analysis.DeleteAnalysis(ID))
          return Ok($"Analysis With ID:{ID} Deleted Succissfully!");
            else
                return NotFound($"No Analysis With Such ID:{ID},no rows were Deleted!");


        }



    }
}
