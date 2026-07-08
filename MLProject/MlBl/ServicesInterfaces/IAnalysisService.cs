using Core.Models;
using MlBL.DTOs;
using MlBL.Entities;
using MlBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBL.ServicesInterfaces
{
    public interface IAnalysisService : IService<AnalysisDto>
    {
        public Task<AnalysisDto?> GetByNameAsync(string analysisName);

        public Task<Dictionary<int, string>> GetMapAsync();
    }
}
