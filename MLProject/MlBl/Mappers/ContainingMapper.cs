using Core.Models;
using MlBL.DTOs;
using MlBL.Interfaces;
using MlBL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBL.Mappers
{
    public static class ContainingMapper
    {
    

        public static ContainingDTO ToContainigDTO(this Containing containing)
        {

            return new ContainingDTO(containing.ContainID, containing.PackageID, containing.AnalysisID);



        }
        public static async Task<StringContainingDTO> TOStringContainingDTO(this Containing containing,IPackagesService IPService,IAnalysisService IAService)
        {
            var PResult =await IPService.FindByID(containing.PackageID);
            var AResult=await IAService.GetByIdAsync(containing.AnalysisID);
            return new StringContainingDTO(containing.ContainID, PResult.PackageName, AResult.AnalysisName);



        }

        public static CreateContainingDTO ToCreateContainigDTO(this Containing containing)
        {

            return new CreateContainingDTO(containing.PackageID, containing.AnalysisID);



        }

        public static async Task<Containing> ToEntity(this StringContainingDTO containing,IContainingService ICService)
        {
            
            var Result = await ICService.FindByID(containing.ContainID);
            return (Result==null)?null : new Containing(Convert.ToInt32(Result.ContainID), Result.PackageID, Result.AnalysisID);



        }

        public static async Task<Containing> ToEntity(this CreateContainingDTO containing)
        {

            return  new Containing(0,containing.PackageID, containing.AnalysisID);



        }


        public static async Task<Containing> ToEntity(this ContainingDTO containing)
        {

            return new Containing(containing.ContainID??0, containing.PackageID, containing.AnalysisID);



        }






    }
}
