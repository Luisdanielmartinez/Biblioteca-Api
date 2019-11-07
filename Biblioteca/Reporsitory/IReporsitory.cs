using Biblioteca.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Reporsitory
{
    public interface IReporsitory <T> where T:BaseEntity
    {
        IEnumerable<T> GetAllData();
        T GetById(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
