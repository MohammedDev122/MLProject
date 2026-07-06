using Microsoft.Data.SqlClient;
using MlDAL.DbContexts;
using MlDAL.Entities;
using MlDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace MlDAL.Repositories
{

    public class AnalysisRepo : IAnalysisRepository
    {
        private readonly AppDbContext _context;

        public AnalysisRepo(AppDbContext context)
        {
            _context = context;
        }

    
        public Dictionary<int, string> GetAllAnalysisMap()
        {

            return _context.Analyses
                                .Select(a => new { a.AnalysisID, a.AnalysisName })
                                .ToDictionary(a => a.AnalysisID, a => a.AnalysisName);

        }

        public AnalysisDto? GetAnalysisById(int analysisID)
        {
            if (analysisID <= 0)
                throw new ArgumentOutOfRangeException(nameof(analysisID));

            return _context.Analyses
                            .FirstOrDefault(a => a.AnalysisID == analysisID);

        }


        public AnalysisDto? GetAnalysisByName(string analysisName)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(analysisName, nameof(analysisName)); // Prevent received empty or null string

            return _context.Analyses
                            .FirstOrDefault(a => a.AnalysisName == analysisName);

        }

        public int AddAnalysis(AnalysisDto newAnalysis)
        {
            ArgumentNullException.ThrowIfNull(newAnalysis); // prevent received null for a parameter that must not be null


            // Mark this entity as Added
            _context.Analyses.Add(newAnalysis);

            // save  on database
            _context.SaveChanges();

            return newAnalysis.AnalysisID;
        }

        public bool UpdateAnalysis(AnalysisDto updatedAnalysis)
        {

            ArgumentNullException.ThrowIfNull(updatedAnalysis); // prevent received null for a parameter that must not be null

            // Load then update method

            // Load the row
            var analysis = _context.Analyses.
                FirstOrDefault(a => a.AnalysisID == updatedAnalysis.AnalysisID);

            if (analysis == null)
                return false;

            // update the row
            analysis.AnalysisName = updatedAnalysis.AnalysisName;
            analysis.AnalysisCost = updatedAnalysis.AnalysisCost;

            // save changes on database
            _context.SaveChanges();

            return true;

        }


        public List<AnalysisDto> GetAllAnalyses()
        {
            return _context.Analyses
                                .Select(a => new AnalysisDto
                                (
                                    a.AnalysisID,
                                    a.AnalysisName,
                                    a.AnalysisCost
                                )).ToList();
        }

        public bool DeleteAnalysis(int analysisID)
        {
            if (analysisID <= 0)
                throw new ArgumentOutOfRangeException(nameof(analysisID));

            // load then delete approach 
            var analysis =
                _context.Analyses
                        .FirstOrDefault(s => s.AnalysisID == analysisID);

            if (analysis == null)
                return false;   


            _context.Analyses.Remove(analysis);

            return _context.SaveChanges() > 0; // means return true if there are any rows affected
        }

        public bool Exists(int analysisID)
        {
            if (analysisID <= 0)
                throw new ArgumentOutOfRangeException(nameof(analysisID));

            return _context.Analyses
                            .Any(a => a.AnalysisID == analysisID);  
        }

    }
}