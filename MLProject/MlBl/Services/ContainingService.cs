using Core.Models;
using MlBL.DTOs;
using MlBL.Interfaces;
using MlBL.Mappers;
using MlDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBL.Services
{
    public class ContainingService // : IContainingService
    {/*
        IContainingRepo _Containing;
        public ContainingService(IContainingRepo containing)
        {
            _Containing = containing;
        }
        public async Task<ContainingDTO>? FindByID(int ContainID) {
            if (ContainID <= 0) throw new ArgumentOutOfRangeException($"ID:{ContainID} Isn't Correct!");
            ContainingDTO CDTO = (await _Containing.GetByIdAsync(ContainID)).ToContainigDTO();
            return  (CDTO!=null)?CDTO:null;
        
        
        
        }


        public async Task<List<StringContainingDTO>> GetAll()
        {
            Dictionary<int, List<string>> DCont=new Dictionary<int, List<string>>();
            List<StringContainingDTO> SCDTO = new List<StringContainingDTO>();
            DCont =await _Containing.GetAll();
            if (DCont.Count != 0)
            
                SCDTO = DCont.Select(x => new StringContainingDTO(x.Key, x.Value[0], x.Value[1]))
                     .ToList();
                return SCDTO;
            
        }

        public async Task<bool> Delete(int ContainID)
        {
            if (ContainID <= 0) throw new ArgumentOutOfRangeException($"Containing ID:{ContainID} Isn't Correct");
            return await _Containing.DeleteAsync(ContainID);

        }

        public async Task<List<StringContainingDTO>> GetAllPackageContains(int PackageID) { 
        
      if(PackageID <= 0) throw new ArgumentOutOfRangeException($"Package ID:{PackageID} Isn't Correct");
            List < StringContainingDTO > LSCDTO=new List<StringContainingDTO>();
            var Result= await _Containing.GetAllPackage_SContain(PackageID);
            if (Result.Count != 0) LSCDTO=Result.Select(x => new StringContainingDTO(x.Key, x.Value[0], x.Value[1])).ToList();
            return LSCDTO;


        }

       public async Task<List<StringContainingDTO>> GetAllAnalysisContained(int AnalysisID)
        {
            if (AnalysisID <= 0) throw new ArgumentOutOfRangeException($"Analysis ID:{AnalysisID} Isn't Correct");
            List<StringContainingDTO> LSCDTO = new List<StringContainingDTO>();
            var Result = await _Containing.GetAllAnalysis_SContainiers(AnalysisID);
            if(Result.Count!=0) LSCDTO = Result.Select(x => new StringContainingDTO(x.Key, x.Value[0], x.Value[1])).ToList();
            return LSCDTO;


        }

        public async Task<double?> GetAllAnalysisInPackageCost(int PackageID)
        {

            if (PackageID <= 0) throw new ArgumentOutOfRangeException($"Package ID:{PackageID} Isn't Correct");
            double? Cost=await _Containing.GetAllPackage_SContainCost(PackageID);
            return  (Cost!=null)?Cost:null;
        }

        public async Task<ContainingDTO> AddNew(CreateContainingDTO CCDTO)
        {


            if (CCDTO == null) throw new ArgumentNullException("Object Is Empty!");
            Containing CEntity =await CCDTO.ToEntity();
            CEntity.ContainID = await _Containing.AddAsync(CEntity);
            return CEntity.ContainID != 0 ? CEntity.ToContainigDTO() : null;

        }


        public async Task<bool> Exist(int ContainID)
        {
            if (ContainID <= 0) throw new ArgumentOutOfRangeException($"Contain ID:{ContainID} Isn't Correct");

            return await _Containing.ExistsAsync(ContainID);
        }

        public async Task<bool> Exist(int AnalysisID, int PackageID)
        {
            if (AnalysisID <= 0) throw new ArgumentOutOfRangeException($"Analysis ID:{AnalysisID} Isn't Correct");
            if (PackageID <= 0) throw new ArgumentOutOfRangeException($"Contain ID:{PackageID} Isn't Correct");
            return await _Containing.ISExist(AnalysisID, PackageID);



        }












    

    */
    }
}