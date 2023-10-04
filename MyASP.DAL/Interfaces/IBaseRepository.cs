using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyASP.DAL.Interfaces
{
    public interface IBaseRepository<TModel> where TModel : class
    {
        void Delete(string tablename, int id);
        IEnumerable<TModel> GetAll(string tablename);
        TModel Get(string tablename, int id);
    }
}
