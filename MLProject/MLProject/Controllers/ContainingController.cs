using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MlBL.DTOs;
using MlBL.Interfaces;
using MlBL.Validators.ContainingValidator;
using MlBL.Validators.PackagesValidators;
using FluentValidation;


namespace MLProject.Controllers
{
    [Route("api/ContainingController")]
    [ApiController]
    public class ContainingController : ControllerBase
    {

        private readonly IContainingService _ContainingServices;

        public ContainingController(IContainingService ContainingServices)
        {
            _ContainingServices = ContainingServices;
        }


        [HttpGet("GetAllContainings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<StringContainingDTO>>> GetAllContainings()
        {
            List<StringContainingDTO> LContainings = await _ContainingServices.GetAll();
            return (LContainings.Count == 0) ? NotFound(" Containings not Found!") : Ok(LContainings);
        }

        [HttpGet("Package/{PackageID}", Name ="GetAllPackageContains")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<StringContainingDTO>>> GetAllPackageContains(int PackageID)
        {
            if (PackageID <= 0)
                return BadRequest($"ID Isn't Correct!");
            List<StringContainingDTO> LContainings = await _ContainingServices.GetAllPackageContains(PackageID);
            return (LContainings.Count == 0) ? NotFound(" Containings not Found!") : Ok(LContainings);
        }
        [HttpGet("Analysis/{AnalysisID}", Name = "GetAllAnalysisContained")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<StringContainingDTO>>> GetAllAnalysisContained(int AnalysisID)
        {
            if (AnalysisID <= 0)
                return BadRequest($"ID Isn't Correct!");
            List<StringContainingDTO> LContainings = await _ContainingServices.GetAllAnalysisContained(AnalysisID);
            return (LContainings.Count == 0) ? NotFound(" Containings not Found!") : Ok(LContainings);
        }

        [HttpGet("ContainID/{ContainID}", Name = "GetContainByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PackageDTO>> GetContainByID(int ContainID)
        {
            if (ContainID <= 0)
                return BadRequest("Not Accepted ID");
            ContainingDTO? Contain = await _ContainingServices.FindByID(ContainID);
            return (Contain == null) ?
             NotFound($"Package With ID:{ContainID} is not found") : Ok(Contain);
        }


        [HttpPost(Name = "AddContain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PackageDTO>> AddContain(CreateContainingDTO newDto)
        {

            var result = CreateContainingValidator.ValidateData(newDto);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);


            ContainingDTO dto = await _ContainingServices.AddNew(newDto);


            return (dto != null) ? CreatedAtRoute("GetContainByID", new { ID = dto.ContainID }, dto) : BadRequest("Error");

        }



        // I think it is better to make it as inactivate the analysis
        [HttpDelete("ID/{ID}", Name = "DeleteContain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeleteContain(int ID)
        {
            if (ID <= 0)
                return BadRequest("Incorrect ID");

            return (await _ContainingServices.Delete(ID)) ?
                 Ok($"Contain With ID:{ID} Deleted Successfully!") :
                 NotFound($"No Contain With Such ID:{ID},no rows were Deleted!");

        }
        [HttpGet("ExistID/{ExistID}", Name = "Exist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> Exist(int ExistID)
        {
            if (ExistID <= 0)
                return BadRequest("Incorrect ID");

            return (await _ContainingServices.Exist(ExistID)) ?
                 Ok($"Contain With ID:{ExistID} Deleted Successfully!") :
                 NotFound($"No Contain With Such ID:{ExistID},no rows were Deleted!");

        }

        [HttpGet("AnalysisID/{AnalysisID},PackageID/{PackageID}", Name = "ExistByPackageAndAnalysisID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> ExistByPackageAndAnalysisID(int AnalysisID,int PackageID)
        {
            if (AnalysisID <= 0 ||PackageID<=0)
                return BadRequest("Incorrect ID");

            return (await _ContainingServices.Exist(AnalysisID, PackageID)) ?
                 Ok($"Contain That Have Both Analysis With ID:{AnalysisID},And Package With ID{PackageID} Deleted Successfully!") :
                 NotFound($"No Contain  That Have Both Analysis With ID:{AnalysisID},And Package With ID{PackageID},no rows were Deleted!");

        }

        [HttpGet("PackageID/{PackageID}", Name = "GetAllAnalysisInPackageCost")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<double>> AnalysisInPackageCost( int PackageID)
        {
            if ( PackageID <= 0)
                return BadRequest("Incorrect ID");
            double? Cost = await _ContainingServices.GetAllAnalysisInPackageCost(PackageID);
            return ((Cost) !=null) ?
                 Ok(Cost) :
                 NotFound($"No Package with  ID:{PackageID} Recorded in Containig Table");

        }

    }





















}

