using Core.Models;
using MlBL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MlBL.Mappers
{
    public static class PackageMapper
    {
public static Package ToEntity(this CreatePackageDTO CPDTO)
        {
            return new Package(0, CPDTO.PackageName, CPDTO.PackagePhotoPath, CPDTO.PackageType,
                CPDTO.PackageGender, CPDTO.packageStatus, CPDTO.VisitType, CPDTO.PackageCost);


        }
        public static CreatePackageDTO ToCreatedPDTO(this Package Package)
        {

            return new CreatePackageDTO (Package.PackageName, Package.PackagePhotoPath, Package.PackageType,
                Package.PackageGender, Package.packageStatus, Package.VisitType, Package.PackageCost);

        }
        public static Package ToEntity(this UpdatedPackageDto UPDTO)
        {
            return new Package(UPDTO.PackageID, UPDTO.PackageName,UPDTO.PackagePhotoPath, UPDTO.PackageType, UPDTO.PackageGender, UPDTO.packageStatus, UPDTO.VisitType
               , UPDTO.PackageCost);
        }
        public static UpdatedPackageDto TOUpdatedPDTO(this Package Package)
        {

            return new UpdatedPackageDto(Package.PackageID, Package.PackageName, Package.PackagePhotoPath, Package.PackageType, Package.PackageGender, Package.packageStatus, Package.VisitType
               , Package.PackageCost);

        }
        public static Package ToEntity(this PackageDTO PDTO)
        {
            return new Package(PDTO.PackageID??0,PDTO.PackageName,PDTO.PackagePhotoPath,PDTO.PackageType,PDTO.PackageGender,PDTO.packageStatus, PDTO.VisitType,PDTO.PackageCost);


        }
        public static PackageDTO ToPackageDTO(this Package Package) {


            return new PackageDTO(Package.PackageID, Package.PackageName, Package.PackagePhotoPath, Package.PackageType, Package.PackageGender, Package.packageStatus, Package.VisitType, Package.PackageCost);





        }
    }
}
