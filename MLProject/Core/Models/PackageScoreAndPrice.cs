using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class PackageScoreAndPrice
    {
        public int PackageScore { get; set; }
        public double PackagePrice { get; set; }
        public List<int> RemainAnalysis  { get; set; }
      public  PackageScoreAndPrice()
        {
            PackageScore = 0;
            PackagePrice = 0;
            RemainAnalysis = new List<int>();
        }
    }
}
