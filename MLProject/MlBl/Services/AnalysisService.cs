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


        public AnalysisService (IAnalysisRepository analysisRepo)
        {
            _analysisRepository = analysisRepo;
        }

        public async Task<AnalysisDto?> AddAsync(CreateAnalysisDto newAnalysis)
        {

            ArgumentNullException.ThrowIfNull(newAnalysis); // prevent received null for a parameter that must not be null


            AnalysisDto dto = newAnalysis.ToDto();

            Analysis analysis = newAnalysis.ToEntity();

            dto.Id = await _analysisRepository.AddAsync(analysis);

            return (dto.Id != 0) ? dto : null;
        }

        public async Task<bool> UpdateAsync(UpdateAnalysisDto updatedAnalysis)
        {
            ArgumentNullException.ThrowIfNull(updatedAnalysis); // prevent received null for a parameter that must not be null

            var analysis = await _analysisRepository.GetByIdAsync(updatedAnalysis.Id);

            if (analysis == null)
                return false;

            // update it
            analysis.Cost = updatedAnalysis.AnalysisCost;

            return await _analysisRepository.UpdateAsync(analysis);

           
        }

        
        public async Task<bool> DeleteAsync(int analysisId)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(analysisId, "Analysis ID must be greater than zero.");

            return await _analysisRepository.DeleteAsync(analysisId);
        }

    
        public async Task<AnalysisDto?> GetByIdAsync(int analysisId)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(analysisId, "Analysis ID must be greater than zero.");


            Analysis? analysis = await _analysisRepository.GetByIdAsync(analysisId);

            return (analysis != null)? analysis.ToDto() : null;
        }



        public async Task<List<AnalysisDto>> GetAllAsync ()
        { 
            var analyses = await _analysisRepository.GetAllAsync();

            return  analyses
                .Select(a => a.ToDto())
                .ToList();
        }


    }
}
