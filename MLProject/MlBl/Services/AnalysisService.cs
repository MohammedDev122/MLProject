using MlBl;
using MlBL.Entities;
using MlBL.ServicesInterfaces;
using MlDAL.Entities;
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

        public int AddAnalysis(Analysis newAnalysis)
        {

            ArgumentNullException.ThrowIfNull(newAnalysis); // prevent received null for a parameter that must not be null

            if (!newAnalysis.CheckIfDataIsCorrect())
                return -1;


            int Id = _analysisRepository.AddAnalysis(newAnalysis.ADTO);

            if (Id > 0)
            {
                newAnalysis.isAdded = true;
                return Id;
            }

            // if failed to added in database
            Cause = (FailCauses.enFailCauses.enErrorFromAnalysisDB);
            return -1;
        }

        public bool UpdateAnalysis(Analysis updatedAnalysis)
        {
            ArgumentNullException.ThrowIfNull(updatedAnalysis); // prevent received null for a parameter that must not be null

            if (!updatedAnalysis.CheckIfDataIsCorrect())
                return false;

            if (_analysisRepository.UpdateAnalysis(updatedAnalysis.ADTO))
            {
                updatedAnalysis.isAdded = true;
                return true;
            }

            // if failed to updated in database
            Cause = (FailCauses.enFailCauses.enErrorFromAnalysisDB);
            return false;
            
        }

        
        public bool DeleteAnalysis(int analysisId)
        {
            if (analysisId < 0)
                throw new ArgumentOutOfRangeException();

            return _analysisRepository.DeleteAnalysis(analysisId);
        }

    
        public AnalysisDto? GetAnalysisById(int analysisId)
        {
            if (analysisId <= 0)
                throw new ArgumentOutOfRangeException(nameof(analysisId), "Analysis ID must be greater than zero.");

            return _analysisRepository.GetAnalysisById(analysisId);
        }

     
        public AnalysisDto? GetAnalysisByName(string analysisName)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(analysisName);

            return _analysisRepository.GetAnalysisByName(analysisName);
        }

        public List<AnalysisDto> GetAllAnalyses()
        { 
            return _analysisRepository.GetAllAnalyses();
        }


        public Dictionary<int, string> GetAllAnalysisMap()
        {
            return _analysisRepository.GetAllAnalysisMap();
        }


        public bool Exists(int analysisID)
        { 
            if (analysisID <= 0)
                throw new ArgumentOutOfRangeException();

            return _analysisRepository.Exists(analysisID);
        }

    }
}
