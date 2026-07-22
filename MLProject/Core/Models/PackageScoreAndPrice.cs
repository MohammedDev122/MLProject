using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class PackageScoreAndPrice
    {

        public int packageId { get; set; }
        public string packageName { get; set; }
        public string PackagePhotoPath { get; set; }
        public double PackageCost { get; set; }

        public int PackageScore { get; set; }

        public  PackageScoreAndPrice(Package package)
        {
            PackageScore = 1;

            packageId = package.PackageID;
            packageName = package.PackageName;
            PackagePhotoPath = package.PackagePhotoPath;
            PackageCost = package.PackageCost;  
        }
        public void IncreaseScoreByOne ()
        {
            this.PackageScore++;
        }
    }
}
