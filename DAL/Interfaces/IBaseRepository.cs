using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBaseRepository<TModel> where TModel : class
    {
        List<TModel> GetAll();
        TModel Find(params object[] keyValues);
        TModel Add(TModel tmodel);
        void SetValues(TModel entity, TModel dbEntity);
        void Remove(TModel entity);
        void SaveChanges();
    }
}
