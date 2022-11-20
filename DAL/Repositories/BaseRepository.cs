using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BaseRepository<TModel> :IBaseRepository<TModel> where TModel : class
    {

        protected readonly DataContext db;
        public BaseRepository(DataContext _context)
        {
            db = _context;
        }

        public  async Task<List<TModel>> GetAll() {
            try {
                return await db.Set<TModel>().ToListAsync();
            }
            catch {
                throw;
            }
        }
        public async Task<TModel> Find(params object[] keyValues)
        {
            try {
                return await db.Set<TModel>().FindAsync(keyValues);
            }
            catch {
                throw;
            }
        }

        public async Task<TModel> Add(TModel model)
        {
            var v = await db.Set<TModel>().AddAsync(model);
            db.SaveChangesAsync();
            return v.Entity;
        }
    }
}
