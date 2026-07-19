
using Core.Models;
using MlBL.DTOs;

namespace MlBL.Mappers
{
    public static class AnalysisMapper
    {

        public static Analysis ToEntity(this AnalysisDto dto)
        {
            return new Analysis
                (dto.AnalysisID ?? 0, dto.AnalysisName, dto.AnalysisCost);
        }

        public static Analysis ToEntity(this CreateAnalysisDto createDto)
        {
            return new Analysis
                (0, createDto.AnalysisName, createDto.AnalysisCost);
        }
        public static Analysis ToEntity(this UpdateAnalysisDto updateDto)
        {
            return new Analysis
                (updateDto.AnalysisID, updateDto.AnalysisCost);
        }

        public static AnalysisDto ToDto(this Analysis analysis)
        {
            return new AnalysisDto
                (analysis.AnalysisId, analysis.AnalysisName, analysis.Cost);
        }


        public static AnalysisDto ToDto(this CreateAnalysisDto createDto)
        {
            return new AnalysisDto
                (createDto.AnalysisName, createDto.AnalysisCost);
        }
        public static AnalysisDto ToDto(this UpdateAnalysisDto createDto)
        {
            return new AnalysisDto
                (createDto.AnalysisID, "", createDto.AnalysisCost);
        }
    }
}
