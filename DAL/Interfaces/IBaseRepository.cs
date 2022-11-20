using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBaseRepository<TModel> where TModel : class
    {
        Task<List<TModel>> GetAll();
        Task<TModel> Find(params object[] keyValues);
        Task<TModel> Add(TModel tmodel);
    }
}
