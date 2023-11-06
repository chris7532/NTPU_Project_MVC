using Microsoft.EntityFrameworkCore;
using NTPU_Project_MVC.DataAccess.Data;
using NTPU_Project_MVC.DataAccess.Repository.IRepository;
using NTPU_Project_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
namespace NTPU_Project_MVC.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        public DbSet<T> _dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            query = _dbSet.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query;
        }
        public IEnumerable<T> GetByRange(int range, string? orderProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (!string.IsNullOrEmpty(orderProperties))
            {
                query = query.OrderBy(orderProperties+ " descending");
            }
            /*
            int totalRecords = query.Count();
            if (totalRecords <= range)
            {
                return query;
            }
            else
            {
                return query.Skip(totalRecords - range);
            }*/
            return query.Take(range);
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
