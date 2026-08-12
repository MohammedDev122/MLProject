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
    

        public static ContainingDTO ToContainigDTO(this Containings containing)
        {

            return new ContainingDTO(containing.ContainID, containing.PackageID, containing.AnalysisID);



        }
        public static async Task<StringContainingDTO> TOStringContainingDTO(this Containings containing,IPackagesService IPService,IAnalysisService IAService)
        {
            var PResult =await IPService.FindByID(containing.PackageID);
            var AResult=await IAService.GetByIdAsync(containing.AnalysisID);
            return new StringContainingDTO(containing.ContainID, PResult.PackageName, AResult.AnalysisName);



        }

        public static CreateContainingDTO ToCreateContainigDTO(this Containings containing)
        {

            return new CreateContainingDTO(containing.PackageID, containing.AnalysisID);



        }

        public static async Task<Containings> ToEntity(this StringContainingDTO containing,IContainingService ICService)
        {
            
            var Result = await ICService.FindByID(containing.ContainID);
            return (Result==null)?null : new Containings(Convert.ToInt32(Result.ContainID), Result.PackageID, Result.AnalysisID);



        }

        public static async Task<Containings> ToEntity(this CreateContainingDTO containing)
        {

            return  new Containings(0,containing.PackageID, containing.AnalysisID);



        }


        public static async Task<Containings> ToEntity(this ContainingDTO containing)
        {

            return new Containings(containing.ContainID??0, containing.PackageID, containing.AnalysisID);



        }






    }
}
