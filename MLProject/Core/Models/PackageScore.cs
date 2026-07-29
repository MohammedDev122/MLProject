using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class PackageScore
    {

        public int packageId { get; set; }
        public string packageName { get; set; }
        public string PackagePhotoPath { get; set; }
        public double PackageCost { get; set; }

        public HashSet<int> containedAnalysisIds 
            = new HashSet<int>();

        public HashSet<int>? missedAnalysesIds
            = new HashSet<int>();


        public ICollection<Analysis>? missedAnalyses
            = new List<Analysis>();

        public int matchingScore { get; set; }

        public  PackageScore(Package package)
        {
            packageId = package.PackageID;
            packageName = package.PackageName;
            PackagePhotoPath = package.PackagePhotoPath;
            PackageCost = package.PackageCost;

            matchingScore = 0;
        }
    }
}
