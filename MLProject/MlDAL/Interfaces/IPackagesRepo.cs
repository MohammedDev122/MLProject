using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlDAL.Interfaces
{
    public interface IPackagesRepo:IRepository<Packages>
    {
        public  Task<Dictionary<int, double>> GetAllPackagesCostAsync();

    }
}
