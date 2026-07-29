using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Region
    {
        public int RegionID { get; set; }
        public string Name { get; set; }

        public int CityId { get; set; } 
        public City city { get; set; } 

        public ICollection<Lab> labs { get; set; } 
            = new List<Lab>();

        public Region (int regionID,string Name, int cityId)
        {
            RegionID = regionID;
            this.Name = Name;
            CityId = cityId;
        }
    }
}
