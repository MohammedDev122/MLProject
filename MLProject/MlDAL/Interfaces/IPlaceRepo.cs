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

    public interface ICityRepo : IPlaceRepo<City>
    {
        public Task<ICollection<Region>?> GetAllRegions (int cityId);

    }

    public interface IRegionRepo : IPlaceRepo<Region>
    {
        public Task<ICollection<Lab>?> GetAllLabs(int labId);

    }
}
