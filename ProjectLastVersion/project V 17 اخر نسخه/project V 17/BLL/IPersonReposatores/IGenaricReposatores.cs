using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IPersonReposatores
{
    public interface IGenaricReposatores<T>
    {
        IEnumerable<T> GetAll();
        IQueryable<T> GetListOfMissing();
        T GetById(long id);
        T GetByFatherId(long FatherId);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
