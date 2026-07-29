using Core.Models;
using MlBL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBL.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">The Entity</typeparam>
    /// <typeparam name="t">The Dto</typeparam>
    public interface IPlaceService<T, t>
    {
        public Task<t?> AddAsync(t newRecord);
        public Task<bool> UpdateAsync(t updatedRecord);
        public Task<bool> DeleteAsync(int id);
        public Task<t?> GetByIdAsync(int id);

        public Task<List<t>> GetAllAsync();

    }


    public interface ILabService : IPlaceService<Lab, LabDto>
    { }
    public interface ICityService : IPlaceService<City, CityDto> 
    {

        /// <summary>
        /// Retrieves all regions that belong to the specified city.
        /// </summary>
        /// <param name="cityId">
        /// The ID of the city whose regions are to be retrieved.
        /// </param>
        /// <returns>
        /// A collection of regions within the specified city if any are found; otherwise, <c>null</c>.
        /// </returns>
        public Task<ICollection<RegionDto>?> GetAllRegionsAsync(int cityId);

    }

    public interface IRegionService : IPlaceService<Region, RegionDto>
    {
        /// <summary>
        /// Retrieves all laboratory branches located in the specified region.
        /// </summary>
        /// <param name="regionId">
        /// The ID of the region whose laboratory branches are to be retrieved.
        /// </param>
        /// <returns>
        /// A collection of laboratory branches within the specified region if any are found; otherwise, <c>null</c>.
        /// </returns>
        public Task<ICollection<LabDto>?> GetAllLabsAsync (int RegionId);

    }
}
