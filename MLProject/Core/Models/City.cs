using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Region> Regions { get; set; } 
            = new List<Region>();

        public City (int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
