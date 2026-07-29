using Core.Models;
using MlBL.DTOs;
using MlBL.Interfaces;
using MlBL.Mappers;
using MlDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBL.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepo _repo;

        public CityService(ICityRepo repo)
        {
            _repo = repo;
        }


        public async Task<CityDto?> AddAsync(CityDto newRecord)
        {
            ArgumentNullException.ThrowIfNull(newRecord);

            var city = newRecord.ToEntity();

            newRecord.CityId = await _repo.AddAsync(city);

            return (newRecord.CityId != 0) ? newRecord : null;

        }


        public async Task<bool> UpdateAsync(CityDto updatedRecord)
        {
            ArgumentNullException.ThrowIfNull(updatedRecord);

            if (updatedRecord.CityId is null)
                throw new ArgumentException("Id is required.");

            var city = await _repo.GetByIdAsync(updatedRecord.CityId.Value); // .Value() throws an exception if null

            if (city == null) 
                return false;

            city.Name = updatedRecord.Name;

            return await _repo.UpdateAsync(city);
        }


        public async Task<bool> DeleteAsync(int id)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id, "Analysis ID must be greater than zero.");

            return await _repo.DeleteAsync(id);
        }
        public async Task<CityDto?> GetByIdAsync(int id)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id, "Analysis ID must be greater than zero.");

            City? city = await _repo.GetByIdAsync(id);

            return (city != null) ? city.ToDto() : null;
        }
        public async Task<List<CityDto>?> GetAllAsync()
        {
            var cities = await _repo.GetAllAsync();

            return (cities != null) ?

                cities.Select(c => c.ToDto())
                    .ToList() : null;
        }
        public async Task<ICollection<RegionDto>?> GetAllRegionsAsync (int cityId)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(cityId);

            var regions = await _repo.GetAllRegionsAsync(cityId);

            return (regions != null)?

                regions.Select(x => x.ToDto())
                    .ToList() : null;


        }
    }
}
