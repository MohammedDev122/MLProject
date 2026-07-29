using Core.Models;
using MlBL.DTOs;
using MlBL.Interfaces;
using MlBL.Mappers;
using MlDAL.Interfaces;


namespace MlBL.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepo _repo;

        public RegionService(IRegionRepo repo)
        {
            _repo = repo;
        }


        public async Task<RegionDto?> AddAsync(RegionDto newRecord)
        {
            ArgumentNullException.ThrowIfNull(newRecord);

            var region = newRecord.ToEntity();

            newRecord.RegionID = await _repo.AddAsync(region);

            return (newRecord.RegionID != 0) ? newRecord : null;

        }

        public async Task<bool> UpdateAsync(RegionDto updatedRecord)
        {
            ArgumentNullException.ThrowIfNull(updatedRecord);
            
            if (updatedRecord.RegionID is null)
                throw new ArgumentNullException("Id is required");
                
            var region = await _repo.GetByIdAsync(updatedRecord.RegionID.Value);

            if (region == null) 
                return false;

            region.Name = updatedRecord.Name;
            region.CityId = updatedRecord.CityId;

            return await _repo.UpdateAsync(region);

        }


        public async Task<bool> DeleteAsync(int id)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id, "Analysis ID must be greater than zero.");

            return await _repo.DeleteAsync(id);   

        }
        public async Task<RegionDto?> GetByIdAsync(int id)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id, "Analysis ID must be greater than zero.");

            Region? region = await _repo.GetByIdAsync(id);  

            return (region != null) ? region.ToDto() : null;
        }

        public async Task<List<RegionDto>?> GetAllAsync()
        {
            var regions = await _repo.GetAllAsync();

            return (regions != null) ?

                regions.Select(x => x.ToDto())
                    .ToList() : null;
        }

        public async Task<ICollection<LabDto>?> GetAllLabsAsync (int RegionId)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(RegionId);

            var labs = await _repo.GetAllLabsAsync(RegionId);

            return (labs != null) ?

                labs.Select(x => x.ToDto())
                    .ToList() : null;
        }
    }
}
