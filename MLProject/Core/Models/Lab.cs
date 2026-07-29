using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{

    public enum enLabType { Main = 1, Branch  = 2 };
    public enum enLabStatus { Closed = 1, Working = 2}


    public class Lab
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int RegionId { get; set; }
        public Region Region { get; set; }

        public enLabStatus Status { get; set; }

        public enLabType labType { get; set; }
     
        public Lab (int id, string name, string address, int regionId, enLabStatus status, enLabType labType = enLabType.Branch)
        {
            Id = id;
            Name = name;
            Address = address;
            RegionId = regionId;
            Status = status;
            this.labType = labType;
        }
    }
}
