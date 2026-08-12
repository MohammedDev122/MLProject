using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Containings
    {

        public int ContainID { get;  set; }

        public int PackageID { get; set; }
        public Package package { get; set; }

        public int AnalysisID { get; set; }
        public Analysis analysis { get; set; }


        public Containings()
        {
          

        }

        public Containings(int ContainID, int PackageID, int AnalysisID)
        {
            this.ContainID = ContainID;
            this.PackageID = PackageID;
            this.AnalysisID = AnalysisID;
        }









    }
}
