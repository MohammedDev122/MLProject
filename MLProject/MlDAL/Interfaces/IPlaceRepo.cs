using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlDAL.Interfaces
{
    public interface IPlaceRepo<T> : 
        IBaseRepository<T>,
        IGetAll<T>,
        IUpdate<T>

    {

    }
    public interface ILabRepo : IPlaceRepo<Lab>
    { }

    public interface ICityRepo : IPlaceRepo<City>
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
        public Task<ICollection<Region>?> GetAllRegionsAsync (int cityId);

    }

    public interface IRegionRepo : IPlaceRepo<Region>
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
        public Task<ICollection<Lab>?> GetAllLabsAsync (int labId);

    }
}
