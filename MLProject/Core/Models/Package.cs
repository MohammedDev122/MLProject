using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Core.Models
{
    public enum enPackageType { enVip = 1, enNorm = 2, enKids = 3 }
    public enum enPackageGender { enMen = 1, enWomen = 2, enAll = 3 }
    public enum enPackageStatus { enDued = 1, enOnTheMarket = 2, enSoon = 3 }
    public enum enVisitType { enFree = 1, enPaid = 2 }

    public class Package
    {

        public int PackageID { get; set; }
        public string PackageName { get; set; }
        public string PackagePhotoPath { get; set; }
        public double PackageCost { get; set; }
        public enPackageType PackageType { get; set; }
        public enPackageGender PackageGender { get; set; }
        public enPackageStatus packageStatus { get; set; }
        public enVisitType VisitType { get; set; }

        public ICollection<Containing> containingAnalyses { get; set; }
                        = new List<Containing>();

        public Package()
        {
          
         

        }

        public Package(int PackageID, string PackageName, string PackagePhotoPath, enPackageType PackageType, enPackageGender PackageGender, enPackageStatus packageStatus, enVisitType VisitType, double PackageCost)
        {
            this.PackageID = PackageID;
            this.PackageName = PackageName;
            this.PackagePhotoPath = PackagePhotoPath;
            this.PackageType = PackageType;
            this.PackageGender = PackageGender;
            this.packageStatus = packageStatus;
            this.VisitType = VisitType;
            this.PackageCost = PackageCost;

        }

    }
}
