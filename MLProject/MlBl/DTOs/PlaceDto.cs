using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBL.DTOs
{
    public class CityDto
    {
        public int? CityId { get; set; }
        public string Name { get; set; }
        public CityDto ()
        {}
        public CityDto (int Id, string name)
        {
            this.CityId = Id;
            this.Name = name;
        }
    }

    public class RegionDto
    {
        public int? RegionID { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }

        public RegionDto ()
        { }

        public RegionDto(int Id, string name, int cityId)
        {
            this.RegionID = Id;
            Name = name;
            CityId = cityId;
        }
    }

    public class LabDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }

        public int RegionId { get; set; }

        public enLabStatus Status { get; set; }

        public enLabType LabType { get; set; }

        public LabDto ()
        {

        }
        public LabDto(int Id, string name, string address, int regionId, enLabStatus status, enLabType labType = enLabType.Branch)
        {
            this.Id = Id;
            Name = name;
            Address = address;
            RegionId = regionId;
            Status = status;
            LabType = labType;
        }
    }

}
