using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<T> where T :class
    {
        void Add(T entity);
        void Delete(T entity);
        T Get(int id);
        T GetByName(string Name);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Save();
    }
}
