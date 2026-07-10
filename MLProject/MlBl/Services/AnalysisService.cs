using Core.Models;
using MlBl;
using MlBL.DTOs;
using MlBL.Entities;
using MlBL.Interfaces;
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

        public async Task<AnalysisDto> AddAsync(CreateAnalysisDto newAnalysis)
        {

            ArgumentNullException.ThrowIfNull(newAnalysis); // prevent received null for a parameter that must not be null

            var analysis = new AnalysisManager(newAnalysis.ToDto());

            if (!analysis.CheckIfDataIsCorrect())
                return null;

            AnalysisDto dto = newAnalysis.ToDto();
            dto.AnalysisID = await _analysisRepository.AddAsync(analysis.analysis);

            if (dto.AnalysisID > 0)
                return dto;

            // if failed to added in database
            Cause = (FailCauses.enFailCauses.enErrorFromAnalysisDB);
            return null;
        }

        public async Task<AnalysisDto> UpdateAsync(UpdateAnalysisDto updatedAnalysis)
        {
            ArgumentNullException.ThrowIfNull(updatedAnalysis); // prevent received null for a parameter that must not be null

            var analysis = await _analysisRepository.GetByIdAsync(updatedAnalysis.AnalysisID);

            var analysisManager = new AnalysisManager(analysis);

            if (!analysisManager.CheckIfDataIsCorrect())
                return null;

            // update it
            analysis.Cost = updatedAnalysis.AnalysisCost;

            if (await _analysisRepository.UpdateAsync(analysis))
                return new AnalysisDto(analysis);

            // if failed to updated in database
            Cause = (FailCauses.enFailCauses.enErrorFromAnalysisDB);
            return null;
            
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

            return  new AnalysisDto( await _analysisRepository.GetByIdAsync(analysisId));
        }


        public async Task<AnalysisDto?> GetByNameAsync(string analysisName)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(analysisName);

            return new AnalysisDto(await _analysisRepository.GetByNameAsync(analysisName));
        }

        public async Task<List<AnalysisDto>> GetAllAsync ()
        { 
            var analyses = await _analysisRepository.GetAllAsync();
            return  analyses
            .Select(a => new AnalysisDto( a.AnalysisID, a.AnalysisName, a.Cost))
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
