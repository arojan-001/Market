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

        public  List<TModel> GetAll() {
            try {
                return  db.Set<TModel>().ToList();
            }
            catch {
                throw;
            }
        }

        public TModel Find(params object[] keyValues)
        {
            try {
                return db.Set<TModel>().Find(keyValues);
            }
            catch {
                throw;
            }
        }

        public  TModel Add(TModel model)
        {
            var v = db.Set<TModel>().Add(model);
            return v.Entity;
        }

        public void SetValues(TModel entity, TModel dbEntity)
        {
             db.Set<TModel>().Entry(dbEntity).CurrentValues.SetValues(entity);

        }

        public void Remove(TModel entity) 
        {
            db.Set<TModel>().Remove(entity);
        }

        public  void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
