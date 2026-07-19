using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBL.DTOs
{
    public class PackageDTO
    {
        public int? PackageID { get;  set; }
        public string PackageName { get; set; }
        public string PackagePhotoPath { get; set; }
        public double PackageCost { get; set; }
     
        public enPackageType PackageType{ get; set; }
        public enPackageGender PackageGender { get; set; }
        public enPackageStatus packageStatus { get; set; }
        public enVisitType VisitType { get; set; }
        public PackageDTO(int PackageID, string PackageName, string PackagePhotoPath, enPackageType packageType, enPackageGender PackageGender, enPackageStatus packageStatus, enVisitType VisitType, double PackageCost)
        {
            this.PackageID = PackageID;
            this.PackageName = PackageName;
            this.PackagePhotoPath = PackagePhotoPath;
            this.PackageType = packageType;
            this.PackageGender = PackageGender;
            this.packageStatus = packageStatus;
            this.VisitType = VisitType;
            this.PackageCost = PackageCost;

        }
        public PackageDTO( string PackageName, string PackagePhotoPath, enPackageType PackageType, enPackageGender PackageGender, enPackageStatus packageStatus, enVisitType VisitType, double PackageCost)
        {
            this.PackageID = null;
            this.PackageName = PackageName;
            this.PackagePhotoPath = PackagePhotoPath;
            this.PackageType = PackageType;
            this.PackageGender = PackageGender;
            this.packageStatus = packageStatus;
            this.VisitType = VisitType;
            this.PackageCost = PackageCost;

        }
    }
    public class CreatePackageDTO
    {
        public string PackageName { get; set; }
    
        public string PackagePhotoPath { get; set; }
        public double PackageCost { get; set; }

   public   enPackageType PackageType { get; set; }
        public enPackageGender PackageGender { get; set; }
        public enPackageStatus packageStatus { get; set; }
        public enVisitType VisitType { get; set; }

        public CreatePackageDTO(string PackageName, string PackagePhotoPath, enPackageType packageType, enPackageGender PackageGender, enPackageStatus packageStatus, enVisitType VisitType, double PackageCost)
        {
            this.PackageName = PackageName;
            this.PackagePhotoPath = PackagePhotoPath;
           this.PackageType = packageType;
            this.PackageGender = PackageGender;
            this.packageStatus = packageStatus;
            this.VisitType = VisitType;
            this.PackageCost = PackageCost;

        }
    }
    public class UpdatedPackageDto
    {
        public int PackageID { get; set; }

        public string PackageName { get; set; }
        public string PackagePhotoPath { get; set; }
        public double PackageCost { get; set; }
        public enPackageType PackageType { get; set; }
        public enPackageGender PackageGender { get; set; }
        public enPackageStatus packageStatus { get; set; }
        public enVisitType VisitType { get; set; }

        public UpdatedPackageDto(int PackageID,string PackageName, string PackagePhotoPath, enPackageType PackageType, enPackageGender PackageGender, enPackageStatus packageStatus, enVisitType VisitType, double PackageCost)
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
