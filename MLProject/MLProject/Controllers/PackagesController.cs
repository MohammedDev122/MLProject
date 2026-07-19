using Core.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MlBL.DTOs;
using MlBL.Interfaces;
using MlBL.Services;
using MlBL.Validators.PackagesValidators;
using MlDAL.Repositories;

namespace MLProject.Controllers
{
    [Route("api/PackagesController")]
    [ApiController]
    public class PackagesController : ControllerBase

    {
        private readonly IPackagesService _PackagesService;
      
    public PackagesController(IPackagesService packagesService)
    {
        _PackagesService = packagesService;
    }


    [HttpGet("GetAllPackages")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<PackageDTO>>> GetAllPackages()
    {
        List<PackageDTO> Packages = await _PackagesService.GetAll();
            return (Packages.Count == 0)?NotFound("No Packages not Found!"):Ok(Packages);
        }

        [HttpGet("GetAllPackagesPrices")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Dictionary<int,double>>> GetAllPackagesPrices()
        {
            Dictionary<int,double> PackagesPrices = await _PackagesService.GetAllPackagesCostAsync();
            return (PackagesPrices.Count == 0) ? NotFound("No Packages not Found!") : Ok(PackagesPrices);
        }
        [HttpGet("{id}", Name = "GetPackagesByID")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PackageDTO>> GetPackageByID(int id)
    {
        if (id < 0)
            return BadRequest("Not Accepted ID");
        PackageDTO? Package = await _PackagesService.FindByID(id);
            return (Package == null)?
             NotFound($"Package With ID:{id} is not found"): Ok(Package);
    }


        [HttpPost(Name = "AddPackage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [EndpointDescription(@"the enpackage type contain 3 option 1 for vip,2 for normal and 3 for kids.
the enPackageGender contain 3 options 1 for Men,2 for Women and 3 For All.
the enPackageStatus Contain 3 Options 1 for Dued,2 for on the market and 3 for soon.
the enVisit Type Contain 2 Option 1 for free and 2 for paid.")]
        public async Task<ActionResult<PackageDTO>> AddPackage(CreatePackageDTO newDto)
        {
             
            var result =CreatePackageValidator.ValidateData(newDto);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);
            

            PackageDTO dto = await _PackagesService.AddNew(newDto);

            // analysis.SaveAnalysis();

            return (dto!=null)? CreatedAtRoute("GetPackageByID", new { ID = dto.PackageID }, dto):BadRequest("Error");

        }


        [HttpPut("{ID}", Name = "UpdatePackage")]
        [EndpointDescription(@"the enpackage type contain 3 option 1 for vip,2 for normal and 3 for kids.
the enPackageGender contain 3 options 1 for Men,2 for Women and 3 For All.
the enPackageStatus Contain 3 Options 1 for Dued,2 for on the market and 3 for soon.
the enVisit Type Contain 2 Option 1 for free and 2 for paid.")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PackageDTO>> UpdatePackage(int ID, UpdatedPackageDto PDTO)
        {
  
            PDTO.PackageID = ID;
            var result = UpdatePackageValidator.ValidateData(PDTO);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);
            // if update failed cuz the id is wrong
            return (await _PackagesService.Update(PDTO))?
                 CreatedAtRoute("GetPackagesByID", new { id = PDTO.PackageID }, PDTO):
                 NotFound("There Is No Analysis With Such ID!");
        }

        // I think it is better to make it as inactivate the analysis
        [HttpDelete("{ID}", Name = "DeletePackage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeletePackage(int ID)
        {
            if (ID < 0)
                return BadRequest("Incorrect ID");

            return (await _PackagesService.Delete(ID))?
                 Ok($"Analysis With ID:{ID} Deleted Successfully!"):
                 NotFound($"No Analysis With Such ID:{ID},no rows were Deleted!");

        }



    }
}
