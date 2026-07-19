using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBL.DTOs
{
    public class ContainingDTO
    {
        public int? ContainID { get;  set; }
        public int PackageID { get; set; }
        public int AnalysisID { get; set; }


        public ContainingDTO(int ContainID, int PackageID, int AnalysisID)
        {
            this.ContainID = ContainID;
            this.PackageID = PackageID;
            this.AnalysisID = AnalysisID;


        }

        public ContainingDTO( int PackageID, int AnalysisID)
        {
            this.PackageID = PackageID;
            this.AnalysisID = AnalysisID;


        }





    }
    public class CreateContainingDTO
    {
        public int PackageID { get; set; }
        public int AnalysisID { get; set; }


        public CreateContainingDTO( int PackageID, int AnalysisID)
        {
            this.PackageID = PackageID;
            this.AnalysisID = AnalysisID;


        }

      




    }
    public class StringContainingDTO
    {
        public int ContainID { get; set; }
        public string PackageName { get; set; }
        public string AnalysisName { get; set; }


        public StringContainingDTO(int ContainID, string PackageName, string AnalysisName)
        {
            this.ContainID = ContainID;
            this.PackageName = PackageName;
            this.AnalysisName = AnalysisName;


        }

       




    }

}
