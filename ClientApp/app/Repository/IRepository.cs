using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionOffer.ClientApp.app.Repository
{
    interface IRepository<T> 
    {
        IEnumerable<T> GetList();
        T GetById(int id);
        T Add(T entity);
        bool Delete(T entity);
        bool DeleteById(int id);
        bool Update(T entity);
    }
}
