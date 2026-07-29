using Core.Models;
using MlBL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBL.Mappers
{
    public static class PlaceMapper
    {
        
        public static City ToEntity(this CityDto dto)
        {
            return new City
                (dto.CityId ?? 0, dto.Name);
        }

        public static Region ToEntity(this RegionDto dto)
        {
            return new Region
                (dto.RegionID ?? 0, dto.Name, dto.CityId);
        }

        public static Lab ToEntity(this LabDto dto)
        {
            return new Lab
                (dto.Id ?? 0, dto.Name, dto.Address, dto.RegionId, dto.Status, dto.LabType);
        }


        public static CityDto ToDto (this City city)
        {
            return new CityDto(city.CityId, city.Name);
        }

        public static RegionDto ToDto(this Region region)
        {
            return new RegionDto(region.RegionID, region.Name, region.CityId);
        }

        public static LabDto ToDto(this Lab lab)
        {
            return new LabDto(lab.Id,lab.Name, lab.Address, lab.RegionId, lab.Status, lab.labType);
        }
    }
}
