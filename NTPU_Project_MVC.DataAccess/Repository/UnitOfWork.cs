using NTPU_Project_MVC.DataAccess.Data;
using NTPU_Project_MVC.DataAccess.Repository.IRepository;
using NTPU_Project_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTPU_Project_MVC.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IFireWallRepository FireWall { get; private set; }

        public IPop3Repository Pop3 { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            FireWall = new FireWallRepository(_db);
            Pop3 = new Pop3Repository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
