﻿using NTPU_Project_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTPU_Project_MVC.DataAccess.Repository.IRepository
{
    public interface IPop3Repository: IRepository<Pop3>
    {
        public IEnumerable<object> GetByGroup(string startDate, string endDate);
        public IEnumerable<object> GetByGroupTest();
        public IEnumerable<object> HashToIpGroup(string hash);
    }
}
