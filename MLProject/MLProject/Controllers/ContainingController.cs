using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MlBL.DTOs;
using MlBL.Interfaces;
using MlBL.Validators.PackagesValidators;

namespace MLProject.Controllers
{
    [Route("api/AnalysisController")]
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

//        [HttpGet("GetAllPackagesPrices")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public async Task<ActionResult<Dictionary<int, double>>> GetAllPackagesPrices()
//        {
//            Dictionary<int, double> PackagesPrices = await _ContainingServices.GetAllPackagesCostAsync();
//            return (PackagesPrices.Count == 0) ? NotFound("No Packages not Found!") : Ok(PackagesPrices);
//        }
//        [HttpGet("{id}", Name = "GetPackagesByID")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public async Task<ActionResult<PackageDTO>> GetPackageByID(int id)
//        {
//            if (id < 0)
//                return BadRequest("Not Accepted ID");
//            PackageDTO? Package = await _ContainingServices.FindByID(id);
//            return (Package == null) ?
//             NotFound($"Package With ID:{id} is not found") : Ok(Package);
//        }


//        [HttpPost(Name = "AddPackage")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [EndpointDescription(@"the enpackage type contain 3 option 1 for vip,2 for normal and 3 for kids.
//the enPackageGender contain 3 options 1 for Men,2 for Women and 3 For All.
//the enPackageStatus Contain 3 Options 1 for Dued,2 for on the market and 3 for soon.
//the enVisit Type Contain 2 Option 1 for free and 2 for paid.")]
//        public async Task<ActionResult<PackageDTO>> AddPackage(CreatePackageDTO newDto)
//        {

//            var result = CreatePackageValidator.ValidateData(newDto);
//            if (!result.IsValid)
//                throw new ValidationException(result.Errors);


//            PackageDTO dto = await _ContainingServices.AddNew(newDto);

//            // analysis.SaveAnalysis();

//            return (dto != null) ? CreatedAtRoute("GetPackageByID", new { ID = dto.PackageID }, dto) : BadRequest("Error");

//        }


//        [HttpPut("{ID}", Name = "UpdatePackage")]
//        [EndpointDescription(@"the enpackage type contain 3 option 1 for vip,2 for normal and 3 for kids.
//the enPackageGender contain 3 options 1 for Men,2 for Women and 3 For All.
//the enPackageStatus Contain 3 Options 1 for Dued,2 for on the market and 3 for soon.
//the enVisit Type Contain 2 Option 1 for free and 2 for paid.")]

//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public async Task<ActionResult<PackageDTO>> UpdatePackage(int ID, UpdatedPackageDto PDTO)
//        {

//            PDTO.PackageID = ID;
//            var result = UpdatePackageValidator.ValidateData(PDTO);
//            if (!result.IsValid)
//                throw new ValidationException(result.Errors);
//            // if update failed cuz the id is wrong
//            return (await _ContainingServices.Update(PDTO)) ?
//                 CreatedAtRoute("GetPackagesByID", new { id = PDTO.PackageID }, PDTO) :
//                 NotFound("There Is No Analysis With Such ID!");
//        }

//        // I think it is better to make it as inactivate the analysis
//        [HttpDelete("{ID}", Name = "DeletePackage")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public async Task<ActionResult<bool>> DeletePackage(int ID)
//        {
//            if (ID < 0)
//                return BadRequest("Incorrect ID");

//            return (await _ContainingServices.Delete(ID)) ?
//                 Ok($"Analysis With ID:{ID} Deleted Successfully!") :
//                 NotFound($"No Analysis With Such ID:{ID},no rows were Deleted!");

//        }



    }





















}

