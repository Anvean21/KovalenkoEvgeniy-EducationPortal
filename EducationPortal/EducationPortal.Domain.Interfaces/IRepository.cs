using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        //EF
        //void Update(T item);
        void Delete(int id);
        void Save(T item);
    }
}
