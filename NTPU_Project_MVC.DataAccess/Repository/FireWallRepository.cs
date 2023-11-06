using Microsoft.EntityFrameworkCore;
using NTPU_Project_MVC.DataAccess.Data;
using NTPU_Project_MVC.DataAccess.Repository.IRepository;
using NTPU_Project_MVC.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTPU_Project_MVC.DataAccess.Repository
{
    public class FireWallRepository : Repository<FireWall>, IFireWallRepository
    {
        private readonly ApplicationDbContext _db;
        public FireWallRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<object> GetByGroup(string startDate, string endDate)
        {
            DateTime.TryParse(startDate, out DateTime start);
            DateTime.TryParse(endDate, out DateTime end);
            
            var query = _db.FireWalls
                .Where(entity => entity.Time != null  && entity.Time.Substring(0,10).CompareTo(startDate)>=0 && entity.Time.Substring(0, 10).CompareTo(endDate) <= 0) // 選取指定日期範圍內的資料
                .GroupBy(entity => entity.Msg)
                .Select(group => new
                {
                    GroupName = group.Key,
                    GroupCount = group.Count()
                })
                .ToList();

            return query;
            
            
        }
    }
}
