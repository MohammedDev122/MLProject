using Core.Models;
using MlBl;
using MlBL.DTOs;
using MlBL.Interfaces;
using MlBL.Mappers;
using MlDAL.Interfaces;
using MlDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBL.Services
{
    public  class AnalysisService : IAnalysisService
    {  

        private readonly IAnalysisRepository _analysisRepository;

        public FailCauses.enFailCauses Cause { get; set; } // must be shared not in this file i added it to debug till fix


        public AnalysisService (IAnalysisRepository analysisRepo)
        {
            _analysisRepository = analysisRepo;
        }

        public async Task<AnalysisDto?> AddAsync(CreateAnalysisDto newAnalysis)
        {

            ArgumentNullException.ThrowIfNull(newAnalysis); // prevent received null for a parameter that must not be null


            AnalysisDto dto = newAnalysis.ToDto();

            Analysis analysis = dto.ToEntity();

            dto.AnalysisID = await _analysisRepository.AddAsync(analysis);

            if (dto.AnalysisID > 0)
                return dto;

            // if failed to added in database
            Cause = (FailCauses.enFailCauses.enErrorFromAnalysisDB);
            return null;
        }

        public async Task<bool> UpdateAsync(UpdateAnalysisDto updatedAnalysis)
        {
            ArgumentNullException.ThrowIfNull(updatedAnalysis); // prevent received null for a parameter that must not be null

            var analysis = await _analysisRepository.GetByIdAsync(updatedAnalysis.AnalysisID);


            // update it
            analysis.Cost = updatedAnalysis.AnalysisCost;

            return await _analysisRepository.UpdateAsync(analysis);

           
        }

        
        public async Task<bool> DeleteAsync(int analysisId)
        {
            if (analysisId < 0)
                throw new ArgumentOutOfRangeException();

            return await _analysisRepository.DeleteAsync(analysisId);
        }

    
        public async Task<AnalysisDto?> GetByIdAsync(int analysisId)
        {
            if (analysisId <= 0)
                throw new ArgumentOutOfRangeException(nameof(analysisId), "Analysis ID must be greater than zero.");

            Analysis analysis = await _analysisRepository.GetByIdAsync(analysisId);

            return analysis.ToDto();
        }


        public async Task<AnalysisDto?> GetByNameAsync(string analysisName)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(analysisName);

            Analysis analysis = await _analysisRepository.GetByNameAsync(analysisName);

            return analysis.ToDto();
        }

        public async Task<List<AnalysisDto>> GetAllAsync ()
        { 
            var analyses = await _analysisRepository.GetAllAsync();
            return  analyses
            .Select(a => new AnalysisDto( a.AnalysisId, a.AnalysisName, a.Cost))
            .ToList();
        }


        public async Task<Dictionary<int, string>> GetMapAsync()
        {
            return await _analysisRepository.GetMapAsync();
        }


        public async Task<bool> ExistsAsync(int analysisID)
        { 
            if (analysisID <= 0)
                throw new ArgumentOutOfRangeException();

            return await _analysisRepository.ExistsAsync(analysisID);
        }

    }
}
