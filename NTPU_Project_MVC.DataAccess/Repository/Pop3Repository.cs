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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NTPU_Project_MVC.DataAccess.Repository
{
    public class Pop3Repository : Repository<Pop3>, IPop3Repository
    {
        private readonly ApplicationDbContext _db;
        public Pop3Repository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<object> GetByGroup(string startDate, string endDate)
        {
            DateTime.TryParse(startDate, out DateTime start);
            DateTime.TryParse(endDate, out DateTime end);

            var query = _db.Pop3s
                .Where(entity => entity.Date != null  && entity.Date>=start && entity.Date <= end) // 選取指定日期範圍內的資料
                .GroupBy(entity => entity.Hash)
                .Select(group => new
                {
                    GroupName = group.Key,
                    GroupCount = group.Count()
                })
                .ToList();

            return query;
            
            
        }

        public IEnumerable<object> GetByGroupTest()
        {


            var query = _db.Pop3s
                .Where(entity => entity.Date != null && entity.Date >= new DateTime(2019,7,15) && entity.Date <=new DateTime(2019, 7, 16)) // 選取指定日期範圍內的資料
                .GroupBy(entity => entity.Hash)
                .Select(group => new
                {
                    GroupName = group.Key,
                    GroupCount = group.Count()
                })
                .ToList();

            return query;


        }

        public IEnumerable<object> HashToIpGroup(string hash)
        {
            var query = _db.Pop3s.Where(e => e.Hash == hash)
                .GroupBy(e => new { GDate = e.Date, GIP = e.Ip, GCountry = e.Country })
                .Select(group => new
                {
                    GDate = group.Key.GDate,
                    GIP = group.Key.GIP,
                    GCountry = group.Key.GCountry,
                    GCount = group.Count()
                }).ToList();

            return query;


        }
    }
}
