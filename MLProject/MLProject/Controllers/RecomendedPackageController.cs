using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MlBL.Interfaces;

namespace MLProject.Controllers
{ 
    [Route("api/RecomendedPackageController")]
    [ApiController]
    public class RecomendedPackageController : ControllerBase
    {
        IRecomendedPackages _PackageRecomended;

        public RecomendedPackageController(IRecomendedPackages PackageRecomended) {

            _PackageRecomended = PackageRecomended;


        }
 
        [HttpGet("{TakeOnlyNums},{LowestCost}", Name = "GetRecommendedPackages")]

            public async Task<ActionResult<List<KeyValuePair<int,PackageScore>>>> GetRecommendedPackages([FromQuery]  HashSet<int>AnalysisList, int TakeOnlyNums=5,   bool LowestCost =true)
               {
                   if (AnalysisList == null)
                        return BadRequest("Analysis List Must Be Assigned!");

                   if (AnalysisList.Count == 0) 
                        return BadRequest("Analysis List Must Be Full");

                   var RecommendedPackages = await _PackageRecomended.GetBestMatchingPackages(AnalysisList, TakeOnlyNums, LowestCost);

                   /*foreach(var r in RecommendedPackages)
                   {
                      if( r.Key == 1) { }
                   }*/

                   return (RecommendedPackages.Count != 0) ? 
                        Ok(RecommendedPackages.ToList()) :  
                        NotFound("No Package Contains Any Of This Analysis In The List!");




               }







    }
}