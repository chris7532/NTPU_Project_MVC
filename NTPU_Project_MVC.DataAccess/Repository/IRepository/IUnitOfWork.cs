using NTPU_Project_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTPU_Project_MVC.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IFireWallRepository FireWall { get; }
        IPop3Repository Pop3 { get; }
        void Save();
    }
}
