using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.Net.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        object Add(T entity);
        void Change(T entity);
        void Delete(int id);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
